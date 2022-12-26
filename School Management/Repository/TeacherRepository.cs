using Microsoft.EntityFrameworkCore;
using School_Management.Data;
using School_Management.Interface_Repository;
using School_Management.Models;

namespace School_Management.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public TeacherRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public async Task<List<Teacher>> GetTeachers()
        {
            var teachers = await _schoolDbContext.Teachers.Where(t => t.TeacherId < 4).ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            var teacher = await _schoolDbContext.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
            return teacher!;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            await _schoolDbContext.Teachers.AddAsync(teacher);
            await _schoolDbContext.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> DeleteTeacherById(int id)
        {
            var teacher = await _schoolDbContext.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
            if (teacher != null)
            {
                _schoolDbContext.Teachers.Remove(teacher);
                await _schoolDbContext.SaveChangesAsync();
            }
            return teacher!;
        }
    }
}
