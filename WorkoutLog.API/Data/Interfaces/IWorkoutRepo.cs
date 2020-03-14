using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IWorkoutRepo
    {
        Task<Workout> CreateWorkout(Workout workout);
        Task<Workout> AddExerciseToWorkout(int WorkoutId, Exercise exercise);
        Task<Workout> EditWorkout(int workoutId, Workout updatedWorkout);
        Task<bool> DeleteWorkout(int workoutId);
    }
}
