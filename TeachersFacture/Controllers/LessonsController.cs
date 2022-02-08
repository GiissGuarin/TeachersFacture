using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersFacture.Models;
using TeachersFacture.Models.DTO;
using TeachersFacture.Repository;

namespace TeachersFacture.Controllers
{
    [Route("api/Lesson")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ITeacherCourseRepository _teachersCourseRepository;
        private readonly ITeachersRepository _teachersRepository;
   
        protected ResponseDTO _response;

        private int MaxHours = 160;
        private int MaxHourPerCourse = 20;

        public LessonsController(ITeacherCourseRepository teachersCourseRepository, ITeachersRepository teachersRepository)   
        {
            _response = new ResponseDTO();
            _teachersCourseRepository = teachersCourseRepository; 
            _teachersRepository = teachersRepository;
 
        }

        [HttpGet]
        [Route("GetLessonsByIdentification")]
        public async Task<ActionResult> GetLessonById(string IdNumber)
        {
            var Teacher = await _teachersRepository.GetByTeacherIdNumber(IdNumber);
            if(Teacher == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El número de identificación no se encuentra registrado";
                return NotFound(_response);
            }
            var lessons = _teachersCourseRepository.GetByTeacherID(Teacher.Id);
            if(lessons == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "El número de identificación no posee lecciones registradas";
                return NotFound(_response);
            }
            _response.Result = lessons.Result;
            _response.DisplayMessage = $"Listado de Lecciones del profesor {Teacher.Name}";

            return Ok(_response); 

        }


        [HttpPost]
        [Route("CreateLesson")]
        public async Task<ActionResult> PostLesson(TeacherCourseDTO Lesson)
        {
            
            Console.WriteLine(Lesson.ToString());

            try
            {
                var LessonsByTeacher = await _teachersCourseRepository.GetByTeacherID(Lesson.TeacherId);
                int acumulatedHours = Lesson.DictatedHours;
                LessonsByTeacher.ForEach(lesson =>
                {
                    acumulatedHours += lesson.DictatedHours;
                });

                if(acumulatedHours >= MaxHours)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = $"Ha sobrepasado el máximo legal de horas acumuladas en el mes ({MaxHours})";
                    return BadRequest(_response);
                }

                var LessonByTeacherAndCourse = await _teachersCourseRepository.GetByTwoID(Lesson.TeacherId, Lesson.CourseId);
                int acumulatedHoursPerCourse = Lesson.DictatedHours;

                LessonByTeacherAndCourse.ForEach(lesson =>
                {
                    acumulatedHoursPerCourse += lesson.DictatedHours;
                });

                if(acumulatedHoursPerCourse >= MaxHourPerCourse)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = $"Ha sobrepasado el máximo legal de horas acumuladas en el mes dictadas en este curso ({MaxHourPerCourse})";
                    return BadRequest(_response);
                }

                TeacherDTO teacher = await _teachersRepository.GetById(Lesson.TeacherId);
                if (teacher == null)
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "El profesor no existe";
                    return BadRequest(_response);
                }

                Lesson.Cost = teacher.RateHour * Lesson.DictatedHours;

                TeacherCourseDTO model = await _teachersCourseRepository.Create(Lesson);
                _response.Result = model;
                _response.DisplayMessage = "Lección registrada con éxito";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear la lección";
                _response.ErrorMessage = ex.Message;
                return BadRequest(_response);
            }

        }
    }
}
