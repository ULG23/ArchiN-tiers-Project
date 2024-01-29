using System;
using System.Threading.Tasks;
using JeBalance.DTOs;

namespace JeBalance.Services
{
    public interface IDenonciationAppService
    {
        /// <summary>
        /// Créer une dénonciation
        /// </summary>
        /// <param name="_denonciation"></param>
        /// <returns></returns>
        public Task<Guid?> PostCreateDenonciationAsync(DenonciationDTO _denonciation);

        /// <summary>
        /// Permet de récupérer une dénonciation à partir de son Id
        /// </summary>
        /// <param name="_denonciationId"></param>
        /// <returns></returns>
        public Task<DenonciationDTO> GetAsync(Guid _denonciationId);
    }
}