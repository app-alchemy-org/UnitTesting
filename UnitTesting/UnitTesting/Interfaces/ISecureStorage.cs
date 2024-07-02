using LoginServiceExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServiceExample.Interfaces
{
    public interface ISecureStorage
    {
        SecureLogin? GetSecureLogin();
        bool SetSecureLogin(string? userEmail, DateTime? tokenExpiryDate, string? sessionToken);
    }
}
