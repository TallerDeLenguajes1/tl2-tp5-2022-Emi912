using CadeteriaMVC.Models.ViewModels;

namespace CadeteriaMVC.Helpers
{
    public static class Mapper
    {
        public static List<PedidoViewModel> PedidosToPedidosVM(List<Pedido> pedidos)
        {
            List<PedidoViewModel> pedidosVm = new List<PedidoViewModel>();
            foreach (var pedido in pedidos)
            {
                PedidoViewModel pedidoViewModel = new PedidoViewModel()
                {
                    Nro = pedido.Id,
                    Observacion = pedido.Observacion,
                    Nombre_Cliente = pedido.Cliente.Nombre,
                    Estado = pedido.Estado.ToString()
                };
                pedidosVm.Add(pedidoViewModel);

            }
            return pedidosVm;

        }
    }
}
