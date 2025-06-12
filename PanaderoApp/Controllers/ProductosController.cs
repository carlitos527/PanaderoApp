using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration; // Para leer la cadena de conexión
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PanaderoApp.Controllers
{
    public class ProductosController
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor que obtiene la cadena de conexión desde el archivo de configuración.
        /// </summary>
        public ProductosController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        /// <summary>
        /// Agrega un nuevo producto a la base de datos, validando que no exista previamente otro con el mismo nombre.
        /// </summary>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="precioVenta">Precio de venta del producto.</param>
        public void AgregarProducto(string nombre, decimal precioVenta)
        {
            // Validación de nombre duplicado
            if (ExisteProductoConNombre(nombre))
            {
                MessageBox.Show("Ya existe un producto con ese nombre.", "Producto duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Productos (Nombre, PrecioVenta) VALUES (@Nombre, @PrecioVenta)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@PrecioVenta", precioVenta);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Actualiza un producto existente si el nuevo nombre no está repetido en otro producto.
        /// </summary>
        /// <param name="id">Id del producto a actualizar.</param>
        /// <param name="nuevoNombre">Nuevo nombre del producto.</param>
        /// <param name="nuevoPrecio">Nuevo precio de venta.</param>
        /// <returns>True si la actualización fue exitosa, false si no.</returns>
        public bool ActualizarProducto(int id, string nuevoNombre, decimal nuevoPrecio)
        {
            // Validación: no permitir cambiar a un nombre que ya tenga otro producto
            if (ExisteProductoConNombre(nuevoNombre, id))
            {
                MessageBox.Show("Ya existe otro producto con ese nombre.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

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

        /// <summary>
        /// Elimina un producto por su Id.
        /// </summary>
        /// <param name="id">Id del producto a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, false si no.</returns>
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

        /// <summary>
        /// Obtiene todos los productos almacenados en la base de datos.
        /// </summary>
        /// <returns>Lista con todos los productos.</returns>
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

        /// <summary>
        /// Obtiene un producto específico por su Id.
        /// </summary>
        /// <param name="id">Id del producto a buscar.</param>
        /// <returns>Producto encontrado o null si no existe.</returns>
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

        /// <summary>
        /// Verifica si ya existe un producto con el mismo nombre (ignora mayúsculas/minúsculas).
        /// </summary>
        /// <param name="nombre">Nombre a verificar.</param>
        /// <returns>True si ya existe, false si no.</returns>
        private bool ExisteProductoConNombre(string nombre)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM Productos WHERE LOWER(Nombre) = LOWER(@Nombre)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        /// <summary>
        /// Verifica si existe otro producto con el mismo nombre (excepto el del ID actual).
        /// </summary>
        /// <param name="nombre">Nombre a verificar.</param>
        /// <param name="excluirId">Id del producto que se está actualizando.</param>
        /// <returns>True si ya existe otro producto con ese nombre, false si no.</returns>
        private bool ExisteProductoConNombre(string nombre, int excluirId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT COUNT(*) FROM Productos WHERE LOWER(Nombre) = LOWER(@Nombre) AND Id != @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Id", excluirId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
