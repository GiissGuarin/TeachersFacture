using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeachersFacture.DataContexts;
using TeachersFacture.Models;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public class TeacherCourseRepository : ITeacherCourseRepository
    {
        private readonly ApplicationContext _db;
        private IMapper _mapper;

        public TeacherCourseRepository(ApplicationContext db, IMapper mapper )
        {
            _db = db;   
            _mapper = mapper;   
                    
        }
        public async Task<TeacherCourseDTO> Create(TeacherCourseDTO TeacherCourseDTO)
        {
            TeacherCourse lesson = _mapper.Map<TeacherCourseDTO, TeacherCourse>(TeacherCourseDTO);
           
            await _db.TeacherCourses.AddAsync(lesson);
            await _db.SaveChangesAsync();

            return _mapper.Map<TeacherCourse, TeacherCourseDTO>(lesson);
        }

        public async Task<List<TeacherCourseDTO>> GetByCourseID(int CourseId)
        {
            var lesson =  _db.TeacherCourses.Where(x => x.CourseId == CourseId).Include(x=> x.Teachers).ToList();
            return _mapper.Map<List<TeacherCourseDTO>>(lesson);
        }

        public async Task<List<TeacherCourseDTO>> GetByTeacherID(int TeacherId)
        {
            var lesson = _db.TeacherCourses.Where(x => x.TeacherId == TeacherId).Include(x => x.Courses).ToList();
            return _mapper.Map<List<TeacherCourseDTO>>(lesson);
        }
    }
}
