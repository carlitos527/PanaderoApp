using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class FrmProveedores : Form
    {
        private ProveedoresController controller = new ProveedoresController();

        public FrmProveedores()
        {
            InitializeComponent();
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            dgvProveedores.DataSource = controller.ObtenerTodos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            controller.AgregarProveedor(txtNombre.Text, txtTelefono.Text, txtCorreo.Text);
            CargarProveedores();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                controller.ActualizarProveedor(id, txtNombre.Text, txtTelefono.Text, txtCorreo.Text);
                CargarProveedores();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor válido.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                controller.EliminarProveedor(id);
                CargarProveedores();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor válido.");
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProveedores.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value?.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
    }
}
