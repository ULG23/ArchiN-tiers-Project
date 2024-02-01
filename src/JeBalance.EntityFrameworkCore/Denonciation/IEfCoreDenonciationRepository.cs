using System;
using System.Threading.Tasks;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;

namespace JeBalance.Denonciation
{
    public interface IEfCoreDenonciationRepository : IRepository<Entities.Denonciation, Guid>
    {
        public Task<Guid> RegisterDenonciationAsync(Entities.Denonciation denonciation);


        public Task<Entities.Denonciation> GetDenonciationAsync(Guid id);

        Task<List<Entities.Denonciation>> ListDenonciationNonTraiteAsync();

    }
}