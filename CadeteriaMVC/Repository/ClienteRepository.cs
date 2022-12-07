using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;
using Microsoft.Data.Sqlite;

namespace CadeteriaMVC.Repository
{
    public class ClienteRepository : IClientesRepository
    {

        private readonly string _connectionString;
        public ClienteRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");
        }

        public bool DeleteCliente(int id)
        {
            string query = $"DELETE FROM Clientes WHERE clienteID = {id}";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                int rw = command.ExecuteNonQuery();
                if (rw == 1)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = $"SELECT * FROM Clientes";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente nCliente = new Cliente()
                        {
                            Id = Convert.ToInt32(reader["clienteID"]),
                            Direccion = reader["clienteDireccion"].ToString(),
                            Nombre = reader["clienteNombre"].ToString(),
                            Telefono = reader["clienteTelefono"].ToString()

                        };
                        clientes.Add(nCliente);
                    }
                }
                conn.Close();

            }
            return clientes;
        }

        public Cliente GetById(int id)
        {
            Cliente cliente = new Cliente();
            string query = $"SELECT * FROM Clientes WHERE clienteID = {id}";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente.Id = Convert.ToInt32(reader["clienteID"]);
                        cliente.Direccion = reader["clienteDireccion"].ToString();
                        cliente.Nombre = reader["clienteNombre"].ToString();
                        cliente.Telefono = reader["clienteTelefono"].ToString();
                    }
                }

            }
            return cliente;
        }


    }
}
