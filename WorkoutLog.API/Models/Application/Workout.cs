using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutLog.API.Models.Application
{
    public class Workout
    {
        public int Id { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public IdentityUser User { get; set; }
    }
}
