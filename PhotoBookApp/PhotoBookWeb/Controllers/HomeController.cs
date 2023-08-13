using Microsoft.AspNetCore.Mvc;
using PhotoBookWeb.Models;
using System.Diagnostics;

namespace PhotoBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
        [Route("Home/Index/{id}")]
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                TempData["JWT"]= id;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}