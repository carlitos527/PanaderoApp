using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Models
{
    public class StockActualDto
    {
        public int IngredienteId { get; set; }
        public string IngredienteNombre { get; set; }
        public decimal StockActual { get; set; }
    }
}
