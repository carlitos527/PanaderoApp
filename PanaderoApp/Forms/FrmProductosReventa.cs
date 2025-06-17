using System;
using System.Data;
using System.Windows.Forms;
using PanaderoApp.Models;
using PanaderoApp.Controllers;

namespace PanaderoApp.Forms
{
    public partial class FrmProductosReventa : Form
    {
        private readonly ProductosReventaController controller = new ProductosReventaController();

        public FrmProductosReventa()
        {
            InitializeComponent();
            CargarProductos();

            btnAgregar.Visible = false;
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;

            txtNombre.ReadOnly = true;
            txtPrecio.ReadOnly = true;

            txtCantidad.KeyDown += TxtCantidad_KeyDown;

            dtpFechaVencimiento.MinDate = DateTime.Today;
            dtpFechaVencimiento.Format = DateTimePickerFormat.Short;

            dtpFechaIngreso.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso.Value = DateTime.Now;
            dtpFechaIngreso.Enabled = false;

            // Inicializamos el texto del Label que ya está en el diseñador
            lblStockActual.Text = "Stock Actual: -";
            lblStockActual.AutoSize = true;
            // Si quieres ajustar posición, hazlo en el diseñador visual o aquí:
            // lblStockActual.Location = new System.Drawing.Point(20, 320);
        }

        private void CargarProductos()
        {
            var productos = controller.ObtenerProductos();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvProductos.Rows[e.RowIndex];
            if (fila.DataBoundItem is Productos producto)
            {
                txtId.Text = producto.Id.ToString();
                txtNombre.Text = producto.Nombre;
                txtPrecio.Text = producto.PrecioVenta.ToString("F2");

                decimal stockActual = controller.ObtenerStockActual(producto.Id);
                lblStockActual.Text = $"Stock Actual: {stockActual}";

                dtpFechaIngreso.Value = DateTime.Now;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtComentario.Clear();
            dtpFechaVencimiento.Value = DateTime.Today;
            dtpFechaIngreso.Value = DateTime.Now;

            lblStockActual.Text = "Stock Actual: -";
        }

        private void RegistrarMovimiento(string tipoMovimiento, decimal cantidad, DateTime fechaVencimiento, string comentario = null)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto en la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(dgvProductos.SelectedRows[0].DataBoundItem is Productos producto))
            {
                MessageBox.Show("Producto seleccionado inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var movimiento = new StockReventa
            {
                ProductoId = producto.Id,
                TipoMovimiento = tipoMovimiento,
                Cantidad = cantidad,
                Fecha = dtpFechaIngreso.Value,
                FechaVencimiento = fechaVencimiento,
                Comentario = string.IsNullOrWhiteSpace(comentario) ? null : comentario.Trim()
            };

            controller.AgregarMovimientoStock(movimiento);
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fechaVencimiento = dtpFechaVencimiento.Value.Date;
            if (fechaVencimiento < DateTime.Today)
            {
                MessageBox.Show("La fecha de vencimiento no puede ser anterior a hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegistrarMovimiento("Entrada", cantidad, fechaVencimiento, txtComentario.Text);
            MessageBox.Show("Movimiento de entrada registrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarProductos();
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto en la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(dgvProductos.SelectedRows[0].DataBoundItem is Productos producto))
            {
                MessageBox.Show("Producto seleccionado inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal stockActual = controller.ObtenerStockActual(producto.Id);

            if (cantidad > stockActual)
            {
                MessageBox.Show($"Stock insuficiente. Stock actual: {stockActual}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fechaVencimiento = dtpFechaVencimiento.Value.Date;

            RegistrarMovimiento("Salida", cantidad, fechaVencimiento, txtComentario.Text);
            MessageBox.Show("Movimiento de salida registrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarProductos();
        }

        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnRegistrarEntrada.PerformClick();
            }
        }
    }
}
