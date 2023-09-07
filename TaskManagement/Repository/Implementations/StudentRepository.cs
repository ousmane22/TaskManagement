using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TaskManagementDbContext _context;

        public StudentRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var studentToDelete = await _context.Students.FindAsync(id);

            if (studentToDelete == null)
            {
                return false;
            }

            _context.Students.Remove(studentToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> GetByName(string name)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.User.FirstName == name);
        }
    }
}

