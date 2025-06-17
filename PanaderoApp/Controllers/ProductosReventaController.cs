using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using PanaderoApp.Models;  // Importar el modelo Productos

namespace PanaderoApp.Controllers
{
    internal class ProductosReventaController
    {
        private readonly string connectionString;

        public ProductosReventaController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        // CRUD Productos

        public List<Productos> ObtenerProductos()
        {
            var productos = new List<Productos>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, PrecioVenta FROM Productos";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Productos
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            PrecioVenta = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return productos;
        }

        public void CrearProducto(Productos producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Productos (Nombre, PrecioVenta) VALUES (@Nombre, @PrecioVenta)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarProducto(Productos producto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Productos SET Nombre = @Nombre, PrecioVenta = @PrecioVenta WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", producto.Id);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Productos WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Movimientos StockReventa

        public List<StockReventa> ObtenerMovimientosStock(int productoId)
        {
            var movimientos = new List<StockReventa>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, ProductoId, TipoMovimiento, Cantidad, Fecha, FechaVencimiento, Comentario 
                                 FROM StockReventa 
                                 WHERE ProductoId = @ProductoId 
                                 ORDER BY Fecha DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductoId", productoId);
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movimientos.Add(new StockReventa
                        {
                            Id = reader.GetInt32(0),
                            ProductoId = reader.GetInt32(1),
                            TipoMovimiento = reader.GetString(2),
                            Cantidad = reader.GetDecimal(3),
                            Fecha = reader.GetDateTime(4),
                            FechaVencimiento = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                            Comentario = reader.IsDBNull(6) ? null : reader.GetString(6)
                        });
                    }
                }
            }
            return movimientos;
        }

        public void AgregarMovimientoStock(StockReventa movimiento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO StockReventa 
                                 (ProductoId, TipoMovimiento, Cantidad, Fecha, FechaVencimiento, Comentario) 
                                 VALUES 
                                 (@ProductoId, @TipoMovimiento, @Cantidad, @Fecha, @FechaVencimiento, @Comentario)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductoId", movimiento.ProductoId);
                cmd.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                cmd.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                cmd.Parameters.AddWithValue("@FechaVencimiento", movimiento.FechaVencimiento.HasValue ? (object)movimiento.FechaVencimiento.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Comentario", movimiento.Comentario ?? (object)DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Obtener stock actual (entradas - salidas)

        public decimal ObtenerStockActual(int productoId)
        {
            decimal entradas = 0, salidas = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryEntradas = "SELECT ISNULL(SUM(Cantidad), 0) FROM StockReventa WHERE ProductoId = @id AND TipoMovimiento = 'Entrada'";
                string querySalidas = "SELECT ISNULL(SUM(Cantidad), 0) FROM StockReventa WHERE ProductoId = @id AND TipoMovimiento = 'Salida'";

                SqlCommand cmdEntradas = new SqlCommand(queryEntradas, con);
                cmdEntradas.Parameters.AddWithValue("@id", productoId);

                SqlCommand cmdSalidas = new SqlCommand(querySalidas, con);
                cmdSalidas.Parameters.AddWithValue("@id", productoId);

                con.Open();
                entradas = (decimal)cmdEntradas.ExecuteScalar();
                salidas = (decimal)cmdSalidas.ExecuteScalar();
            }

            return entradas - salidas;
        }
    }

    internal class StockReventa
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string Comentario { get; set; }
    }
}
