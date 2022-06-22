using CoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Services
{
    public interface IJWTService
    {
        public Token Authenticate(User user);
    }
}
