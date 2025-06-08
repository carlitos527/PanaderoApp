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

        /// <summary>
        /// Genera el PDF del recibo para una venta ya existente.
        /// </summary>
        public void GenerarRecibo(Venta venta, string carpetaDestino = "Recibos")
        {
            if (venta == null)
            {
                MessageBox.Show("La venta es nula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (venta.Id <= 0)
            {
                MessageBox.Show("La venta debe estar guardada previamente para generar el recibo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cultura colombiana para formato moneda
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-CO");

            try
            {
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string nombreArchivo = $"Recibo_{venta.Id}_{timestamp}.pdf";
                string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                using (Document doc = new Document())
                {
                    using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        var titulo = new Paragraph("RECIBO DE VENTA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 10f
                        };
                        doc.Add(titulo);

                        var fecha = new Paragraph($"Fecha: {venta.Fecha:dd/MM/yyyy HH:mm}", FontFactory.GetFont(FontFactory.HELVETICA, 12))
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 5f
                        };
                        doc.Add(fecha);

                        var separador = new Paragraph("-------------------------------------")
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        doc.Add(separador);

                        foreach (var item in venta.Detalle)
                        {
                            string linea = $"{item.Cantidad} x {item.PrecioUnitario:C} = {(item.Cantidad * item.PrecioUnitario):C}";
                            var detalle = new Paragraph(linea, FontFactory.GetFont(FontFactory.HELVETICA, 12))
                            {
                                Alignment = Element.ALIGN_CENTER
                            };
                            doc.Add(detalle);
                        }

                        doc.Add(separador);

                        var total = new Paragraph($"TOTAL: {venta.TotalVenta:C}",
                            FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingBefore = 5f
                        };
                        doc.Add(total);

                        doc.Close();
                        writer.Close();
                    }
                }

                GuardarRegistroRecibo(venta.Id, nombreArchivo, rutaCompleta);

                MessageBox.Show($"Recibo generado: {rutaCompleta}", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    string query = "INSERT INTO RecibosPDF (VentaId, NombreArchivo, RutaArchivo, FechaGeneracion) VALUES (@VentaId, @NombreArchivo, @RutaArchivo, GETDATE())";

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
