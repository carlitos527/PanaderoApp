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

namespace PanaderoApp.Class
{
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
                MessageBox.Show("La venta debe estar guardada previamente para generar el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cultura colombiana
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-CO");

            try
            {
                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string nombreArchivo = $"Recibo_{venta.Id}_{timestamp}.pdf";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                using (Document doc = new Document(PageSize.A6, 10, 10, 10, 10))
                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Encabezado del negocio
                    Paragraph header = new Paragraph("PANADERÍA LA ALEMANA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(header);

                    doc.Add(new Paragraph("NIT: 000000000-0", FontFactory.GetFont(FontFactory.HELVETICA, 10)) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph("Calle 19 #05 - 40", FontFactory.GetFont(FontFactory.HELVETICA, 10)) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph("Tel: 3136333503", FontFactory.GetFont(FontFactory.HELVETICA, 10)) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph($"Fecha: {venta.Fecha:dd/MM/yyyy HH:mm}", FontFactory.GetFont(FontFactory.HELVETICA, 10)) { Alignment = Element.ALIGN_CENTER });

                    doc.Add(new Paragraph("------------------------------------") { Alignment = Element.ALIGN_CENTER });

                    // Tabla de productos
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 1f, 3f, 2f, 2f });

                    // Encabezados
                    table.AddCell("Cant");
                    table.AddCell("Producto");
                    table.AddCell("P. Unit");
                    table.AddCell("Subtotal");

                    foreach (var item in venta.Detalle)
                    {
                        table.AddCell(item.Cantidad.ToString());
                        table.AddCell(item.NombreProducto);
                        table.AddCell(item.PrecioUnitario.ToString("C0")); // sin decimales
                        table.AddCell((item.Cantidad * item.PrecioUnitario).ToString("C0"));
                    }

                    doc.Add(table);
                    doc.Add(new Paragraph("------------------------------------") { Alignment = Element.ALIGN_CENTER });

                    // Total
                    Paragraph total = new Paragraph($"TOTAL A PAGAR: {venta.TotalVenta.ToString("C0")}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingBefore = 10f
                    };
                    doc.Add(total);

                    doc.Add(new Paragraph("Forma de pago: Efectivo", FontFactory.GetFont(FontFactory.HELVETICA, 10)) { Alignment = Element.ALIGN_CENTER });

                    // Nota legal
                    doc.Add(new Paragraph("\nEste documento no es válido como factura oficial.", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingBefore = 15f
                    });

                    doc.Add(new Paragraph("Gracias por su compra", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingBefore = 5f
                    });

                    doc.Close();
                    writer.Close();
                }

                GuardarRegistroRecibo(venta.Id, nombreArchivo, rutaCompleta);

                MessageBox.Show($"Recibo generado correctamente:\n{rutaCompleta}", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaCompleta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarRegistroRecibo(int ventaId, string nombreArchivo, string rutaArchivo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO RecibosPDF (VentaId, NombreArchivo, RutaArchivo, FechaGeneracion)
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
                MessageBox.Show($"Error guardando registro del recibo en base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
