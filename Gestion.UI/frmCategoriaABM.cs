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
    public partial class frmCategoriaABM : Form
    {
        public frmCategoriaABM()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtCategoria.Text = string.Empty;
        }

        private void frmCategoriasABM_Load(object sender, EventArgs e)
        {
            IniciarControles();
            FiltrarForm();
        }

        private void FiltrarForm()
        {
            try
            {
                string categoria = txtCategoria.Text == string.Empty ? null : txtCategoria.Text;

                var query = from row in Categorias.FindAllFiltro(categoria)
                            select row;
                
                dgvCategorias.Rows.Clear();
                foreach(var row in query)
                {
                    dgvCategorias.Rows.Add(row.id, row.categoria, row.activo);
                }

                dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FiltrarForm();
            }
        }

        private void frmCategoriasABM_Activated(object sender, EventArgs e)
        {
            FiltrarForm();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
