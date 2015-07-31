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
    public partial class frmCondicionIvaABM : Form
    {
        public frmCondicionIvaABM()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            help.SetHelpString(txtCondicionIva, "Presiona Enter para filtrar los datos.");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCondicionIva frm = new frmCondicionIva();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void frmCondicionIvaABM_Load(object sender, EventArgs e)
        {
            IniciarControles();
            FiltrarForm();
        }


        private void FiltrarForm()
        {
            string condicion_iva = txtCondicionIva.Text == string.Empty ? null : txtCondicionIva.Text;

            try
            {
                var query = from row in CondicionesIva.FindAllFiltro(condicion_iva)
                            select row;

                dgvCondicionesIva.Rows.Clear();
                foreach(var row in query)
                {
                    dgvCondicionesIva.Rows.Add(row.id, row.condicion_iva, row.activo);
                }

                dgvCondicionesIva.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch(Exception e)
            {

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCondicionIva_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FiltrarForm();
            }
        }

        private void frmCondicionIvaABM_Activated(object sender, EventArgs e)
        {
            FiltrarForm();
        }

    }
}
