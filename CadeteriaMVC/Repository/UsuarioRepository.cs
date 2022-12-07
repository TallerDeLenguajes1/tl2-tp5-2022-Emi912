using CadeteriaMVC.Helpers;
using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;
using Microsoft.Data.Sqlite;

namespace CadeteriaMVC.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;
        public UsuarioRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");
        }
        public Usuario Login(string user, string password)
        {
            string query = $"SELECT * FROM Usuarios WHERE usuario = '{user}' AND password = '{EncryptHelper.Encrypt(password)}'";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand comm = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario Usuariolog = new Usuario()
                        {
                            Nombre = user,
                            Rol = (Rol)Convert.ToInt32(reader["rol"]),
                            Id = Convert.ToInt32(reader["id_usuario"]),
                            Password = password
                        };
                        return Usuariolog;
                    }
                }
            }
            return null;
        }

        public bool Register(Usuario user)
        {
            string query = $"INSERT INTO Usuarios('usuario', 'password', 'rol') VALUES('{user.Nombre}', '{EncryptHelper.Encrypt(user.Password)}', '{Convert.ToInt32(user.Rol)}')";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand comm = new SqliteCommand(query, conn);
                int rw = comm.ExecuteNonQuery();
                if (rw == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

     
    }
}
