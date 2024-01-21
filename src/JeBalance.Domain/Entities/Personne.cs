using System;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
	public class Personne : Entity<Guid>
	{
		public  string? Prenom { get; set; }

		public  string? Nom { get; set; }

		public  Adresse? Adresse { get; set; }

		public bool Calomniateur { get; set; }

		public bool VIP { get; set; }

        public Personne(Guid id) : base(id)
        {

        }

        public Personne()
        { }
    }
}