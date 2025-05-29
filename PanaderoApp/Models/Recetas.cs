using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanaderoApp.Models
{
    public class Recetas
    {
        public int Id { get; set; }                // Identificador único de la receta
        public int ProductoId { get; set; }        // ID del producto al que pertenece esta receta
        public int IngredienteId { get; set; }     // ID del ingrediente utilizado
        public decimal Cantidad { get; set; }      // Cantidad del ingrediente necesaria

        // Propiedades opcionales para mostrar información adicional en la UI
        public string NombreProducto { get; set; }       // Nombre del producto (no en BD)
        public string NombreIngrediente { get; set; }    // Nombre del ingrediente (no en BD)
        public string UnidadIngrediente { get; set; }    // Unidad de medida del ingrediente (no en BD)
    }
}
