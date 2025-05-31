using FontAwesome.Sharp;
using System.Windows.Controls;
using System.Windows.Forms;


namespace PanaderoApp.Forms
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private IconButton btnClientes;
        private IconButton btnProductos;
        private IconButton btnProveedores;
        private IconButton btnRecetas;
        private IconButton btnVender;
        private IconButton btnFacturas;
        private IconButton btnIngredientes; // Agregado

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.btnIngredientes = new FontAwesome.Sharp.IconButton();
            this.btnProductos = new FontAwesome.Sharp.IconButton();
            this.btnProveedores = new FontAwesome.Sharp.IconButton();
            this.btnRecetas = new FontAwesome.Sharp.IconButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnVender = new FontAwesome.Sharp.IconButton();
            this.btnFacturas = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnClientes.ForeColor = System.Drawing.Color.Black;
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnClientes.IconColor = System.Drawing.Color.Black;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.IconSize = 32;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(3, 48);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnClientes.Size = new System.Drawing.Size(249, 80);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.Clientes_Click);
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngredientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnIngredientes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIngredientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnIngredientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnIngredientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngredientes.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnIngredientes.ForeColor = System.Drawing.Color.Black;
            this.btnIngredientes.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnIngredientes.IconColor = System.Drawing.Color.Black;
            this.btnIngredientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngredientes.IconSize = 32;
            this.btnIngredientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngredientes.Location = new System.Drawing.Point(258, 48);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnIngredientes.Size = new System.Drawing.Size(249, 80);
            this.btnIngredientes.TabIndex = 1;
            this.btnIngredientes.Text = "Inventario de Ingredientes";
            this.btnIngredientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngredientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngredientes.UseVisualStyleBackColor = true;
            this.btnIngredientes.Click += new System.EventHandler(this.Ingredientes_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProductos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnProductos.ForeColor = System.Drawing.Color.Black;
            this.btnProductos.IconChar = FontAwesome.Sharp.IconChar.Store;
            this.btnProductos.IconColor = System.Drawing.Color.Black;
            this.btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProductos.IconSize = 32;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(3, 197);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnProductos.Size = new System.Drawing.Size(249, 62);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Catálogo de Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.Productos_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProveedores.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnProveedores.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnProveedores.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.btnProveedores.IconColor = System.Drawing.Color.DarkSlateGray;
            this.btnProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProveedores.IconSize = 34;
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(258, 199);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnProveedores.Size = new System.Drawing.Size(249, 60);
            this.btnProveedores.TabIndex = 3;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.Proveedores_Click);
            // 
            // btnRecetas
            // 
            this.btnRecetas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecetas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRecetas.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnRecetas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRecetas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecetas.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnRecetas.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRecetas.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.btnRecetas.IconColor = System.Drawing.Color.MidnightBlue;
            this.btnRecetas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecetas.IconSize = 38;
            this.btnRecetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecetas.Location = new System.Drawing.Point(513, 48);
            this.btnRecetas.Name = "btnRecetas";
            this.btnRecetas.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnRecetas.Size = new System.Drawing.Size(249, 80);
            this.btnRecetas.TabIndex = 4;
            this.btnRecetas.Text = "Formulación";
            this.btnRecetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecetas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.btnRecetas, "Abrir la gestión de recetas y fórmulas de productos.");
            this.btnRecetas.UseVisualStyleBackColor = true;
            this.btnRecetas.Click += new System.EventHandler(this.Recetas_Click);
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnVender.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVender.ForeColor = System.Drawing.Color.White;
            this.btnVender.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnVender.IconColor = System.Drawing.Color.White;
            this.btnVender.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVender.IconSize = 36;
            this.btnVender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVender.Location = new System.Drawing.Point(513, 193);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(249, 66);
            this.btnVender.TabIndex = 5;
            this.btnVender.Text = "Realizar Venta";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVender.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Click += new System.EventHandler(this.Vender_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnFacturas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFacturas.ForeColor = System.Drawing.Color.White;
            this.btnFacturas.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.btnFacturas.IconColor = System.Drawing.Color.White;
            this.btnFacturas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFacturas.IconSize = 32;
            this.btnFacturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturas.Location = new System.Drawing.Point(258, 339);
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(249, 52);
            this.btnFacturas.TabIndex = 6;
            this.btnFacturas.Text = "Ver Productos Vendidos";
            this.btnFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturas.UseVisualStyleBackColor = false;
            this.btnFacturas.Click += new System.EventHandler(this.Facturas_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnClientes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFacturas, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnIngredientes, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnVender, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnProveedores, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnProductos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRecetas, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 394);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       // private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;
        //private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button Vender;
        private System.Windows.Forms.Button Facturas;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
