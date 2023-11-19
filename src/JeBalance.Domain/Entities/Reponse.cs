using System;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Reponse : Entity<Guid>
    {
        public required Confirmation Confirmation { get; set; }
    }
}