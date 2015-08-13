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
    public partial class frmAlicuota : Form
    {
        public frmAlicuota()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtAlicuota.Text = string.Empty;
            txtCodigoAfip.Text = string.Empty;
            txtPorcentaje.Text = string.Empty;

            ckbActivo.CheckState = CheckState.Checked;

            this.ActiveControl = txtAlicuota;
        }

        private void frmAlicuota_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private Boolean ValidarForm()
        {
            error.Clear();
            bool resultado = true;

            if(string.IsNullOrEmpty(txtAlicuota.Text))
            {
                resultado = false;
                error.SetError(txtAlicuota, "Debe completar el campo Alicuota.");
            }

            if(string.IsNullOrEmpty(txtCodigoAfip.Text))
            {
                resultado = false;
                error.SetError(txtCodigoAfip, "Debe completar el campo Código AFIP.");
            }
            if(string.IsNullOrEmpty(txtPorcentaje.Text))
            {
                resultado = false;
                error.SetError(txtPorcentaje, "Debe completar el campo Porcentaje.");
            }

            return resultado;
        }



        private void RegistrarAlicuota()
        {
            try
            {
                Alicuota alicuota = new Alicuota();
                alicuota.alicuota = txtAlicuota.Text;
                alicuota.porcentaje = Convert.ToDouble(txtPorcentaje.Text);
                alicuota.activo = Convert.ToInt32(ckbActivo.Checked);
                alicuota.codigo_afip = Convert.ToInt32(txtCodigoAfip.Text);

                int resultado = Alicuotas.Add(alicuota);
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
            txtCodigoAfip.Text = string.Empty;
            txtAlicuota.Text = string.Empty;
            txtPorcentaje.Text = string.Empty;

            ckbActivo.CheckState = CheckState.Checked;
        }

        private void txtCodigoAfip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                error.SetError(txtCodigoAfip, "Solo se permiten numeros en campo Código AFIP.");
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                RegistrarAlicuota();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                error.SetError(txtPorcentaje, "Solo se permiten numeros en campo Porcentaje.");
                e.Handled = true;
                return;
            }
        }

    }
}
