using System;
namespace JeBalance.Entities
{
	public class Personne
	{
		public required string Prenom { get; set; }

		public required string Nom { get; set; }

		public required Adresse Adresse { get; set; }
	}
}

