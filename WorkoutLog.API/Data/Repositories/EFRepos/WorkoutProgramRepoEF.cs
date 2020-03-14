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
    public class WorkoutProgramRepoEF : IWorkoutProgramRepo
    {
        private DatabaseContext _db;

        public WorkoutProgramRepoEF(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<WorkoutProgram> AddWorkoutToProgram(int programId, Workout workoutToAdd)
        {
            try
            {
                var program = await _db.WorkoutPrograms.FirstOrDefaultAsync(p => p.Id == programId);
                program.Workouts.ToList().Add(workoutToAdd);
                return await _db.SaveChangesAsync() > 0 ? program : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<WorkoutProgram> CreateProgram(WorkoutProgram program)
        {
            try
            {
                await _db.WorkoutPrograms.AddAsync(program);
                return await _db.SaveChangesAsync() > 0 ? program : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteProgram(int programId)
        {
            try
            {
                var programToDelete = await _db.WorkoutPrograms.FirstOrDefaultAsync(p => p.Id == programId);
                _db.WorkoutPrograms.Remove(programToDelete);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<WorkoutProgram> EditProgram(int programId, WorkoutProgram updatedProgram)
        {
            try
            {
                var programToEdit = await _db.WorkoutPrograms.FirstOrDefaultAsync(p => p.Id == programId);
                programToEdit = updatedProgram;
                programToEdit.Id = programId;
                return await _db.SaveChangesAsync() > 0 ? programToEdit : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<WorkoutProgram>> GetUserPrograms(string userId)
        {
            try
            {
                return await _db.WorkoutPrograms.Where(p => p.User.Id == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
