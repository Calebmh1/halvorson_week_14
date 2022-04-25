using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group_3_Week_11_DB_API.Data;
using Group_3_Week_11_DB_API.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Group_3_Week_11_DB_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        private readonly Wossamotta_UContext _context;


        private readonly TestAuthManager testAuthManager;

        public AuthenticationController(Wossamotta_UContext context, TestAuthManager testAuthManager)
        {
            _context = context;
            this.testAuthManager = testAuthManager;
        }


        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] user usr)
        {
            var token = testAuthManager.Authenticate(usr.username, usr.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }


    }

    public class user
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}


