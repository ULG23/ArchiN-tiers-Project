using System;
using Volo.Abp.Auditing;

namespace JeBalance.DTOs
{
    public class ReponseDTO : IHasCreationTime, IHasModificationTime
    {
        public Guid? Id { get; set; }

        public ConfirmationDTO? Confirmation { get; set; }

        // Permet d'avoir l'horodatage de la création de l'objet
        public DateTime CreationTime { get; set; }

        // Permet d'avoir l'horodatage de la dernière modification de la réponse
        public DateTime? LastModificationTime { get; set; }

        // Permet de déterminer si la dénonciation est rejettée ou pas
        public bool? Rejected { get; set; }

    }
}