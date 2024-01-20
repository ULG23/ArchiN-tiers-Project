using System;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
	public class Personne : Entity<Guid>
	{
		public required string Prenom { get; set; }

		public required string Nom { get; set; }

		public required Adresse Adresse { get; set; }

		public bool Calominateur { get; set; }

		public bool VIP { get; set; }
	}
}