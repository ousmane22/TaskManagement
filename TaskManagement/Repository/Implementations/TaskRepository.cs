using System.Threading.Tasks;
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

        public TaskUser delete(int id)
        {
            var taskToDelete = _taskManagementDbContext.TaskUsers.Find(id);
            if (taskToDelete == null)
            {
                throw new Exception("Tâche introuvable");
            }

            _taskManagementDbContext.TaskUsers.Remove(taskToDelete);
            _taskManagementDbContext.SaveChanges();
            return taskToDelete;
        }

        public TaskUser GetTaskById(int id)
        {
            var task = _taskManagementDbContext.TaskUsers.FirstOrDefault(task => task.Id == id);

            if (task == null)
                throw new NotFoundException($"Task with ID {id} not found");
            return task;
           
        }

        public TaskUser GetTaskByName(string name)
        {
            return _taskManagementDbContext.TaskUsers.FirstOrDefault(task => task.Title == name);
        }

        public IEnumerable<TaskUser> GetTasks()
        {
            return _taskManagementDbContext.TaskUsers.ToList();
        }

       
    }
}
