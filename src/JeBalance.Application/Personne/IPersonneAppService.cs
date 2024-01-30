using JeBalance.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JeBalance.Services
{
    public interface IPersonneAppService
    {
        public Task<PersonneDTO> PutModifyPersonneVIPStatusAsync(Guid id, bool newVipStatus);
        public Task<List<PersonneDTO>> GetListPersonneVip();
    }
}