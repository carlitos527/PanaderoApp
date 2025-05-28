using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                _nombre = value;
            }
        }

        private string _telefono;
        public string Telefono
        {
            get => _telefono;
            set
            {
                // Aquí puedes agregar validaciones específicas para teléfono si quieres
                _telefono = value;
            }
        }

        private string _correo;
        public string Correo
        {
            get => _correo;
            set
            {
                // Validación básica para correo electrónico (puedes mejorarla)
                if (!string.IsNullOrWhiteSpace(value) && !value.Contains("@"))
                    throw new ArgumentException("El correo electrónico no es válido.");
                _correo = value;
            }
        }

        public Cliente() { }

        public Cliente(int id, string nombre, string telefono, string correo)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
        }
    }
}
