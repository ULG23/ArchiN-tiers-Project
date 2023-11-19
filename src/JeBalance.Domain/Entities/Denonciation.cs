using System;
using JeBalance.Enums;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
	public class Denonciation : Entity<Guid>
	{
        public Guid? Informateur { get; set; }

        public required Suspect Suspect { get; set; }

		public eDelit Delit { get; set; }

		public string? PaysEvasion { get; set; }

		public Reponse? Reponse { get; set; }
	}
}

