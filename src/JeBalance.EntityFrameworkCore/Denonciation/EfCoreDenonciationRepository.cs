using System;
using System.Threading.Tasks;
using JeBalance.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using JeBalance.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace JeBalance.Denonciation
{
	public class EfCoreDenonciationRepository : EfCoreRepository<JeBalanceDbContext, Entities.Denonciation, Guid>, IEfCoreDenonciationRepository
    {
		public EfCoreDenonciationRepository(IDbContextProvider<JeBalanceDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
        public async Task<Guid> RegisterDenonciationAsync(Entities.Denonciation denonciation)
        {
            var context = await GetDbContextAsync().ConfigureAwait(false);

            // Vérification de l'informateur ne soit pas un Calominateur, sinon message d'erreur
            var informateur = await context.Personnes.SingleOrDefaultAsync(p => p.Id == denonciation.Informateur).ConfigureAwait(false);
            if (informateur != null && informateur.Calominateur)
            {
                throw new UserFriendlyException("Vous êtes un vilain Calominateur, vous ne pouvez plus délatter !");
            }
            // Vérification que l'informateur ne possède pas déjà 3 délations rejettées à son actif
            var numberOfRejectedDelation = await context.Denonciations
                .CountAsync(d => (d.Reponse != null ? d.Reponse.Rejected : false) == false &&
                                 d.Informateur == denonciation.Informateur)
                .ConfigureAwait(false);
            // Si c'est le cas on met alors à jour l'informateur pour le déclarer comme Calominateur
            if (numberOfRejectedDelation >= 3 && informateur!=null)
            {
                informateur.Calominateur = true;
                context.Update(informateur);
                await context.SaveChangesAsync().ConfigureAwait(false);

                throw new UserFriendlyException("Vous avez réalisé trop de délations, vous êtes désormais un Calominateur !");

            }
            // Enfin, si le suspect de la dénonciation est VIP, alors l'informateur devient Calominateur
            // Comme on n'a pas l'id du Suspect, on doit le confondre par nom, prénom et ville de résidence pour être sûr
            var suspect = await context.Personnes.FirstOrDefaultAsync(p => p.Prenom == denonciation.Suspect.Accuse.Prenom &&
                p.Nom == denonciation.Suspect.Accuse.Nom && p.Adresse.NomdeCommune == denonciation.Suspect.Accuse.Adresse.NomdeCommune).ConfigureAwait(false);

            if (suspect !=null && suspect.VIP && informateur != null)
            {
                informateur.Calominateur = true;
                context.Update(informateur);
                await context.SaveChangesAsync().ConfigureAwait(false);

                throw new UserFriendlyException("Vous tentez de délater une personne protégée, vous êtes désormais un Calominateur !");
            }
            await context.AddAsync(denonciation).ConfigureAwait(false);

            await context.SaveChangesAsync().ConfigureAwait(false);

            return denonciation.Id;

        }
    }
}

