using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    public class RecetasController
    {
        private readonly string connectionString;

        public RecetasController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        // Crear (Agregar receta)
        public void AgregarReceta(int productoId, int ingredienteId, decimal cantidad)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Recetas (ProductoId, IngredienteId, Cantidad) VALUES (@ProductoId, @IngredienteId, @Cantidad)", conn))
            {
                cmd.Parameters.AddWithValue("@ProductoId", productoId);
                cmd.Parameters.AddWithValue("@IngredienteId", ingredienteId);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Leer todas las recetas
        public List<Recetas> ObtenerTodas()
        {
            var lista = new List<Recetas>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT r.Id, r.ProductoId, p.Nombre AS NombreProducto, 
                         r.IngredienteId, i.Nombre AS NombreIngrediente, i.Unidad AS UnidadIngrediente,
                         r.Cantidad
                  FROM Recetas r
                  INNER JOIN Productos p ON r.ProductoId = p.Id
                  INNER JOIN Ingredientes i ON r.IngredienteId = i.Id", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Recetas
                        {
                            Id = reader.GetInt32(0),
                            ProductoId = reader.GetInt32(1),
                            NombreProducto = reader.GetString(2),
                            IngredienteId = reader.GetInt32(3),
                            NombreIngrediente = reader.GetString(4),
                            UnidadIngrediente = reader.GetString(5),
                            Cantidad = reader.GetDecimal(6)
                        });
                    }
                }
            }

            return lista;
        }

        // Leer receta por Id
        public Recetas ObtenerPorId(int id)
        {
            Recetas receta = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT r.Id, r.ProductoId, p.Nombre AS NombreProducto, 
                         r.IngredienteId, i.Nombre AS NombreIngrediente, i.Unidad AS UnidadIngrediente,
                         r.Cantidad
                  FROM Recetas r
                  INNER JOIN Productos p ON r.ProductoId = p.Id
                  INNER JOIN Ingredientes i ON r.IngredienteId = i.Id
                  WHERE r.Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        receta = new Recetas
                        {
                            Id = reader.GetInt32(0),
                            ProductoId = reader.GetInt32(1),
                            NombreProducto = reader.GetString(2),
                            IngredienteId = reader.GetInt32(3),
                            NombreIngrediente = reader.GetString(4),
                            UnidadIngrediente = reader.GetString(5),
                            Cantidad = reader.GetDecimal(6)
                        };
                    }
                }
            }

            return receta;
        }

        // Actualizar receta
        public bool ActualizarReceta(int id, int productoId, int ingredienteId, decimal cantidad)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Recetas SET ProductoId = @ProductoId, IngredienteId = @IngredienteId, Cantidad = @Cantidad WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@ProductoId", productoId);
                cmd.Parameters.AddWithValue("@IngredienteId", ingredienteId);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        // Eliminar receta
        public bool EliminarReceta(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Recetas WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}
