using System;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.DTOs
{
	public class AdresseDTO
	{
        public int Numero { get; set; }

        [Required]
        public string NomdeVoie { get; set; }

        public int CodePostal { get; set; }

        [Required]
        public string NomdeCommune { get; set; }
    }
}

