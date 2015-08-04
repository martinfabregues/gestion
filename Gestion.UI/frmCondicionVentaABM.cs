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
    public partial class frmCondicionVentaABM : Form
    {
        public frmCondicionVentaABM()
        {
            InitializeComponent();
        }


        private void IniciarControles()
        {
            txtCondicionVenta.Text = string.Empty;
        }

        private void frmCondicionVentaABM_Load(object sender, EventArgs e)
        {
            IniciarControles();
            FiltrarForm();
        }


        private void FiltrarForm()
        {
            try
            {
                string condicion_venta = txtCondicionVenta.Text == string.Empty ? null : txtCondicionVenta.Text;

                var query = from row in CondicionesVenta.FindAllFiltro(condicion_venta)
                            select row;

                dgvCondicionesVenta.Rows.Clear();
                foreach (var row in query)
                {
                    dgvCondicionesVenta.Rows.Add(row.id, row.condicion_venta, row.activo);
                }

                dgvCondicionesVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCondicionVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FiltrarForm();
            }
        }

        private void frmCondicionVentaABM_Activated(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCondicionVenta frm = new frmCondicionVenta();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }



    }
}
