using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachersFacture.DataContexts;
using TeachersFacture.Models;

namespace TeachersFacture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationContext _contextTeachers;

        public TeachersController(ApplicationContext contexto)
        {
            _contextTeachers = contexto;
        }

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachersInfo()
        {
            return await _contextTeachers.TeachersInfo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherInfo(int id)
        {
            var teacher = await _contextTeachers.TeachersInfo.FindAsync(id);

            if(teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<ActionResult> PostTeachersInfo(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

           _contextTeachers.TeachersInfo.Add(teacher);
            await _contextTeachers.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeacherInfo), new { id = teacher.Id }, teacher);
        }
    }
}
