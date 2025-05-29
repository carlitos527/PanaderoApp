using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PanaderoApp.Controllers
{
    public class ProveedoresController
    {
        private readonly string connectionString;

        public ProveedoresController()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        // Crear
        public void AgregarProveedor(string nombre, string telefono, string correo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Proveedores (Nombre, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)", conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar).Value = (object)telefono ?? DBNull.Value;
                cmd.Parameters.Add("@Correo", System.Data.SqlDbType.NVarChar).Value = (object)correo ?? DBNull.Value;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Leer todos
        public List<Proveedores> ObtenerTodos()
        {
            var lista = new List<Proveedores>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Telefono, Correo FROM Proveedores", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Proveedores
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Telefono = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Correo = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }

            return lista;
        }

        // Leer por ID
        public Proveedores ObtenerPorId(int id)
        {
            Proveedores proveedor = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Telefono, Correo FROM Proveedores WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        proveedor = new Proveedores
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Telefono = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Correo = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
            }

            return proveedor;
        }

        // Actualizar
        public bool ActualizarProveedor(int id, string nuevoNombre, string nuevoTelefono, string nuevoCorreo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("UPDATE Proveedores SET Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.NVarChar).Value = (object)nuevoTelefono ?? DBNull.Value;
                cmd.Parameters.Add("@Correo", System.Data.SqlDbType.NVarChar).Value = (object)nuevoCorreo ?? DBNull.Value;

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        // Eliminar
        public bool EliminarProveedor(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Proveedores WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}
