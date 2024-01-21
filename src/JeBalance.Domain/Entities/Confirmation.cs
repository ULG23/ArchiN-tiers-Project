using System;
using Volo.Abp.Domain.Entities;

namespace JeBalance.Entities
{
    public class Confirmation : Entity<Guid>
    {
        public long? Retribution { get; set; }

        public Confirmation(Guid id) : base(id)
        {

        }

        public Confirmation()
        { }
    }
}