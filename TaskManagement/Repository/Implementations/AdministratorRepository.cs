using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data;
using TaskManagement.Models;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository.Implementations
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly TaskManagementDbContext _context;

        public AdministratorRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Administrator administrator)
        {
            _context.Administrators.Add(administrator);
            await _context.SaveChangesAsync();
            return administrator.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var administratorToDelete = await _context.Administrators.FindAsync(id);

            if (administratorToDelete == null)
            {
                return false; 
            }

            _context.Administrators.Remove(administratorToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Administrator>> GetAll()
        {
            return await _context.Administrators.ToListAsync();
        }

        public async Task<Administrator> GetById(int id)
        {
            return await _context.Administrators.FindAsync(id);
        }

        public async Task<Administrator> GetByName(string name)
        {
            return await _context.Administrators.FirstOrDefaultAsync(administrator => administrator.User.FirstName == name);
        }
    }
}
