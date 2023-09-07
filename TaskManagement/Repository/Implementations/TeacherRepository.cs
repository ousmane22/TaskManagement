using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.DTO;
using TaskManagement.Models;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TaskManagementDbContext _context;
        private readonly IMapper _mapper;
        public TeacherRepository(TaskManagementDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);   
            await _context.SaveChangesAsync();
            return teacher.UserId; 
        }

        //public async Task<int> AddTeacherWithDto(TeacherCreationModel teacherDto)
        //{
            
        //    var teacher = _mapper.Map<TeacherCreationModel, Teacher>(teacherDto);

        //    _context.Teachers.Add(teacher);
        //    await _context.SaveChangesAsync();

        //    return teacher.UserId;
        //}
        

        public async Task<bool> Delete(int id)
        {
            var teacherToDelete = await _context.Teachers.FindAsync(id);

            if (teacherToDelete == null)
            {
                return false; 
            }

            _context.Teachers.Remove(teacherToDelete);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Teacher> GetByName(string name)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.User.FirstName == name);
        }
    }
}
