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
    public partial class Bienvenido : Form
    {
        private static Bienvenido _instance;
        private readonly UsuarioController _usuario;

        public Bienvenido()
        {
            InitializeComponent();

            // Obtener la cadena de conexión desde el archivo de configuración
            var connectionStringSetting = ConfigurationManager.ConnectionStrings["PanaderiaConnection"];
            if (connectionStringSetting == null)
            {
                MessageBox.Show("Cadena de conexión no encontrada en el archivo de configuración.");
                return;
            }

            string connectionString = connectionStringSetting.ConnectionString;

            // Inicializa el repositorio pasando la cadena de conexión
            _usuario = new UsuarioController(connectionString);

            VerificarPerfiles(); // Llama a la función para verificar perfiles.
        }

        public static Bienvenido Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Bienvenido();
                }
                return _instance;
            }
        }

        private void VerificarPerfiles()
        {
            try
            {
                if (_usuario.ExistePerfil())
                {
                    btnCrear.Enabled = false; // Deshabilitar el botón de crear perfil
                                              // MessageBox.Show("Ya existe un perfil creado. No puedes crear más perfiles.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar perfiles: {ex.Message}");
            }
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            AggUsuario aggUsuarioForm = new AggUsuario();
            aggUsuarioForm.Show();
            this.Hide(); // Oculta el formulario Bienvenido en lugar de cerrarlo
        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesionForm = new IniciarSesion();
            iniciarSesionForm.Show();
            this.Hide();
        }
    }
}
