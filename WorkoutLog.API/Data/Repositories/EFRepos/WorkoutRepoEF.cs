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
    public class WorkoutRepoEF : IWorkoutRepo
    {
        private DatabaseContext _db;

        public WorkoutRepoEF(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<Workout> AddExerciseToWorkout(int workoutId, Exercise exercise)
        {
            try
            {
                var workout = await _db.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId);
                workout.Exercises.ToList().Add(exercise);
                return await _db.SaveChangesAsync() > 0 ? workout : null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Workout> CreateWorkout(Workout workout)
        {
            try
            {
                _db.Workouts.Add(workout);
                return await _db.SaveChangesAsync() > 0 ? workout : null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> DeleteWorkout(int workoutId)
        {
            try
            {
                var workoutToDelete = await _db.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId);
                _db.Workouts.Remove(workoutToDelete);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<Workout> EditWorkout(int workoutId, Workout updatedWorkout)
        {
            try
            {
                var workoutToEdit = await _db.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId);
                workoutToEdit = updatedWorkout;
                workoutToEdit.Id = workoutId;
                return await _db.SaveChangesAsync() > 0 ? workoutToEdit : null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
