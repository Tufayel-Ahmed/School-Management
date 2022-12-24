using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management.Models
{
    public class StudentAddress
    {
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }

        public string AddressOne { get; set;}

        public string AddressTwo { get; set;}

        public string MoblileNo { get; set; }

        public string Email { get; set; }
    }
}
