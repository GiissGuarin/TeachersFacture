using AutoMapper;
using System.Linq;
using TeachersFacture.DataContexts;
using TeachersFacture.Interfaces;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public class NominaRepository : INominaRepository

    {
        private readonly ApplicationContext _db;
        private readonly IExchangeRepository _exchangeRepository;
        private IMapper _mapper;

        public NominaRepository(ApplicationContext db, IExchangeRepository exchangeRepository , IMapper mapper  )
        {
            _db = db; 
            _exchangeRepository = exchangeRepository;
            _mapper = mapper;
        }
        public async Task<List<NominaDTO>> GetByMonth(int month)
        {


            DateTime dt = DateTime.Now;


            var lesson = (from lessons in _db.TeacherCourses
                          join teacher in _db.TeachersInfo
                              on lessons.TeacherId equals teacher.Id
                          where lessons.Date.Month == month && lessons.Date.Year == dt.Year
                          select new { teacher.Name, teacher.Surname, lessons.Cost }).ToList();


            return _mapper.Map<List<NominaDTO>>(lesson);
            
        }

        public async Task<double> CalculateCost(TeacherDTO Teacher, int LessonHours)
        {
            ExchangeDTO exchange = await _exchangeRepository.GetByMoney(Teacher.MoneyPay);
            var conversion = Teacher.RateHour * exchange.conversion_rates.COP;
            var costInCOP = LessonHours * conversion;
            return costInCOP;
        }
    }
}
