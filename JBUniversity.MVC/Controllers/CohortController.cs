using JBUniversity.Services;
using Microsoft.AspNetCore.Mvc;

namespace JBUniversity.WebMVC.Controllers
{
    public class CohortController : Controller
    {
        private readonly ICohortService _cohortService;

        public CohortController(ICohortService cohortService)
        {
            _cohortService = cohortService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _cohortService.GetAllAsync());
        }
    }
}