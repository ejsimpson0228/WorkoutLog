using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutLog.API.Models.Auth
{
    public class RegisterUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
