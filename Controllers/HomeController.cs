using EmployeeProject.Models; // Importing the model for error handling
using Microsoft.AspNetCore.Mvc; // Importing ASP.NET Core MVC components
using System.Diagnostics; // Importing for diagnostic and logging purposes

namespace EmployeeProject.Controllers
{
    // Controller to manage home page actions
    public class HomeController : Controller
    {
        // Field to log messages, useful for debugging and monitoring
        private readonly ILogger<HomeController> _logger;

        // Constructor to initialize the logger via dependency injection
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Action method to load the main index view.
        /// </summary>
        /// <returns>The main Index view for the application</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action method to load the privacy policy view.
        /// </summary>
        /// <returns>The Privacy view of the application</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Action method to handle errors.
        /// Caches the response for zero duration and does not store it.
        /// </summary>
        /// <returns>The Error view populated with an ErrorViewModel</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}