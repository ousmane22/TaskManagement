using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagement.Data;
using TaskManagement.Models;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public TaskRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(TaskUser task)
        {
            _context.TaskUsers.Add(task);
            await _context.SaveChangesAsync();
            return task.Id; 
        }

        public async Task<bool> Delete(int id)
        {
            var taskToDelete = await _context.TaskUsers.FindAsync(id);

            if (taskToDelete == null)
            {
                return false;
            }

            _context.TaskUsers.Remove(taskToDelete);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<IEnumerable<TaskUser>> GetAll()
        {
            return await _context.TaskUsers.ToListAsync();
        }

        public async Task<TaskUser> GetById(int id)
        {
            return await _context.TaskUsers.FindAsync(id);
        }

        public async Task<TaskUser> GetByName(string name)
        {
            return await _context.TaskUsers.FirstOrDefaultAsync(task => task.Title == name);
        }

        public async Task<IEnumerable<TaskUser>> GetTasksByUserIdAsync(int userId)
        {
            var tasks = await _context.TaskUsers.Where(task => task.UserId == userId).ToListAsync();

            return tasks;

        }
    }
}
