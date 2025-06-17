using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con ventas y su detalle.
    /// </summary>
    public class VentasController
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor que inicializa la cadena de conexión desde el archivo de configuración.
        /// </summary>
        public VentasController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        /// <summary>
        /// Crea una venta junto con su detalle y actualiza el stock en StockReventas.
        /// Todo se ejecuta en una transacción para asegurar atomicidad.
        /// </summary>
        /// <param name="venta">Objeto Venta que contiene los datos de la venta y su detalle.</param>
        /// <returns>El ID de la venta creada o 0 si falla la operación.</returns>
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
                        // Insertar la venta y obtener el Id generado
                        using (SqlCommand cmdVenta = new SqlCommand("sp_InsertarVenta", con, tran))
                        {
                            cmdVenta.CommandType = CommandType.StoredProcedure;
                            cmdVenta.Parameters.AddWithValue("@Fecha", venta.Fecha);
                            cmdVenta.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);
                            cmdVenta.Parameters.AddWithValue("@UsuarioId", venta.UsuarioId);
                            cmdVenta.Parameters.AddWithValue("@ClienteId", (object)venta.ClienteId ?? DBNull.Value);

                            SqlParameter outputId = new SqlParameter("@VentaId", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmdVenta.Parameters.Add(outputId);

                            cmdVenta.ExecuteNonQuery();
                            int ventaId = (int)outputId.Value;

                            // Insertar detalles y descontar stock para cada producto
                            foreach (var detalle in venta.Detalle)
                            {
                                // Insertar detalle de venta (el SP sp_InsertarDetalleVenta ya inserta el movimiento de salida)
                                using (SqlCommand cmdDetalle = new SqlCommand("sp_InsertarDetalleVenta", con, tran))
                                {
                                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                                    cmdDetalle.Parameters.AddWithValue("@VentaId", ventaId);
                                    cmdDetalle.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                    cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                                    cmdDetalle.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                            return ventaId;
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        LogError(ex);
                        return 0;
                    }
                }
            }
        }


        /// <summary>
        /// Obtiene una venta y su detalle por ID.
        /// </summary>
        /// <param name="id">ID de la venta.</param>
        /// <returns>Objeto Venta con su detalle o null si no existe.</returns>
        public Venta ObtenerVentaConDetalle(int id)
        {
            Venta venta = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Obtener datos generales de la venta
                using (SqlCommand cmdVenta = new SqlCommand("sp_ObtenerVenta", con))
                {
                    cmdVenta.CommandType = CommandType.StoredProcedure;
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

                // Si se encontró la venta, cargar el detalle
                if (venta != null)
                {
                    using (SqlCommand cmdDetalle = new SqlCommand("sp_ObtenerDetalleVenta", con))
                    {
                        cmdDetalle.CommandType = CommandType.StoredProcedure;
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
        /// Obtiene todas las ventas sin cargar el detalle.
        /// </summary>
        /// <returns>Lista de ventas.</returns>
        public List<Venta> ObtenerVentas()
        {
            var listaVentas = new List<Venta>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ObtenerVentas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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
        /// Actualiza datos generales de una venta (sin detalle).
        /// </summary>
        /// <param name="venta">Objeto Venta a actualizar.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        public bool ActualizarVenta(Venta venta)
        {
            if (venta == null || !venta.EsValida() || venta.Id <= 0)
                return false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_ActualizarVenta", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", venta.Id);
                    cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);
                    cmd.Parameters.AddWithValue("@UsuarioId", venta.UsuarioId);
                    cmd.Parameters.AddWithValue("@ClienteId", (object)venta.ClienteId ?? DBNull.Value);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        /// <summary>
        /// Actualiza una venta y su detalle, eliminando el detalle previo y agregando el nuevo.
        /// Todo en una transacción.
        /// </summary>
        /// <param name="venta">Objeto Venta con los datos actualizados.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
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
                        // Actualizar encabezado de la venta
                        using (SqlCommand cmd = new SqlCommand("sp_ActualizarVenta", con, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", venta.Id);
                            cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                            cmd.Parameters.AddWithValue("@TotalVenta", venta.TotalVenta);
                            cmd.Parameters.AddWithValue("@UsuarioId", venta.UsuarioId);
                            cmd.Parameters.AddWithValue("@ClienteId", (object)venta.ClienteId ?? DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }

                        // Eliminar detalles anteriores
                        using (SqlCommand cmdDelete = new SqlCommand("sp_EliminarDetalleVenta", con, tran))
                        {
                            cmdDelete.CommandType = CommandType.StoredProcedure;
                            cmdDelete.Parameters.AddWithValue("@VentaId", venta.Id);
                            cmdDelete.ExecuteNonQuery();
                        }

                        // Insertar nuevos detalles
                        foreach (var detalle in venta.Detalle)
                        {
                            using (SqlCommand cmdDetalle = new SqlCommand("sp_InsertarDetalleVenta", con, tran))
                            {
                                cmdDetalle.CommandType = CommandType.StoredProcedure;
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
                        LogError(ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Elimina una venta y su detalle en una transacción.
        /// </summary>
        /// <param name="id">ID de la venta a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, false en caso contrario.</returns>
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
                        // Eliminar detalles de la venta
                        using (SqlCommand cmdDetalles = new SqlCommand("sp_EliminarDetalleVenta", con, tran))
                        {
                            cmdDetalles.CommandType = CommandType.StoredProcedure;
                            cmdDetalles.Parameters.AddWithValue("@VentaId", id);
                            cmdDetalles.ExecuteNonQuery();
                        }

                        // Eliminar la venta
                        using (SqlCommand cmdVenta = new SqlCommand("sp_EliminarVenta", con, tran))
                        {
                            cmdVenta.CommandType = CommandType.StoredProcedure;
                            cmdVenta.Parameters.AddWithValue("@Id", id);
                            int rows = cmdVenta.ExecuteNonQuery();

                            tran.Commit();
                            return rows > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        LogError(ex);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Método privado para registrar errores en un archivo de log.
        /// </summary>
        /// <param name="ex">Excepción capturada.</param>
        private void LogError(Exception ex)
        {
            PanaderoApp.Class.LogError.Registrar(ex);
        }
    }
}
