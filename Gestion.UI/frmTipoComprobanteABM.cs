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
    public partial class frmTipoComprobanteABM : Form
    {
        public frmTipoComprobanteABM()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtTipoComprobante.Text = string.Empty;

            help.SetHelpString(txtTipoComprobante, "Presiona Enter para filtrar los datos.");
        }


     
        private void frmTipoComprobanteABM_Load(object sender, EventArgs e)
        {
            IniciarControles();

            FiltrarForm();
        }

        private void FiltrarForm()
        {
            try
            {
                string tipo_comprobante = txtTipoComprobante.Text == string.Empty ? null : txtTipoComprobante.Text;

                var query = from row in TiposComprobante.FindAllFiltro(tipo_comprobante)
                            select row;

                dgvTiposComprobante.Rows.Clear();
                foreach(var row in query)
                {
                    dgvTiposComprobante.Rows.Add(row.id, row.tipo_comprobante, row.codigo_afip, row.activo);
                }

                dgvTiposComprobante.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTipoComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FiltrarForm();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmTipoComprobante frm = new frmTipoComprobante();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTipoComprobanteABM_Activated(object sender, EventArgs e)
        {
            FiltrarForm();
        }



    }
}
