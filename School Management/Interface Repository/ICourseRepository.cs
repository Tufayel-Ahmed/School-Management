using School_Management.Models;

namespace School_Management.Interface_Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCourses();

        Task<Course> GetCourseById(int id);

        Task<Course> AddCourse(Course course);

        Task<Course> DeleteCourseById(int id);
    }
}
