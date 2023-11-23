using System;
using JeBalance.DTOs;

namespace JeBalance.Services
{
    public interface IDenonciationAppService
    {
        public Guid CreateDenonciation(DenonciationDTO _denonciation);
    }
}