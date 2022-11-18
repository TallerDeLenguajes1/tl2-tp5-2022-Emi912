using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaMVC.Models
{
    public class Cadete : Entity
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Cadeteria Cadeteria { get; set; }

        public Cadete()
        {

        }

    }
}
