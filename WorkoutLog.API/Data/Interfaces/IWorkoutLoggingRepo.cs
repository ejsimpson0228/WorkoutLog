using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IWorkoutLoggingRepo
    {
        Task<IEnumerable<Log>> GetLogs(string userId);
        Task<Log> LogExercise(Exercise exerciseToLog, DateTime dateLogged);
        Task<Log> EditLog(int logId, Log updatedLog);
        Task<bool> DeleteLog(int logId);
    }
}
