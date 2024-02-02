using System;
using System.Threading.Tasks;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;

namespace JeBalance.Denonciation
{
    public interface IEfCoreDenonciationRepository : IRepository<Entities.Denonciation, Guid>
    {
        /// <summary>
        /// Permet d'enregistrer une dénonciation
        /// </summary>
        /// <param name="denonciation"></param>
        /// <returns></returns>
        public Task<Guid> RegisterDenonciationAsync(Entities.Denonciation denonciation);

        /// <summary>
        /// Permet de récupérer une dénonciation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Entities.Denonciation> GetDenonciationAsync(Guid id);

        /// <summary>
        /// Permet de récupérer la liste de toutes les dénonciations non traitées
        /// </summary>
        /// <returns></returns>
        public Task<List<Entities.Denonciation>> ListDenonciationNonTraiteAsync();

    }
}