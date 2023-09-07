using TaskManagement.Repository.Implementations;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository
{
    public  static class ServiceExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            
        }
    }
}
