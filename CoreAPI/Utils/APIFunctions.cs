using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAPI.Utils
{
    public static class APIFunctions
    {
        public static bool CredentialCheck(List<Claim> claims)
        {
            var userName = claims.FirstOrDefault(x => x.Type == "userName").Value;
            var password = claims.FirstOrDefault(x => x.Type == "password").Value;
            if (userName.Equals("admin") && password.Equals("123456"))
                return true;
            else
                return false;
        }
    }
}
