using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey("Standard")]
        public int StandardId { get; set; }
    }
}
