using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    /// <summary>
    /// Controlador para operaciones CRUD sobre la tabla DetalleVenta.
    /// </summary>
    public class VentasFacController
    {
        // Cadena de conexión a la base de datos, obtenida desde App.config o Web.config
        private readonly string connectionString;

        public VentasFacController()
        {
            // Se obtiene la cadena de conexión desde el archivo de configuración
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        /// <summary>
        /// Inserta un nuevo registro en la tabla DetalleVenta.
        /// </summary>
        /// <param name="ventaFac">Objeto VentasFac con los datos a insertar.</param>
        /// <returns>True si la inserción fue exitosa; false en caso contrario.</returns>
        public bool Crear(VentasFac ventaFac)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario) 
                                 VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VentaId", ventaFac.VentaId);
                cmd.Parameters.AddWithValue("@ProductoId", ventaFac.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", ventaFac.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", ventaFac.PrecioUnitario);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0; // Devuelve true si al menos una fila fue insertada
            }
        }

        /// <summary>
        /// Obtiene todos los registros de la tabla DetalleVenta, incluyendo el nombre del producto desde la tabla Productos.
        /// </summary>
        /// <returns>Lista de objetos VentasFac.</returns>
        public List<VentasFac> ObtenerTodos()
        {
            List<VentasFac> lista = new List<VentasFac>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT dv.Id, dv.VentaId, dv.ProductoId, p.Nombre AS NombreProducto, 
                           dv.Cantidad, dv.PrecioUnitario
                    FROM DetalleVenta dv
                    INNER JOIN Productos p ON dv.ProductoId = p.Id";

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
                        NombreProducto = reader["NombreProducto"].ToString(),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"])
                    });
                }
            }

            return lista;
        }

        /// <summary>
        /// Actualiza un registro existente en la tabla DetalleVenta.
        /// </summary>
        /// <param name="ventaFac">Objeto VentasFac con los datos actualizados.</param>
        /// <returns>True si la actualización fue exitosa; false en caso contrario.</returns>
        public bool Actualizar(VentasFac ventaFac)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE DetalleVenta 
                                 SET VentaId = @VentaId, ProductoId = @ProductoId, Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario 
                                 WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VentaId", ventaFac.VentaId);
                cmd.Parameters.AddWithValue("@ProductoId", ventaFac.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", ventaFac.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", ventaFac.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Id", ventaFac.Id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0; // Devuelve true si al menos una fila fue modificada
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla DetalleVenta por su Id.
        /// </summary>
        /// <param name="id">Id del detalle de venta a eliminar.</param>
        /// <returns>True si se eliminó correctamente; false en caso contrario.</returns>
        public bool Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM DetalleVenta WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0; // Devuelve true si se eliminó una fila
            }
        }
    }
}
