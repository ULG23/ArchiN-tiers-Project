using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Informateur : Entity<Guid>
	{
        public required List<Denonciation> Denonciations { get; set; }
	}
}

