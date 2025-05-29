using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class FrmProductos : Form
    {
        private ProductosController controller = new ProductosController();

        public FrmProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            decimal precio;

            if (string.IsNullOrEmpty(nombre) || !decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Datos inválidos.");
                return;
            }

            controller.AgregarProducto(nombre, precio);
            LimpiarCampos();
            CargarProductos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);
            string nombre = txtNombre.Text.Trim();
            decimal precio;

            if (string.IsNullOrEmpty(nombre) || !decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Datos inválidos.");
                return;
            }

            controller.ActualizarProducto(id, nombre, precio);
            LimpiarCampos();
            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);

            var confirm = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                controller.EliminarProducto(id);
                LimpiarCampos();
                CargarProductos();
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["PrecioVenta"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            dgvProductos.ClearSelection();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = controller.ObtenerTodos();
        }
    }
}
