using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;
using Microsoft.Data.Sqlite;

namespace CadeteriaMVC.Repository
{
    public class PedidoRepository : IPedidosRepository
    {
        private readonly string _connectionString;
        public PedidoRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");
        }
        public bool DeletePedido(int id)
        {
            string query = $"DELETE FROM Pedidos WHERE pedidoID = {id}";
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

        public List<Pedido> GetAll()
        {
            List<Pedido> pedidos = new List<Pedido>();
            string query = $"SELECT * FROM Pedidos";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pedido nPedido = new Pedido()
                        {
                            Id = Convert.ToInt32(reader["pedidoID"]),
                            Observacion = reader["pedidoObs"].ToString(),
                            Estado = (Estado)Convert.ToInt32(reader["pedidoEstado"]),
                            Cliente = GetCliente(Convert.ToInt32(reader["clienteId"]))

                        };
                        pedidos.Add(nPedido);
                    }
                }
                conn.Close();

            }
            return pedidos;
        }

        public Pedido GetById(int id)
        {
            Pedido pedido = new Pedido();
            string query = $"SELECT * FROM Pedidos WHERE pedidoID = {id}";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pedido.Id = Convert.ToInt32(reader["pedidoID"]);
                        pedido.Observacion = reader["pedidoObs"].ToString();
                        pedido.Estado = (Estado)Convert.ToInt32(reader["pedidoEstado"]);
                        pedido.Cliente = GetCliente(Convert.ToInt32(reader["clienteId"]));
                    }
                }

            }
            return pedido;
        }

        public Cliente GetCliente(int id)
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
