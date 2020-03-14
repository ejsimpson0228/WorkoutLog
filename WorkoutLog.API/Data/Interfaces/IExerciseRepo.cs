using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IExerciseRepo
    {
        Task<Exercise> CreateExercise(Exercise exercise);
        Task<Exercise> EditExercise(int exerciseId, Exercise updatedExercise);
        Task<bool> DeleteExercise(int exerciseId);
    }
}
