using Afip.FE;
using Afip.FE.Wsfe;
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
        private FacturaElectronica Fe = new FacturaElectronica("C:\\Certificados\\bonechi\\Desarrollo.p12", 20107618725, "HOMO");
        
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
                factura.tipocomprobante = TiposComprobante.FindById(factura.tipocomprobante_id);

                var respuesta = Fe.FECompUltimoAutorizado(3, factura.tipocomprobante.codigo_afip);
                int ultcomprobante = respuesta.CbteNro;

                factura.alicuotas = FacturasAlicuotas.FindAllByIdFactura(factura_id).ToList();

                int i = 0;
                AlicIva[] ivas = new AlicIva[factura.alicuotas.Count];
                foreach (var row in factura.alicuotas)
                {
                    Alicuota alicuota = Alicuotas.FindById(row.alicuota_id);

                    Afip.FE.Wsfe.AlicIva alic = new Afip.FE.Wsfe.AlicIva();
                    alic.Id = alicuota.codigo_afip;
                    alic.BaseImp = row.base_imponible;
                    alic.Importe = row.importe;
                    ivas[i] = alic;

                    i += 1;
                }

                var response = Fe.FECAESolicitar(1, 3, factura.tipocomprobante.codigo_afip, factura.concepto, 80, 20077998846, ultcomprobante + 1, ultcomprobante + 1, factura.fecha.ToString("yyyyMMdd"), factura.total, 0, factura.subtotal, 0, factura.otros_tributos, factura.iva, "", "", "", "PES", 1, null, null, ivas, null);

                string resultado = response.FeCabResp.Resultado;
                
                //Obtengo el CAE y su vencimiento
                string CAE = response.FeDetResp[0].CAE;
                string FchVencimiento = response.FeDetResp[0].CAEFchVto;
                DateTime fechavencimientocae = DateTime.ParseExact(FchVencimiento, "yyyyMMdd", null);
                
                long numero_comp = response.FeDetResp[0].CbteDesde;
                int ptovta = response.FeCabResp.PtoVta;

                string mensaje = string.Empty;

                //Le doy formato al resultado
                if (resultado == "A")
                {
                    mensaje += "Comprobante Autorizado" + Environment.NewLine + Environment.NewLine + 
                        "Nro. Comprobante: " + String.Format("{0:0000}", ptovta) + "-" + String.Format("{0:00000000}", numero_comp) +  
                        Environment.NewLine + "CAE : " + CAE + Environment.NewLine + "Vencimiento : " + fechavencimientocae.ToShortDateString() + 
                        Environment.NewLine + Environment.NewLine;
                   
                }

                if (resultado == "R")
                {
                    mensaje += "Comprobante Rechazado" + Environment.NewLine + Environment.NewLine;
                   
                }

                if (resultado == "P")
                {
                    mensaje += "Comprobante Autorizado Parcial" + Environment.NewLine + Environment.NewLine +
                        "Nro. Comprobante: " + String.Format("{0:0000}", ptovta) + "-" + String.Format("{0:00000000}", numero_comp) +
                        Environment.NewLine + "CAE : " + CAE + Environment.NewLine + "Vencimiento : " + fechavencimientocae.ToShortDateString() +
                        Environment.NewLine + Environment.NewLine;
                    
                }

                

                //Obtengo las observaciones y las muestro en el textbox
                var observaciones = response.FeDetResp[0].Observaciones;

                if (observaciones != null)
                {
                    foreach (var Obs in observaciones)
                    {                        
                        mensaje += " * " + Obs.Code + " : " + Obs.Msg + Environment.NewLine;
                    }
                }

                //Obtengo los errores y los muestro si los hubiese
                var Errors = response.Errors;
                if (Errors != null)
                {
                    foreach (var Error in Errors)
                    {
                        mensaje += " * " + Error.Code + " : " + Error.Msg + Environment.NewLine;
                    }
                }


                MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
