using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Models.ViewModels;
using CoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly APIDBContext _context;
        private readonly IJWTService _jWTService;

        public HomeController(APIDBContext context, IJWTService jWTService)
        {
            _context = context;
            _jWTService = jWTService;
        }
        [HttpPost]
        [Route("api/v1/login")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (Request.ContentType == null)
            {
                return Unauthorized();
            }
            var user = new User
            {
                userName = Request.Form["userName"].ToString(),
                password = Request.Form["password"].ToString()
            };
            var token = _jWTService.Authenticate(user);

            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Json(token);
            }
        }

    }
}
