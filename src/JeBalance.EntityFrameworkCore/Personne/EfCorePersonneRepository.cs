using System;
using System.Threading.Tasks;
using JeBalance.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using JeBalance.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using JeBalance.Personne;

namespace JeBalance.Personne
{
	public class EfCorePersonneRepository : EfCoreRepository<JeBalanceDbContext, Entities.Personne, Guid>, IEfCorePersonneRepository
    {
		public EfCorePersonneRepository(IDbContextProvider<JeBalanceDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}

        public async Task<Entities.Personne> UpdatePersonneVIPFieldAsync(Guid idPersonneToChangeVIPStatus, bool newVipStatus)
        {
            var context = await GetDbContextAsync().ConfigureAwait(false);

            var personToChangeVIPStatus = await context.Personnes.SingleOrDefaultAsync(p => p.Id == idPersonneToChangeVIPStatus).ConfigureAwait(false);

            if (personToChangeVIPStatus != null)
            {
                personToChangeVIPStatus.VIP = newVipStatus;

                await context.SaveChangesAsync().ConfigureAwait(false);

                return personToChangeVIPStatus;
            }

            else
            {
                throw new UserFriendlyException("Le statut de la personne n'a pas pu être changé, car l'id ne correspond à aucune personne de la base de données. ID introuvable :" + idPersonneToChangeVIPStatus);
            }
        }

       
        

    }
}

