using PanaderoApp.Class;
using PanaderoApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanaderoApp.Forms
{
    public partial class IniciarSesion : Form
    {

        private readonly UsuarioController _usuarioController;

        public IniciarSesion()
        {
            InitializeComponent();

            // Leer la cadena de conexión desde el archivo de configuración
            string connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
            _usuarioController = new UsuarioController(connectionString);
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string password = txtPassword.Text;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                // Verificar si el usuario existe en la base de datos obteniéndolo por el nombre de usuario
                var usuario = _usuarioController.ObtenerUsuarioPorNombre(nombreUsuario); // Asegúrate de que este método solo busque por nombre de usuario

                if (usuario != null)
                {
                    // Usar PasswordHelper para verificar la contraseña ingresada con la almacenada
                    if (PasswordHelper.VerifyPassword(password, usuario.Password))
                    {
                        // Inicio de sesión exitoso
                        this.Hide(); // Oculta el formulario de inicio de sesión

                        // Muestra el formulario Contabilidad
                        FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal();
                        frmMenuPrincipal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual y muestra el formulario Bienvenido
            Bienvenido bienvenidoForm = Bienvenido.Instance; // Usa la instancia global de Bienvenido
            bienvenidoForm.Show();
            this.Close();
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Ingrese nombre de usuario" || textBox.Text == "Ingrese la contraseña")
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;

                // Si es el campo de contraseña, cambia el carácter de contraseña
                if (textBox == txtPassword)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void SetPlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.ForeColor = System.Drawing.Color.Gray;

                if (textBox == txtNombreUsuario)
                {
                    textBox.Text = "Ingrese nombre de usuario";
                }
                else if (textBox == txtPassword)
                {
                    textBox.Text = "Ingrese la contraseña";
                    textBox.UseSystemPasswordChar = false; // Desactiva el carácter de contraseña
                }
            }
        }

    }
}
