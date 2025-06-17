using System;
using System.Linq;
using System.Windows.Forms;
using PanaderoApp.Models;
using PanaderoApp.Controllers;

namespace PanaderoApp.Forms
{
    public partial class FrmIngredientes : Form
    {
        private IngredienteController controller = new IngredienteController();

        public FrmIngredientes()
        {
            InitializeComponent();

            // 🔒 Ocultar elementos no deseados en la interfaz
            btnEliminar.Visible = false;
            txtId.Visible = false;

            // 🔒 Deshabilitar el botón Actualizar hasta que se seleccione un ingrediente
            btnActualizar.Enabled = false;

            // ✅ Asignar el botón Agregar como botón por defecto (Enter lo activa)
            this.AcceptButton = btnAgregar;

            // Evento para búsqueda
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            AgregarPlaceholders(); // 👈 Agregamos los placeholders

            CargarIngredientes();
        }

        private void CargarIngredientes()
        {
            var ingredientes = controller.ObtenerIngredientes();
            dgvIngredientes.DataSource = ingredientes;
            dgvIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.ForeColor == System.Drawing.Color.Gray) return;

            string texto = txtBuscar.Text.ToLower();
            var ingredientes = controller.ObtenerIngredientes();
            var filtrados = ingredientes
                .Where(i => i.Nombre.ToLower().Contains(texto))
                .ToList();

            dgvIngredientes.DataSource = filtrados;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Ingrediente ingrediente = new Ingrediente
                {
                    Nombre = txtNombre.Text,
                    Unidad = txtUnidad.Text,
                    PrecioUnitario = decimal.Parse(txtPrecio.Text)
                };

                controller.CrearIngrediente(ingrediente);
                CargarIngredientes();
                LimpiarCampos();
                MessageBox.Show("Ingrediente agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Ingrediente ingrediente = new Ingrediente
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Unidad = txtUnidad.Text,
                    PrecioUnitario = decimal.Parse(txtPrecio.Text)
                };

                controller.ActualizarIngrediente(ingrediente);
                CargarIngredientes();
                LimpiarCampos();
                MessageBox.Show("Ingrediente actualizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                controller.EliminarIngrediente(id);
                CargarIngredientes();
                LimpiarCampos();
                MessageBox.Show("Ingrediente eliminado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dgvIngredientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvIngredientes.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvIngredientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtUnidad.Text = dgvIngredientes.Rows[e.RowIndex].Cells["Unidad"].Value.ToString();
                txtPrecio.Text = dgvIngredientes.Rows[e.RowIndex].Cells["PrecioUnitario"].Value.ToString();

                txtNombre.ForeColor = System.Drawing.Color.Black;
                txtUnidad.ForeColor = System.Drawing.Color.Black;
                txtPrecio.ForeColor = System.Drawing.Color.Black;

                btnActualizar.Enabled = true;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtBuscar.Text = "";
            btnActualizar.Enabled = false;

            SetPlaceholder(txtNombre, "Ej. Harina de trigo");
            SetPlaceholder(txtUnidad, "Ej. kg, lt, unidad...");
            SetPlaceholder(txtPrecio, "Ej. 5.25");
        }

        // 📝 Método para simular placeholders
        private void AgregarPlaceholders()
        {
            SetPlaceholder(txtBuscar, "Buscar por nombre...");
            SetPlaceholder(txtNombre, "Ej. Harina de trigo");
            SetPlaceholder(txtUnidad, "Ej. kg, lt, unidad...");
            SetPlaceholder(txtPrecio, "Ej. 5.25");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.Color.Gray;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }
    }
}
