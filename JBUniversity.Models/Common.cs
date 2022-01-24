using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Models
{
    public enum StudentType { [Display(Name = "Part Time")]PartTime, [Display(Name = "Full Time")] FullTime, Expelled, Graduated };
    public class Common
    {
    }
}
