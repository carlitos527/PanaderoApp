using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PanaderoApp.Models;
using System.Configuration; // Asegúrate de agregar esta referencia

namespace PanaderoApp.Controllers
{
    public class ClienteController
    {
        private readonly string connectionString;
        public ClienteController()
        {
            // Obtén la cadena de conexión desde el archivo de configuración
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }
        // Crear Cliente
        public void CrearCliente(Cliente cliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Nombre, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", (object)cliente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Correo", (object)cliente.Correo ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Leer todos los clientes
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, Telefono, Correo FROM Clientes";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente c = new Cliente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : null,
                            Correo = reader["Correo"] != DBNull.Value ? reader["Correo"].ToString() : null
                        };
                        clientes.Add(c);
                    }
                }
            }

            return clientes;
        }

        // Actualizar cliente
        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Clientes SET Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", (object)cliente.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Correo", (object)cliente.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", cliente.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar cliente
        public void EliminarCliente(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Clientes WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Obtener cliente por ID
        public Cliente ObtenerClientePorId(int id)
        {
            Cliente cliente = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nombre, Telefono, Correo FROM Clientes WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : null,
                            Correo = reader["Correo"] != DBNull.Value ? reader["Correo"].ToString() : null
                        };
                    }
                }
            }

            return cliente;
        }
    }
}
