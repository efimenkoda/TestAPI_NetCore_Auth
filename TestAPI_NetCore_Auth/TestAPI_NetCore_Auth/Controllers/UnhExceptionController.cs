using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI_NetCore_Auth.Filters;

namespace TestAPI_NetCore_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UnhandledException]
    public class UnhExceptionController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            int x = 0;
            int y = 8 / x;
            return Ok(y);

        }
    }
}
