using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey("Standard")]
        public int StandardId { get; set; }
    }
}
