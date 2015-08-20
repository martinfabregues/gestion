using Afip.FE;
using Afip.FE.Wsfe;
using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Gestion.Negocio
{
    public class Facturas
    {
        
        public static int Add(Factura entity)
        {
            int factura_id = 0;
            bool resultado = true;

            try
            {
                using(TransactionScope scope = new TransactionScope())
                {
                    IFacturaRepository _repository = new FacturaRepository();
                    factura_id = _repository.Add(entity);

                    if(factura_id > 0)
                    {
                        foreach(var row in entity.alicuotas)
                        {
                            row.factura_id = factura_id;

                            int res = FacturasAlicuotas.Add(row);
                            if(res == 0)
                            {
                                resultado = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        resultado = false;
                    }

                    if (resultado == true)
                        scope.Complete();
                                            
                }
    
            }
            catch(Exception e)
            {
                
                throw e;
            }

            return factura_id;
        }


        public static IEnumerable<Factura> FindAll()
        {
            try
            {
                IFacturaRepository _repository = new FacturaRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static int UpdateComprobanteAfip(Factura factura)
        {
            string CAE = string.Empty;
            string FchVencimiento = string.Empty;
            DateTime fechavencimientocae = factura.fecha;
            long numero_comp = 0;
            int ptovta = 0;

            try
            {

                factura.tipocomprobante = TiposComprobante.FindById(factura.tipocomprobante_id);
                FacturaElectronica Fe = new FacturaElectronica("C:\\Certificados\\bonechi\\Desarrollo.p12", 20107618725, "HOMO");

                var respuesta = Fe.FECompUltimoAutorizado(3, factura.tipocomprobante.codigo_afip);
                int proximocomprobante = respuesta.CbteNro + 1;

                factura.alicuotas = FacturasAlicuotas.FindAllByIdFactura(factura.id).ToList();
              
                var query = factura.alicuotas.GroupBy(x => x.alicuota_id)
                    .Select(item => new FacturaAlicuota 
                    { 
                        alicuota_id = item.First().alicuota_id,
                        base_imponible = item.Sum(x => x.base_imponible),
                        importe = item.Sum(x => x.importe)

                    }).ToList();

                int i = 0;
                AlicIva[] ivas = new AlicIva[query.ToList().Count];
                foreach (var row in query)
                {
                    
                    Alicuota alicuota = Alicuotas.FindById(row.alicuota_id);

                    Afip.FE.Wsfe.AlicIva alic = new Afip.FE.Wsfe.AlicIva();
                    alic.Id = alicuota.codigo_afip;
                    alic.BaseImp = row.base_imponible;
                    alic.Importe = row.importe;
                    ivas[i] = alic;

                    i += 1;
                }

                var response = Fe.FECAESolicitar(1, 3, factura.tipocomprobante.codigo_afip, 
                    factura.concepto, factura.cliente.tipodocumento.codigo_afip, factura.cliente.documento, 
                    proximocomprobante, proximocomprobante, factura.fecha.ToString("yyyyMMdd"), factura.total, 
                    0, factura.subtotal, 0, factura.otros_tributos, factura.iva, "", "", "", "PES", 1, null, null, 
                    ivas, null);

                string resultado = response.FeCabResp.Resultado;

                if (resultado != "R")
                {
                    //Obtengo el CAE y su vencimiento
                    CAE = response.FeDetResp[0].CAE;
                    FchVencimiento = response.FeDetResp[0].CAEFchVto;
                    fechavencimientocae = DateTime.ParseExact(FchVencimiento, "yyyyMMdd", null);
                    numero_comp = response.FeDetResp[0].CbteDesde;
                    ptovta = response.FeCabResp.PtoVta;
                }

                string obsafip = string.Empty;
                //Obtengo las observaciones y las muestro en el textbox
                var observaciones = response.FeDetResp[0].Observaciones;

                if (observaciones != null)
                {
                    foreach (var Obs in observaciones)
                    {
                        obsafip += " * " + Obs.Code + " : " + Obs.Msg + Environment.NewLine;
                    }
                }

                string erroresafip = string.Empty;
                //Obtengo los errores y los muestro si los hubiese
                var Errors = response.Errors;
                if (Errors != null)
                {
                    foreach (var Error in Errors)
                    {
                        erroresafip += " * " + Error.Code + " : " + Error.Msg + Environment.NewLine;
                    }
                }

                string CB = "20107618725" + String.Format("{0:00}", factura.tipocomprobante.codigo_afip) +
                    String.Format("{0:0000}", 3) + CAE + FchVencimiento;

                factura.cae = CAE;
                factura.fecha_vencimiento_cae = fechavencimientocae;
                factura.codigo_barras = CB;
                factura.estado_afip = resultado;
                factura.numero = String.Format("{0:00000000}", numero_comp);
                factura.estado = "A";
                factura.observacionesafip = obsafip;
                factura.erroresafip = erroresafip;

                IFacturaRepository _repository = new FacturaRepository();
                return _repository.UpdateComprobanteAfip(factura);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static Factura FindById(int id)
        {
            try
            {
                IFacturaRepository _repository = new FacturaRepository();
                return _repository.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        
    }
}
