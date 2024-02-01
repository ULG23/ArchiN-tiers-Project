using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JeBalance.Denonciation;
using JeBalance.DTOs;
using JeBalance.Entities;
using JeBalance.Personne;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace JeBalance.Services
{
    public class PersonneAppService : ApplicationService, IPersonneAppService, ITransientDependency
    {
        private readonly IEfCorePersonneRepository efCorePersonneRepository;

        public PersonneAppService(IEfCorePersonneRepository _efCorePersonneRepository)
        {
            efCorePersonneRepository = _efCorePersonneRepository;
        }

        // Permet de rendre l'endpoint accessible seulement avec un Token JWT en Header, valide, et dont l'un des Rôle est admin
        [Authorize(Roles = "admin")]
        public async Task<PersonneDTO> PutModifyPersonneVipStatusAsync(Guid id, bool newVipStatus)
        {

            var modifiedPersonneVIP = await efCorePersonneRepository.UpdatePersonneVIPFieldAsync(id, newVipStatus).ConfigureAwait(false);

            return ObjectMapper.Map<Entities.Personne, PersonneDTO>(modifiedPersonneVIP);

        }

        // Permet de rendre l'endpoint accessible seulement avec un Token JWT en Header, valide, et dont l'un des Rôle est admin
        [Authorize(Roles = "admin")]
        public async Task<List<PersonneDTO>> GetListPersonneVip()
        {
            var listPersonneVip = await efCorePersonneRepository.GetListAsync(p => p.VIP == true).ConfigureAwait(false);

            return ObjectMapper.Map<List<Entities.Personne>, List<PersonneDTO>>(listPersonneVip);
        }
    }
}

