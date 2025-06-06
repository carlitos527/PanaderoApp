namespace PanaderoApp.Forms
{
    partial class FrmVenta
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnQuitarProducto;
        private System.Windows.Forms.Button btnGuardarVenta;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnQuitarProducto = new System.Windows.Forms.Button();
            this.btnGuardarVenta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 66);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(336, 287);
            this.dgvProductos.TabIndex = 0;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(21, 13);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(616, 351);
            this.dgvDetalles.TabIndex = 1;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(149, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(115, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // txtTotal
            // 
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTotal.Location = new System.Drawing.Point(492, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(130, 22);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFecha.Location = new System.Drawing.Point(64, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(56, 18);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Location = new System.Drawing.Point(433, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 27);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Total:";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAgregarProducto.Location = new System.Drawing.Point(20, 382);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(100, 88);
            this.btnAgregarProducto.TabIndex = 6;
            this.btnAgregarProducto.Text = "🛒";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnQuitarProducto
            // 
            this.btnQuitarProducto.BackColor = System.Drawing.Color.Red;
            this.btnQuitarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarProducto.Location = new System.Drawing.Point(161, 382);
            this.btnQuitarProducto.Name = "btnQuitarProducto";
            this.btnQuitarProducto.Size = new System.Drawing.Size(103, 88);
            this.btnQuitarProducto.TabIndex = 7;
            this.btnQuitarProducto.Text = "❎";
            this.btnQuitarProducto.UseVisualStyleBackColor = false;
            this.btnQuitarProducto.Click += new System.EventHandler(this.btnQuitarProducto_Click);
            // 
            // btnGuardarVenta
            // 
            this.btnGuardarVenta.BackColor = System.Drawing.Color.Green;
            this.btnGuardarVenta.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarVenta.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuardarVenta.Location = new System.Drawing.Point(526, 30);
            this.btnGuardarVenta.Name = "btnGuardarVenta";
            this.btnGuardarVenta.Size = new System.Drawing.Size(96, 67);
            this.btnGuardarVenta.TabIndex = 8;
            this.btnGuardarVenta.Text = "✅";
            this.btnGuardarVenta.UseVisualStyleBackColor = false;
            this.btnGuardarVenta.Click += new System.EventHandler(this.btnGuardarVenta_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Controls.Add(this.btnQuitarProducto);
            this.panel1.Controls.Add(this.btnAgregarProducto);
            this.panel1.Controls.Add(this.dgvProductos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 482);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvDetalles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(353, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 482);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 382);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 100);
            this.panel3.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.24012F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.24F));
            this.tableLayoutPanel1.Controls.Add(this.lblTotal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardarVenta, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTotal, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 100);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // FrmVenta
            // 
            this.ClientSize = new System.Drawing.Size(1011, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVenta";
            this.Text = "Registrar Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
