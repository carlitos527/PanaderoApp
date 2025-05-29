using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration; // Para leer la cadena de conexión
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PanaderoApp.Controllers
{
    public class ProductosController
    {
        private readonly string connectionString;

        public ProductosController()
        {
            // Leer la cadena de conexión desde App.config o Web.config
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        // Crear - Agregar un nuevo producto
        public void AgregarProducto(string nombre, decimal precioVenta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Productos (Nombre, PrecioVenta) VALUES (@Nombre, @PrecioVenta)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@PrecioVenta", precioVenta);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Producto agregado exitosamente." : "Error al agregar producto.");
            }
        }

        // Leer - Obtener todos los productos
        public List<Productos> ObtenerTodos()
        {
            var lista = new List<Productos>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Nombre, PrecioVenta FROM Productos";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Productos
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        PrecioVenta = reader.GetDecimal(2)
                    });
                }
            }

            return lista;
        }

        // Leer - Obtener producto por Id
        public Productos ObtenerPorId(int id)
        {
            Productos producto = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT Id, Nombre, PrecioVenta FROM Productos WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    producto = new Productos
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        PrecioVenta = reader.GetDecimal(2)
                    };
                }
            }

            return producto;
        }

        // Actualizar producto
        public bool ActualizarProducto(int id, string nuevoNombre, decimal nuevoPrecio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Productos SET Nombre = @Nombre, PrecioVenta = @PrecioVenta WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                cmd.Parameters.AddWithValue("@PrecioVenta", nuevoPrecio);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Eliminar producto
        public bool EliminarProducto(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Productos WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
