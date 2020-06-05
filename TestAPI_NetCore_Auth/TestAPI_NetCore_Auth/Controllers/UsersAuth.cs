using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestAPI_NetCore_Auth.Configuration;
using TestAPI_NetCore_Auth.Models;

namespace TestAPI_NetCore_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthcs : ControllerBase
    {
        private readonly ContextDB contextDB;

        public UsersAuthcs(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetUsers([FromBody] Users users)
        {
            if(ModelState.IsValid)
            {
                var identity = GetIdentity(users);
                if (identity == null)
                {
                    return BadRequest(new { errorText = "Invalid username or password." });
                }

                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.Now,
                    claims: identity.Claims,
                    expires: DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new
                {
                    access_token = encodedJwt,
                    username = identity.Name
                };
                return  Ok(response);
            }
            return BadRequest(new { errorText = "Invalid username or password." });
        }

        private ClaimsIdentity GetIdentity(Users user)
        {
            Users person = contextDB.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserName)
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }

    }
}
