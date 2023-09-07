using TaskManagement.Data;
using TaskManagement.Models;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDbContext _taskManagementDbContext;

        public TaskRepository(TaskManagementDbContext taskManagementDbContext)
        {
            _taskManagementDbContext = taskManagementDbContext;
        }

        public TaskUser AddTask(TaskUser task)
        {
            _taskManagementDbContext.TaskUsers.Add(task);
            _taskManagementDbContext.SaveChanges();
            return task;
        }

        public Task delete(Task task)
        {
            var taskToDelete = _taskManagementDbContext.Tasks.Find(id);
            if (taskToDelete == null)
            {
                throw new Exception("Tâche introuvable");
            }

            _taskManagementDbContext.Tasks.Remove(taskToDelete);
            _taskManagementDbContext.SaveChanges();
            return taskToDelete;
        }

        public TaskUser GetTaskById(int id)
        {
            return _taskManagementDbContext.TaskUsers.Find(id);
           
        }

        public TaskUser GetTaskByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskUser> GetTasks()
        {
            throw new NotImplementedException();
        }
    }
}
