namespace PanaderoApp.Forms
{
    partial class FrmUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegistrar;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.Gray;
            this.txtNombreUsuario.Location = new System.Drawing.Point(30, 30);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(200, 20);
            this.txtNombreUsuario.TabIndex = 0;
            this.txtNombreUsuario.Text = "Ingrese nombre de usuario";
            this.txtNombreUsuario.GotFocus += new System.EventHandler(this.RemovePlaceholderText);
            this.txtNombreUsuario.LostFocus += new System.EventHandler(this.SetPlaceholderText);
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(30, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Ingrese la contraseña";
            this.txtPassword.GotFocus += new System.EventHandler(this.RemovePlaceholderText);
            this.txtPassword.LostFocus += new System.EventHandler(this.SetPlaceholderText);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.Green;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(139, 119);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(91, 57);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "👥";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(41, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 53);
            this.button1.TabIndex = 3;
            this.button1.Text = "◀️◀️";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Atras_Click);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(280, 180);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtNombreUsuario);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Usuario";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
    }
}
