using JBUniversity.Models.Cohort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Services
{
    public interface ICohortService
    {
        Task<List<CohortDisplay>> GetAllAsync();
    }
}
