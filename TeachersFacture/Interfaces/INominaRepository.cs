using TeachersFacture.Models;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Interfaces
{
    public interface INominaRepository
    {
        Task<List<NominaDTO>> GetByMonth(DateTime DateNomina);
        Task<double> CalculateCost(string TeacherID, double LessonCost);

    }
}
