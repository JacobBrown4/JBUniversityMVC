using System.ComponentModel.DataAnnotations;

namespace JBUniversity.Models
{
    public class StudentDisplay
    {
        public int StudentId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public StudentType StudentType { get; set; }
    }
}