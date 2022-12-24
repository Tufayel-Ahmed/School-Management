using System.ComponentModel.DataAnnotations;

namespace School_Management.Models
{
    public class Standard
    {
        [Key]
        public int StandardId { get; set; }

        public string StandardName { get; set; }

        public string Description { get; set; }
    }
}
