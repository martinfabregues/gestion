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
    public partial class frmProvincia : Form
    {
        public frmProvincia()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtProvincia.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;

            this.ActiveControl = txtProvincia;
        }

        private void frmProvincia_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean ValidarForm()
        {
            bool resultado = true;
            error.Clear();

            if(string.IsNullOrEmpty(txtProvincia.Text))
            {
                resultado = false;
                error.SetError(txtProvincia, "DEbe completar el campo Provincia.");
            }

            return resultado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                RegistrarProvincia();
            }
        }


        private void RegistrarProvincia()
        {
            try
            {
                Provincia provincia = new Provincia();
                provincia.activo = Convert.ToInt32(ckbActivo.Checked);
                provincia.provincia = txtProvincia.Text;

                int resultado = Provincias.Add(provincia);
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
            txtProvincia.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;
        }

    }
}
