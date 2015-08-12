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
           
            txtCodigoCliente.Text = string.Empty;
          
            txtDireccion.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            
         
            txtNombre.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtOtrosTributos.Text = "0.00";
           
            txtSubtotal.Text = "0.00";
            txtIva.Text = "0.00";
            txtTotal.Text = "0.00";

            //txtDescripcion.Enabled = false;
            //txtNombre.Enabled = false;
            //txtDireccion.Enabled = false;
            //txtDocumento.Enabled = false;
            //cboTipoDocumento.Enabled = false;
            //cboCondicionIva.Enabled = false;

            chkProductos.CheckState = CheckState.Checked;

            dgvDetalle.RowCount = 1;

            dgvDetalle.Columns[3].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[4].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[5].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[6].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDetalle.Columns[8].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                cboAlicuota.DataPropertyName = "id";
                cboAlicuota.DataSource = Alicuotas.FindAll().Where(x => x.activo == 1).ToList();

                if (cboAlicuota.Items.Count != 0)
                    dgvDetalle.Rows[0].Cells["cboAlicuota"].Value = 1;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }

        private void btnNuevaFila_Click(object sender, EventArgs e)
        {
            dgvDetalle.Rows.Add();
        }

      

     

        

        

       


    }
}
