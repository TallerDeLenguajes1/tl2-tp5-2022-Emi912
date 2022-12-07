using Cadetes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cadetes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var valor = HttpContext.Session.GetString("rol");
            if (HttpContext.Session.GetString("rol") == "Cadete")
            {
                return RedirectToAction("Index", "Pedido");
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }

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
