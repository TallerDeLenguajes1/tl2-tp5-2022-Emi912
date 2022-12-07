using CadeteriaMVC.Models;

public class Cadeteria : Entity
{
    public string Nombre { get; set; }
    public List<Cadeteria> ListadoCadetes { get; set; }

    public Cadeteria()
    {

    }
    public Cadeteria(string nombre, string direccion)
    {
        this.Nombre = nombre;
    }




}