using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI_NetCore_Auth.Configuration
{
    public static class AuthOptions
    {
        public const string ISSUER = "TestAPIServer"; 
        public const string AUDIENCE = "TestAPIServer"; 
        const string KEY = "TestAPIServer!005062020";  
        public const int LIFETIME = 120; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
