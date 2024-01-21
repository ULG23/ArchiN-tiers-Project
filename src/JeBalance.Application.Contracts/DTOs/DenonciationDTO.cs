using System;
using JeBalance.Enums;
using Volo.Abp.Auditing;
using Volo.Abp.Guids;

namespace JeBalance.DTOs
{
    public class DenonciationDTO : IHasCreationTime, IHasModificationTime
    {

        public Guid? Id { get; set; } 

        public InformateurDTO? Informateur { get; set; }

        public SuspectDTO? Suspect { get; set; }

        public eDelit? Delit { get; set; }

        //Permet de récuperer la description de la dénonciation
        public string DelitDescription => Delit?.GetDescription();

        public string? PaysEvasion { get; set; }

        public ReponseDTO? Reponse { get; set; }

        // Permet d'avoir l'horodatage de la création de l'objet
        public DateTime CreationTime { get; set; }

        // Permet d'avoir l'horodatage de la dernière modification de la dénonciation
        public DateTime? LastModificationTime { get; set; }

    }
}

