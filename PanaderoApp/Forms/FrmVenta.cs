using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class FrmVenta : Form
    {
        private readonly VentasController ventasController = new VentasController();
        private List<Producto> productos = new List<Producto>(); // Lista de productos para selección
        private List<VentasImpresion> detallesVenta = new List<VentasImpresion>(); // Detalles en la venta actual

        public FrmVenta()
        {
            InitializeComponent();
            CargarProductos();
            InicializarGrids();
            dtpFecha.Value = DateTime.Now;
            txtTotal.Text = "0.00";
        }

        private void CargarProductos()
        {
            try
            {
                var controller = new ProductosController();
                var productosDesdeBD = controller.ObtenerTodos(); // Esto trae la lista desde la base de datos

                productos = productosDesdeBD.Select(p => new Producto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.PrecioVenta
                }).ToList();

                dgvProductos.DataSource = productos;
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }


        private void InicializarGrids()
        {
            // Configurar dgvProductos
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Width = 50 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 150 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 70 });

            // Configurar dgvDetalles
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.ReadOnly = false; // Permitir editar cantidad
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ProductoId", DataPropertyName = "ProductoId", Name = "ProductoId", Visible = false });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Producto", DataPropertyName = "Nombre", ReadOnly = true, Width = 150 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Cantidad", Width = 70 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio Unitario", DataPropertyName = "PrecioUnitario", ReadOnly = true, Width = 90 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Subtotal", DataPropertyName = "Subtotal", ReadOnly = true, Width = 90 });

            dgvDetalles.CellEndEdit += DgvDetalles_CellEndEdit;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para agregar.");
                return;
            }

            var productoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            var detalleExistente = detallesVenta.FirstOrDefault(d => d.ProductoId == productoSeleccionado.Id);
            if (detalleExistente != null)
            {
                detalleExistente.Cantidad++;
            }
            else
            {
                detallesVenta.Add(new VentasImpresion
                {
                    ProductoId = productoSeleccionado.Id,
                    Cantidad = 1,
                    PrecioUnitario = productoSeleccionado.Precio
                });
            }

            ActualizarGridDetalles();
            CalcularTotal();
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un detalle para quitar.");
                return;
            }

            try
            {
                int productoId = Convert.ToInt32(dgvDetalles.CurrentRow.Cells["ProductoId"].Value);
                detallesVenta.RemoveAll(d => d.ProductoId == productoId);

                ActualizarGridDetalles();
                CalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar el producto: " + ex.Message);
            }
        }

        private void DgvDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.Columns[e.ColumnIndex].DataPropertyName == "Cantidad")
            {
                var detalle = detallesVenta[e.RowIndex];
                var valorCelda = dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (!int.TryParse(Convert.ToString(valorCelda), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad debe ser un número entero mayor que cero.");
                    dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = detalle.Cantidad;
                    return;
                }

                detalle.Cantidad = cantidad;
                ActualizarGridDetalles();
                CalcularTotal();
            }
        }

        private void ActualizarGridDetalles()
        {
            var listaMostrar = detallesVenta.Select(d =>
            {
                var producto = productos.FirstOrDefault(p => p.Id == d.ProductoId);
                return new
                {
                    d.ProductoId,
                    Nombre = producto?.Nombre ?? "N/D",
                    d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario.ToString("F2"),
                    Subtotal = (d.Cantidad * d.PrecioUnitario).ToString("F2")
                };
            }).ToList();

            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = listaMostrar;
        }

        private void CalcularTotal()
        {
            decimal total = detallesVenta.Sum(d => d.Cantidad * d.PrecioUnitario);
            txtTotal.Text = total.ToString("F2");
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta.");
                return;
            }

            decimal totalCalculado = detallesVenta.Sum(d => d.Cantidad * d.PrecioUnitario);

            var venta = new Venta
            {
                Fecha = dtpFecha.Value,
                TotalVenta = totalCalculado,
                UsuarioId = 1, // TODO: reemplazar con usuario real
                ClienteId = null,
                Detalle = detallesVenta.Select(d => new VentasImpresion
                {
                    ProductoId = d.ProductoId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario
                }).ToList()
            };

            if (!venta.EsValida())
            {
                MessageBox.Show("La venta no es válida. Revisa los datos.");
                return;
            }

            bool resultado = ventasController.CrearVentaConDetalle(venta);

            if (resultado)
            {
                MessageBox.Show("Venta guardada exitosamente.");
                detallesVenta.Clear();
                ActualizarGridDetalles();
                txtTotal.Text = "0.00";
            }
            else
            {
                MessageBox.Show("Error al guardar la venta.");
            }
        }
    }

    // Clase auxiliar Producto para demo (usa tu modelo real si tienes)
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
