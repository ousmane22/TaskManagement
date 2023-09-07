using AutoMapper;
using TaskManagement.Models;

namespace TaskManagement.DTO
{


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TeacherCreationModel, Teacher>();
        }

    }

}
