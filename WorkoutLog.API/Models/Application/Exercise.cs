using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutLog.API.Models.Application
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LogType LogType { get; set; }
        public IdentityUser User { get; set; }
    }
}
