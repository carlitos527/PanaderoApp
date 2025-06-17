using PanaderoApp.Models;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;
using System.Drawing; // Necesario para convertir ICO a imagen

namespace PanaderoApp.Class
{
    /// <summary>
    /// Clase encargada de generar recibos en formato PDF para ventas realizadas.
    /// Optimizada para impresoras térmicas de 5 cm de ancho.
    /// Aplica la promoción "3 panes por 1000" automáticamente.
    /// </summary>
    public class GenerarReciboPDF
    {
        private readonly string connectionString;

        public GenerarReciboPDF()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
        }

        public void GenerarRecibo(Venta venta, string carpetaDestino = "Recibos")
        {
            if (venta == null || venta.Id <= 0)
            {
                MessageBox.Show("La venta debe estar guardada previamente para generar el recibo.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-CO");

            try
            {
                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string nombreArchivo = $"Recibo_{venta.Id}_{timestamp}.pdf";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                // ⚠️ Usamos el nombre completo para evitar ambigüedad
                iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(222f, 600f);

                using (Document doc = new Document(pageSize, 8, 5, 8, 8))
                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    AgregarLogoImagen(doc);
                    AgregarEncabezado(doc, venta.Fecha);
                    AgregarDetalleVenta(doc, venta);
                    AgregarTotalYNotas(doc, venta.TotalVenta);

                    doc.Close();
                    writer.Close();
                }

                GuardarRegistroRecibo(venta.Id, nombreArchivo, rutaCompleta);

                MessageBox.Show($"Recibo generado correctamente:\n{rutaCompleta}",
                    "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaCompleta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalcularSubtotalConPromocion(VentasImpresion detalle)
        {
            if (detalle.NombreProducto != null && detalle.NombreProducto.ToLower().Contains("pan"))
            {
                int gruposDeTres = detalle.Cantidad / 3;
                int restantes = detalle.Cantidad % 3;
                return gruposDeTres * 1000m + restantes * detalle.PrecioUnitario;
            }

            return detalle.Cantidad * detalle.PrecioUnitario;
        }

        private void AgregarLogoImagen(Document doc)
        {
            try
            {
                string rutaLogo = @"D:\Proyecto\PanaderiaApp\PanaderoApp\img\Panadero.png";

                if (File.Exists(rutaLogo))
                {
                    // Cargar la imagen PNG directamente
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);

                    // Ajustar tamaño para evitar cortes (puedes modificar estos valores)
                    logo.ScaleToFit(110f, 45f);

                    // Centrar la imagen
                    logo.Alignment = Element.ALIGN_CENTER;

                    // Espaciados para que no quede pegado a otros elementos
                    logo.SpacingBefore = 8f;
                    logo.SpacingAfter = 12f;

                    doc.Add(logo);
                }
                else
                {
                    MessageBox.Show($"No se encontró el archivo de logo en la ruta: {rutaLogo}",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el logo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AgregarEncabezado(Document doc, DateTime fechaVenta)
        {
            Paragraph header = new Paragraph("PANADERÍA LA ALEMANA",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
            { Alignment = Element.ALIGN_CENTER };
            doc.Add(header);

            doc.Add(new Paragraph("NIT: 000000000-0", FontFactory.GetFont(FontFactory.HELVETICA, 9)) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("Calle 19 #05 - 40", FontFactory.GetFont(FontFactory.HELVETICA, 9)) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("Tel: 3136333503", FontFactory.GetFont(FontFactory.HELVETICA, 9)) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph($"Fecha: {fechaVenta:dd/MM/yyyy HH:mm}", FontFactory.GetFont(FontFactory.HELVETICA, 9)) { Alignment = Element.ALIGN_CENTER });

            doc.Add(new Paragraph("------------------------------------") { Alignment = Element.ALIGN_CENTER });
        }

        private void AgregarDetalleVenta(Document doc, Venta venta)
        {
            PdfPTable table = new PdfPTable(4)
            {
                WidthPercentage = 100
            };
            table.SetWidths(new float[] { 1f, 4f, 2f, 2f });

            table.AddCell(new PdfPCell(new Phrase("Cant", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { HorizontalAlignment = Element.ALIGN_LEFT });
            table.AddCell(new PdfPCell(new Phrase("P.Unit", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { HorizontalAlignment = Element.ALIGN_RIGHT });
            table.AddCell(new PdfPCell(new Phrase("Subtotal", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { HorizontalAlignment = Element.ALIGN_RIGHT });

            foreach (var item in venta.Detalle)
            {
                decimal subtotalConPromo = CalcularSubtotalConPromocion(item);

                table.AddCell(new PdfPCell(new Phrase(item.Cantidad.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8))) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(item.NombreProducto, FontFactory.GetFont(FontFactory.HELVETICA, 8))) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase(item.PrecioUnitario.ToString("C0"), FontFactory.GetFont(FontFactory.HELVETICA, 8))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase(subtotalConPromo.ToString("C0"), FontFactory.GetFont(FontFactory.HELVETICA, 8))) { HorizontalAlignment = Element.ALIGN_RIGHT });
            }

            doc.Add(table);
            doc.Add(new Paragraph("------------------------------------") { Alignment = Element.ALIGN_CENTER });
        }

        private void AgregarTotalYNotas(Document doc, decimal totalVenta)
        {
            Paragraph total = new Paragraph($"TOTAL A PAGAR: {totalVenta.ToString("C0")}",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingBefore = 10f
            };
            doc.Add(total);

            doc.Add(new Paragraph("Forma de pago: Efectivo", FontFactory.GetFont(FontFactory.HELVETICA, 9)) { Alignment = Element.ALIGN_CENTER });

            doc.Add(new Paragraph("\nEste documento no es válido como factura oficial.",
                FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingBefore = 15f
            });

            doc.Add(new Paragraph("Gracias por su compra", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingBefore = 5f
            });
        }

        private void GuardarRegistroRecibo(int ventaId, string nombreArchivo, string rutaArchivo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    const string query = @"INSERT INTO RecibosPDF (VentaId, NombreArchivo, RutaArchivo, FechaGeneracion)
                                           VALUES (@VentaId, @NombreArchivo, @RutaArchivo, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@VentaId", ventaId);
                        cmd.Parameters.AddWithValue("@NombreArchivo", nombreArchivo);
                        cmd.Parameters.AddWithValue("@RutaArchivo", rutaArchivo);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando registro del recibo en base de datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
