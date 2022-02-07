using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TeachersFacture.DataContexts;
using TeachersFacture.Models;
using TeachersFacture.Models.DTO;

namespace TeachersFacture.Repository
{
    public class TeacherRepository : ITeachersRepository
    {
        private readonly ApplicationContext _db;
        private IMapper _mapper;

        public TeacherRepository(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TeacherDTO> CreateUpdate(TeacherDTO teacherDTO)
        {
            Teacher teacher = _mapper.Map<TeacherDTO, Teacher>(teacherDTO);

            if(teacher.Id > 0)
            {
                _db.TeachersInfo.Update(teacher);
            }
            else
            {
                await _db.TeachersInfo.AddAsync(teacher);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Teacher, TeacherDTO>(teacher);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Teacher teacher = await _db.TeachersInfo.FindAsync(id);
                if (teacher == null)
                {
                    return false;
                }
                _db.TeachersInfo.Remove(teacher);
                await _db.SaveChangesAsync();

                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<TeacherDTO>> GetTeachers()
        {
            List<Teacher> lista = await _db.TeachersInfo.ToListAsync();
            return _mapper.Map<List<TeacherDTO>>(lista);
        }

        public async Task<TeacherDTO> GetById(int id)
        {
            Teacher teacher = await _db.TeachersInfo.FindAsync(id);

            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<bool> TeacherExist(string idNumber)
        {
            if(await _db.TeachersInfo.AnyAsync(x=>x.IdentifyNumber == idNumber))
            {
                return true;
            }
            return false;
        }

       
    }


}
