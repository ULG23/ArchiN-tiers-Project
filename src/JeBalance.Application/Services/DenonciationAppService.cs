using System;
using System.Net.Mail;
using System.Threading.Tasks;
using JeBalance.Denonciation;
using JeBalance.DTOs;
using JeBalance.Entities;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace JeBalance.Services
{
    public class DenonciationAppService : ApplicationService, IDenonciationAppService, ITransientDependency
    {
        private readonly IEfCoreDenonciationRepository efCoreDenonciationRepository;

        public DenonciationAppService(IEfCoreDenonciationRepository _efCoreDenonciationRepository)
        {
            efCoreDenonciationRepository = _efCoreDenonciationRepository;
        }

        public async Task<Guid?> PostCreateDenonciationAsync(DenonciationDTO _denonciation)
        {
            var denonciationToRegistrer = ObjectMapper.Map< DenonciationDTO, Entities.Denonciation > (_denonciation);


            return  await efCoreDenonciationRepository.RegisterDenonciationAsync(denonciationToRegistrer).ConfigureAwait(false);
            
        }

        public async Task<DenonciationDTO> GetAsync(Guid id)
        {
            var denonciation = await efCoreDenonciationRepository.GetAsync(id).ConfigureAwait(false);

            return ObjectMapper.Map<Entities.Denonciation, DenonciationDTO>(denonciation);
        }
    }
}

