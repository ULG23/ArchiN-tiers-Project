using JeBalance.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeBalance.Services
{
    public interface IPersonneAppService
    {
        /// <summary>
        /// Permet de modifier le statut d'une personne, à partir de son Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newVipStatus"></param>
        /// <returns></returns>
        public Task<PersonneDTO> PutModifyPersonneVipStatusAsync(Guid id, bool newVipStatus);

        /// <summary>
        /// Permet de retourner la liste des personnes dont le statut est VIP
        /// </summary>
        /// <returns></returns>
        public Task<List<PersonneDTO>> GetListPersonneVip();
    }
}