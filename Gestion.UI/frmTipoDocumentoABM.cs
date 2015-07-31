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
    public partial class frmTipoDocumentoABM : Form
    {
        public frmTipoDocumentoABM()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            help.SetHelpString(txtTipoDocumento, "Presiona Enter para filtrar los datos.");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmTipoDocumento frm = new frmTipoDocumento();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void frmTipoDocumentoABM_Load(object sender, EventArgs e)
        {
            IniciarControles();
            FiltrarForm();
        }

        private void FiltrarForm()
        {
            try
            {
                string tipo_documento = txtTipoDocumento.Text == string.Empty ? null : txtTipoDocumento.Text;

                var query = from row in TiposDocumento.FindAllFiltro(tipo_documento)
                            select row;

                dgvTiposDocumento.Rows.Clear();
                foreach(var row in query)
                {
                    dgvTiposDocumento.Rows.Add(row.id, row.tipo_documento, row.codigo_afip, row.activo);
                }

                dgvTiposDocumento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmTipoDocumentoABM_Activated(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void txtTipoDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FiltrarForm();
            }
        }

    }
}
