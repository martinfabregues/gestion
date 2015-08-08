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
            txtBonificacion.Text = "0.00";
            txtCantidad.Text = "0.00";
            txtCodigoCliente.Text = string.Empty;
            txtCodigoProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtImporteIva.Text = "0.00";
            txtIva105.Text = "0.00";
            txtIva21.Text = "0.00";
            txtIva25.Text = "0.00";
            txtIva27.Text = "0.00";
            txtIva5.Text = "0.00";
            txtNombre.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtOtrosTributos.Text = "0.00";
            txtPrecioUnitario.Text = "0.00";
            txtSubtotal.Text = "0.00";

            //txtDescripcion.Enabled = false;
            //txtNombre.Enabled = false;
            //txtDireccion.Enabled = false;
            //txtDocumento.Enabled = false;
            //cboTipoDocumento.Enabled = false;
            //cboCondicionIva.Enabled = false;

            chkProductos.CheckState = CheckState.Checked;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            IniciarControles();

            FindTiposComprobante();
            FindTiposDocumento();
            FindCondicionesIva();
            FindCondicionesVenta();
            FindAlicuotasIva();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(ValidarLineaProductos() == true)
            {
                double subtotal = (Convert.ToDouble(txtPrecioUnitario.Text) * Convert.ToDouble(txtCantidad.Text));
                double importeiva = (Convert.ToDouble(txtImporteIva.Text) * Convert.ToDouble(txtCantidad.Text));
                double total = subtotal + importeiva;

                dgvDetalle.Rows.Add(0, txtCodigoProducto.Text, txtDescripcion.Text, txtCantidad.Text,
                    txtPrecioUnitario.Text, txtBonificacion.Text, subtotal,
                    cboAlicuota.SelectedValue, cboAlicuota.Text, 
                    importeiva, total);
            }
        }

        private Boolean ValidarLineaProductos()
        {
            bool resultado = true;

            if(String.IsNullOrEmpty(txtDescripcion.Text))
            {
                resultado = false;
                error.SetError(txtDescripcion, "Debe completar el campo Descripción.");
            }

            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                resultado = false;
                error.SetError(txtCantidad, "Debe completar el campo Cantidad.");
            }

            if (String.IsNullOrEmpty(txtPrecioUnitario.Text))
            {
                resultado = false;
                error.SetError(txtPrecioUnitario, "Debe completar el campo Precio Unit.");
            }

            if (String.IsNullOrEmpty(txtBonificacion.Text))
            {
                resultado = false;
                error.SetError(txtBonificacion, "Debe completar el campo Bonificación.");
            }
            
            if (String.IsNullOrEmpty(txtImporteIva.Text))
            {
                resultado = false;
                error.SetError(txtImporteIva, "Debe completar el campo Importe Iva.");
            }

            return resultado;
        }



    }
}
