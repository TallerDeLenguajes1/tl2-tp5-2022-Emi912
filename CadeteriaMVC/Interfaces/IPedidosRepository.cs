using CadeteriaMVC.Models;

namespace CadeteriaMVC.Interfaces
{
    public interface IPedidosRepository
    {
        List<Pedido> GetAll();
        //bool UpdatePedido(int id);
        bool DeletePedido(int id);
        Pedido GetById(int id);
        Cliente GetCliente(int id);

    }
}
