using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServiceExample.Models
{
    public class SecureLogin(string? userEmail, DateTime? tokenExpiryDate, string? sessionToken)
    {
        public string? UserEmail { get; } = userEmail;
        public DateTime? TokenExpiryDate { get; } = tokenExpiryDate;
        public string? SessionToken { get;} = sessionToken;
    }
}
