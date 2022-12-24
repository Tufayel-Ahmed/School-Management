using Microsoft.AspNetCore.Mvc;
using School_Management.Models;

namespace School_Management.Interface_Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentById(int id);

        //Task<List<Standard>> GetTeacherInfo();

        Task<Student> AddStudent(Student student);

        Task<Student> DeleteStudent(int id);
    }
}
