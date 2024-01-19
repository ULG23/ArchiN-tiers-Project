using System;
using JeBalance.Enums;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Suspect : Entity<Guid>
    {
        public required Personne Accuse { get; set; }

        public Denonciation? Denonciation { get; set; }
    }
}