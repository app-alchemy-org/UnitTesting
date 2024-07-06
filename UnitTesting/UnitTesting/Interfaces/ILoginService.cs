using LoginServiceExample.Enums;
using LoginServiceExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoginServiceExample.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseType> Login(string? email, string? password);
        bool AutoLogin();
    }
}
