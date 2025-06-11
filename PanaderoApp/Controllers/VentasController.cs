using PanaderoApp.Models;                // Referencia a los modelos del sistema
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    /// <summary>
    /// Controlador que gestiona las operaciones CRUD (Crear, Leer, Actualizar, Eliminar)
    /// relacionadas con las ventas y sus detalles.
    /// </summary>
    public class VentasController
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor que obtiene la cadena de conexión desde el archivo de configuración.
        /// </summary>
        public VentasController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        /// <summary>
        /// Crea una nueva venta con sus productos (detalle), usando una transacción para asegurar consistencia.
        /// </summary>
        /// <param name="venta">Venta con información general y lista de productos.</param>
        /// <returns>ID de la venta creada, o 0 si hubo error.</returns>
        public int CrearVentaConDetalle(Venta venta)
        {
            if (venta == null || venta.Detalle == null || venta.Detalle.Count == 0 || !venta.EsValida())
                return 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        // Insertar venta en tabla Ventas y obtener su ID generado
                        string queryVenta = @"
                            INSERT INTO Ventas (Fecha, TotalVenta, UsuarioId, ClienteId) 
                            VALUES (@Fecha, @TotalVenta, @UsuarioId, @ClienteId);
                            SELECT CAST(SCOPE_IDENTITY() AS int);";

                        int ventaId;
                        using (SqlCommand cmdVenta = new SqlCommand(queryVenta, con, tran))
                        {
                            cmdVenta.Parameters.AddWithValue("@Fecha", venta.Fecha);
                            cmdVenta.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);
                            cmdVenta.Parameters.AddWithValue("@UsuarioId", venta.UsuarioId);
                            cmdVenta.Parameters.AddWithValue("@ClienteId", venta.ClienteId.HasValue ?
                                (object)venta.ClienteId.Value : DBNull.Value);

                            ventaId = (int)cmdVenta.ExecuteScalar();
                        }

                        // Insertar cada detalle (producto vendido)
                        string queryDetalle = @"
                            INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario) 
                            VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario)";

                        foreach (var detalle in venta.Detalle)
                        {
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, con, tran))
                            {
                                cmdDetalle.Parameters.AddWithValue("@VentaId", ventaId);
                                cmdDetalle.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // Confirmar transacción
                        tran.Commit();
                        return ventaId;
                    }
                    catch (Exception ex)
                    {
                        // Revertir si hubo error
                        tran.Rollback();
                        System.Windows.Forms.MessageBox.Show("Error al guardar venta:\n" + ex.Message);
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene una venta específica junto con sus productos vendidos (detalle).
        /// </summary>
        /// <param name="id">ID de la venta.</param>
        /// <returns>Objeto Venta con información general y detalles.</returns>
        public Venta ObtenerVentaConDetalle(int id)
        {
            Venta venta = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Obtener la venta general
                string queryVenta = "SELECT * FROM Ventas WHERE Id = @Id";
                using (SqlCommand cmdVenta = new SqlCommand(queryVenta, con))
                {
                    cmdVenta.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader readerVenta = cmdVenta.ExecuteReader())
                    {
                        if (readerVenta.Read())
                        {
                            venta = new Venta
                            {
                                Id = (int)readerVenta["Id"],
                                Fecha = (DateTime)readerVenta["Fecha"],
                                TotalVenta = (decimal)readerVenta["TotalVenta"],
                                UsuarioId = (int)readerVenta["UsuarioId"],
                                ClienteId = readerVenta["ClienteId"] == DBNull.Value ?
                                    (int?)null : (int)readerVenta["ClienteId"],
                                Detalle = new List<VentasImpresion>()
                            };
                        }
                    }
                }

                // Obtener productos de la venta si existe
                if (venta != null)
                {
                    string queryDetalle = @"
                        SELECT dv.ProductoId, dv.Cantidad, dv.PrecioUnitario, p.Nombre AS NombreProducto
                        FROM DetalleVenta dv
                        INNER JOIN Productos p ON dv.ProductoId = p.Id
                        WHERE dv.VentaId = @VentaId";

                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, con))
                    {
                        cmdDetalle.Parameters.AddWithValue("@VentaId", venta.Id);

                        using (SqlDataReader readerDetalle = cmdDetalle.ExecuteReader())
                        {
                            while (readerDetalle.Read())
                            {
                                venta.Detalle.Add(new VentasImpresion
                                {
                                    ProductoId = (int)readerDetalle["ProductoId"],
                                    Cantidad = (int)readerDetalle["Cantidad"],
                                    PrecioUnitario = (decimal)readerDetalle["PrecioUnitario"],
                                    NombreProducto = readerDetalle["NombreProducto"].ToString()
                                });
                            }
                        }
                    }
                }
            }

            return venta;
        }

        /// <summary>
        /// Obtiene todas las ventas (solo encabezados, sin detalle).
        /// </summary>
        /// <returns>Lista de ventas.</returns>
        public List<Venta> ObtenerVentas()
        {
            var listaVentas = new List<Venta>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ventas ORDER BY Fecha DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaVentas.Add(new Venta
                            {
                                Id = (int)reader["Id"],
                                Fecha = (DateTime)reader["Fecha"],
                                TotalVenta = (decimal)reader["TotalVenta"],
                                UsuarioId = (int)reader["UsuarioId"],
                                ClienteId = reader["ClienteId"] == DBNull.Value ? (int?)null : (int)reader["ClienteId"],
                                Detalle = null
                            });
                        }
                    }
                }
            }

            return listaVentas;
        }

        /// <summary>
        /// Actualiza los datos principales de una venta (sin tocar los productos).
        /// </summary>
        /// <param name="venta">Venta modificada.</param>
        /// <returns>True si se actualizó correctamente.</returns>
        public bool ActualizarVenta(Venta venta)
        {
            if (venta == null || !venta.EsValida() || venta.Id <= 0)
                return false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Ventas SET 
                        Fecha = @Fecha,
                        TotalVenta = @TotalVenta,
                        UsuarioId = @UsuarioId,
                        ClienteId = @ClienteId
                    WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);
                    cmd.Parameters.AddWithValue("@UsuarioId", venta.UsuarioId);
                    cmd.Parameters.AddWithValue("@ClienteId", venta.ClienteId.HasValue ?
                        (object)venta.ClienteId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", venta.Id);

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Actualiza una venta completa, incluyendo sus productos (detalle). Usa transacción.
        /// </summary>
        /// <param name="venta">Venta con detalle actualizado.</param>
        /// <returns>True si se actualizó correctamente.</returns>
        public bool ActualizarVentaConDetalle(Venta venta)
        {
            if (venta == null || !venta.EsValida() || venta.Id <= 0)
                return false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        // Actualiza encabezado de la venta
                        string queryUpdateVenta = @"
                            UPDATE Ventas SET 
                                Fecha = @Fecha,
                                TotalVenta = @TotalVenta,
                                UsuarioId = @UsuarioId,
                                ClienteId = @ClienteId
                            WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(queryUpdateVenta, con, tran))
                        {
                            cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                            cmd.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);
                            cmd.Parameters.AddWithValue("@UsuarioId", venta.UsuarioId);
                            cmd.Parameters.AddWithValue("@ClienteId", venta.ClienteId.HasValue ?
                                (object)venta.ClienteId.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@Id", venta.Id);
                            cmd.ExecuteNonQuery();
                        }

                        // Borra detalles anteriores
                        string deleteQuery = "DELETE FROM DetalleVenta WHERE VentaId = @VentaId";
                        using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, con, tran))
                        {
                            cmdDelete.Parameters.AddWithValue("@VentaId", venta.Id);
                            cmdDelete.ExecuteNonQuery();
                        }

                        // Inserta nuevos detalles
                        string insertDetalle = @"
                            INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario) 
                            VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario)";

                        foreach (var detalle in venta.Detalle)
                        {
                            using (SqlCommand cmdDetalle = new SqlCommand(insertDetalle, con, tran))
                            {
                                cmdDetalle.Parameters.AddWithValue("@VentaId", venta.Id);
                                cmdDetalle.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        System.Windows.Forms.MessageBox.Show("Error al actualizar venta:\n" + ex.Message);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Elimina una venta junto con todos sus productos vendidos (detalle), de forma transaccional.
        /// </summary>
        /// <param name="id">ID de la venta a eliminar.</param>
        /// <returns>True si se eliminó correctamente.</returns>
        public bool EliminarVenta(int id)
        {
            if (id <= 0)
                return false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        // Eliminar detalles primero
                        string deleteDetalles = "DELETE FROM DetalleVenta WHERE VentaId = @VentaId";
                        using (SqlCommand cmdDetalles = new SqlCommand(deleteDetalles, con, tran))
                        {
                            cmdDetalles.Parameters.AddWithValue("@VentaId", id);
                            cmdDetalles.ExecuteNonQuery();
                        }

                        // Luego eliminar la venta principal
                        string deleteVenta = "DELETE FROM Ventas WHERE Id = @Id";
                        using (SqlCommand cmdVenta = new SqlCommand(deleteVenta, con, tran))
                        {
                            cmdVenta.Parameters.AddWithValue("@Id", id);
                            int rows = cmdVenta.ExecuteNonQuery();

                            tran.Commit();
                            return rows > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        System.Windows.Forms.MessageBox.Show("Error al eliminar venta:\n" + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
