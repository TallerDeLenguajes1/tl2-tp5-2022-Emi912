using CadeteriaMVC.Models;

public enum Estado
{
    EnCamino,
    Entregado,
    Cancelado
}
public class Pedido : Entity
{
    public string Observacion { get; set; }
    public Cliente Cliente { get; set; }
    public Estado Estado { get; set; }

    public Pedido(int id, string observacion, Cliente cliente)
    {
        this.Id = id;
        this.Estado = 0;
        this.Observacion = observacion;
        this.Cliente = cliente;
    }

    public Pedido()
    {

    }


}