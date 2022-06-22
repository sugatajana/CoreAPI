using CoreAPI.Data;
using CoreAPI.Models.UserModel;
using CoreAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly APIDBContext _context;

        public UserController(APIDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/v1/users")]
        public IActionResult Index()
        {
            var token = Request.Headers["Authorization"].ToString();

            if (!token.StartsWith("Bearer"))
            {
                return Unauthorized();
            }
            token = token.Split("Bearer ").LastOrDefault();
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.ToList();

            if (APIFunctions.CredentialCheck(claims))
            {
                var users = _context.customers.ToList();
                return Json(users);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("api/v1/users/email")]
        public IActionResult GetUserByEmail([FromBody] User userData)
        {
            var token = Request.Headers["Authorization"].ToString();
            if (!token.StartsWith("Bearer"))
            {
                return Unauthorized();
            }
            token = token.Split("Bearer ").LastOrDefault();
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.ToList();

            if (APIFunctions.CredentialCheck(claims))
            {
                var user = _context.customers.Where(x => x.customerEmail == userData.email).FirstOrDefault();
                if (user == null)
                {
                    return Ok("No user found");
                }
                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
