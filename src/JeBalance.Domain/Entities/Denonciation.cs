using System;
using JeBalance.Enums;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
	public class Denonciation : Entity<Guid>, IHasCreationTime, IHasModificationTime
    {
        public required Informateur Informateur { get; set; }

        public required Suspect Suspect { get; set; }

		public eDelit Delit { get; set; }

		public required string PaysEvasion { get; set; }

		public Reponse? Reponse { get; set; }

        // Permet d'avoir l'horodatage de la création de l'objet
        public DateTime CreationTime { get; set; }

        // Permet d'avoir l'horodatage de la dernière modification de la dénonciation
        public DateTime? LastModificationTime { get; set; }

        public Denonciation(Guid id) : base(id)
        {

        }

        public Denonciation()
        { }
    }
}

