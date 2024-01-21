using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Reponse : Entity<Guid>, IHasCreationTime, IHasModificationTime
    {
        public Confirmation? Confirmation { get; set; }

        // Permet de déterminer si la dénonciation est rejettée ou pas
        public required bool Rejected { get; set; }

        // Permet d'avoir l'horodatage de la création de l'objet
        public DateTime CreationTime { get; set; }

        // Permet d'avoir l'horodatage de la dernière modification de la réponse
        public DateTime? LastModificationTime { get; set; }

        public Reponse(Guid id) : base(id)
        {

        }

        public Reponse()
        { }
    }
}