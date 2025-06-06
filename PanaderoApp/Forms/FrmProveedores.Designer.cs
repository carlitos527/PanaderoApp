namespace PanaderoApp.Forms
{
    partial class FrmProveedores
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvProveedores;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProveedores));
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(106, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(48, 20);
            this.txtId.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(106, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(223, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(106, 87);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 2;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(3, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 18);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "ID:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(3, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(68, 18);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(3, 84);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(75, 18);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Green;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Location = new System.Drawing.Point(3, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(104, 92);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "✅";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SkyBlue;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(122, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(104, 97);
            this.btnActualizar.TabIndex = 9;
            this.btnActualizar.Text = "✏️";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(241, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 97);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "🚮";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.Location = new System.Drawing.Point(0, 0);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new System.Drawing.Size(859, 271);
            this.dgvProveedores.TabIndex = 11;
            this.dgvProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 219);
            this.panel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btnEliminar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAgregar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnActualizar, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(357, 120);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.58883F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.41117F));
            this.tableLayoutPanel1.Controls.Add(this.lblNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTelefono, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCorreo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCorreo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTelefono, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(34, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 171);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(3, 126);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(60, 18);
            this.lblCorreo.TabIndex = 7;
            this.lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(106, 129);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(318, 20);
            this.txtCorreo.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvProveedores);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 271);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 219);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(496, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(363, 219);
            this.panel4.TabIndex = 14;
            // 
            // FrmProveedores
            // 
            this.ClientSize = new System.Drawing.Size(859, 490);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProveedores";
            this.Text = "Gestión de Proveedores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}
