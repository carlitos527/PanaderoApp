using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    public class VentasController
    {
        private readonly string connectionString;

        public VentasController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        // Crear venta con detalle en una transacción
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
                        string queryVenta = @"INSERT INTO Ventas (Fecha, TotalVenta, UsuarioId, ClienteId) 
                                      VALUES (@Fecha, @TotalVenta, @UsuarioId, @ClienteId);
                                      SELECT CAST(SCOPE_IDENTITY() AS int);";

                        int ventaId;

                        using (SqlCommand cmdVenta = new SqlCommand(queryVenta, con, tran))
                        {
                            cmdVenta.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = venta.Fecha;
                            cmdVenta.Parameters.Add("@TotalVenta", System.Data.SqlDbType.Decimal).Value = venta.TotalVenta;
                            cmdVenta.Parameters.Add("@UsuarioId", System.Data.SqlDbType.Int).Value = venta.UsuarioId;

                            if (venta.ClienteId.HasValue)
                                cmdVenta.Parameters.Add("@ClienteId", System.Data.SqlDbType.Int).Value = venta.ClienteId.Value;
                            else
                                cmdVenta.Parameters.Add("@ClienteId", System.Data.SqlDbType.Int).Value = DBNull.Value;

                            ventaId = (int)cmdVenta.ExecuteScalar();
                        }

                        string queryDetalle = @"INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario) 
                                        VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario)";

                        foreach (var detalle in venta.Detalle)
                        {
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, con, tran))
                            {
                                cmdDetalle.Parameters.Add("@VentaId", System.Data.SqlDbType.Int).Value = ventaId;
                                cmdDetalle.Parameters.Add("@ProductoId", System.Data.SqlDbType.Int).Value = detalle.ProductoId;
                                cmdDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = detalle.Cantidad;
                                cmdDetalle.Parameters.Add("@PrecioUnitario", System.Data.SqlDbType.Decimal).Value = detalle.PrecioUnitario;

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return ventaId;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        System.Windows.Forms.MessageBox.Show("Error al guardar venta:\n" + ex.Message);
                        return 0;
                    }
                }
            }
        }


        // Obtener venta con detalles
        public Venta ObtenerVentaConDetalle(int id)
        {
            Venta venta = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 1. Obtener la venta principal
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
                                ClienteId = readerVenta["ClienteId"] == DBNull.Value ? (int?)null : (int)readerVenta["ClienteId"],
                                Detalle = new List<VentasImpresion>()
                            };
                        }
                    }
                }

                // 2. Si la venta existe, obtener sus detalles con nombre del producto
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
                                var detalle = new VentasImpresion
                                {
                                    ProductoId = (int)readerDetalle["ProductoId"],
                                    Cantidad = (int)readerDetalle["Cantidad"],
                                    PrecioUnitario = (decimal)readerDetalle["PrecioUnitario"],
                                    NombreProducto = readerDetalle["NombreProducto"].ToString()
                                };
                                venta.Detalle.Add(detalle);
                            }
                        }
                    }
                }
            }

            return venta;
        }


        // Obtener todas las ventas (sin detalle)
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
                            var venta = new Venta
                            {
                                Id = (int)reader["Id"],
                                Fecha = (DateTime)reader["Fecha"],
                                TotalVenta = (decimal)reader["TotalVenta"],
                                UsuarioId = (int)reader["UsuarioId"],
                                ClienteId = reader["ClienteId"] == DBNull.Value ? (int?)null : (int)reader["ClienteId"],
                                Detalle = null
                            };
                            listaVentas.Add(venta);
                        }
                    }
                }
            }

            return listaVentas;
        }

        // Actualizar venta general (solo datos principales, no detalle)
        public bool ActualizarVenta(Venta venta)
        {
            if (venta == null || !venta.EsValida() || venta.Id <= 0)
                return false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Ventas SET 
                                 Fecha = @Fecha,
                                 TotalVenta = @TotalVenta,
                                 UsuarioId = @UsuarioId,
                                 ClienteId = @ClienteId
                                 WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = venta.Fecha;
                    cmd.Parameters.Add("@TotalVenta", System.Data.SqlDbType.Decimal).Value = venta.TotalVenta;
                    cmd.Parameters.Add("@UsuarioId", System.Data.SqlDbType.Int).Value = venta.UsuarioId;

                    if (venta.ClienteId.HasValue)
                        cmd.Parameters.Add("@ClienteId", System.Data.SqlDbType.Int).Value = venta.ClienteId.Value;
                    else
                        cmd.Parameters.Add("@ClienteId", System.Data.SqlDbType.Int).Value = DBNull.Value;

                    cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = venta.Id;

                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Actualizar venta con detalles (transaccional)
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
                        string queryUpdateVenta = @"UPDATE Ventas SET 
                                                     Fecha = @Fecha,
                                                     TotalVenta = @TotalVenta,
                                                     UsuarioId = @UsuarioId,
                                                     ClienteId = @ClienteId
                                                     WHERE Id = @Id";

                        using (SqlCommand cmdUpdateVenta = new SqlCommand(queryUpdateVenta, con, tran))
                        {
                            cmdUpdateVenta.Parameters.Add("@Fecha", System.Data.SqlDbType.DateTime).Value = venta.Fecha;
                            cmdUpdateVenta.Parameters.Add("@TotalVenta", System.Data.SqlDbType.Decimal).Value = venta.TotalVenta;
                            cmdUpdateVenta.Parameters.Add("@UsuarioId", System.Data.SqlDbType.Int).Value = venta.UsuarioId;

                            if (venta.ClienteId.HasValue)
                                cmdUpdateVenta.Parameters.Add("@ClienteId", System.Data.SqlDbType.Int).Value = venta.ClienteId.Value;
                            else
                                cmdUpdateVenta.Parameters.Add("@ClienteId", System.Data.SqlDbType.Int).Value = DBNull.Value;

                            cmdUpdateVenta.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = venta.Id;

                            cmdUpdateVenta.ExecuteNonQuery();
                        }

                        string queryDeleteDetalles = "DELETE FROM DetalleVenta WHERE VentaId = @VentaId";
                        using (SqlCommand cmdDeleteDetalles = new SqlCommand(queryDeleteDetalles, con, tran))
                        {
                            cmdDeleteDetalles.Parameters.Add("@VentaId", System.Data.SqlDbType.Int).Value = venta.Id;
                            cmdDeleteDetalles.ExecuteNonQuery();
                        }

                        string queryInsertDetalle = @"INSERT INTO DetalleVenta (VentaId, ProductoId, Cantidad, PrecioUnitario) 
                                                     VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario)";
                        foreach (var detalle in venta.Detalle)
                        {
                            using (SqlCommand cmdInsertDetalle = new SqlCommand(queryInsertDetalle, con, tran))
                            {
                                cmdInsertDetalle.Parameters.Add("@VentaId", System.Data.SqlDbType.Int).Value = venta.Id;
                                cmdInsertDetalle.Parameters.Add("@ProductoId", System.Data.SqlDbType.Int).Value = detalle.ProductoId;
                                cmdInsertDetalle.Parameters.Add("@Cantidad", System.Data.SqlDbType.Int).Value = detalle.Cantidad;
                                cmdInsertDetalle.Parameters.Add("@PrecioUnitario", System.Data.SqlDbType.Decimal).Value = detalle.PrecioUnitario;

                                cmdInsertDetalle.ExecuteNonQuery();
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

        // Eliminar venta y detalles en transacción
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
                        string queryEliminarDetalles = "DELETE FROM DetalleVenta WHERE VentaId = @VentaId";
                        using (SqlCommand cmdDetalles = new SqlCommand(queryEliminarDetalles, con, tran))
                        {
                            cmdDetalles.Parameters.Add("@VentaId", System.Data.SqlDbType.Int).Value = id;
                            cmdDetalles.ExecuteNonQuery();
                        }

                        string queryEliminarVenta = "DELETE FROM Ventas WHERE Id = @Id";
                        using (SqlCommand cmdVenta = new SqlCommand(queryEliminarVenta, con, tran))
                        {
                            cmdVenta.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
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
