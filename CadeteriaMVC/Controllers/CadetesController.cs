using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;
using Cadetes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cadetes.Controllers
{
    public class CadetesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientesRepository _repo;

        public CadetesController(ILogger<HomeController> logger, IClientesRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Cliente> pedidos = _repo.GetAll();
            return View(pedidos);
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