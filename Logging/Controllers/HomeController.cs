using Logging.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logging.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        public IActionResult Index()
        {
            //_logger.LogTrace("Index sayfasına girildi");
            //_logger.LogDebug("Index sayfasına girildi");
            //_logger.LogInformation("Index sayfasına girildi");
            //_logger.LogWarning("Index sayfasına girildi");
            //_logger.LogError("Index sayfasına girildi");
            //_logger.LogCritical("Index sayfasına girildi");

            _logger.LogInformation("Hello, this is the index!");
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