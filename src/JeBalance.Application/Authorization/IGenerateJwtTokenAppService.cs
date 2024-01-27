using System.Threading.Tasks;

namespace JeBalance.Authorization
{
    public interface IGenerateJwtTokenAppService
    {
        public Task<string> GetTokenWithAdminRole();

        public Task<string> GetTokenWithAdminFiscaleRole();

        public Task<string> GetTokenWithBothAdminRole();

    }
}