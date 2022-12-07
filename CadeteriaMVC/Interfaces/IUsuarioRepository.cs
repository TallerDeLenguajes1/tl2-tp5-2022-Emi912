using CadeteriaMVC.Models;

namespace CadeteriaMVC.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string user, string pass);

        bool Register(Usuario user);
    }
}
