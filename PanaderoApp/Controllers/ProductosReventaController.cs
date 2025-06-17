using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    /// <summary>
    /// Controlador para gestionar productos y stock usando la tabla Productos y StockReventa.
    /// </summary>
    internal class ProductosReventaController
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor que obtiene la cadena de conexión desde el archivo de configuración.
        /// </summary>
        public ProductosReventaController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        #region CRUD Productos

        /// <summary>
        /// Obtiene la lista de productos desde la tabla Productos.
        /// </summary>
        /// <returns>Lista de productos con Id, Nombre y PrecioVenta.</returns>
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, PrecioVenta FROM Productos";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
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

        /// <summary>
        /// Crea un nuevo producto en la tabla Productos.
        /// </summary>
        /// <param name="producto">Objeto Producto con Nombre y PrecioVenta.</param>
        public void CrearProducto(Producto producto)
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

        /// <summary>
        /// Actualiza un producto existente en la tabla Productos.
        /// </summary>
        /// <param name="producto">Objeto Producto con Id, Nombre y PrecioVenta.</param>
        public void ActualizarProducto(Producto producto)
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

        /// <summary>
        /// Elimina un producto de la tabla Productos por Id.
        /// </summary>
        /// <param name="id">Id del producto a eliminar.</param>
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

        #endregion

        #region CRUD StockReventa

        /// <summary>
        /// Obtiene el historial de movimientos de stock para un producto dado.
        /// </summary>
        /// <param name="productoId">Id del producto.</param>
        /// <returns>Lista de movimientos de stock ordenados por fecha descendente.</returns>
        public List<StockReventa> ObtenerMovimientosStock(int productoId)
        {
            var movimientos = new List<StockReventa>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id, ProductoId, TipoMovimiento, Cantidad, Fecha, Comentario 
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
                            Comentario = reader.IsDBNull(5) ? null : reader.GetString(5)
                        });
                    }
                }
            }
            return movimientos;
        }

        /// <summary>
        /// Agrega un movimiento de stock para un producto específico.
        /// </summary>
        /// <param name="movimiento">Objeto StockReventa con datos del movimiento.</param>
        public void AgregarMovimientoStock(StockReventa movimiento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO StockReventa (ProductoId, TipoMovimiento, Cantidad, Comentario) 
                                 VALUES (@ProductoId, @TipoMovimiento, @Cantidad, @Comentario)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductoId", movimiento.ProductoId);
                cmd.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                cmd.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                cmd.Parameters.AddWithValue("@Comentario", (object)movimiento.Comentario ?? DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }

    /// <summary>
    /// Modelo para producto, representando la tabla Productos.
    /// </summary>
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
    }

    /// <summary>
    /// Modelo para movimientos de stock en StockReventa.
    /// </summary>
    internal class StockReventa
    {
        public int Id { get; set; }

        /// <summary>
        /// Llave foránea al producto en Productos.Id
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Tipo de movimiento (Ej: Entrada, Salida, Ajuste)
        /// </summary>
        public string TipoMovimiento { get; set; }

        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
    }
}
