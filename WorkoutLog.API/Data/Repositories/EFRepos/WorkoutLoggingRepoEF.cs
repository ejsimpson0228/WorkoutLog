using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Goal> AddGoal(Goal goal)
        {
            try
            {
                _db.Goals.Add(goal);
                return await _db.SaveChangesAsync() > 0 ? goal : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteLog(int logId)
        {
            try
            {
                var logToDelete = await _db.Logs.FirstOrDefaultAsync(l => l.Id == logId);
                _db.Logs.Remove(logToDelete);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<Log> EditLog(int logId, Log updatedLog)
        {
            try
            {
                var logToEdit = await _db.Logs.FirstOrDefaultAsync(l => l.Id == logId);
                logToEdit = updatedLog;
                logToEdit.Id = logId;
                return await _db.SaveChangesAsync() > 0 ? logToEdit : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Report> GetUserReportInfo(IdentityUser user)
        {
            try
            {
                var report = new Report
                {
                    User = user
                };
                report.WorkoutPrograms = await _db.WorkoutPrograms.Where(p => p.User == user).ToListAsync();
                report.Workouts = await _db.Workouts.Where(w => w.User == user).ToListAsync();
                report.Exercises = await _db.Exercises.Where(e => e.User == user).ToListAsync();
                report.Goals = await _db.Goals.Where(g => g.User == user).ToListAsync();

                return report;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Log>> GetLogs(string userId)
        {
            try
            {
                return await _db.Logs.Where(l => l.User.Id == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Log> LogExercise(Exercise exerciseToLog, Volume volumeToLog, DateTime dateLogged)
        {
            var log = new Log
            {
                Exercise = exerciseToLog,
                Date = dateLogged,
                User = exerciseToLog.User,
                Volume = volumeToLog
            };

            try
            {
                _db.Logs.Add(log);
                return await _db.SaveChangesAsync() > 0 ? log : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Goal> GetGoalForExercise(int exerciseId)
        {
            throw new NotImplementedException();
        }
    }
}
