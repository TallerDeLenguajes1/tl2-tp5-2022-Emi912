using CadeteriaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class Usuario : Entity
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
