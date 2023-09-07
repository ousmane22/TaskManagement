using System.Threading.Tasks;
using TaskManagement.Models;

namespace TaskManagement.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);

        Task<T> GetByName(string name);

        Task<int> Add(T task);

        Task<bool> Delete(int id);
    }
}
