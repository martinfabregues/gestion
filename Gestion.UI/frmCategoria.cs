using Gestion.Entidad;
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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtCategoria.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;

            this.ActiveControl = txtCategoria;
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private Boolean ValidarForm()
        {
            bool resultado = true;
            error.Clear();

            if(string.IsNullOrEmpty(txtCategoria.Text))
            {
                resultado = false;
                error.SetError(txtCategoria, "Debe completar el campo Categoria.");
            }

            return resultado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                RegistrarCategoria();
            }
        }

        private void RegistrarCategoria()
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.activo = Convert.ToInt32(ckbActivo.Checked);
                categoria.categoria = txtCategoria.Text;

                int resultado = Categorias.Add(categoria);
                if (resultado > 0)
                {
                    MessageBox.Show("Los datos se registraron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar los datos. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {
            txtCategoria.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;
        }

    }
}
