using EffortTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System;
using EffortTracker.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace EffortTracker.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly Context _context;

        public TasksRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Tasks> AddTaskAsync(Tasks task)
        {
            var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                command.Transaction = transaction.GetDbTransaction();
                command.CommandText = @"
                    SET IDENTITY_INSERT Tasks ON;
                    INSERT INTO Tasks (task_id, task_name, description)
                    VALUES (@task_id, @task_name, @description);
                    SET IDENTITY_INSERT Tasks OFF;
                ";

                command.Parameters.Add(new SqlParameter("@task_id", task.task_id));
                command.Parameters.Add(new SqlParameter("@task_name", task.task_name));
                command.Parameters.Add(new SqlParameter("@description", (object?)task.description ?? DBNull.Value));

                await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();

                return task;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public async Task<Tasks> UpdateTaskAsync(Tasks task)
        {
            var existingTask = await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.task_id == task.task_id);
            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task with ID {task.task_id} not found.");
            }

            _context.Entry(task).Property(t => t.task_id).IsModified = false;
            _context.Entry(task).Property(t => t.task_name).IsModified = true;
            _context.Entry(task).Property(t => t.description).IsModified = true;

            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}