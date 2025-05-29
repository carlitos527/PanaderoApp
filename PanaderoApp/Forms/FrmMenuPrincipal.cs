using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace PanaderoApp.Forms
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            this.Load += FrmMenuPrincipal_Load;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            btnClientes.IconChar = IconChar.Users;
            btnClientes.IconColor = Color.Black;
            btnClientes.IconSize = 32;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;

           


        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            // Aquí iría el código para abrir el formulario de clientes
            FrmClientes clientesForm = new FrmClientes();
            clientesForm.ShowDialog();
            
        }

        private void Ingredientes_Click(object sender, EventArgs e)
        {
            FrmInventario inventarioForm = new FrmInventario();
            inventarioForm.ShowDialog();
            

        }

        private void Productos_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.ShowDialog();

        }

        private void Proveedores_Click(object sender, EventArgs e)
        {
            FrmProveedores frmProveedores = new FrmProveedores();
            frmProveedores.ShowDialog();

        }

        private void Recetas_Click(object sender, EventArgs e)
        {
            FrmRecetas frmRecetas = new FrmRecetas();
            frmRecetas.ShowDialog();

        }
    }
}
