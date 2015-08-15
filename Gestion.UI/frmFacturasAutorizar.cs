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
    public partial class frmFacturasAutorizar : Form
    {
        
        
        public frmFacturasAutorizar()
        {
            InitializeComponent();
        }

        private void frmFacturasAutorizar_Load(object sender, EventArgs e)
        {
            GetFacturasAutorizar();
        }

        private void GetFacturasAutorizar()
        {
            var query = from row in Facturas.FindAll().OrderBy(x => x.fecha).OrderBy(x => x.puntoventa_id)
                        select row;

            dgvFacturas.Rows.Clear();
            foreach(var row in query)
            {
                dgvFacturas.Rows.Add(row.id, row.fecha.ToShortDateString(), row.numero, row.tipocomprobante.tipo_comprobante, 
                    row.puntoventa_id, row.cliente.apellido, row.subtotal, row.total, row.cae,
                    row.fecha_vencimiento_cae.ToShortDateString(), row.estado);
            }

            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex.Equals(11))
            {
                int factura_id = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells[0].Value);
                AutorizarFacturaAfip(factura_id);
            }
        }


        private void AutorizarFacturaAfip(int factura_id)
        {
            try
            {
                Factura factura = new Factura();
                factura = Facturas.FindById(factura_id);
                factura.cliente = Clientes.FindById(factura.cliente_id);
                factura.cliente.tipodocumento = TiposDocumento.FindById(factura.cliente.tipodocumento_id);


                if (factura.estado_afip != "A" || string.IsNullOrEmpty(factura.estado_afip))
                {
                    int resultado_update = Facturas.UpdateComprobanteAfip(factura);
                    if (resultado_update > 0)
                    {
                        factura = Facturas.FindById(factura_id);

                        string mensaje = string.Empty;

                        if (factura.estado_afip.Trim() == "A")
                        {
                            mensaje += "Comprobante Autorizado" + Environment.NewLine + Environment.NewLine +
                          "Nro. Comprobante: " + String.Format("{0:0000}", factura.puntoventa_id) + "-" + String.Format("{0:00000000}", factura.numero) +
                          Environment.NewLine + "CAE : " + factura.cae + Environment.NewLine + "Vencimiento : " + factura.fecha_vencimiento_cae.ToShortDateString() +
                          Environment.NewLine + Environment.NewLine;
                        }

                        if (factura.estado_afip.Trim() == "R")
                        {
                            mensaje += "Comprobante Rechazado" + Environment.NewLine + Environment.NewLine;
                        }

                        if (factura.estado_afip.Trim() == "P")
                        {
                            mensaje += "Comprobante Autorizado Parcial" + Environment.NewLine + Environment.NewLine +
                            "Nro. Comprobante: " + String.Format("{0:0000}", factura.puntoventa_id) + "-" + String.Format("{0:00000000}", factura.numero) +
                            Environment.NewLine + "CAE : " + factura.cae + Environment.NewLine + "Vencimiento : " + factura.fecha_vencimiento_cae.ToShortDateString() +
                            Environment.NewLine + Environment.NewLine;
                        }

                        MessageBox.Show(mensaje, "Autorización de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El Comprobante Seleccionado ya se encuentra autorizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFacturasAutorizar_Activated(object sender, EventArgs e)
        {
            GetFacturasAutorizar();
        }
    }
}
