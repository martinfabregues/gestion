using Gestion.Datos.Interfases;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;

namespace Gestion.Datos.Repositories
{
    public interface IFacturaRepository : IRepository<Factura>
    {

    }

    public class FacturaRepository : IFacturaRepository
    {

        protected readonly IDbConnection _db;

        public FacturaRepository()
        {
            try
            {
                _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public IEnumerable<Factura> FindAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Factura entity)
        {
            string query = "INSERT INTO FACTURA (FECHA, NUMERO, TIPOCOMPROBANTE_ID, PUNTOVENTA_ID, CONDICIONVENTA_ID, CLIENTE_ID, CONCEPTO, SUBTOTAL, " +
                            "IVA_27, IVA_21, IVA_105, IVA_5, IVA_25, OTROS_TRIBUTOS, TOTAL, OBSERVACIONES, CAE, FECHA_VENCIMIENTO_CAE, CODIGO_BARRAS, " +
                            "ESTADO) VALUES (@fecha, @numero, @tipocomprobante_id, @puntoventa_id, @condicionventa_id, @cliente_id, @concepto, @subtotal, " + 
                            "@iva_27, @iva_21, @iva_105, @iva_5, @iva_25, @otros_tributos, @total, @observaciones, @cae, @fechavencimientocae, @codigobarras, " + 
                            "estado);" +
                            "SELECT SCOPE_IDENTITY();";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<int>(query, new
                    {
                        fecha = entity.fecha,
                        numero = entity.numero,
                        tipocomprobante_id = entity.tipocomprobante_id,
                        puntoventa_id = entity.puntoventa_id,
                        condicionventa_id = entity.condicionventa_id,
                        cliente_id = entity.cliente_id,
                        concepto = entity.concepto,
                        subtotal = entity.subtotal,
                        iva_27 = entity.iva_27,
                        iva_21 = entity.iva_21,
                        iva_105 = entity.iva_105,
                        iva_5 = entity.iva_5,
                        iva_25 = entity.iva_25,
                        otros_tributos = entity.otros_tributos,
                        total = entity.total,
                        observaciones = entity.observaciones,
                        cae = entity.cae,
                        fechavencimientocae = entity.fecha_vencimiento_cae,
                        codigobarras = entity.codigo_barras,
                        estado = entity.estado

                    }).Single();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int Modify(Factura entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }


        public Factura FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
