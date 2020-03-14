using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutLog.API.Data.Interfaces;
using WorkoutLog.API.Models;
using WorkoutLog.API.Models.Application;

namespace WorkoutLog.API.Data.Repositories.EFRepos
{
    public class ExerciseRepoEF : IExerciseRepo
    {
        private DatabaseContext _db;
        public ExerciseRepoEF(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<Exercise> CreateExercise(Exercise exercise)
        {
            try
            {
                await _db.Exercises.AddAsync(exercise);
                await _db.SaveChangesAsync();

                return await _db.Exercises.FirstOrDefaultAsync(e => e == exercise);
            }
            catch (Exception ex)
            {
                // TODO: log exceptions
                return null;
            }
        }

        public Task<bool> DeleteExercise(int exerciseId)
        {
            throw new NotImplementedException();
        }

        public Task<Exercise> EditExercise(int exerciseId, Exercise updatedExercise)
        {
            throw new NotImplementedException();
        }
    }
}
