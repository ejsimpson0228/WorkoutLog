using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutLog.API.Models.Application
{
    public class Log
    {
        public int Id { get; set; }
        public Exercise Exercise { get; set; }
        public Volume Volume { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public IdentityUser User { get; set; }
    }
}
