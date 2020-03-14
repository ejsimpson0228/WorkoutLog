using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IWorkoutRepo
    {
        Workout CreateWorkout(Workout workout);
        Workout AddExerciseToWorkout(Exercise exercise);
        Workout EditWorkout(int workoutId, Workout updatedWorkout);
        void DeleteWorkout(int workoutId);
    }
}
