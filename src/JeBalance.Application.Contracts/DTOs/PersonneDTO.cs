using System;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.DTOs
{
	public class PersonneDTO
	{
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public AdresseDTO Adresse { get; set; }
    }
}

