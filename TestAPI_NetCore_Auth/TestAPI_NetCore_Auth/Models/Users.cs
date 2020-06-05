using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI_NetCore_Auth.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]        
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public int? AuthorizeUserID { get; set; }
        public AuthorizeUser AuthorizeUser { get; set; }
    }
}
