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
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtBonificacion.Text = "0";
            txtCantidad.Text = "0";
            txtCodigoCliente.Text = string.Empty;
            txtCodigoProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtImporteIva.Text = "0";
            txtIva105.Text = "0";
            txtIva21.Text = "0";
            txtIva25.Text = "0";
            txtIva27.Text = "0";
            txtIva5.Text = "0";
            txtNombre.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtOtrosTributos.Text = "0";
            txtPrecioUnitario.Text = "0";
            txtSubtotal.Text = "0";

            txtDescripcion.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtDocumento.Enabled = false;
            cboTipoDocumento.Enabled = false;
            cboCondicionIva.Enabled = false;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            IniciarControles();

            FindTiposComprobante();
            FindTiposDocumento();
            FindCondicionesIva();
            FindCondicionesVenta();
        }

        private void FindTiposComprobante()
        {
            try
            {
                cboTipoComprobante.DisplayMember = "tipo_comprobante";
                cboTipoComprobante.ValueMember = "id";
                cboTipoComprobante.DataSource = TiposComprobante.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }

        private void FindTiposDocumento()
        {
            try
            {
                cboTipoDocumento.ValueMember = "id";
                cboTipoDocumento.DisplayMember = "tipo_documento";
                cboTipoDocumento.DataSource = TiposDocumento.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }

        private void FindCondicionesIva()
        {
            try
            {
                cboCondicionIva.DisplayMember = "condicion_iva";
                cboCondicionIva.ValueMember = "id";
                cboCondicionIva.DataSource = CondicionesIva.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }


        private void FindCondicionesVenta()
        {
            try
            {
                cboCondicionVenta.DisplayMember = "condicion_venta";
                cboCondicionVenta.ValueMember = "id";
                cboCondicionVenta.DataSource = CondicionesVenta.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }


        private void FindAlicuotasIva()
        {
            try
            {
                cboAlicuota.ValueMember = "id";
                cboAlicuota.DisplayMember = "alicuota";
                cboAlicuota.DataSource = Alicuotas.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }

        



    }
}
