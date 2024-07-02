using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LoginServiceExample.Models
{
    public class WebLoginResponse(HttpStatusCode statusCode, string? sessionToken, DateTime? sessionExpiryDate)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
        public string? SessionToken { get; } = sessionToken;
        public DateTime? SessionExpiryDate { get; } = sessionExpiryDate;
    }
}
