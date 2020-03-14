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

        public async Task<bool> DeleteExercise(int exerciseId)
        {
            try
            {
                var exerciseToDelete = await _db.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);
                _db.Remove(exerciseToDelete);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Exercise> EditExercise(int exerciseId, Exercise updatedExercise)
        {
            try
            {
                var exerciseToEdit = await _db.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);
                exerciseToEdit = updatedExercise;
                exerciseToEdit.Id = exerciseId;
                return await _db.SaveChangesAsync() > 0 ? exerciseToEdit : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
