using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersFacture.Interfaces;
using TeachersFacture.Models;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        protected ResponseDTO _response;
        private readonly ICourseRepository _courseRepository;

        public CourseController(ResponseDTO response, ICourseRepository courseRepository)
        {
            _response = response;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("GetCoursesList")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            try
            {
                var lista = await _courseRepository.GetCourses();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Cursos";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }

           
        }

        [HttpPost]
        [Route("CreateCourse")]
        public async Task<ActionResult> PostCourse(CourseDTO courseDTO)
        {
            try
            {
                CourseDTO model = await _courseRepository.PostCourse(courseDTO);
                _response.Result = model;
                _response.DisplayMessage = "El curso fue creado exitosamente";
                return Ok(_response);
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el curso";
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }
        }
    }
}
