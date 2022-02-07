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
        private readonly IExchangeRepository _exchangeRepository;
        private IMapper _mapper;

        public TeacherCourseRepository(ApplicationContext db, IMapper mapper, IExchangeRepository exchangeRepository )
        {
            _db = db;   
            _exchangeRepository = exchangeRepository;  
            _mapper = mapper;   
                    
        }

        public async Task<double> CalculateCost(TeacherDTO Teacher,int LessonHours)
        {
            ExchangeDTO exchange = await _exchangeRepository.GetByMoney(Teacher.MoneyPay);
            var conversion = Teacher.RateHour * exchange.conversion_rates.COP;
            var costInCOP = LessonHours * conversion; 
            return costInCOP;
        }

        public async Task<TeacherCourseDTO> Create(TeacherCourseDTO TeacherCourseDTO)
        {
            TeacherCourse lesson = _mapper.Map<TeacherCourseDTO, TeacherCourse>(TeacherCourseDTO);
           
            await _db.TeacherCourses.AddAsync(lesson);
            await _db.SaveChangesAsync();

            return _mapper.Map<TeacherCourse, TeacherCourseDTO>(lesson);
        }


        public async Task<List<TeacherCourseDTO>> GetByTeacherID(int TeacherId)
        {
            DateTime dt = DateTime.Now;
            var lesson = _db.TeacherCourses.Where(x => x.TeacherId == TeacherId)
                .Where(x => x.Date.Month == dt.Month)
                .Where(x => x.Date.Year == dt.Year)
                .Include(x => x.Courses).ToList();
            return _mapper.Map<List<TeacherCourseDTO>>(lesson);
        }

        public async Task<List<TeacherCourseDTO>> GetByTwoID(int TeacherId, int CourseId)
        {
            DateTime dt = DateTime.Now;
            var lesson = _db.TeacherCourses
                .Where(x => x.TeacherId == TeacherId)
                .Where(x => x.CourseId == CourseId)
                .Where(x => x.Date.Month == dt.Month)
                .Where(x => x.Date.Year == dt.Year)
                .Include(x => x.Courses).ToList();
            return _mapper.Map<List<TeacherCourseDTO>>(lesson);
        }


    }
}
