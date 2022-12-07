namespace CadeteriaMVC.Models
{
    public class Cadete : Entity
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Cadeteria Cadeteria { get; set; }

    }
}
