using System;
using System.Collections.Generic;
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


        /// <summary>
        /// Permet de donner une réponse à une dénonciation, il faut être de l'adminnistration fiscale pour ça
        /// </summary>
        /// <param name="_denonciationId"> id de la dénonciation que l'on veut mettre à jour </param>
        /// <param name="_reponse"> réponse que l'on veut appoerter à la dite dénonciation </param>
        /// <returns></returns>
        public Task<DenonciationDTO> PostCreateRespondToDenonciation(Guid _denonciationId, ReponseDTO _reponse);

        public Task<List<DenonciationDTO>> GetListDenonciationNonTraiteAsync();

    }
}