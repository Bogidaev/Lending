using Lending.Authentification.Interface;
using Lending.Core;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Lending.Authentification.Implementation
{
    public class AuthLogin : IAuthLogin
    {
        public async Task<bool> TryLogin()
        {
            var baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            var result = await HttpHelper.Post<AuthResult>($"{baseUrl}/ServiceModel/AuthService.svc/Login", new
            {
                UserName = ConfigurationManager.AppSettings["login"],
                UserPassword = ConfigurationManager.AppSettings["password"]
            });

            var cookieCollection = HttpHelper.CookieContainer.GetCookies(new Uri(baseUrl));
            var csrfToken = cookieCollection["BPMCSRF"].Value;

            HttpHelper.Handler.Remove("BPMCSRF");
            HttpHelper.Handler.Add("BPMCSRF", csrfToken);

            if (result.Code != 0)
            {
                throw new Exception(result.Message);
            }

            return true;
        }
    }
}
