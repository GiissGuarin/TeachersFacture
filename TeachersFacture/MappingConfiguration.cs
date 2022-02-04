using AutoMapper;
using TeachersFacture.Models;
using TeachersFacture.Models.DTO;

namespace TeachersFacture
{
    public class MappingConfiguration
    { 
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TeacherDTO, Teacher>();
                config.CreateMap<Teacher, TeacherDTO>();
            });
            return mappingConfig;
        }
    }
}
