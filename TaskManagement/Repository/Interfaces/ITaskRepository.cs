using TaskManagement.Models;

namespace TaskManagement.Repository.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskUser> GetTasks();
        TaskUser GetTaskById(int id);

        TaskUser GetTaskByName(string name);

        TaskUser AddTask(TaskUser task);

        Task delete(Task task);
    }
}
