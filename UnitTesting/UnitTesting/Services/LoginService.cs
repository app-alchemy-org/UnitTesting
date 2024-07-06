using LoginServiceExample.Enums;
using LoginServiceExample.Interfaces;
using LoginServiceExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracking.Services
{
    public class LoginService(IWebClient webClient, ISecureStorage secureStorage) : ILoginService
    {
        public async Task<LoginResponseType> Login(string? email, string? password)
        {
            if (email == null || password == null)
            {
                return LoginResponseType.InvalidUsernameOrPassword;
            }

            var loginResponse = await webClient.Login(email, password);
            if (loginResponse.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
            {
                return LoginResponseType.ServerNotAvailable;
            }

            if (loginResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var storedSecurely = secureStorage.SetSecureLogin(email, loginResponse.SessionExpiryDate, loginResponse.SessionToken);

                if (!storedSecurely)
                {
                    return LoginResponseType.SecureStorageFailed;
                }
            }

            return LoginResponseType.Success;
        }

        public bool AutoLogin()
        {
            var secureLogin = secureStorage.GetSecureLogin();

            if (secureLogin == null) return false;

            if (secureLogin.TokenExpiryDate < DateTime.Now) return false;

            return true;
        }
    }
}
