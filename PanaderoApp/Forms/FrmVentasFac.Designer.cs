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
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasFac)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVentasFac
            // 
            this.dgvVentasFac.AllowUserToAddRows = false;
            this.dgvVentasFac.AllowUserToDeleteRows = false;
            this.dgvVentasFac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasFac.Location = new System.Drawing.Point(12, 12);
            this.dgvVentasFac.Name = "dgvVentasFac";
            this.dgvVentasFac.ReadOnly = true;
            this.dgvVentasFac.RowHeadersWidth = 51;
            this.dgvVentasFac.RowTemplate.Height = 24;
            this.dgvVentasFac.Size = new System.Drawing.Size(600, 200);
            this.dgvVentasFac.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(120, 230);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 22);
            this.txtId.TabIndex = 1;
            // 
            // txtVentaId
            // 
            this.txtVentaId.Location = new System.Drawing.Point(120, 270);
            this.txtVentaId.Name = "txtVentaId";
            this.txtVentaId.Size = new System.Drawing.Size(100, 22);
            this.txtVentaId.TabIndex = 2;
            // 
            // txtProductoId
            // 
            this.txtProductoId.Location = new System.Drawing.Point(120, 310);
            this.txtProductoId.Name = "txtProductoId";
            this.txtProductoId.Size = new System.Drawing.Size(100, 22);
            this.txtProductoId.TabIndex = 3;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(120, 350);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 22);
            this.txtCantidad.TabIndex = 4;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(120, 390);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(100, 22);
            this.txtPrecioUnitario.TabIndex = 5;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(30, 233);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 17);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "ID";
            // 
            // lblVentaId
            // 
            this.lblVentaId.AutoSize = true;
            this.lblVentaId.Location = new System.Drawing.Point(30, 273);
            this.lblVentaId.Name = "lblVentaId";
            this.lblVentaId.Size = new System.Drawing.Size(68, 17);
            this.lblVentaId.TabIndex = 7;
            this.lblVentaId.Text = "Venta ID";
            // 
            // lblProductoId
            // 
            this.lblProductoId.AutoSize = true;
            this.lblProductoId.Location = new System.Drawing.Point(30, 313);
            this.lblProductoId.Name = "lblProductoId";
            this.lblProductoId.Size = new System.Drawing.Size(85, 17);
            this.lblProductoId.TabIndex = 8;
            this.lblProductoId.Text = "Producto ID";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(30, 353);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(65, 17);
            this.lblCantidad.TabIndex = 9;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(30, 393);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(101, 17);
            this.lblPrecioUnitario.TabIndex = 10;
            this.lblPrecioUnitario.Text = "Precio Unitario";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(350, 230);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 30);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(350, 280);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(350, 330);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmVentasFac
            // 
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblPrecioUnitario);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblProductoId);
            this.Controls.Add(this.lblVentaId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtPrecioUnitario);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtProductoId);
            this.Controls.Add(this.txtVentaId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.dgvVentasFac);
            this.Name = "FrmVentasFac";
            this.Text = "Gestión de Ventas Fac";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasFac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
