using System.ComponentModel.DataAnnotations;

namespace JBUniversity.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int TypeOfStudent { get; set; }
    }
}