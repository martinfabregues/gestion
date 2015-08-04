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
    public partial class frmPrincipal2 : Form
    {
        public frmPrincipal2()
        {
            InitializeComponent();
        }

        private void proveedoresABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedoresABM frm = new frmProveedoresABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeComprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoComprobanteABM frm = new frmTipoComprobanteABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoDocumentoABM frm = new frmTipoDocumentoABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void condicionesDeIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCondicionIvaABM frm = new frmCondicionIvaABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void marcasABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcaABM frm = new frmMarcaABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productosABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductoABM frm = new frmProductoABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void categoriasABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoriaABM frm = new frmCategoriaABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClienteABM frm = new frmClienteABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void provinciasABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProvinciaABM frm = new frmProvinciaABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal2_Load(object sender, EventArgs e)
        {
            CargarFondo();
        }

        private void CargarFondo()
        {
            Size desktop = new Size();
            desktop = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;
            int alto = desktop.Height;
            int ancho = desktop.Width;

            //resolución 1280x1024
            if (ancho == 1280)
            {
                this.BackgroundImage = new Bitmap(Properties.Resources.bg_02);
            }
            if (ancho == 1680)
            {
                this.BackgroundImage = new Bitmap(Properties.Resources.bg_1280);
            }
        }

        private void facturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFactura frm = new frmFactura();
            frm.MdiParent = this;
            frm.Show();
        }

        private void condiciionesDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCondicionVentaABM frm = new frmCondicionVentaABM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aliCuotasIVAABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlicuotaABM frm = new frmAlicuotaABM();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
