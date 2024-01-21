using System;
using System.Threading.Tasks;
using JeBalance.DTOs;

namespace JeBalance.Services
{
    public interface IDenonciationAppService
    {
        public Task<Guid?> PostCreateDenonciationAsync(DenonciationDTO _denonciation);

        public Task<DenonciationDTO> GetAsync(Guid _denonciationId);
    }
}