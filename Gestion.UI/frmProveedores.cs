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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();

            inicializar();
        }

        private void inicializar()
        {
            errorProveedor.Clear();

            txtCodigo.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtNombreFantasia.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            cboProvincia.DataSource = null;
            cboLocalidad.DataSource = null;
            txtCP.Text = string.Empty;
            txtCodArea.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtWeb.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboCondIva.DataSource = null;
            txtCuit.Text = string.Empty;
            txtIngBrutos.Text = string.Empty;
            txtFechaAlta.Text = string.Empty;
            chkActivo.CheckState = CheckState.Unchecked;
            txtObservaciones.Text = string.Empty;

            cargarProvincias();
            cargarCondicionesIva();
        }

        private void cargarProvincias()
        {

            cboProvincia.SelectedIndex = -1;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(cboProvincia.SelectedValue.ToString());
            cargarLocalidades(idProvincia);
        }

        private void cargarLocalidades(int idProvincia)
        {

            cboLocalidad.SelectedIndex = -1;
        }

        private void cargarCondicionesIva()
        {

            cboCondIva.SelectedIndex = -1;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void validarDatos()
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
