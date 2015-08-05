using Gestion.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion.UI
{
    public partial class frmProductoABM : Form
    {
        public frmProductoABM()
        {
            InitializeComponent();
        }

        private void frmProductoABM_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void inicializar()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = Productos.FindAllFiltro(null);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProducto frm = new frmProducto();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
