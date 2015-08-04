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
    public partial class frmAlicuotaABM : Form
    {
        public frmAlicuotaABM()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtAlicuota.Text = string.Empty;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiltrarForm()
        {
            try
            {
                string alicuota = txtAlicuota.Text == string.Empty ? null : txtAlicuota.Text;

                var query = from row in Alicuotas.FindAllFiltro(alicuota)
                            select row;

                dgvCategorias.Rows.Clear();
                foreach (var row in query)
                {
                    dgvCategorias.Rows.Add(row.id, row.alicuota, row.codigo_afip, row.activo);
                }

                dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlicuota_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FiltrarForm();
            }
        }

        private void frmAlicuotaABM_Activated(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void frmAlicuotaABM_Load(object sender, EventArgs e)
        {
            IniciarControles();
            FiltrarForm();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAlicuota frm = new frmAlicuota();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
