using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Models
{
    public class Productos
    {
        public int Id { get; set; }                 // Identificador del producto (clave primaria)
        public string Nombre { get; set; }          // Nombre del producto
        public decimal PrecioVenta { get; set; }    // Precio de venta al público
    }
}
