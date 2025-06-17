using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PanaderoApp.Models;
using PanaderoApp.Controllers;

namespace PanaderoApp.Forms
{
    public partial class FrmClientes : Form
    {
        // Controlador para manejar la lógica de clientes
        private ClienteController controller = new ClienteController();

        // ID del cliente seleccionado en el DataGridView (nullable)
        private int? clienteSeleccionadoId = null;

        public FrmClientes()
        {
            InitializeComponent();

            // Establece que al presionar Enter se ejecute btnGuardar_Click
            this.AcceptButton = btnGuardar;
            // Inicialmente deshabilitamos el botón Actualizar
            btnActualizar.Enabled = false;

            // Ocultamos el botón Eliminar según indicación
            btnEliminar.Visible = false;

            // Limpiamos los campos para que estén vacíos al iniciar
            LimpiarCampos();

            // Cargamos los clientes en el DataGridView
            CargarClientes();

            // Asociamos el evento SelectionChanged para limpiar campos si no hay selección
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
        }

        /// <summary>
        /// Carga los clientes desde el controlador y los muestra en el DataGridView.
        /// </summary>
        private void CargarClientes()
        {
            var clientes = controller.ObtenerClientes();
            dgvClientes.DataSource = clientes;

            // Ajustamos automáticamente el tamaño de columnas para llenar el espacio disponible
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Evento clic del botón Guardar: crea un nuevo cliente con los datos ingresados.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            controller.CrearCliente(cliente);
            LimpiarCampos();
            CargarClientes();

            MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Evento que ocurre al seleccionar una celda en el DataGridView.
        /// Llena los TextBox con los datos del cliente seleccionado y habilita actualizar.
        /// </summary>
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
                clienteSeleccionadoId = Convert.ToInt32(fila.Cells["Id"].Value);

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value?.ToString();

                btnActualizar.Enabled = true; // Habilitamos botón Actualizar
            }
        }

        /// <summary>
        /// Evento para actualizar un cliente seleccionado con los nuevos datos.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId != null)
            {
                Cliente cliente = new Cliente
                {
                    Id = clienteSeleccionadoId.Value,
                    Nombre = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim()
                };

                controller.ActualizarCliente(cliente);
                CargarClientes();
                LimpiarCampos();

                MessageBox.Show("Cliente actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un cliente primero para actualizar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// (Botón eliminar oculto, pero código para referencia futura)
        /// Elimina el cliente seleccionado.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionadoId != null)
            {
                controller.EliminarCliente(clienteSeleccionadoId.Value);
                LimpiarCampos();
                CargarClientes();

                MessageBox.Show("Cliente eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Evento clic del botón Limpiar: limpia los campos y deshabilita actualización.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>
        /// Limpia los campos de texto, resetea el ID seleccionado y deshabilita el botón Actualizar.
        /// </summary>
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            clienteSeleccionadoId = null;
            btnActualizar.Enabled = false;
        }

        /// <summary>
        /// Evento que se dispara cuando cambia la selección en el DataGridView.
        /// Si no hay fila seleccionada, limpia los campos.
        /// </summary>
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                LimpiarCampos();
            }
        }
    }
}
