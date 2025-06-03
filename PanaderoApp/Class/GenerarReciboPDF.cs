using PanaderoApp.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PanaderoApp.Class
{
    public class GenerarReciboPDF
    {
        public void GenerarRecibo(Venta venta, string carpetaDestino = "Recibos")
        {
            if (venta == null)
            {
                MessageBox.Show("La venta es nula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Crear carpeta destino si no existe
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                string nombreArchivo = Path.Combine(carpetaDestino, $"Recibo_{venta.Id}.pdf");

                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(nombreArchivo, FileMode.Create));
                doc.Open();

                // Título
                var titulo = new Paragraph("RECIBO DE VENTA")
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 10f,
                    Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)
                };
                doc.Add(titulo);

                // Fecha
                doc.Add(new Paragraph($"Fecha: {venta.Fecha}"));
                doc.Add(new Paragraph("-------------------------------------"));

                // Detalle
                foreach (var item in venta.Detalle)
                {
                    string linea = $"{item.Cantidad} x {item.PrecioUnitario:C} = {(item.Cantidad * item.PrecioUnitario):C}";
                    doc.Add(new Paragraph(linea));
                }

                doc.Add(new Paragraph("-------------------------------------"));

                // Total
                doc.Add(new Paragraph($"TOTAL: {venta.TotalVenta:C}",
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));

                doc.Close();
                writer.Close();

                MessageBox.Show($"Recibo generado: {nombreArchivo}", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir automáticamente el PDF
                Process.Start(new ProcessStartInfo
                {
                    FileName = nombreArchivo,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
