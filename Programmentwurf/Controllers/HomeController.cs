using Buecherverwaltung.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;



namespace Buchverwaltung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Die Aktion für die Startseite (Home/Index)
        public IActionResult Index()
        {
            return View();
        }

        // Die Aktion für die Datenschutz-Seite (Home/Privacy)
        public IActionResult Privacy()
        {
            return View();
        }

        // Die Aktion für die Fehler-Seite (Home/Error)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Hier wird ein ErrorViewModel erstellt, um Fehlerinformationen an die Fehler-View zu übergeben
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
