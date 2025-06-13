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

        // Validación básica de la venta con promoción para "pan"
        public bool EsValida()
        {
            if (Detalle == null || Detalle.Count == 0)
                return false;

            if (UsuarioId <= 0)
                return false;

            // Validar cada detalle
            if (Detalle.Any(d => !d.EsValido()))
                return false;

            // Validar que el total de la venta sea al menos igual a la suma del detalle con promoción
            decimal sumaDetalleConPromocion = Detalle.Sum(d =>
            {
                if (!string.IsNullOrEmpty(d.NombreProducto) && d.NombreProducto.ToLower().Contains("pan"))
                {
                    int gruposDe3 = d.Cantidad / 3;
                    int restantes = d.Cantidad % 3;
                    return gruposDe3 * 1000m + restantes * d.PrecioUnitario;
                }
                else
                {
                    return d.Cantidad * d.PrecioUnitario;
                }
            });

            if (TotalVenta < sumaDetalleConPromocion)
                return false;

            return true;
        }
    }

    public class VentasImpresion
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }
        public string NombreProducto { get; set; }

        public decimal PrecioUnitario { get; set; }

        // Validación básica del detalle
        public bool EsValido()
        {
            return ProductoId > 0 && Cantidad > 0 && PrecioUnitario >= 0;
        }
    }
}
