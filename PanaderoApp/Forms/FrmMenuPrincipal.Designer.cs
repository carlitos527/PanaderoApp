using FontAwesome.Sharp;

namespace PanaderoApp.Forms
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private IconButton btnClientes;
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
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.btnIngredientes = new FontAwesome.Sharp.IconButton(); // Agregado

            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnClientes.IconColor = System.Drawing.Color.Black;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.IconSize = 32;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(94, 68);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(181, 80);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.Clientes_Click);
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.IconChar = FontAwesome.Sharp.IconChar.Carrot;
            this.btnIngredientes.IconColor = System.Drawing.Color.Black;
            this.btnIngredientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngredientes.IconSize = 32;
            this.btnIngredientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngredientes.Location = new System.Drawing.Point(378, 68);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Size = new System.Drawing.Size(220, 80);
            this.btnIngredientes.TabIndex = 1;
            this.btnIngredientes.Text = "Inventario de Ingredientes";
            this.btnIngredientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngredientes.UseVisualStyleBackColor = true;
            this.btnIngredientes.Click += new System.EventHandler(this.Ingredientes_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIngredientes);
            this.Controls.Add(this.btnClientes);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);
        }
    }
}
