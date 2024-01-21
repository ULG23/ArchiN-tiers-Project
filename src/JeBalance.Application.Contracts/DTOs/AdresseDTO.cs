using System;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.DTOs
{
	public class AdresseDTO
	{
        public Guid? Id { get; set; }

        public int? Numero { get; set; }

        public string? NomdeVoie { get; set; }

        public int? CodePostal { get; set; }

        public string? NomdeCommune { get; set; }

        public Guid? PersonneId { get; set; }

    }
}

