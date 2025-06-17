using System.Windows.Forms;
using System.ComponentModel;

namespace PanaderoApp.Forms
{
    partial class FrmProductosReventa
    {
        private IContainer components = null;

        private DataGridView dgvProductos;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private TextBox txtComentario;

        private Label lblId;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblCantidad;
        private Label lblFechaVencimiento;
        private Label lblFechaIngreso;

        private Label lblStockActual; // NUEVO LABEL STOCK ACTUAL

        private DateTimePicker dtpFechaVencimiento;
        private DateTimePicker dtpFechaIngreso;

        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnRegistrarEntrada;
        private Button btnRegistrarSalida;
        private Panel panelTabla;
        private Panel panelFormularioContenido;
        private Panel panelBotonesMovimiento;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblStockActual = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRegistrarEntrada = new System.Windows.Forms.Button();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.panelFormularioContenido = new System.Windows.Forms.Panel();
            this.panelBotonesMovimiento = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelTabla = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panelFormularioContenido.SuspendLayout();
            this.panelBotonesMovimiento.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(0, 0);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(632, 669);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(64, 23);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(35, 22);
            this.txtId.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(170, 112);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(250, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(173, 161);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(120, 22);
            this.txtPrecio.TabIndex = 5;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(173, 210);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(120, 22);
            this.txtCantidad.TabIndex = 7;
            // 
            // txtComentario
            // 
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Location = new System.Drawing.Point(95, 349);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(308, 80);
            this.txtComentario.TabIndex = 10;
            // 
            // lblId
            // 
            this.lblId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblId.Location = new System.Drawing.Point(29, 25);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(29, 22);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // lblNombre
            // 
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNombre.Location = new System.Drawing.Point(84, 114);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 22);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrecio.Location = new System.Drawing.Point(93, 161);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(60, 22);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCantidad.Location = new System.Drawing.Point(95, 212);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(60, 22);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(84, 268);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(105, 35);
            this.lblFechaVencimiento.TabIndex = 8;
            this.lblFechaVencimiento.Text = "Fecha Vencimiento:";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFechaIngreso.Location = new System.Drawing.Point(292, 9);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(119, 22);
            this.lblFechaIngreso.TabIndex = 9;
            this.lblFechaIngreso.Text = "Fecha Ingreso:";
            // 
            // lblStockActual
            // 
            this.lblStockActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStockActual.Location = new System.Drawing.Point(126, 23);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(141, 22);
            this.lblStockActual.TabIndex = 11;
            this.lblStockActual.Text = "Stock Actual: 0";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(215, 268);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(120, 22);
            this.dtpFechaVencimiento.TabIndex = 12;
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Enabled = false;
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(291, 41);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(120, 22);
            this.dtpFechaIngreso.TabIndex = 10;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 480);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 35);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(126, 480);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 35);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(263, 471);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 35);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarEntrada
            // 
            this.btnRegistrarEntrada.BackColor = System.Drawing.Color.Green;
            this.btnRegistrarEntrada.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarEntrada.Location = new System.Drawing.Point(66, 18);
            this.btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            this.btnRegistrarEntrada.Size = new System.Drawing.Size(160, 106);
            this.btnRegistrarEntrada.TabIndex = 16;
            this.btnRegistrarEntrada.Text = "Entrada Stock";
            this.btnRegistrarEntrada.UseVisualStyleBackColor = false;
            this.btnRegistrarEntrada.Click += new System.EventHandler(this.btnRegistrarEntrada_Click);
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.Red;
            this.btnRegistrarSalida.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarSalida.Location = new System.Drawing.Point(251, 18);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(160, 106);
            this.btnRegistrarSalida.TabIndex = 17;
            this.btnRegistrarSalida.Text = "Salida Stock";
            this.btnRegistrarSalida.UseVisualStyleBackColor = false;
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);
            // 
            // panelFormularioContenido
            // 
            this.panelFormularioContenido.BackColor = System.Drawing.Color.LightYellow;
            this.panelFormularioContenido.Controls.Add(this.panelBotonesMovimiento);
            this.panelFormularioContenido.Controls.Add(this.textBox1);
            this.panelFormularioContenido.Controls.Add(this.lblId);
            this.panelFormularioContenido.Controls.Add(this.txtId);
            this.panelFormularioContenido.Controls.Add(this.lblNombre);
            this.panelFormularioContenido.Controls.Add(this.txtNombre);
            this.panelFormularioContenido.Controls.Add(this.lblPrecio);
            this.panelFormularioContenido.Controls.Add(this.txtPrecio);
            this.panelFormularioContenido.Controls.Add(this.lblCantidad);
            this.panelFormularioContenido.Controls.Add(this.txtCantidad);
            this.panelFormularioContenido.Controls.Add(this.lblStockActual);
            this.panelFormularioContenido.Controls.Add(this.lblFechaIngreso);
            this.panelFormularioContenido.Controls.Add(this.dtpFechaIngreso);
            this.panelFormularioContenido.Controls.Add(this.lblFechaVencimiento);
            this.panelFormularioContenido.Controls.Add(this.dtpFechaVencimiento);
            this.panelFormularioContenido.Controls.Add(this.txtComentario);
            this.panelFormularioContenido.Controls.Add(this.btnAgregar);
            this.panelFormularioContenido.Controls.Add(this.btnActualizar);
            this.panelFormularioContenido.Controls.Add(this.btnEliminar);
            this.panelFormularioContenido.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFormularioContenido.Location = new System.Drawing.Point(0, 0);
            this.panelFormularioContenido.Name = "panelFormularioContenido";
            this.panelFormularioContenido.Size = new System.Drawing.Size(426, 669);
            this.panelFormularioContenido.TabIndex = 13;
            // 
            // panelBotonesMovimiento
            // 
            this.panelBotonesMovimiento.Controls.Add(this.btnRegistrarEntrada);
            this.panelBotonesMovimiento.Controls.Add(this.btnRegistrarSalida);
            this.panelBotonesMovimiento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotonesMovimiento.Location = new System.Drawing.Point(0, 521);
            this.panelBotonesMovimiento.Name = "panelBotonesMovimiento";
            this.panelBotonesMovimiento.Size = new System.Drawing.Size(426, 148);
            this.panelBotonesMovimiento.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(183, 321);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "Comentario :";
            // 
            // panelTabla
            // 
            this.panelTabla.Controls.Add(this.dgvProductos);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Location = new System.Drawing.Point(426, 0);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(632, 669);
            this.panelTabla.TabIndex = 2;
            // 
            // FrmProductosReventa
            // 
            this.ClientSize = new System.Drawing.Size(1058, 669);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.panelFormularioContenido);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmProductosReventa";
            this.Text = "Gestión de Productos Reventa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panelFormularioContenido.ResumeLayout(false);
            this.panelFormularioContenido.PerformLayout();
            this.panelBotonesMovimiento.ResumeLayout(false);
            this.panelTabla.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TextBox textBox1;
    }
}
