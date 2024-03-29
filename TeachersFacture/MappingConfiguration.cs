﻿using AutoMapper;
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
                config.CreateMap<TeacherCourse, TeacherCourseDTO>();
                config.CreateMap<TeacherCourseDTO, TeacherCourse>();
                config.CreateMap<Exchange, ExchangeDTO>();
                config.CreateMap<ExchangeDTO, Exchange>();
                config.CreateMap<NominaDTO, Nomina>();
                config.CreateMap<Nomina, NominaDTO>();
                config.CreateMap<CourseDTO, Course>();
                config.CreateMap<Course, CourseDTO>();

            });
            return mappingConfig;
        }
    }
}
