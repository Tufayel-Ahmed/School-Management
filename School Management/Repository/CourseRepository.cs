using Microsoft.EntityFrameworkCore;
using School_Management.Data;
using School_Management.Interface_Repository;
using School_Management.Models;

namespace School_Management.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public CourseRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public async Task<List<Course>> GetCourses()
        {
            var courses = await _schoolDbContext.Courses.OrderByDescending(c => c.CourseName).ToListAsync();
            return courses;
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = await _schoolDbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            return course!;
        }

        public async Task<Course> AddCourse(Course course)
        {
            await _schoolDbContext.Courses.AddAsync(course);
            await _schoolDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteCourseById(int id)
        {
            var course = await _schoolDbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            if (course != null)
            {
                _schoolDbContext.Courses.Remove(course);
                await _schoolDbContext.SaveChangesAsync();
            }
            return course!;
        }
    }
}
