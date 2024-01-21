using System;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.DTOs
{
	public class PersonneDTO
	{
        public Guid? Id { get; set; }

        public string? Prenom { get; set; }

        public string? Nom { get; set; }

        public AdresseDTO? Adresse { get; set; }

        public bool? Calomniateur { get; set; }

        public bool? VIP { get; set; }
    }
}

