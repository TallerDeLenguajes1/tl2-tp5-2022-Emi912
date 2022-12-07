using System.ComponentModel.DataAnnotations;


public enum Rol
{
    Administrador,
    Cadete


}
namespace CadeteriaMVC.Models
{
    public class Usuario : Entity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]

        public string Password { get; set; }
        public Rol Rol { get; set; }


    }
}
