using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class FrmProveedores : Form
    {
        // Controlador para manejar la lógica de proveedores
        private ProveedoresController controller = new ProveedoresController();

        public FrmProveedores()
        {
            InitializeComponent();

            // Enter ejecuta el botón Agregar
            this.AcceptButton = btnAgregar;

            // Ocultar controles que no deben verse en la interfaz
            btnEliminar.Visible = false; // Eliminar no será visible
            txtId.Visible = false;       // Oculta el campo de ID
            if (lblId != null)           // Asegura que también se oculte la etiqueta si existe
                lblId.Visible = false;

            btnActualizar.Enabled = false; // 🔒 Deshabilitar botón Actualizar hasta que se seleccione un proveedor

            CargarProveedores();
        }

        /// <summary>
        /// Carga todos los proveedores en el DataGridView.
        /// </summary>
        private void CargarProveedores()
        {
            dgvProveedores.DataSource = controller.ObtenerTodos();
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Agrega un nuevo proveedor con los datos ingresados.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            controller.AgregarProveedor(txtNombre.Text, txtTelefono.Text, txtCorreo.Text);
            CargarProveedores();
            LimpiarCampos();
        }

        /// <summary>
        /// Actualiza los datos del proveedor seleccionado.
        /// </summary>
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

        /// <summary>
        /// Elimina el proveedor seleccionado (este botón está oculto).
        /// </summary>
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

        /// <summary>
        /// Llena los campos de texto al hacer clic en una fila del DataGridView.
        /// También habilita el botón de actualización.
        /// </summary>
        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProveedores.Rows[e.RowIndex];

                // Guardar el ID internamente (aunque esté oculto)
                txtId.Text = row.Cells["Id"].Value.ToString();

                // Mostrar los datos del proveedor en los campos de texto
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value?.ToString();

                btnActualizar.Enabled = true; // 🔓 Habilitar botón Actualizar
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            btnActualizar.Enabled = false; // 🔒 Deshabilita después de limpiar
        }
    }
}
