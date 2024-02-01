using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using JeBalance.Denonciation;
using JeBalance.DTOs;
using JeBalance.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;

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


        public async Task<DenonciationDTO> GetAsync(Guid id)
        {
            var denonciation = await efCoreDenonciationRepository.GetDenonciationAsync(id).ConfigureAwait(false);

            return ObjectMapper.Map<Entities.Denonciation, DenonciationDTO>(denonciation);
        }

        [Authorize(Roles ="adminFiscale")]
        public async Task<DenonciationDTO> PostCreateResponseToDenonciation(Guid id, ReponseDTO _reponse)
        {
            // vérification que la dénonciation n'a pas encore reçue de réponse
            var denonciation = await efCoreDenonciationRepository.GetDenonciationAsync(id).ConfigureAwait(false);

            if(denonciation.Reponse != null)
            {
                throw new UserFriendlyException("Cette dénonciation a déjà été traitée");
            }

            var reponseEntity = ObjectMapper.Map<ReponseDTO, Reponse>(_reponse);

            denonciation.Reponse = reponseEntity;

            var denonciationUpdated = await efCoreDenonciationRepository.UpdateAsync(denonciation).ConfigureAwait(false);

            return ObjectMapper.Map<Entities.Denonciation, DenonciationDTO>(denonciationUpdated);
        }

        [Authorize(Roles = "adminFiscale")]
        public async Task<List<DenonciationDTO>> GetListDenonciationNonTraiteAsync()
        {
            var listDenonciationNonTraite = await efCoreDenonciationRepository.ListDenonciationNonTraiteAsync().ConfigureAwait(false);

            return ObjectMapper.Map<List<Entities.Denonciation>, List<DenonciationDTO>>(listDenonciationNonTraite);
        }
    }
}

