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


            chkProductos.CheckState = CheckState.Checked;

            dgvDetalle.RowCount = 1;

            dgvDetalle.Columns[3].DefaultCellStyle.NullValue = "1.00";
            dgvDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[3].DefaultCellStyle.Format = "n2";

            dgvDetalle.Columns[4].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[4].DefaultCellStyle.Format = "n2";

            dgvDetalle.Columns[5].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[5].DefaultCellStyle.Format = "n2";

            dgvDetalle.Columns[6].DefaultCellStyle.NullValue = "0.00";
            dgvDetalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns[6].DefaultCellStyle.Format = "n2";

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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
                cboAlicuota.DataSource = Alicuotas.FindAll().Where(x => x.activo == 1).ToList();                
                cboAlicuota.DisplayMember = "alicuota";
                cboAlicuota.ValueMember = "id";
                cboAlicuota.DataPropertyName = "id";
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

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(SoloNumeros_KeyPress);
            if (dgvDetalle.CurrentCell.ColumnIndex == 3 || dgvDetalle.CurrentCell.ColumnIndex == 4 ||
                dgvDetalle.CurrentCell.ColumnIndex == 5 || dgvDetalle.CurrentCell.ColumnIndex == 6 ) 
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
                }
            }

            ComboBox cbo = e.Control as ComboBox;
            if(cbo != null)
            {
                
                cbo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                cbo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
                cbo.SelectionChangeCommitted += new EventHandler(cbo_SelectionChangeCommitted);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            AgregarFilaAlicuotaIva();
        }



        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        private void cbo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(((ComboBox)sender).SelectedValue);

            dgvDetalle.CurrentCell.Value = value;
            
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //columna cantidad
            if(e.ColumnIndex.Equals(3))
            {
                int cantidad = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[3].Value);
                double precio_unitario = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[4].Value);
                double bonificacion = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[5].Value);

                if (cantidad == 0)
                    cantidad = 1;

                if (bonificacion == 0)
                    bonificacion = 1;

                double subtotal = (cantidad * (precio_unitario * bonificacion));

                dgvDetalle.Rows[e.RowIndex].Cells[3].Value = Math.Round(Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[6].Value), 2);
                dgvDetalle.Rows[e.RowIndex].Cells[6].Value = subtotal;
            }

            //columna precio unitario
            if(e.ColumnIndex.Equals(4))
            {
                int cantidad = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[3].Value);
                double precio_unitario = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[4].Value);
                double bonificacion = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[5].Value);

                if (cantidad == 0)
                    cantidad = 1;

                if (bonificacion == 0)
                    bonificacion = 1;

                double subtotal = (cantidad * (precio_unitario * bonificacion));

                dgvDetalle.Rows[e.RowIndex].Cells[4].Value = Math.Round(Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[4].Value), 2); ;
                dgvDetalle.Rows[e.RowIndex].Cells[6].Value = subtotal;
            }

            //columna bonificacion
            if(e.ColumnIndex.Equals(5))
            {
                int cantidad = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells[3].Value);
                double precio_unitario = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[4].Value);
                double bonificacion = Convert.ToDouble(dgvDetalle.Rows[e.RowIndex].Cells[5].Value);

                if (cantidad == 0)
                    cantidad = 1;

                if (bonificacion == 0)
                    bonificacion = 1;

                double subtotal = (cantidad * (precio_unitario * bonificacion));

                dgvDetalle.Rows[e.RowIndex].Cells[6].Value = subtotal;
            }

            CalcularTotal();
           
        }
        

        private void AgregarFilaAlicuotaIva()
        {
            dgvAlicuotas.Rows.Clear();
            foreach(DataGridViewRow row in dgvDetalle.Rows)
            {
                double subtotal = Convert.ToDouble(row.Cells[6].Value);
                int alicuota_id = Convert.ToInt32(row.Cells[7].Value);

                if (Convert.ToDouble(row.Cells[6].Value) != 0 && alicuota_id != 0)
                {
                    Alicuota alicuota = Alicuotas.FindById(alicuota_id);

                    dgvAlicuotas.Rows.Add(alicuota.id, alicuota.alicuota, subtotal, (subtotal * alicuota.porcentaje));
                }
            }

            CalcularIva();
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       
        private void CalcularTotal()
        {
            if (dgvDetalle.Rows.Count != 0)
            {
                double subtotal = 0;
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    subtotal += Convert.ToDouble(row.Cells[6].Value);
                }

                txtSubtotal.Text = subtotal.ToString();
            }

        }

        private void CalcularIva()
        {
            if (dgvAlicuotas.Rows.Count != 0)
            {
                double subtotal_iva = 0;
                foreach (DataGridViewRow row in dgvAlicuotas.Rows)
                {
                    subtotal_iva += Convert.ToDouble(row.Cells[3].Value);
                }

                txtIva.Text = subtotal_iva.ToString();
            }
        }

    }
}
