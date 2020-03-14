using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutLog.API.Models.Application
{
    public class Report
    {
        public IdentityUser User { get; set; }
        public IEnumerable<WorkoutProgram> WorkoutPrograms { get; set; }
        public IEnumerable<Workout> Workouts { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
    }
}
