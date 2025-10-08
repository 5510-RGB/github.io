using Microsoft.AspNetCore.Mvc;

namespace PolatPortfolio.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
