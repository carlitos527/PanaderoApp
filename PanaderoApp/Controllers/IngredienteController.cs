using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Controllers
{
    public class IngredienteController
    {
        private readonly string connectionString;
        public IngredienteController()
        {
            // Obtén la cadena de conexión desde el archivo de configuración
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }
        public void CrearIngrediente(Ingrediente ingrediente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ingredientes (Nombre, Unidad, PrecioUnitario) VALUES (@Nombre, @Unidad, @PrecioUnitario)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", ingrediente.Nombre);
                cmd.Parameters.AddWithValue("@Unidad", ingrediente.Unidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", ingrediente.PrecioUnitario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Ingrediente> ObtenerIngredientes()
        {
            List<Ingrediente> lista = new List<Ingrediente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, Unidad, PrecioUnitario FROM Ingredientes";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Ingrediente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Unidad = reader["Unidad"].ToString(),
                            PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"])
                        });
                    }
                }
            }

            return lista;
        }

        public void ActualizarIngrediente(Ingrediente ingrediente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ingredientes SET Nombre = @Nombre, Unidad = @Unidad, PrecioUnitario = @PrecioUnitario WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", ingrediente.Nombre);
                cmd.Parameters.AddWithValue("@Unidad", ingrediente.Unidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", ingrediente.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Id", ingrediente.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarIngrediente(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ingredientes WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
