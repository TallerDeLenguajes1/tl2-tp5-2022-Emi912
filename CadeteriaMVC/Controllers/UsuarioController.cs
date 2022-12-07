using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;
using Cadetes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadeteriaMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioController(IUsuarioRepository repo)
        {

            _repo = repo;

        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Pedido");

            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Usuario user)
        {
            _repo.Register(user);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Login(string nombre, string password)
        {
            Usuario lUsuario = _repo.Login(nombre, password);
                if (lUsuario != null)
                {
                    HttpContext.Session.SetString("user", lUsuario.Nombre);
                    HttpContext.Session.SetString("rol", lUsuario.Rol.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Register");

                }
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
