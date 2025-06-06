namespace PanaderoApp.Forms
{
    partial class FrmRecetas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRecetas;
        private System.Windows.Forms.ComboBox cbProductos;
        private System.Windows.Forms.ComboBox cbIngredientes;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecetas));
            this.dgvRecetas = new System.Windows.Forms.DataGridView();
            this.cbProductos = new System.Windows.Forms.ComboBox();
            this.cbIngredientes = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRecetas
            // 
            this.dgvRecetas.AllowUserToAddRows = false;
            this.dgvRecetas.AllowUserToDeleteRows = false;
            this.dgvRecetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecetas.Location = new System.Drawing.Point(0, 0);
            this.dgvRecetas.MultiSelect = false;
            this.dgvRecetas.Name = "dgvRecetas";
            this.dgvRecetas.ReadOnly = true;
            this.dgvRecetas.RowHeadersVisible = false;
            this.dgvRecetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecetas.Size = new System.Drawing.Size(914, 308);
            this.dgvRecetas.TabIndex = 0;
            this.dgvRecetas.SelectionChanged += new System.EventHandler(this.dgvRecetas_SelectionChanged);
            // 
            // cbProductos
            // 
            this.cbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductos.FormattingEnabled = true;
            this.cbProductos.Location = new System.Drawing.Point(116, 3);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(200, 21);
            this.cbProductos.TabIndex = 2;
            // 
            // cbIngredientes
            // 
            this.cbIngredientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIngredientes.FormattingEnabled = true;
            this.cbIngredientes.Location = new System.Drawing.Point(116, 36);
            this.cbIngredientes.Name = "cbIngredientes";
            this.cbIngredientes.Size = new System.Drawing.Size(200, 21);
            this.cbIngredientes.TabIndex = 4;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(116, 69);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 6;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(3, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(75, 18);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "Producto:";
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIngrediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrediente.Location = new System.Drawing.Point(3, 33);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(91, 18);
            this.lblIngrediente.TabIndex = 3;
            this.lblIngrediente.Text = "Ingrediente:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(3, 66);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(75, 18);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(103, 94);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "✅";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SkyBlue;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(122, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(103, 94);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "✏️";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(360, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 94);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "🚮";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(241, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(103, 94);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 151);
            this.panel1.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.btnEliminar, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAgregar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnActualizar, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnLimpiar, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(20, 34);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(476, 100);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.11267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.88732F));
            this.tableLayoutPanel1.Controls.Add(this.lblProducto, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIngrediente, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCantidad, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbProductos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCantidad, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbIngredientes, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(355, 100);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvRecetas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(914, 308);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 151);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(406, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(508, 151);
            this.panel4.TabIndex = 15;
            // 
            // FrmRecetas
            // 
            this.ClientSize = new System.Drawing.Size(914, 459);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmRecetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Recetas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}
