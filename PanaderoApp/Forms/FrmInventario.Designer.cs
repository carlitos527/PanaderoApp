﻿using FontAwesome.Sharp;

namespace PanaderoApp.Forms
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer components = null;
        private IconButton btnIngredientes;
        private IconButton btnStockMovimientos;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventario));
            this.btnIngredientes = new FontAwesome.Sharp.IconButton();
            this.btnStockMovimientos = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnIngredientes.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnIngredientes.IconColor = System.Drawing.Color.Black;
            this.btnIngredientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngredientes.IconSize = 32;
            this.btnIngredientes.Location = new System.Drawing.Point(50, 40);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Size = new System.Drawing.Size(200, 60);
            this.btnIngredientes.TabIndex = 0;
            this.btnIngredientes.Text = "Consultar Ingredientes";
            this.btnIngredientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngredientes.UseVisualStyleBackColor = false;
            this.btnIngredientes.Click += new System.EventHandler(this.Ingredintes_Click);
            // 
            // btnStockMovimientos
            // 
            this.btnStockMovimientos.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStockMovimientos.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.btnStockMovimientos.IconColor = System.Drawing.Color.Black;
            this.btnStockMovimientos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStockMovimientos.IconSize = 32;
            this.btnStockMovimientos.Location = new System.Drawing.Point(50, 120);
            this.btnStockMovimientos.Name = "btnStockMovimientos";
            this.btnStockMovimientos.Size = new System.Drawing.Size(200, 60);
            this.btnStockMovimientos.TabIndex = 1;
            this.btnStockMovimientos.Text = "Movimientos de Stock";
            this.btnStockMovimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockMovimientos.UseVisualStyleBackColor = false;
            this.btnStockMovimientos.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmInventario
            // 
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.btnStockMovimientos);
            this.Controls.Add(this.btnIngredientes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);

        }
    }
}
