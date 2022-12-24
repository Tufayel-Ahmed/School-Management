using Microsoft.EntityFrameworkCore;
using School_Management.Models;

namespace School_Management.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options){}

        public DbSet<Standard> Standards { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentAddress> StudentAddresses { get; set; }

       public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}
