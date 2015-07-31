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
    public partial class frmProvinciaABM : Form
    {
        public frmProvinciaABM()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtProvincia.Text = string.Empty;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProvinciaABM_Load(object sender, EventArgs e)
        {
            IniciarControles();
            FiltrarForm();
        }


        private void FiltrarForm()
        {
            try
            {
                string provincia = txtProvincia.Text == string.Empty ? null : txtProvincia.Text;

                var query = from row in Provincias.FindAllFiltro(provincia)
                            select row;

                dgvProvincias.Rows.Clear();
                foreach(var row in query)
                {
                    dgvProvincias.Rows.Add(row.id, row.provincia, row.activo);
                }

                dgvProvincias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProvincia_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FiltrarForm();
            }
        }

        private void frmProvinciaABM_Activated(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProvincia frm = new frmProvincia();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

    }
}
