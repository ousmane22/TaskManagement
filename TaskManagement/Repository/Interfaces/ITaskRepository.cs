using TaskManagement.Models;

namespace TaskManagement.Repository.Interfaces
{
    public interface ITaskRepository:IGenericRepository<TaskUser>
    {
        Task<IEnumerable<TaskUser>> GetTasksByUserIdAsync(int userId);

    }
}
