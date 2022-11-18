using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cadetes.Models;
using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;

namespace Cadetes.Controllers
{
    public class CadetesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICadeteRepository _repo;

        public CadetesController(ILogger<HomeController> logger, ICadeteRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            List<Cadete> cadetes = _repo.GetAll();
            return View(cadetes);
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