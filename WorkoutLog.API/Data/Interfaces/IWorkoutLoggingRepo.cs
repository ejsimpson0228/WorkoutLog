using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IWorkoutLoggingRepo
    {
        IEnumerable<Log> GetLogs(string userId);
        Log LogExercise(Exercise exerciseToLog, DateTime dateLogged);
        Log EditLog(int logId, Log updatedLog);
        void DeleteLog(int logId);
    }
}
