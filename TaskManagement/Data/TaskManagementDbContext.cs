using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class TaskManagementDbContext:DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options):
            base(options)
        {
        }

        public DbSet<Administrator>  Administrators { get; set;}
        public DbSet<Student>  Students { get; set;}
        public DbSet<Teacher>  Teachers { get; set;}
        public DbSet<TaskUser> TaskUsers { get; set;}
        public DbSet<User> Users { get; set;}
    }
}
