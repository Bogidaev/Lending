using Lending.Authentification.Interface;
using Lending.Core;
using Lending.Services.Interface;
using System.Threading.Tasks;

namespace Lending.Services.Implementation
{
    public class LendingService : ILendingService
    {
        private readonly IAuthLogin _authLogin;

        public LendingService(IAuthLogin authLogin)
        {
            this._authLogin = authLogin;
        }

        public async Task<string> SendRequest(string phone)
        {
            await this._authLogin.TryLogin();

            return await HttpHelper.Post("http://interview.mfi-ap.asia/0/rest/InfintoPortalService/GetClientInfo",
                  new { mobile = phone });
        }
    }
}
