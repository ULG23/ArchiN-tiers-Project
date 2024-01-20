using System;
using System.Threading.Tasks;
using JeBalance.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JeBalance.Denonciation
{
	public class EfCoreDenonciationRepository : EfCoreRepository<JeBalanceDbContext, Entities.Denonciation, Guid>, IEfCoreDenonciationRepository
    {
		public EfCoreDenonciationRepository(IDbContextProvider<JeBalanceDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}

        public async Task<Guid> RegisterDenonciationAsync(Entities.Denonciation denonciation)
        {
            var dbSet = await GetDbSetAsync().ConfigureAwait(false);

            await dbSet.AddAsync(denonciation).ConfigureAwait(false);

            return denonciation.Id;

        }
    }
}

