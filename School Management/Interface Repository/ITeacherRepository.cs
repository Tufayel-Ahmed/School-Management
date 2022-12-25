using School_Management.Models;

namespace School_Management.Interface_Repository
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetTeachers();

        Task<Teacher> GetTeacherById(int id);

        Task<Teacher> AddTeacher(Teacher teacher);

        Task<Teacher> DeleteTeacherById(int id);
    }
}
