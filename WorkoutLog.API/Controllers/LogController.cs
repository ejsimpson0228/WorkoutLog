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
    public class LogController : BaseController
    {
        private DatabaseContext _db;
        public LogController(DatabaseContext db, UserManager<IdentityUser> userManager) : base(db, userManager)
        {
            _db = db;
        }


    }
}