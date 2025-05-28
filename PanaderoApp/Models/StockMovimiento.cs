using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Models
{
    public class StockMovimiento
    {
        public int Id { get; set; }
        public int IngredienteId { get; set; }
        public string TipoMovimiento { get; set; } // Entrada, Salida, Ajuste
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }

        // Opción adicional: incluir el nombre del ingrediente para mostrar en grids
        public string IngredienteNombre { get; set; }
    }
}
