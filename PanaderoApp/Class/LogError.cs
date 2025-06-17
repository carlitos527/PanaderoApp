using System;
using System.IO;

namespace PanaderoApp.Class
{
    internal class LogError
    {
        private static readonly string logFilePath = "error_log.txt";

        /// <summary>
        /// Registra un mensaje de error en un archivo de texto con fecha y hora.
        /// </summary>
        /// <param name="ex">La excepción a registrar.</param>
        public static void Registrar(Exception ex)
        {
            try
            {
                string mensaje = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {ex.Message}\nStackTrace: {ex.StackTrace}\n";
                File.AppendAllText(logFilePath, mensaje);
            }
            catch
            {
                // Si hay error al escribir el log, no hacer nada para evitar excepciones no manejadas
            }
        }

        /// <summary>
        /// Registra un mensaje personalizado en el archivo de log.
        /// </summary>
        /// <param name="mensaje">Mensaje a registrar.</param>
        public static void Registrar(string mensaje)
        {
            try
            {
                string log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {mensaje}\n";
                File.AppendAllText(logFilePath, log);
            }
            catch
            {
                // Ignorar errores en logging
            }
        }
    }
}
