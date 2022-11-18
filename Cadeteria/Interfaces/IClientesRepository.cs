using CadeteriaMVC.Models;
using System.Collections.Generic;

namespace CadeteriaMVC.Interfaces
{
    public interface IClientesRepository
    {
        List<Cliente> GetAll();
        //bool UpdateCliente(int id);
        bool DeleteCliente(int id);
        Cliente GetById(int id);
    }
}
