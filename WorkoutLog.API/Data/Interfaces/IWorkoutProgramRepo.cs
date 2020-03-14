using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IWorkoutProgramRepo
    {
        Task<WorkoutProgram> CreateProgram(WorkoutProgram program);
        Task<WorkoutProgram> EditProgram(int programId, WorkoutProgram updatedProgram);
        Task<bool> DeleteProgram(int programId);
        Task<IEnumerable<WorkoutProgram>> GetUserPrograms(string userId);
        Task<WorkoutProgram> AddWorkoutToProgram(int programId, Workout workoutToAdd);
    }
}
