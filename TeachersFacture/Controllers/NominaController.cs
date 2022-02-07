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

        [HttpGet]
        public async Task<ActionResult> GenerateNomina(int Month)
        {
            var lessons = await _repository.GetByMonth(Month);

            if(lessons == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "No hay lecciones registrada en el mes";
                return NotFound(_response);
            }

            return Ok(lessons);
            

        }

    }
}
