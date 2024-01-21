using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Informateur : Personne
    {
        //public List<Denonciation>? Denonciations { get; set; }
        public Informateur(Guid id) : base(id)
        {
        }

        public Informateur()
        { }
    }
}

