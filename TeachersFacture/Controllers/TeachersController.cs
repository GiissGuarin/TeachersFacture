using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachersFacture.DataContexts;
using TeachersFacture.Models;
using TeachersFacture.Models.DTO;
using TeachersFacture.Repository;

namespace TeachersFacture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;
        protected ResponseDTO _response;

        public TeachersController(ITeachersRepository teachersRepository)
        {
            _teachersRepository=teachersRepository;
            _response=new ResponseDTO();

        }

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachersInfo()
        {
            try
            {
                var lista = await _teachersRepository.GetTeachers();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Profesores";
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage=ex.Message;
            }

            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherInfo(int id)
        {
            var teacher = await _teachersRepository.GetTeachersById(id);

            if(teacher == null)
            {
                _response.IsSuccess=false;
                _response.DisplayMessage = "El profesor no existe";
                return NotFound(_response);
            }

            _response.Result = teacher;
            _response.DisplayMessage = "Información del Profesor";
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult> PostTeachersInfo(TeacherDTO teacherDTO)
        {

            try
            {
                if(teacherDTO.RolId == 1 && teacherDTO.MoneyPay != "COP")
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "La moneda para los profesores de planta debe ser peso Colombiano (COP)";
                    return BadRequest(_response);

                }

                if (teacherDTO.RolId == 2)
                {
                    Exchange exchange = await _teachersRepository.GetExchangeMoney(teacherDTO.MoneyPay);
                    if (exchange == null || exchange.conversion_rates.COP == 0)
                    {
                        _response.IsSuccess = false;
                        _response.DisplayMessage = "La moneda ingresada no posee equivalencia al peso Colombiano (COP)";
                        return BadRequest(_response);
                    }

                }
                   

                var existTeacher = await _teachersRepository.TeacherExist(teacherDTO.IdentifyNumber);
                if (existTeacher)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "El número de identificación ya se encuentra registrado";
                    return BadRequest(_response);
                }

                TeacherDTO model = await _teachersRepository.CreateUpdate(teacherDTO);
                _response.Result = model;
                return CreatedAtAction(nameof(GetTeacherInfo), new { id = model.Id }, model);
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el profesor";
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }
          
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTeacher(int id, TeacherDTO teacherDTO)
        {
            try
            {
                TeacherDTO model = await _teachersRepository.CreateUpdate(teacherDTO);
                _response.Result=model;
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar la información del profesor";
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            try
            {
               bool statusDelete= await _teachersRepository.Delete(id); 
                if (statusDelete)
                {
                    _response.Result = statusDelete;
                    _response.DisplayMessage = "Profesor eliminado con éxito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess=false;
                    _response.DisplayMessage = "Error al eliminar al profesor";
                    return BadRequest(_response);

                }
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al eliminar al profesor";
                _response.ErrorMessage=ex.Message;
                return BadRequest(_response);
            }

        }
    }
}
