using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class FrmProductos : Form
    {
        private readonly ProductosController controller = new ProductosController();

        public FrmProductos()
        {
            InitializeComponent();

            // Ocultar el botón Eliminar (no se usa)
            btnEliminar.Visible = false;

            // Eventos para agregar con Enter
            txtNombre.KeyDown += Txt_KeyDown;
            txtPrecio.KeyDown += Txt_KeyDown;

            // Cargar productos al iniciar
            CargarProductos();
        }

        /// <summary>
        /// Agrega un producto nuevo, validando que no esté vacío ni duplicado.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            decimal precio;

            if (string.IsNullOrEmpty(nombre) || !decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Datos inválidos. Asegúrese de que el nombre no esté vacío y el precio sea numérico.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controller.AgregarProducto(nombre, precio);
            LimpiarCampos();
            CargarProductos();
        }

        /// <summary>
        /// Actualiza el producto seleccionado con los nuevos valores ingresados.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para actualizar.",
                    "Producto no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);
            string nombre = txtNombre.Text.Trim();
            decimal precio;

            if (string.IsNullOrEmpty(nombre) || !decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Datos inválidos. Asegúrese de que el nombre no esté vacío y el precio sea numérico.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool actualizado = controller.ActualizarProducto(id, nombre, precio);
            if (actualizado)
            {
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                // Ya se muestra el mensaje de nombre duplicado desde el controlador
            }
        }

        /// <summary>
        /// No implementado, el botón está oculto.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Este botón no se usa
        }

        /// <summary>
        /// Carga el producto seleccionado en los campos de texto.
        /// Solo si el usuario lo selecciona manualmente.
        /// </summary>
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.Focused && dgvProductos.SelectedRows.Count == 1)
            {
                var row = dgvProductos.SelectedRows[0];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = row.Cells["PrecioVenta"].Value.ToString();
            }
        }

        /// <summary>
        /// Limpia los campos de entrada y la selección del DataGridView.
        /// </summary>
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        /// <summary>
        /// Carga todos los productos desde la base de datos.
        /// Desactiva temporalmente el evento SelectionChanged para evitar llenado automático.
        /// </summary>
        private void CargarProductos()
        {
            dgvProductos.SelectionChanged -= dgvProductos_SelectionChanged;

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = controller.ObtenerTodos();
            dgvProductos.ClearSelection();

            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        }

        /// <summary>
        /// Permite agregar un producto presionando Enter desde un campo de texto.
        /// </summary>
        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregar_Click(sender, EventArgs.Empty);
            }
        }
    }
}
