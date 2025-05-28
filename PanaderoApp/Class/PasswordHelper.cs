using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Class
{
    public class PasswordHelper
    {
        // Método para generar un hash seguro de una contraseña
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convertir la contraseña en un array de bytes usando UTF8
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                // Generar el hash de la contraseña
                var hashBytes = sha256.ComputeHash(passwordBytes);

                // Convertir el hash a una cadena en Base64 para almacenamiento
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Método para verificar si una contraseña coincide con un hash
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Generar el hash de la contraseña proporcionada
            string hashedInputPassword = HashPassword(password);

            // Comparar el hash generado con el hash almacenado
            return hashedInputPassword == hashedPassword;
        }
    }
}
