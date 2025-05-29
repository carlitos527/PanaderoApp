using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class FrmRecetas : Form
    {
        private RecetasController recetasController = new RecetasController();
        private ProductosController productosController = new ProductosController(); // Necesitas este controlador para llenar cbProductos
        private IngredienteController ingredientesController = new IngredienteController(); // Y este para cbIngredientes
        private int? recetaSeleccionadaId = null;

        public FrmRecetas()
        {
            InitializeComponent();
            CargarProductos();
            CargarIngredientes();
            CargarRecetas();
        }

        private void CargarProductos()
        {
            var productos = productosController.ObtenerTodos();
            cbProductos.DataSource = productos;
            cbProductos.DisplayMember = "Nombre";
            cbProductos.ValueMember = "Id";
        }

        private void CargarIngredientes()
        {
            var ingredientes = ingredientesController.ObtenerIngredientes();
            cbIngredientes.DataSource = ingredientes;
            cbIngredientes.DisplayMember = "Nombre";
            cbIngredientes.ValueMember = "Id";
        }

        private void CargarRecetas()
        {
            var recetas = recetasController.ObtenerTodas();
            dgvRecetas.DataSource = recetas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                int productoId = (int)cbProductos.SelectedValue;
                int ingredienteId = (int)cbIngredientes.SelectedValue;
                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad))
                {
                    MessageBox.Show("Cantidad no válida.");
                    return;
                }

                recetasController.AgregarReceta(productoId, ingredienteId, cantidad);
                MessageBox.Show("Receta agregada.");
                CargarRecetas();
                LimpiarCampos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (recetaSeleccionadaId == null)
            {
                MessageBox.Show("Selecciona una receta para actualizar.");
                return;
            }

            if (ValidarCampos())
            {
                int productoId = (int)cbProductos.SelectedValue;
                int ingredienteId = (int)cbIngredientes.SelectedValue;
                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad))
                {
                    MessageBox.Show("Cantidad no válida.");
                    return;
                }

                bool exito = recetasController.ActualizarReceta(recetaSeleccionadaId.Value, productoId, ingredienteId, cantidad);
                if (exito)
                {
                    MessageBox.Show("Receta actualizada.");
                    CargarRecetas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar receta.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (recetaSeleccionadaId == null)
            {
                MessageBox.Show("Selecciona una receta para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Seguro que deseas eliminar la receta seleccionada?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool exito = recetasController.EliminarReceta(recetaSeleccionadaId.Value);
                if (exito)
                {
                    MessageBox.Show("Receta eliminada.");
                    CargarRecetas();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar receta.");
                }
            }
        }

        private void dgvRecetas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecetas.CurrentRow != null && dgvRecetas.CurrentRow.DataBoundItem != null)
            {
                Recetas receta = (Recetas)dgvRecetas.CurrentRow.DataBoundItem;
                recetaSeleccionadaId = receta.Id;
                cbProductos.SelectedValue = receta.ProductoId;
                cbIngredientes.SelectedValue = receta.IngredienteId;
                txtCantidad.Text = receta.Cantidad.ToString();
            }
        }

        private bool ValidarCampos()
        {
            if (cbProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un producto.");
                return false;
            }

            if (cbIngredientes.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un ingrediente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Ingresa la cantidad.");
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            recetaSeleccionadaId = null;
            cbProductos.SelectedIndex = -1;
            cbIngredientes.SelectedIndex = -1;
            txtCantidad.Clear();
            dgvRecetas.ClearSelection();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
