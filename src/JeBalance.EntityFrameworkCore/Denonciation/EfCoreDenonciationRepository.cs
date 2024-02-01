using System;
using System.Threading.Tasks;
using JeBalance.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using JeBalance.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using System.Collections.Generic;
using System.Linq;

namespace JeBalance.Denonciation
{
	public class EfCoreDenonciationRepository : EfCoreRepository<JeBalanceDbContext, Entities.Denonciation, Guid>, IEfCoreDenonciationRepository
    {
		public EfCoreDenonciationRepository(IDbContextProvider<JeBalanceDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}

        public async Task<Entities.Denonciation> GetDenonciationAsync(Guid id)
        {
            var context = await GetDbContextAsync().ConfigureAwait(false);

            var denonciation = await context.Denonciations
                                    .Include(p => p.Informateur)
                                     .Include(p => p.Suspect)
                                     .SingleOrDefaultAsync(d => d.Id == id).ConfigureAwait(false);
            if(denonciation == null)
            {
                throw new UserFriendlyException("Désolé, aucune dénonciation ne correspond à cet Id");
            }

            return denonciation;
        }

        public async Task<Guid> RegisterDenonciationAsync(Entities.Denonciation denonciation)
        {
            var context = await GetDbContextAsync().ConfigureAwait(false);

            // Vérification de l'informateur ne soit pas un Calominateur, sinon message d'erreur
            var informateur = await context.Personnes.SingleOrDefaultAsync(p => p.Id == denonciation.Informateur.Id).ConfigureAwait(false);
            if (informateur != null && informateur.Calomniateur)
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
                informateur.Calomniateur = true;
                context.Update(informateur);
                await context.SaveChangesAsync().ConfigureAwait(false);

                throw new UserFriendlyException("Vous avez réalisé trop de délations, vous êtes désormais un Calominateur !");

            }
            // Enfin, si le suspect de la dénonciation est VIP, alors l'informateur devient Calominateur
            // Comme on n'a pas l'id du Suspect, on doit le confondre par nom, prénom et l'adresse pour être sûr
            var suspect = await context.Suspects
                //.Include(p => p.Accuse) 
                .FirstOrDefaultAsync(p =>
                    denonciation.Suspect != null &&
                    //p.Accuse.Id == denonciation.Suspect.Accuse.Id && 
                    (p.Prenom == denonciation.Suspect.Prenom) &&
                    (p.Nom == denonciation.Suspect.Nom) &&
                    (p.Adresse != null && denonciation.Suspect.Adresse != null) &&
                    (p.Adresse.PersonneId == denonciation.Suspect.Id))
                .ConfigureAwait(false);


            if (suspect !=null && suspect.VIP && informateur != null)
            {
                informateur.Calomniateur = true;
                context.Update(informateur);
                await context.SaveChangesAsync().ConfigureAwait(false);

                throw new UserFriendlyException("Vous tentez de délater une personne protégée, vous êtes désormais un Calominateur !");
            }
            await context.AddAsync(denonciation).ConfigureAwait(false);

            await context.SaveChangesAsync().ConfigureAwait(false);

            return denonciation.Id;

        }

        public async Task<List<Entities.Denonciation>> ListDenonciationNonTraiteAsync()
        {
            var context = await GetDbContextAsync().ConfigureAwait(false);

            var denonciationsWithNonGuidFormatReponse = await context.Denonciations
                .Where(d => d.Reponse.Id == null)
                .OrderBy(d => d.CreationTime)
                .ToListAsync()
                .ConfigureAwait(false);

            return denonciationsWithNonGuidFormatReponse;
        }
    }
}

