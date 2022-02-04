using TeachersFacture.Models;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public interface ITeachersRepository
    {
        Task<List<TeacherDTO>> GetTeachers();
        Task<TeacherDTO> GetById(int id);
        Task<TeacherDTO> CreateUpdate(TeacherDTO teacherDTO);
        Task<bool> Delete(int id);
        Task<bool> TeacherExist(string idNumber);
        Task<Exchange> GetExchangeMoney(string money);

    }
}
