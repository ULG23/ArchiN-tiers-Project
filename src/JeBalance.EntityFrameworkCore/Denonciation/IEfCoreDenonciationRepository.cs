using System;
using System.Threading.Tasks;

namespace JeBalance.Denonciation
{
    public interface IEfCoreDenonciationRepository
    {
        public Task RegisterDenonciationAsync(Entities.Denonciation denonciation);
    }
}