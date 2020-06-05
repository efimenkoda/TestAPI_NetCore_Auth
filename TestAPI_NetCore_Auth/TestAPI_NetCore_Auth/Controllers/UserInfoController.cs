using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI_NetCore_Auth.Models;

namespace TestAPI_NetCore_Auth.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    [Authorize]
    public class UserInfoController : ControllerBase
    {
        private readonly ContextDB contextDB;

        public UserInfoController(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = await contextDB.Users.FirstOrDefaultAsync(x => x.UserName == userName);
                var find = await contextDB.AuthorizeUsers.FirstOrDefaultAsync(x => x.Id == user.Id);
                var result = new
                {
                    Name = find.Name,
                    BirthDate = find.BirthDate,
                    Amount = find.Amount
                };
                return Ok( result );
            }
           
            return BadRequest("Error Authenticathion");
        }
    }
}
