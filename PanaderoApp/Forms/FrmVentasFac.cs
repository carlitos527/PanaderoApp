using PanaderoApp.Controllers;
using PanaderoApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    /// <summary>
    /// Formulario para gestionar las ventas detalladas (VentasFac).
    /// </summary>
    public partial class FrmVentasFac : Form
    {
        // Controlador que maneja la lógica de negocio para ventas detalladas.
        private VentasFacController controller = new VentasFacController();

        // Lista que almacena temporalmente todas las ventas detalladas.
        private List<VentasFac> listaVentasFac = new List<VentasFac>();

        /// <summary>
        /// Constructor del formulario. Inicializa componentes, oculta botones y carga los datos.
        /// </summary>
        public FrmVentasFac()
        {
            InitializeComponent();
            OcultarBotones(); // Oculta los botones de acción
            ConfigurarDataGridView(); // Configura las columnas y formato del DataGridView
            CargarDatos(); // Carga los datos desde la base de datos
        }

        /// <summary>
        /// Oculta los botones de acción (Nuevo, Guardar, Eliminar).
        /// </summary>
        private void OcultarBotones()
        {
            btnNuevo.Visible = false;
            btnGuardar.Visible = false;
            btnEliminar.Visible = false;
        }

        /// <summary>
        /// Configura el DataGridView para mostrar las ventas detalladas.
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvVentasFac.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentasFac.MultiSelect = false;
            dgvVentasFac.ReadOnly = true;
            dgvVentasFac.AutoGenerateColumns = false;

            dgvVentasFac.Columns.Clear();

            // Agrega columnas personalizadas
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
                DefaultCellStyle = { Format = "'$'#,0.00" } // Formato de moneda
            });

            // Evento para detectar selección de fila
            dgvVentasFac.SelectionChanged += DgvVentasFac_SelectionChanged;
        }

        /// <summary>
        /// Carga los datos desde la base de datos y los muestra en el DataGridView.
        /// </summary>
        private void CargarDatos()
        {
            listaVentasFac = controller.ObtenerTodos();
            dgvVentasFac.DataSource = null;
            dgvVentasFac.DataSource = listaVentasFac;
            dgvVentasFac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LimpiarCampos();
        }

        /// <summary>
        /// Limpia todos los campos de entrada del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtVentaId.Clear();
            txtProductoId.Clear();
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
        }

        /// <summary>
        /// Evento del botón "Nuevo". Limpia los campos para ingresar una nueva venta.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>
        /// Evento del botón "Guardar". Guarda o actualiza un registro en la base de datos.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crea el objeto desde los campos del formulario
                var ventaFac = new VentasFac
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    VentaId = int.Parse(txtVentaId.Text),
                    ProductoId = int.Parse(txtProductoId.Text),
                    Cantidad = int.Parse(txtCantidad.Text),
                    PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text)
                };

                // Decide si crear o actualizar
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

        /// <summary>
        /// Evento del botón "Eliminar". Elimina el registro seleccionado.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Seleccione un registro para eliminar");
                return;
            }

            int id = int.Parse(txtId.Text);

            // Confirmación antes de eliminar
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

        /// <summary>
        /// Evento que se ejecuta cuando se selecciona una fila del DataGridView.
        /// Muestra los datos seleccionados en los campos del formulario.
        /// </summary>
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
