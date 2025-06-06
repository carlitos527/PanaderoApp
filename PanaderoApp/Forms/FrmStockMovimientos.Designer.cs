namespace PanaderoApp.Forms
{
    partial class FrmStockMovimientos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockMovimientos));
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.comboIngredientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioEntrada = new System.Windows.Forms.RadioButton();
            this.radioSalida = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvStockActual = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockActual)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.Location = new System.Drawing.Point(0, 0);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(884, 591);
            this.dgvMovimientos.TabIndex = 0;
            this.dgvMovimientos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellClick);
            // 
            // comboIngredientes
            // 
            this.comboIngredientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIngredientes.Location = new System.Drawing.Point(193, 29);
            this.comboIngredientes.Name = "comboIngredientes";
            this.comboIngredientes.Size = new System.Drawing.Size(200, 21);
            this.comboIngredientes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 26;
            this.label1.Text = "Ingrediente:";
            // 
            // radioEntrada
            // 
            this.radioEntrada.AutoSize = true;
            this.radioEntrada.Checked = true;
            this.radioEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEntrada.Location = new System.Drawing.Point(193, 74);
            this.radioEntrada.Name = "radioEntrada";
            this.radioEntrada.Size = new System.Drawing.Size(79, 20);
            this.radioEntrada.TabIndex = 25;
            this.radioEntrada.TabStop = true;
            this.radioEntrada.Text = "Entrada";
            // 
            // radioSalida
            // 
            this.radioSalida.AutoSize = true;
            this.radioSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSalida.Location = new System.Drawing.Point(296, 76);
            this.radioSalida.Name = "radioSalida";
            this.radioSalida.Size = new System.Drawing.Size(60, 17);
            this.radioSalida.TabIndex = 24;
            this.radioSalida.Text = "Salida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Cantidad:";
            // 
            // numericCantidad
            // 
            this.numericCantidad.DecimalPlaces = 2;
            this.numericCantidad.Location = new System.Drawing.Point(193, 103);
            this.numericCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(79, 20);
            this.numericCantidad.TabIndex = 22;
            this.numericCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(193, 145);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(200, 60);
            this.txtComentario.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(220, 239);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(138, 20);
            this.dtpFecha.TabIndex = 18;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Location = new System.Drawing.Point(39, 285);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 93);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "✅";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(296, 285);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(97, 93);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "🚮";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(166, 285);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(93, 93);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(362, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 595);
            this.panel1.TabIndex = 27;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dgvMovimientos);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(888, 595);
            this.panel4.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvStockActual);
            this.panel2.Controls.Add(this.comboIngredientes);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.radioEntrada);
            this.panel2.Controls.Add(this.btnLimpiar);
            this.panel2.Controls.Add(this.radioSalida);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpFecha);
            this.panel2.Controls.Add(this.numericCantidad);
            this.panel2.Controls.Add(this.txtComentario);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 595);
            this.panel2.TabIndex = 1;
            // 
            // dgvStockActual
            // 
            this.dgvStockActual.AllowUserToAddRows = false;
            this.dgvStockActual.AllowUserToDeleteRows = false;
            this.dgvStockActual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStockActual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStockActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockActual.Location = new System.Drawing.Point(18, 384);
            this.dgvStockActual.Name = "dgvStockActual";
            this.dgvStockActual.ReadOnly = true;
            this.dgvStockActual.RowHeadersVisible = false;
            this.dgvStockActual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockActual.Size = new System.Drawing.Size(390, 186);
            this.dgvStockActual.TabIndex = 14;
            // 
            // FrmStockMovimientos
            // 
            this.ClientSize = new System.Drawing.Size(1250, 595);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmStockMovimientos";
            this.Text = "Gestión de Movimientos de Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStockMovimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockActual)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.ComboBox comboIngredientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioEntrada;
        private System.Windows.Forms.RadioButton radioSalida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvStockActual;
    }
}
