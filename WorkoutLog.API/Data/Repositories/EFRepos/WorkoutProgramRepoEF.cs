using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Data.Interfaces;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Repositories.EFRepos
{
    public class WorkoutProgramRepoEF : IWorkoutProgramRepo
    {
        public async Task<WorkoutProgram> AddWorkoutToProgram(int programId, Workout workoutToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<WorkoutProgram> CreateProgram(Program program)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProgram(int programId)
        {
            throw new NotImplementedException();
        }

        public Task<WorkoutProgram> EditProgram(int programId, Program updatedProgram)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WorkoutProgram>> GetUserPrograms(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
