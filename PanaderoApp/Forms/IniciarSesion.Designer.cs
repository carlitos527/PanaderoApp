namespace PanaderoApp.Forms
{
    partial class IniciarSesion
    {
        private void InitializeComponent()
        {
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.Gray;
            this.txtNombreUsuario.Location = new System.Drawing.Point(145, 22);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(167, 20);
            this.txtNombreUsuario.TabIndex = 0;
            this.txtNombreUsuario.Text = "Ingrese nombre de usuario";
            this.txtNombreUsuario.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtNombreUsuario.Leave += new System.EventHandler(this.SetPlaceholderText);
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(145, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Ingrese la contraseña";
            this.txtPassword.Enter += new System.EventHandler(this.RemovePlaceholderText);
            this.txtPassword.Leave += new System.EventHandler(this.SetPlaceholderText);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.Green;
            this.btnIniciarSesion.Location = new System.Drawing.Point(203, 121);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(87, 49);
            this.btnIniciarSesion.TabIndex = 2;
            this.btnIniciarSesion.Text = "✅";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(99, 121);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 49);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "❎";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña:";
            // 
            // IniciarSesion
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(373, 193);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtNombreUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "IniciarSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}