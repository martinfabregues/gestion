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
    public partial class frmTipoDocumento : Form
    {
        public frmTipoDocumento()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciarControles()
        {
            txtCodigoAfip.Text = string.Empty;
            txtTipoDocumento.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;

            this.ActiveControl = txtTipoDocumento;
        }


        private void frmTipoDocumento_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private Boolean ValidarForm()
        {
            bool resultado = true;
            error.Clear();

            if(string.IsNullOrEmpty(txtTipoDocumento.Text))
            {
                resultado = false;
                error.SetError(txtTipoDocumento, "Debe completar el campo Tipo de Documento.");
            }

            if(string.IsNullOrEmpty(txtCodigoAfip.Text))
            {
                resultado = false;
                error.SetError(txtCodigoAfip, "Debe completar el campo Código AFIP.");
            }

            return resultado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                RegistrarTipoDocumento();
            }
        }


        private void RegistrarTipoDocumento()
        {
            try
            {
                TipoDocumento tipo_documento = new TipoDocumento();
                tipo_documento.activo = Convert.ToInt32(ckbActivo.Checked);
                tipo_documento.codigo_afip = txtCodigoAfip.Text;
                tipo_documento.tipo_documento = txtTipoDocumento.Text;

                int resultado = TiposDocumento.Add(tipo_documento);
                if(resultado > 0)
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

        private void txtCodigoAfip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                error.SetError(txtCodigoAfip, "Solo se permiten numeros en campo Código AFIP.");
                e.Handled = true;
                return;
            }
        }

        private void LimpiarControles()
        {
            txtTipoDocumento.Text = string.Empty;
            txtCodigoAfip.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;
        }


    }
}
