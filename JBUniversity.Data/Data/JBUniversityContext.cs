#nullable disable
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Data.Data
{
    public class JBUniversityContext : DbContext
    {
        public JBUniversityContext(DbContextOptions<JBUniversityContext> options)
               : base(options)
        {
        }

        public DbSet<JBUniversity.Data.Student> Students { get; set; }
        public DbSet<JBUniversity.Data.Cohort> Cohorts { get; set; }
    }
}
