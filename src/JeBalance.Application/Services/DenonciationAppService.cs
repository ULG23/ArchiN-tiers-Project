using System;
using System.Threading.Tasks;
using JeBalance.Denonciation;
using JeBalance.DTOs;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

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
            var denonciationToRegistrer = new Entities.Denonciation
            {
                Informateur = _denonciation.Informateur,
                Suspect = new Entities.Suspect
                {
                    Accuse = new Entities.Personne
                    {
                        Nom = _denonciation.Suspect.Accuse.Nom,
                        Prenom = _denonciation.Suspect.Accuse.Prenom,
                        Adresse = new Entities.Adresse
                        {
                            NomdeCommune = _denonciation.Suspect.Accuse.Adresse.NomdeCommune,
                            NomdeVoie = _denonciation.Suspect.Accuse.Adresse.NomdeVoie,
                            Numero = _denonciation.Suspect.Accuse.Adresse.Numero,
                            CodePostal = _denonciation.Suspect.Accuse.Adresse.CodePostal
                            
                        }
                    }
                },
                PaysEvasion = _denonciation.PaysEvasion,
                Delit = (Enums.eDelit)_denonciation.Delit
            };

            var denonciatonId = await efCoreDenonciationRepository.RegisterDenonciationAsync(denonciationToRegistrer).ConfigureAwait(false);

            return denonciatonId;
            
        }

        public DenonciationDTO Get(Guid id)
        {
            return new DenonciationDTO
            {
                Id = new Guid()
            };
        }
    }
}

