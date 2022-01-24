using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Models.Student
{
    public class StudentDetail
    {
        public int StudentId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Type of Student")]
        public StudentType TypeOfStudent { get; set; }
    }
}
