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
    public partial class frmCondicionIva : Form
    {
        public frmCondicionIva()
        {
            InitializeComponent();
        }



        private void IniciarControles()
        {
            txtCondicionIva.Text = string.Empty;

            this.ActiveControl = txtCondicionIva;

            ckbActivo.CheckState = CheckState.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                RegistrarCondicionIva();
            }
        }

        private void frmCondicionIva_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }


        private void RegistrarCondicionIva()
        {
            try
            {
                CondicionIva condicion_iva = new CondicionIva();
                condicion_iva.activo = Convert.ToInt32(ckbActivo.Checked);
                condicion_iva.condicion_iva = txtCondicionIva.Text;

                int resultado = CondicionesIva.Add(condicion_iva);
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

        private Boolean ValidarForm()
        {
            bool resultado = true;
            error.Clear();

            if(String.IsNullOrEmpty(txtCondicionIva.Text))
            {
                resultado = false;
                error.SetError(txtCondicionIva, "Debe completar el campo Condición de IVA.");
            }

            return resultado;
        }

        private void LimpiarControles()
        {
            txtCondicionIva.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
