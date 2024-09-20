using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
