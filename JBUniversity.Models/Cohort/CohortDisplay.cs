using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Models.Cohort
{
    public class CohortDisplay
    {
        [Required]
        public int CohortId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
