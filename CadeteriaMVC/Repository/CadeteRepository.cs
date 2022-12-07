using CadeteriaMVC.Interfaces;
using CadeteriaMVC.Models;
using Microsoft.Data.Sqlite;

namespace CadeteriaMVC.Repository
{
    public class CadeteRepository : ICadeteRepository
    {
        private readonly string _connectionString;
        public CadeteRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default");
        }

        public bool DeleteCadete(int id)
        {
            string query = $"DELETE FROM Cadetes WHERE cadeteID = {id}";
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

        public List<Cadete> GetAll()
        {
            List<Cadete> cadetes = new List<Cadete>();
            string query = $"SELECT * FROM Cadetes";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cadete nCadete = new Cadete()
                        {
                            Id = Convert.ToInt32(reader["cadeteID"]),
                            Direccion = reader["cadeteDireccion"].ToString(),
                            Nombre = reader["cadeteNombre"].ToString(),
                            Telefono = reader["cadeteTelefono"].ToString(),
                            Cadeteria = GetCadeteria(Convert.ToInt32(reader["cadeteriaId"]))

                        };
                        cadetes.Add(nCadete);
                    }
                }
                conn.Close();

            }
            return cadetes;
        }

        public Cadete GetById(int id)
        {
            Cadete cadete = new Cadete();
            string query = $"SELECT * FROM Cadetes WHERE cadeteID = {id}";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cadete.Id = Convert.ToInt32(reader["cadeteID"]);
                        cadete.Direccion = reader["cadeteDireccion"].ToString();
                        cadete.Nombre = reader["cadeteNombre"].ToString();
                        cadete.Telefono = reader["cadeteTelefono"].ToString();
                        cadete.Cadeteria = GetCadeteria(Convert.ToInt32(reader["cadeteriaId"]));
                    }
                }

            }
            return cadete;
        }

        public Cadeteria GetCadeteria(int id)
        {
            Cadeteria cadeteria = new Cadeteria();
            string query = $"SELECT * FROM Cadeteria WHERE cadeteriaID = {id}";
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                SqliteCommand command = new SqliteCommand(query, conn);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cadeteria.Id = Convert.ToInt32(reader["clienteID"]);
                        cadeteria.Nombre = reader["clienteNombre"].ToString();
                    }
                }

            }
            return cadeteria;
        }



    }
}
