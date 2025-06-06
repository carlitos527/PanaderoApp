namespace PanaderoApp.Forms
{
    partial class FrmIngredientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngredientes));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(154, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtUnidad
            // 
            this.txtUnidad.Location = new System.Drawing.Point(154, 68);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(200, 20);
            this.txtUnidad.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(154, 102);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(200, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIngredientes.Location = new System.Drawing.Point(0, 0);
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.Size = new System.Drawing.Size(712, 239);
            this.dgvIngredientes.TabIndex = 4;
            this.dgvIngredientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngredientes_CellClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(81, 83);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "✅";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Turquoise;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(223, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(85, 81);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "✏️";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(113, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 83);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "🚮";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(32, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(68, 18);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnidad.Location = new System.Drawing.Point(32, 72);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(63, 18);
            this.lblUnidad.TabIndex = 3;
            this.lblUnidad.Text = "Unidad:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(32, 104);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(116, 18);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio Unitario:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(40, 20);
            this.txtId.TabIndex = 0;
            this.txtId.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 141);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvIngredientes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 239);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(374, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 141);
            this.panel3.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnAgregar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminar, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(332, 100);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblNombre);
            this.panel4.Controls.Add(this.lblUnidad);
            this.panel4.Controls.Add(this.txtId);
            this.panel4.Controls.Add(this.txtPrecio);
            this.panel4.Controls.Add(this.lblPrecio);
            this.panel4.Controls.Add(this.txtUnidad);
            this.panel4.Controls.Add(this.txtNombre);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(374, 141);
            this.panel4.TabIndex = 7;
            // 
            // FrmIngredientes
            // 
            this.ClientSize = new System.Drawing.Size(712, 380);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmIngredientes";
            this.Text = "Gestión de Ingredientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
    }
}
