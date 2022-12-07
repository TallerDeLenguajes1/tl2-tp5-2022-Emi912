using System.ComponentModel.DataAnnotations;

namespace CadeteriaMVC.Models.ViewModels
{
    public class PedidoViewModel
    {
        [Required(ErrorMessage ="Este campo es requerido")]
        public int Nro { get; set; }
        [Required]
        public string Observacion { get; set; }
        [Required]
        public string Nombre_Cliente { get; set; }
        [Required]
        public Estado Estado { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

    }
}
