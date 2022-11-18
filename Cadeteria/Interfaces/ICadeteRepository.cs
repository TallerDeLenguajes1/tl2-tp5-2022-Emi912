using CadeteriaMVC.Models;
using System.Collections.Generic;

namespace CadeteriaMVC.Interfaces
{
    public interface ICadeteRepository
    {
        List<Cadete> GetAll();
        bool DeleteCadete(int id);
        Cadete GetById(int id);

        Cadeteria GetCadeteria(int id);
    }
}
