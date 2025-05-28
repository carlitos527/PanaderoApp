using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PanaderoApp.Controllers;
using PanaderoApp.Models;

namespace PanaderoApp.Forms
{
    public partial class FrmStockMovimientos : Form
    {
        private StockMovimientosController controlador = new StockMovimientosController();
        private List<Ingrediente> ingredientes;  // Necesitamos obtenerlos para el ComboBox
        private int? idMovimientoSeleccionado = null;

        public FrmStockMovimientos()
        {
            InitializeComponent();
        }

        private void FrmStockMovimientos_Load(object sender, EventArgs e)
        {
            CargarIngredientes();
            CargarMovimientos();
            CargarStockActual(); // Aquí cargamos el stock acumulado
            radioEntrada.Checked = true;
            dtpFecha.Value = DateTime.Now;
        }
        private void CargarStockActual()
        {
            var listaStock = controlador.ObtenerStockActual();
            dgvStockActual.DataSource = listaStock;

            // Cambiar nombre de columna
            dgvStockActual.Columns["IngredienteNombre"].HeaderText = "Nombre";
        }
        private void CargarIngredientes()
        {
            // Aquí simulo obtener la lista de ingredientes
            // Si tienes controlador Ingredientes, llama al método para obtenerlos
            IngredienteController ingCtrl = new IngredienteController();
            ingredientes = ingCtrl.ObtenerIngredientes();

            comboIngredientes.DisplayMember = "Nombre";
            comboIngredientes.ValueMember = "Id";
            comboIngredientes.DataSource = ingredientes;
        }

        private void CargarMovimientos()
        {
            dgvMovimientos.DataSource = null;
            var lista = controlador.ObtenerMovimientos();
            dgvMovimientos.DataSource = lista;

            // Cambiar encabezado visual
            dgvMovimientos.Columns["IngredienteNombre"].HeaderText = "Nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                StockMovimiento mov = new StockMovimiento
                {
                    IngredienteId = (int)comboIngredientes.SelectedValue,
                    TipoMovimiento = radioEntrada.Checked ? "Entrada" : "Salida",
                    Cantidad = numericCantidad.Value,
                    Fecha = dtpFecha.Value,
                    Comentario = txtComentario.Text.Trim()
                };

                if (idMovimientoSeleccionado == null)
                {
                    controlador.CrearMovimiento(mov);
                    MessageBox.Show("Movimiento registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    mov.Id = idMovimientoSeleccionado.Value;
                    controlador.ActualizarMovimiento(mov);
                    MessageBox.Show("Movimiento actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    idMovimientoSeleccionado = null;
                }

                LimpiarFormulario();
                CargarMovimientos();
                CargarStockActual(); // <-- Agrega esta línea
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (comboIngredientes.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un ingrediente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            comboIngredientes.SelectedIndex = 0;
            radioEntrada.Checked = true;
            numericCantidad.Value = 1;
            txtComentario.Clear();
            dtpFecha.Value = DateTime.Now;
            idMovimientoSeleccionado = null;
            btnGuardar.Text = "Guardar";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idMovimientoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un movimiento para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro que desea eliminar el movimiento seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    controlador.EliminarMovimiento(idMovimientoSeleccionado.Value);
                    MessageBox.Show("Movimiento eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarMovimientos();
                    CargarStockActual(); // <-- Agrega esta línea
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvMovimientos.Rows[e.RowIndex];
                idMovimientoSeleccionado = (int)fila.Cells["Id"].Value;

                comboIngredientes.SelectedValue = (int)fila.Cells["IngredienteId"].Value;
                var tipo = fila.Cells["TipoMovimiento"].Value.ToString();
                radioEntrada.Checked = tipo == "Entrada";
                radioSalida.Checked = tipo == "Salida";
                numericCantidad.Value = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                txtComentario.Text = fila.Cells["Comentario"].Value?.ToString() ?? "";

                btnGuardar.Text = "Actualizar";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
