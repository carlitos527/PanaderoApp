using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class FrmVentasFac : Form
    {
        private VentasFacController controller = new VentasFacController();
        private List<VentasFac> listaVentasFac = new List<VentasFac>();

        public FrmVentasFac()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatos();
        }

        private void ConfigurarDataGridView()
        {
            dgvVentasFac.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentasFac.MultiSelect = false;
            dgvVentasFac.ReadOnly = true;
            dgvVentasFac.AutoGenerateColumns = false;

            dgvVentasFac.Columns.Clear();
            dgvVentasFac.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });
            dgvVentasFac.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "VentaId",
                DataPropertyName = "VentaId",
                HeaderText = "Venta ID",
                Width = 70
            });
            dgvVentasFac.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ProductoId",
                DataPropertyName = "ProductoId",
                HeaderText = "Producto ID",
                Width = 70
            });
            dgvVentasFac.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Cantidad",
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                Width = 70
            });
            dgvVentasFac.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PrecioUnitario",
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                Width = 100,
                DefaultCellStyle = { Format = "'$'#,0.00" }  // <-- aquí está el cambio
            });

            dgvVentasFac.SelectionChanged += DgvVentasFac_SelectionChanged;
        }

        private void CargarDatos()
        {
            listaVentasFac = controller.ObtenerTodos();
            dgvVentasFac.DataSource = null;
            dgvVentasFac.DataSource = listaVentasFac;
            dgvVentasFac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtVentaId.Clear();
            txtProductoId.Clear();
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var ventaFac = new VentasFac
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    VentaId = int.Parse(txtVentaId.Text),
                    ProductoId = int.Parse(txtProductoId.Text),
                    Cantidad = int.Parse(txtCantidad.Text),
                    PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text)
                };

                bool resultado = ventaFac.Id == 0 ? controller.Crear(ventaFac) : controller.Actualizar(ventaFac);

                if (resultado)
                {
                    MessageBox.Show("Operación exitosa");
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error en la operación");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Seleccione un registro para eliminar");
                return;
            }

            int id = int.Parse(txtId.Text);

            var confirm = MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool resultado = controller.Eliminar(id);
                if (resultado)
                {
                    MessageBox.Show("Registro eliminado");
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar");
                }
            }
        }

        private void DgvVentasFac_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVentasFac.CurrentRow != null)
            {
                txtId.Text = dgvVentasFac.CurrentRow.Cells["Id"].Value.ToString();
                txtVentaId.Text = dgvVentasFac.CurrentRow.Cells["VentaId"].Value.ToString();
                txtProductoId.Text = dgvVentasFac.CurrentRow.Cells["ProductoId"].Value.ToString();
                txtCantidad.Text = dgvVentasFac.CurrentRow.Cells["Cantidad"].Value.ToString();
                txtPrecioUnitario.Text = dgvVentasFac.CurrentRow.Cells["PrecioUnitario"].Value.ToString();
            }
        }
    }
}
