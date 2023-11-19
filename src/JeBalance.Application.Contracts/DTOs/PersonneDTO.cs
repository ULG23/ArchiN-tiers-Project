using System;
namespace JeBalance.DTOs
{
	public class PersonneDTO
	{
        public required string Prenom { get; set; }

        public required string Nom { get; set; }

        public required AdresseDTO Adresse { get; set; }
    }
}

