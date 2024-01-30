using JeBalance.Entities;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace JeBalance.Personne
{
    public interface IEfCorePersonneRepository : IRepository<Entities.Personne, Guid>
    {
        Task<Entities.Personne> UpdatePersonneVIPFieldAsync(Guid personneToRegistrer, bool newVipStatus);
    }
}