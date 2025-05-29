using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    public class VentasFacController
    {

        private readonly string connectionString;
        public VentasFacController()
        {
            // Obtén la cadena de conexión desde el archivo de configuración
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }
        // Crear (Insertar)
        public bool Crear(VentasFac ventaFac)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario) " +
                               "VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VentaId", ventaFac.VentaId);
                cmd.Parameters.AddWithValue("@ProductoId", ventaFac.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", ventaFac.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", ventaFac.PrecioUnitario);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Leer (Obtener todos)
        public List<VentasFac> ObtenerTodos()
        {
            List<VentasFac> lista = new List<VentasFac>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, VentaId, ProductoId, Cantidad, PrecioUnitario FROM DetalleVenta";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new VentasFac
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        VentaId = Convert.ToInt32(reader["VentaId"]),
                        ProductoId = Convert.ToInt32(reader["ProductoId"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"])
                    });
                }
            }
            return lista;
        }

        // Actualizar
        public bool Actualizar(VentasFac ventaFac)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE DetalleVenta SET VentaId=@VentaId, ProductoId=@ProductoId, Cantidad=@Cantidad, PrecioUnitario=@PrecioUnitario " +
                               "WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VentaId", ventaFac.VentaId);
                cmd.Parameters.AddWithValue("@ProductoId", ventaFac.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", ventaFac.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", ventaFac.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Id", ventaFac.Id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Eliminar
        public bool Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM DetalleVenta WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
