using System;
using System.Net.Mail;
using System.Threading.Tasks;
using JeBalance.Denonciation;
using JeBalance.DTOs;
using JeBalance.Entities;
using JeBalance.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;
using static Volo.Abp.Identity.IdentityPermissions;

namespace JeBalance.Services
{
    public class DenonciationAppService : ApplicationService, IDenonciationAppService, ITransientDependency
    {
        private readonly IEfCoreDenonciationRepository efCoreDenonciationRepository;
        private readonly IGuidGenerator _guidGenerator;

        public DenonciationAppService(IEfCoreDenonciationRepository _efCoreDenonciationRepository, IGuidGenerator guidGenerator)
        {
            efCoreDenonciationRepository = _efCoreDenonciationRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task<Guid?> PostCreateDenonciationAsync(DenonciationDTO denonciation)
        {
            denonciation.Id = _guidGenerator.Create();
            denonciation.Informateur.Adresse.Id = _guidGenerator.Create();
            denonciation.Suspect.Id = _guidGenerator.Create();
            denonciation.Informateur.Adresse.PersonneId = denonciation.Informateur.Id;
            denonciation.Suspect.Adresse.PersonneId = denonciation.Suspect.Id;
            denonciation.Suspect.Adresse.Id = _guidGenerator.Create();
            denonciation.CreationTime = DateTime.Now;
            denonciation.LastModificationTime = DateTime.Now;
            var denonciationToRegistrer = ObjectMapper.Map< DenonciationDTO, Entities.Denonciation > (denonciation);

            await efCoreDenonciationRepository.RegisterDenonciationAsync(denonciationToRegistrer).ConfigureAwait(false);
            return denonciation.Id;
            
        }

        [Authorize(Roles = JeBalancePermissions.AdminFiscale)]
        public async Task<DenonciationDTO> GetAsync(Guid id)
        {
            var denonciation = await efCoreDenonciationRepository.GetDenonciationAsync(id).ConfigureAwait(false);

            return ObjectMapper.Map<Entities.Denonciation, DenonciationDTO>(denonciation);
        }
    }
}

