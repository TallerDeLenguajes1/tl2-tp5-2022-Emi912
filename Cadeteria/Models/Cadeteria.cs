using CadeteriaMVC.Models;
using System;
using System.Collections.Generic;

namespace CadeteriaMVC.Models
{
    public class Cadeteria : Entity
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Cadeteria> ListadoCadetes { get; set; }

        public Cadeteria()
        {

        }
        public Cadeteria(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
        }




    }
}