using System;
using System.Collections.Generic;
using System.Linq;

namespace PanaderoApp.Models
{
    public class Venta
    {
        public int Id { get; set; }

        // Fecha de la venta, por defecto ahora
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Total de la venta
        public decimal TotalVenta { get; set; }

        // Id del usuario que realizó la venta
        public int UsuarioId { get; set; }

        // Id del cliente (opcional)
        public int? ClienteId { get; set; }

        // Lista de detalles de la venta
        public List<VentasImpresion> Detalle { get; set; } = new List<VentasImpresion>();

        public Venta() { }

        // Validación básica de la venta
        public bool EsValida()
        {
            if (Detalle == null || Detalle.Count == 0)
                return false;

            if (UsuarioId <= 0)
                return false;

            // Validar cada detalle
            if (Detalle.Any(d => !d.EsValido()))
                return false;

            // Validar que el total de la venta sea al menos igual a la suma del detalle
            decimal sumaDetalle = Detalle.Sum(d => d.Cantidad * d.PrecioUnitario);

            if (TotalVenta < sumaDetalle)
                return false;

            return true;
        }
    }

    public class VentasImpresion
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        // Validación básica del detalle
        public bool EsValido()
        {
            return ProductoId > 0 && Cantidad > 0 && PrecioUnitario >= 0;
        }
    }
}
