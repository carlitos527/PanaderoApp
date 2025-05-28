using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace PanaderoApp.Forms
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            btnIngredientes.IconChar = IconChar.Warehouse; // O usa otro icono que prefieras
            btnIngredientes.IconColor = Color.Black;
            btnIngredientes.IconSize = 32;
            btnIngredientes.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnStockMovimientos.IconChar = IconChar.BoxOpen; // O usa otro icono que prefieras
            btnStockMovimientos.IconColor = Color.Black;
            btnStockMovimientos.IconSize = 32;
            btnStockMovimientos.TextImageRelation = TextImageRelation.ImageBeforeText;
        }


        private void Ingredintes_Click(object sender, EventArgs e)
        {

            FrmIngredientes frmIngredientes = new FrmIngredientes();
            frmIngredientes.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FrmStockMovimientos frmStockMovimientos = new FrmStockMovimientos();
            frmStockMovimientos.ShowDialog();

        }
    }
}
