using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PanaderoApp.Models;
using PanaderoApp.Controllers;

namespace PanaderoApp.Forms
{
    public partial class FrmClientes : Form
    {
        private ClienteController controller = new ClienteController();
        private int? clienteSeleccionadoId = null;

        public FrmClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            var clientes = controller.ObtenerClientes();
            dgvClientes.DataSource = clientes;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            if (clienteSeleccionadoId == null)
            {
                controller.CrearCliente(cliente);
            }
            else
            {
                cliente.Id = clienteSeleccionadoId.Value;
                controller.ActualizarCliente(cliente);
            }

            LimpiarCampos();
            CargarClientes();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                clienteSeleccionadoId = Convert.ToInt32(fila.Cells["Id"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value?.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId != null)
            {
                controller.EliminarCliente(clienteSeleccionadoId.Value);
                LimpiarCampos();
                CargarClientes();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            clienteSeleccionadoId = null;
        }
    }
}
