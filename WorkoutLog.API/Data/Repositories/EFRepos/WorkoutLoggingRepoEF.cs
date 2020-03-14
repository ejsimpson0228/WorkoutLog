using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Data.Interfaces;
using WorkoutLog.API.Models;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Repositories.EFRepos
{
    public class WorkoutLoggingRepoEF : IWorkoutLoggingRepo
    {
        private DatabaseContext _db;
        private UserManager<IdentityUser> _userManager;

        public WorkoutLoggingRepoEF(DatabaseContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public Task<bool> DeleteLog(int logId)
        {
            throw new NotImplementedException();
        }

        public Task<Log> EditLog(int logId, Log updatedLog)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Log>> GetLogs(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Log> LogExercise(Exercise exerciseToLog, DateTime dateLogged)
        {
            throw new NotImplementedException();
        }
    }
}
