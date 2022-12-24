using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using School_Management.Data;
using School_Management.Interface_Repository;
using School_Management.Models;
using System.Linq;

namespace School_Management.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public async Task<List<Student>> GetStudents()
        {
            var students =  await _schoolDbContext.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _schoolDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            return student!;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _schoolDbContext.Students.AddAsync(student);
            await _schoolDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _schoolDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if(student != null)
            {
                 _schoolDbContext.Students.Remove(student);
                await _schoolDbContext.SaveChangesAsync();
            }
            return student!;
        }

        /*public async Task<List<Standard>> GetTeacherInfo()
        {
            var teacherInfo = await _schoolDbContext.Standards.Join(
                _schoolDbContext.Teachers, standard => 
                standard.StandardId, teacher => 
                teacher.StandardId, (s, t) => 
                new { 
                    Standard_Name = s.StandardName, 
                    Teacher_First_Name = t.FirstName, 
                    Teacher_Last_Name = t.LastName 
                }).ToListAsync();
            return teacherInfo;
        }*/
    }
}
