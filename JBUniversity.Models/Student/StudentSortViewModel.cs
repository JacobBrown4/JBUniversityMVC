using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Models
{
    public class StudentSortViewModel
    {
        public List<StudentDisplay>? Students { get; set; }
        public SelectList? Type { get; set; }

        public string? Time { get; set; }
        public string? SearchString { get; set; }
    }
}
