using System;
using System.Threading.Tasks;

namespace JeBalance.Denonciation
{
    public interface IEfCoreDenonciationRepository
    {
        public Task<Guid> RegisterDenonciationAsync(Entities.Denonciation denonciation);
    }
}