using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IWorkoutProgramRepo
    {
        WorkoutProgram CreateProgram(Program program);
        WorkoutProgram EditProgram(int programId, Program updatedProgram);
        void DeleteProgram(int programId);
        IEnumerable<WorkoutProgram> GetUserPrograms(string userId);
        WorkoutProgram AddWorkoutToProgram(int programId, Workout workoutToAdd);
    }
}
