using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersFacture.Interfaces;
using TeachersFacture.Models.DTO;
using TeachersFacture.Repository;

namespace TeachersFacture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NominaController : ControllerBase
    {
        private readonly INominaRepository _repository;
        protected ResponseDTO _response;

        public NominaController(INominaRepository repository)
        {
            _repository = repository;  
            _response = new ResponseDTO();
        }

        [HttpPost]
        [Route("GenerateNomina")]
        public async Task<ActionResult> GenerateNomina(string DateNomina)
        {
            var date = DateTime.Parse(DateNomina);
        
            var lessons = await _repository.GetByMonth(date);

            if(lessons == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "No hay lecciones registrada en el mes seleccionado";
                return NotFound(_response);
            }
            double totalAcumulated = 0;
            lessons.ForEach(async x =>
            {
                x.CostInCOP = await _repository.CalculateCost(x.MoneyPay, x.Cost);
                totalAcumulated += x.CostInCOP;

            });
        

            return Ok(new { lessons, totalAcumulated });
            

        }

    }
}
