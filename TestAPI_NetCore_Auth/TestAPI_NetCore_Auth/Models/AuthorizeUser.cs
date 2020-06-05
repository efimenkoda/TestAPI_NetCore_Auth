using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TestAPI_NetCore_Auth.Models
{
    public class AuthorizeUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime BirthDate { get; set; }
        public int Amount { get; set; }

    }
}
