using System;
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
            CargarIngredientes();
        }

        private void CargarIngredientes()
        {
            var ingredientes = controller.ObtenerIngredientes();
            dgvIngredientes.DataSource = ingredientes;
            dgvIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtUnidad.Text = "";
            txtPrecio.Text = "";
        }
    }
}
