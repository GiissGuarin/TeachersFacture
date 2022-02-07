using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TeachersFacture.DataContexts;
using TeachersFacture.Interfaces;
using TeachersFacture.Models;
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
        public async Task<List<NominaDTO>> GetByMonth(DateTime DateNomina)
        {
      
            var lesson =    from Datagroup in (from lessons in _db.TeacherCourses
                                            where lessons.Date.Month == DateNomina.Month && lessons.Date.Year == DateNomina.Year
                                               group lessons by lessons.TeacherId into lessonsGroup
                                            select new { idTeacher = lessonsGroup.Key , CostoLecccion = lessonsGroup.ToList().Sum(l => l.Cost)})
                            join teacher in _db.TeachersInfo on Datagroup.idTeacher equals teacher.Id
                            select new { Id= teacher.Id, Name = teacher.Name, Surname = teacher.Surname, MoneyPay = teacher.MoneyPay, Cost = Datagroup.CostoLecccion};

            List <NominaDTO> lista = lesson.Select(l => new NominaDTO(l.Id, l.Name, l.Surname, l.MoneyPay, l.Cost, 0)).ToList();

            return lista;
        }

        public async Task<double> CalculateCost(string MoneyPay, double LessonCost)
        {
            ExchangeDTO exchange = _exchangeRepository.GetByMoney(MoneyPay).Result;
            var costInCOP = LessonCost * exchange.conversion_rates.COP;
            return costInCOP;
        }
    }
}
