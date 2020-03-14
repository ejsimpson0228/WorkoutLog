using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Data.Interfaces;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Repositories.EFRepos
{
    public class WorkoutRepoEF : IWorkoutRepo
    {
        public Task<Workout> AddExerciseToWorkout(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public Task<Workout> CreateWorkout(Workout workout)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWorkout(int workoutId)
        {
            throw new NotImplementedException();
        }

        public Task<Workout> EditWorkout(int workoutId, Workout updatedWorkout)
        {
            throw new NotImplementedException();
        }
    }
}
