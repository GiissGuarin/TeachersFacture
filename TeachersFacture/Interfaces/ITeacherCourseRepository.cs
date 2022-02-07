using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public interface ITeacherCourseRepository
    {
        Task<List<TeacherCourseDTO>> GetByTeacherID(int TeacherId);
        Task<List<TeacherCourseDTO>> GetByTwoID(int TeacherId,int CourseId);
        Task<TeacherCourseDTO> Create(TeacherCourseDTO TeacherCourseDTO);
    }
}
