using System;
using JeBalance.Enums;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Suspect : Personne
    {
        //public required Personne Accuse { get; set; }

        //public required Denonciation Denonciation { get; set; }

        public Suspect(Guid id) : base(id)
        {

        }

        public Suspect()
        { }
    }
}