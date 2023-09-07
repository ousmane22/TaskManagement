using TaskManagement.DTO;
using TaskManagement.Models;

namespace TaskManagement.Repository.Interfaces
{
    public interface ITeacherRepository:IGenericRepository<Teacher>
    {
        //Task<int> AddTeacherWithDto(TeacherCreationModel teacherDto);
    }
}
