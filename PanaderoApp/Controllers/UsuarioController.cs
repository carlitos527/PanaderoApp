using System;
using PanaderoApp.Models;
using PanaderoApp.Class;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Controllers
{
    public class UsuarioController
    {
        private readonly string _connectionString;

        public UsuarioController(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Agrega un nuevo usuario
        public void AgregarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            string hashedPassword = PasswordHelper.HashPassword(usuario.Password);

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO [PanaderiaDB].[dbo].[Usuarios] (NombreUsuario, Password) VALUES (@NombreUsuario, @Password)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Obtiene un usuario por su nombre
        public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, NombreUsuario, Password FROM [PanaderiaDB].[dbo].[Usuarios] WHERE NombreUsuario = @NombreUsuario";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = reader.GetInt32(0),
                                NombreUsuario = reader.GetString(1),
                                Password = reader.GetString(2)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Verifica si un usuario existe con nombre y contraseña
        public Usuario ObtenerUsuario(string nombreUsuario, string password)
        {
            string hashedPassword = PasswordHelper.HashPassword(password);

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, NombreUsuario, Password FROM [PanaderiaDB].[dbo].[Usuarios] WHERE NombreUsuario = @NombreUsuario AND Password = @Password";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = reader.GetInt32(0),
                                NombreUsuario = reader.GetString(1),
                                Password = reader.GetString(2)
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Verifica si hay usuarios registrados
        public bool ExistePerfil()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM [PanaderiaDB].[dbo].[Usuarios]";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
