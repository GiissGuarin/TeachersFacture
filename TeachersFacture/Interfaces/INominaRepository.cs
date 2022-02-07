using TeachersFacture.Models.DTO;

namespace TeachersFacture.Interfaces
{
    public interface INominaRepository
    {
        Task<List<NominaDTO>> GetByMonth(int month);
        Task<double> CalculateCost(TeacherDTO Teacher, int LessonHours);

    }
}
