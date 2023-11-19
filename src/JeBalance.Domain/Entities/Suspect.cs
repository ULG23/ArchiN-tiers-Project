using System;
using JeBalance.Enums;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Suspect : Entity<Guid>
    {
        public required Personne Accuse { get; set; }

        public required Denonciation Denonciation { get; set; }
    }
}