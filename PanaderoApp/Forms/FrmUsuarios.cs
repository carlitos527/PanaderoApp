using PanaderoApp.Controllers;
using PanaderoApp.Models;
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
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioController _usuarioController;

        public FrmUsuarios()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["PanaderiaConnection"].ConnectionString;
            _usuarioController = new UsuarioController(connectionString);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                var usuario = new Usuario
                {
                    NombreUsuario = nombreUsuario,
                    Password = password // Asegúrate de que el PasswordHelper hash la contraseña
                };

                _usuarioController.AgregarUsuario(usuario);

                MessageBox.Show("Usuario registrado exitosamente.");

                txtNombreUsuario.Clear();
                txtPassword.Clear();

                // Mostrar la instancia global del formulario Bienvenido y cerrar el formulario actual
                ShowBienvenidoForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el usuario: {ex.Message}");
            }
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.ForeColor == System.Drawing.Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;


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
                    textBox.UseSystemPasswordChar = false;
                }
            }
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            ShowBienvenidoForm();
        }

        private void ShowBienvenidoForm()
        {
            // Muestra la instancia global del formulario Bienvenido y cierra el formulario actual
            Bienvenido.Instance.Show();
            this.Close();
        }
    }
}
