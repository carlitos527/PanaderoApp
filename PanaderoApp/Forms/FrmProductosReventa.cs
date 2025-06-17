using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PanaderoApp.Forms
{
    /// <summary>
    /// Formulario para gestionar productos y registrar movimientos de stock con comentarios.
    /// </summary>
    public partial class FrmProductosReventa : Form
    {
        /// <summary>
        /// Cadena de conexión extraída del archivo de configuración App.config.
        /// </summary>
        private string connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmProductosReventa"/>.
        /// </summary>
        public FrmProductosReventa()
        {
            InitializeComponent();
            CargarProductos();

            // Oculta botones no usados en esta ventana
            btnAgregar.Visible = false;
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;

            // Evita que se editen manualmente estos campos
            txtNombre.ReadOnly = true;
            txtPrecio.ReadOnly = true;

            // Captura la tecla Enter en txtCantidad para registrar entrada rápidamente
            txtCantidad.KeyDown += TxtCantidad_KeyDown;
        }

        /// <summary>
        /// Carga los productos desde la base de datos y los muestra en el DataGridView.
        /// </summary>
        private void CargarProductos()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Productos";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvProductos.DataSource = dt;
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProductos.ReadOnly = true;
                dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en una fila del DataGridView.
        /// Carga los datos del producto seleccionado en los campos de texto.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento de celda.</param>
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = row.Cells["PrecioVenta"].Value.ToString();
            }
        }

        /// <summary>
        /// Limpia todos los campos de texto del formulario, incluyendo el comentario.
        /// </summary>
        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtComentario.Text = "";
        }

        /// <summary>
        /// Registra un movimiento de stock (entrada o salida) para el producto seleccionado.
        /// </summary>
        /// <param name="tipoMovimiento">Tipo de movimiento ("Entrada" o "Salida").</param>
        /// <param name="cantidad">Cantidad a registrar.</param>
        /// <param name="comentario">Comentario opcional para el movimiento.</param>
        private void RegistrarMovimiento(string tipoMovimiento, decimal cantidad, string comentario = null)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto en la lista.");
                return;
            }

            var selectedRow = dgvProductos.SelectedRows[0];
            int productoId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO StockReventa (ProductoId, TipoMovimiento, Cantidad, Comentario)
                                 VALUES (@productoId, @tipoMovimiento, @cantidad, @comentario)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productoId", productoId);
                cmd.Parameters.AddWithValue("@tipoMovimiento", tipoMovimiento);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@comentario", (object)comentario ?? DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Maneja el clic en el botón para registrar una entrada de stock.
        /// Valida cantidad y registra el movimiento con comentario.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }
            RegistrarMovimiento("Entrada", cantidad, txtComentario.Text);
            MessageBox.Show("Movimiento de entrada registrado.");
            LimpiarCampos();
        }

        /// <summary>
        /// Maneja el clic en el botón para registrar una salida de stock.
        /// Valida cantidad, verifica stock disponible y registra el movimiento con comentario.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto en la lista.");
                return;
            }

            int productoId = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
            decimal stockActual = ObtenerStockActual(productoId);

            if (cantidad > stockActual)
            {
                MessageBox.Show($"Stock insuficiente. Stock actual: {stockActual}");
                return;
            }

            RegistrarMovimiento("Salida", cantidad, txtComentario.Text);
            MessageBox.Show("Movimiento de salida registrado.");
            LimpiarCampos();
        }

        /// <summary>
        /// Obtiene el stock actual para un producto específico calculando entradas menos salidas.
        /// </summary>
        /// <param name="productoId">Identificador del producto.</param>
        /// <returns>Stock actual disponible.</returns>
        private decimal ObtenerStockActual(int productoId)
        {
            decimal entradas = 0, salidas = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string queryEntradas = "SELECT ISNULL(SUM(Cantidad), 0) FROM StockReventa WHERE ProductoId = @id AND TipoMovimiento = 'Entrada'";
                SqlCommand cmdEntradas = new SqlCommand(queryEntradas, con);
                cmdEntradas.Parameters.AddWithValue("@id", productoId);

                string querySalidas = "SELECT ISNULL(SUM(Cantidad), 0) FROM StockReventa WHERE ProductoId = @id AND TipoMovimiento = 'Salida'";
                SqlCommand cmdSalidas = new SqlCommand(querySalidas, con);
                cmdSalidas.Parameters.AddWithValue("@id", productoId);

                con.Open();
                entradas = (decimal)cmdEntradas.ExecuteScalar();
                salidas = (decimal)cmdSalidas.ExecuteScalar();
            }
            return entradas - salidas;
        }

        /// <summary>
        /// Evento para capturar la tecla Enter en el campo de cantidad y registrar entrada.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento de tecla.</param>
        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnRegistrarEntrada.PerformClick(); // Ejecuta entrada de stock con Enter
            }
        }
    }
}
