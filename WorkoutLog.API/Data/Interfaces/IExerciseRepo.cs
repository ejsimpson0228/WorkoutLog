using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Interfaces
{
    public interface IExerciseRepo
    {
        Exercise CreateExercies(Exercise exercise);
        Exercise EditExercise(int exerciseId, Exercise updatedExercise);
        void DeleteExercie(int exerciseId);
    }
}
