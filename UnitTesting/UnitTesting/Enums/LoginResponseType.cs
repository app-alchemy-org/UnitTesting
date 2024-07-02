using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServiceExample.Enums
{
    public enum LoginResponseType
    {
        Unknown = 0,
        Success = 1,
        InvalidUsernameOrPassword = 2,
        ServerNotAvailable = 3,
        SecureStorageFailed = 4,
    }
}
