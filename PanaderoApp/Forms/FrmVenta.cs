using PanaderoApp.Controllers;
using PanaderoApp.Models;
using PanaderoApp.Class;  // Asegúrate de tener el namespace correcto para GenerarReciboPDF
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    /// <summary>
    /// Formulario para registrar y gestionar ventas.
    /// </summary>
    public partial class FrmVenta : Form
    {
        private readonly VentasController ventasController = new VentasController();

        // Lista de productos disponibles para la venta
        private List<Producto> productos = new List<Producto>();

        // Detalles (productos) de la venta actual
        private List<VentasImpresion> detallesVenta = new List<VentasImpresion>();

        public FrmVenta()
        {
            InitializeComponent();
            CargarProductos();      // Carga los productos desde la base de datos
            InicializarGrids();     // Configura las grillas (tablas)
            dtpFecha.Value = DateTime.Now;
            txtTotal.Text = "0.00"; // Inicializa el total
        }

        /// <summary>
        /// Carga los productos desde la base de datos y los muestra en la grilla de productos.
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                var controller = new ProductosController();
                var productosDesdeBD = controller.ObtenerTodos();

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

        /// <summary>
        /// Configura la apariencia y funcionalidad de las grillas dgvProductos y dgvDetalles.
        /// </summary>
        private void InicializarGrids()
        {
            // Configuración de grilla de productos
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Width = 50 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Width = 250 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 100 });

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvProductos.ScrollBars = ScrollBars.Both;

            // Configuración de grilla de detalles de la venta
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.ReadOnly = false;
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ProductoId", DataPropertyName = "ProductoId", Name = "ProductoId", Visible = false });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Producto", DataPropertyName = "Nombre", ReadOnly = true, Width = 250 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Cantidad", Width = 70 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio Unitario", DataPropertyName = "PrecioUnitario", ReadOnly = true, Width = 100 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Subtotal", DataPropertyName = "Subtotal", ReadOnly = true, Width = 100 });

            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.ScrollBars = ScrollBars.Both;

            dgvDetalles.CellEndEdit += DgvDetalles_CellEndEdit;
        }

        /// <summary>
        /// Agrega el producto seleccionado en la grilla a los detalles de la venta.
        /// </summary>
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para agregar.");
                return;
            }

            var productoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            // Si ya existe en la lista, aumenta la cantidad
            var detalleExistente = detallesVenta.FirstOrDefault(d => d.ProductoId == productoSeleccionado.Id);
            if (detalleExistente != null)
            {
                detalleExistente.Cantidad++;
            }
            else
            {
                // Agrega nuevo producto
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

        /// <summary>
        /// Quita el producto seleccionado de los detalles de la venta.
        /// </summary>
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

        /// <summary>
        /// Valida y actualiza la cantidad editada por el usuario en la grilla de detalles.
        /// </summary>
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

        /// <summary>
        /// Calcula el subtotal de un detalle aplicando la promoción "3 panes por 1000".
        /// </summary>
        private decimal CalcularSubtotalConPromocion(VentasImpresion detalle)
        {
            var producto = productos.FirstOrDefault(p => p.Id == detalle.ProductoId);

            if (producto != null && producto.Nombre.ToLower().Contains("pan"))
            {
                int gruposDeTres = detalle.Cantidad / 3;
                int restantes = detalle.Cantidad % 3;
                return gruposDeTres * 1000m + restantes * detalle.PrecioUnitario;
            }

            return detalle.Cantidad * detalle.PrecioUnitario;
        }

        /// <summary>
        /// Actualiza la grilla de detalles con los datos actuales, aplicando promoción al "pan".
        /// </summary>
        private void ActualizarGridDetalles()
        {
            var listaMostrar = detallesVenta.Select(d =>
            {
                var producto = productos.FirstOrDefault(p => p.Id == d.ProductoId);
                decimal subtotal = CalcularSubtotalConPromocion(d);

                return new
                {
                    d.ProductoId,
                    Nombre = producto?.Nombre ?? "N/D",
                    d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario.ToString("F2"),
                    Subtotal = subtotal.ToString("F2")
                };
            }).ToList();

            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = listaMostrar;
        }

        /// <summary>
        /// Calcula el total de la venta aplicando la promoción al "pan".
        /// </summary>
        private void CalcularTotal()
        {
            decimal total = detallesVenta.Sum(d => CalcularSubtotalConPromocion(d));
            txtTotal.Text = total.ToString("F2");
        }

        /// <summary>
        /// Guarda la venta en la base de datos y genera el recibo en PDF.
        /// </summary>
        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta.");
                return;
            }

            decimal totalCalculado = detallesVenta.Sum(d => CalcularSubtotalConPromocion(d));

            var venta = new Venta
            {
                Fecha = dtpFecha.Value,
                TotalVenta = totalCalculado,
                UsuarioId = 1, // TODO: Reemplazar con el ID del usuario autenticado
                ClienteId = null, // Si se implementa funcionalidad de cliente
                Detalle = detallesVenta.Select(d =>
                {
                    var producto = productos.FirstOrDefault(p => p.Id == d.ProductoId);
                    return new VentasImpresion
                    {
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        NombreProducto = producto?.Nombre ?? "N/D"
                    };
                }).ToList()
            };

            // Validar la venta antes de guardar
            if (!venta.EsValida())
            {
                MessageBox.Show("La venta no es válida. Revisa los datos.");
                return;
            }

            // Guardar en base de datos
            int ventaId = ventasController.CrearVentaConDetalle(venta);

            if (ventaId > 0)
            {
                venta.Id = ventaId; // Asignar ID generado

                MessageBox.Show("Venta guardada exitosamente.");

                // Generar PDF del recibo
                var generadorPDF = new GenerarReciboPDF();
                generadorPDF.GenerarRecibo(venta, "Recibos");

                // Limpiar para nueva venta
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

    /// <summary>
    /// Clase auxiliar de Producto para mostrar en grilla.
    /// </summary>
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
