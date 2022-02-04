using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public interface ITeacherCourseRepository
    {
        Task<TeacherCourseDTO> GetByTeacherID(int TeacherId);
        Task<TeacherCourseDTO> GetByCourseID(int CourseId);
        Task<TeacherCourseDTO> Create(TeacherCourseDTO TeacherCourseDTO);
    }
}
