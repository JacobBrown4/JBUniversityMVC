using JBUniversity.Data.Data;
using JBUniversity.Models.Cohort;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Services
{
    public class CohortService : ICohortService
    {
        private readonly JBUniversityContext _context;

        public CohortService(JBUniversityContext context)
        {
            _context = context;
        }


        public async Task<List<CohortDisplay>> GetAllAsync()
        {
            var cohorts = from m in _context.Cohorts
                          select m;


            var cohortsList = await cohorts.OrderBy(c => c.Name).Select(s => new CohortDisplay
            {
                Name = s.Name,
                CohortId = s.Id
            }).ToListAsync();


            return cohortsList;

        }
    }
}
