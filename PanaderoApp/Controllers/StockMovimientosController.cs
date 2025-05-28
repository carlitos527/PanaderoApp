using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PanaderoApp.Models;

namespace PanaderoApp.Controllers
{

        public class StockMovimientosController
        {
        private readonly string connectionString;
        public StockMovimientosController()
        {
            // Obtén la cadena de conexión desde el archivo de configuración
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }
        // Crear nuevo movimiento de stock
        public void CrearMovimiento(StockMovimiento movimiento)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO StockMovimientos (IngredienteId, TipoMovimiento, Cantidad, Fecha, Comentario)
                                 VALUES (@IngredienteId, @TipoMovimiento, @Cantidad, @Fecha, @Comentario)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@IngredienteId", movimiento.IngredienteId);
                    cmd.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                    cmd.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                    cmd.Parameters.AddWithValue("@Comentario", (object)movimiento.Comentario ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        // Obtener todos los movimientos de stock
        public List<StockMovimiento> ObtenerMovimientos()
        {
            List<StockMovimiento> lista = new List<StockMovimiento>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Hacemos INNER JOIN con Ingredientes para traer el nombre
                string query = @"
            SELECT sm.Id, sm.IngredienteId, sm.TipoMovimiento, sm.Cantidad, sm.Fecha, sm.Comentario, i.Nombre AS IngredienteNombre
            FROM StockMovimientos sm
            INNER JOIN Ingredientes i ON sm.IngredienteId = i.Id
            ORDER BY sm.Fecha DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StockMovimiento mov = new StockMovimiento
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IngredienteId = Convert.ToInt32(reader["IngredienteId"]),
                            TipoMovimiento = reader["TipoMovimiento"].ToString(),
                            Cantidad = Convert.ToDecimal(reader["Cantidad"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Comentario = reader["Comentario"] != DBNull.Value ? reader["Comentario"].ToString() : null,
                            IngredienteNombre = reader["IngredienteNombre"].ToString()
                        };
                        lista.Add(mov);
                    }
                }
            }
            return lista;
        }

        // Actualizar movimiento
        public void ActualizarMovimiento(StockMovimiento movimiento)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE StockMovimientos 
                                 SET IngredienteId = @IngredienteId, TipoMovimiento = @TipoMovimiento, Cantidad = @Cantidad, Fecha = @Fecha, Comentario = @Comentario
                                 WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@IngredienteId", movimiento.IngredienteId);
                    cmd.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                    cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                    cmd.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                    cmd.Parameters.AddWithValue("@Comentario", (object)movimiento.Comentario ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", movimiento.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Eliminar movimiento por Id
            public void EliminarMovimiento(int id)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM StockMovimientos WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Obtener movimiento por Id
            public StockMovimiento ObtenerMovimientoPorId(int id)
            {
                StockMovimiento movimiento = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, IngredienteId, TipoMovimiento, Cantidad, Fecha, Comentario FROM StockMovimientos WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            movimiento = new StockMovimiento
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IngredienteId = Convert.ToInt32(reader["IngredienteId"]),
                                TipoMovimiento = reader["TipoMovimiento"].ToString(),
                                Cantidad = Convert.ToDecimal(reader["Cantidad"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Comentario = reader["Comentario"] != DBNull.Value ? reader["Comentario"].ToString() : null
                            };
                        }
                    }
                }

                return movimiento;
            }

        public List<StockActualDto> ObtenerStockActual()
        {
            List<StockActualDto> lista = new List<StockActualDto>();

            string query = @"
        SELECT 
            i.Id AS IngredienteId,
            i.Nombre AS IngredienteNombre,
            ISNULL(SUM(CASE WHEN sm.TipoMovimiento = 'Entrada' THEN sm.Cantidad ELSE 0 END), 0) -
            ISNULL(SUM(CASE WHEN sm.TipoMovimiento = 'Salida' THEN sm.Cantidad ELSE 0 END), 0) AS StockActual
        FROM Ingredientes i
        LEFT JOIN StockMovimientos sm ON i.Id = sm.IngredienteId
        GROUP BY i.Id, i.Nombre";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new StockActualDto
                        {
                            IngredienteId = Convert.ToInt32(reader["IngredienteId"]),
                            IngredienteNombre = reader["IngredienteNombre"].ToString(),
                            StockActual = Convert.ToDecimal(reader["StockActual"])
                        });
                    }
                }
            }
            return lista;
        }

    }


}
