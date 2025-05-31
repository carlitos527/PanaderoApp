namespace PanaderoApp.Forms
{
    partial class FrmVentasFac
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvVentasFac;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtVentaId;
        private System.Windows.Forms.TextBox txtProductoId;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblVentaId;
        private System.Windows.Forms.Label lblProductoId;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentasFac));
            this.dgvVentasFac = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtVentaId = new System.Windows.Forms.TextBox();
            this.txtProductoId = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblVentaId = new System.Windows.Forms.Label();
            this.lblProductoId = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasFac)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVentasFac
            // 
            this.dgvVentasFac.AllowUserToAddRows = false;
            this.dgvVentasFac.AllowUserToDeleteRows = false;
            this.dgvVentasFac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentasFac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVentasFac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasFac.Location = new System.Drawing.Point(28, 19);
            this.dgvVentasFac.Name = "dgvVentasFac";
            this.dgvVentasFac.ReadOnly = true;
            this.dgvVentasFac.RowHeadersWidth = 51;
            this.dgvVentasFac.RowTemplate.Height = 24;
            this.dgvVentasFac.Size = new System.Drawing.Size(650, 410);
            this.dgvVentasFac.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(81, 16);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(52, 22);
            this.txtId.TabIndex = 1;
            // 
            // txtVentaId
            // 
            this.txtVentaId.Location = new System.Drawing.Point(170, 63);
            this.txtVentaId.Name = "txtVentaId";
            this.txtVentaId.Size = new System.Drawing.Size(100, 22);
            this.txtVentaId.TabIndex = 2;
            // 
            // txtProductoId
            // 
            this.txtProductoId.Location = new System.Drawing.Point(170, 111);
            this.txtProductoId.Name = "txtProductoId";
            this.txtProductoId.Size = new System.Drawing.Size(100, 22);
            this.txtProductoId.TabIndex = 3;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(170, 179);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 22);
            this.txtCantidad.TabIndex = 4;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(170, 246);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioUnitario.TabIndex = 5;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblId.Location = new System.Drawing.Point(43, 19);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(32, 18);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "ID :";
            // 
            // lblVentaId
            // 
            this.lblVentaId.AutoSize = true;
            this.lblVentaId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVentaId.Location = new System.Drawing.Point(43, 69);
            this.lblVentaId.Name = "lblVentaId";
            this.lblVentaId.Size = new System.Drawing.Size(76, 18);
            this.lblVentaId.TabIndex = 7;
            this.lblVentaId.Text = "Venta ID :";
            // 
            // lblProductoId
            // 
            this.lblProductoId.AutoSize = true;
            this.lblProductoId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProductoId.Location = new System.Drawing.Point(43, 117);
            this.lblProductoId.Name = "lblProductoId";
            this.lblProductoId.Size = new System.Drawing.Size(98, 18);
            this.lblProductoId.TabIndex = 8;
            this.lblProductoId.Text = "Producto ID :";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCantidad.Location = new System.Drawing.Point(46, 183);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(79, 18);
            this.lblCantidad.TabIndex = 9;
            this.lblCantidad.Text = "Cantidad :";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(43, 250);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(120, 18);
            this.lblPrecioUnitario.TabIndex = 10;
            this.lblPrecioUnitario.Text = "Precio Unitario :";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 327);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 30);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(130, 327);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(29, 374);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblId);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtVentaId);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.lblVentaId);
            this.panel1.Controls.Add(this.txtPrecioUnitario);
            this.panel1.Controls.Add(this.lblPrecioUnitario);
            this.panel1.Controls.Add(this.lblProductoId);
            this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.txtProductoId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 441);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvVentasFac);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(286, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 441);
            this.panel2.TabIndex = 15;
            // 
            // FrmVentasFac
            // 
            this.ClientSize = new System.Drawing.Size(976, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVentasFac";
            this.Text = "Gestión de Ventas Fac";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasFac)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
