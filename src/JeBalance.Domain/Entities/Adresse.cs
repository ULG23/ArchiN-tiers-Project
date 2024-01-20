using System;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Adresse : Entity<Guid>
    {
        public required int Numero { get; set; }

         public required string NomdeVoie { get; set; }

        public required int CodePostal { get; set; }

        public required string NomdeCommune { get; set; }
    }
}