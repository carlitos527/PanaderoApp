using System;
using PanaderoApp.Class;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        private string _nombreUsuario;
        public string NombreUsuario
        {
            get => _nombreUsuario;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de usuario no puede estar vacío.");
                _nombreUsuario = value;
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                // Asigna el valor directamente, asumiendo que ya está hasheado.
                _password = value;
            }
        }

        public Usuario() { }

        public Usuario(int id, string nombreUsuario, string password)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            Password = password;
        }

        // Método para cambiar el password y asegurar que esté hasheado correctamente
        public void CambiarPassword(string nuevoPassword)
        {
            if (string.IsNullOrWhiteSpace(nuevoPassword))
                throw new ArgumentException("La contraseña no puede estar vacía.");
            if (!ValidarPassword(nuevoPassword))
                throw new ArgumentException("La contraseña no cumple con las reglas de seguridad.");

            // Utiliza PasswordHelper para hashear la contraseña
            Password = PasswordHelper.HashPassword(nuevoPassword);
        }

        // Método para validar si el password cumple con ciertas reglas
        public static bool ValidarPassword(string password)
        {
            // Ejemplo básico: mínimo 8 caracteres
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 8;
        }

        // Método para actualizar el nombre de usuario
        public void ActualizarNombreUsuario(string nuevoNombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombreUsuario))
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");

            NombreUsuario = nuevoNombreUsuario;
        }

        // Método para comparar dos usuarios
        public bool EsIgual(Usuario otroUsuario)
        {
            if (otroUsuario == null) return false;
            return Id == otroUsuario.Id &&
                   NombreUsuario == otroUsuario.NombreUsuario &&
                   Password == otroUsuario.Password; // Comparación directa del hash
        }

        // Método para validar si el nombre de usuario es válido (ejemplo: longitud mínima de 3 caracteres)
        public static bool EsNombreUsuarioValido(string nombreUsuario)
        {
            return !string.IsNullOrWhiteSpace(nombreUsuario) && nombreUsuario.Length >= 3;
        }
    }
}
