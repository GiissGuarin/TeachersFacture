using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeachersFacture.DataContexts;
using TeachersFacture.Interfaces;
using TeachersFacture.Models;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public class CourseRepository : ICourseRepository
    {

        private readonly ApplicationContext _db;
        private IMapper _mapper;

        public CourseRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;   
        }
        public async Task<List<CourseDTO>> GetCourses()
        {
            List<Course> lista = await _db.Courses.ToListAsync();
            return _mapper.Map<List<CourseDTO>>(lista);
        }

        public async Task<CourseDTO> PostCourse(CourseDTO Course)
        {
            Course course = _mapper.Map<CourseDTO, Course>(Course);
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return _mapper.Map<Course, CourseDTO>(course);
        }

    }
}
