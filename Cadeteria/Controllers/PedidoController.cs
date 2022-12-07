using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cadetes.Models;
using CadeteriaMVC.Models.ViewModels;
using CadeteriaMVC.Helpers;
using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;

namespace Cadetes.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPedidosRepository _repo;
        public PedidoController(ILogger<HomeController> logger, IPedidosRepository repo)
        {
            _logger = logger;
            _repo = repo;

        }

        public IActionResult Index()
        {
            List<Pedido> pedidos = _repo.GetAll();
            List<PedidoViewModel> pedidosViewModel = Mapper.PedidosToPedidosVM(pedidos);
            return View(pedidosViewModel);
        }
        [HttpGet]
        public IActionResult AddPedido()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddPedido(string nombre, string direccion, string obs, string telefono)
        {
            //Cliente cliente = new Cliente(nombre, direccion, telefono, direccion, null);
            //Pedido pedido = new Pedido(obs, cliente);
            //HelperArchivos.InsertCliente(cliente);
            //HelperArchivos.InsertPedido(pedido);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Pedido nPedido = _repo.GetById(id);
            PedidoViewModel pedidoVM = Mapper.PedidoToPedidoVM(nPedido);

            return View(pedidoVM);
        }

        
        public IActionResult Delete(int id)
        {
            Pedido nPedido = _repo.GetById(id);
            PedidoViewModel pedidoVM = Mapper.PedidoToPedidoVM(nPedido);

            return View(pedidoVM);
        
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _repo.DeletePedido(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(PedidoViewModel pedido)
        {
            Cliente cliente = new Cliente()
            {
                Id = _repo.GetLastIdCliente(),
                Telefono = pedido.Telefono,
                Nombre = pedido.Nombre_Cliente,
                Direccion = pedido.Direccion
            };

        
            return RedirectToAction("Index");

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}