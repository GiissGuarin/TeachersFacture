using TeachersFacture.Models.DTO;

namespace TeachersFacture.Interfaces
{
    public interface ICourseRepository
    {
        Task<CourseDTO> PostCourse(CourseDTO Course);
        Task<List<CourseDTO>> GetCourses();
    }
}
