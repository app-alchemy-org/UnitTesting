using LoginServiceExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoginServiceExample.Interfaces
{
    public interface IWebClient
    {
        Task<WebLoginResponse> Login(string? email, string? password);
    }
}
