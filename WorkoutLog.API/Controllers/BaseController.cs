using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutLog.API.Models;

namespace WorkoutLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private DatabaseContext _db;
        private UserManager<IdentityUser> _userManager;
        public BaseController(DatabaseContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public BaseController()
        {
        }

        protected async Task<IdentityUser> GetUser()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            return await _userManager.FindByIdAsync(userId);
        }
    }
}