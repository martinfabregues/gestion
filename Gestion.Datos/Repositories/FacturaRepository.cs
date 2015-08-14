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
        int UpdateComprobanteAfip(Factura factura);
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
            string query = "SELECT * FROM FACTURAS F " +
                "INNER JOIN TIPOSCOMPROBANTE TC ON TC.ID = F.TIPOCOMPROBANTE_ID " +
                "INNER JOIN CONDICIONESVENTA CV ON CV.ID = F.CONDICIONVENTA_ID " +
                "INNER JOIN CLIENTES C ON C.ID = F.CLIENTE_ID ";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Factura, TipoComprobante, CondicionVenta, Cliente, Factura>(query, 
                        (factura, tipocomprobante, condicionventa, cliente) => 
                        {
                            factura.tipocomprobante = tipocomprobante;
                            factura.condicionventa = condicionventa;
                            factura.cliente = cliente;
                            return factura;
                        }, splitOn:"id");
                   
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(Factura entity)
        {
            string query = "INSERT INTO FACTURAS (FECHA, NUMERO, TIPOCOMPROBANTE_ID, PUNTOVENTA_ID, CONDICIONVENTA_ID, CLIENTE_ID, CONCEPTO, SUBTOTAL, " +
                            "IVA, OTROS_TRIBUTOS, TOTAL, OBSERVACIONES, CAE, FECHA_VENCIMIENTO_CAE, CODIGO_BARRAS, " +
                            "ESTADO_AFIP, OBSERVACIONESAFIP, ERRORESAFIP, ESTADO) VALUES (@fecha, @numero, @tipocomprobante_id, @puntoventa_id, @condicionventa_id, @cliente_id, @concepto, @subtotal, " + 
                            "@iva, @otros_tributos, @total, @observaciones, @cae, @fechavencimientocae, @codigobarras, " + 
                            "@estado_afip, @observacionesafip, @erroresafip, @estado);" +
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
                        iva = entity.iva,                       
                        otros_tributos = entity.otros_tributos,
                        total = entity.total,
                        observaciones = entity.observaciones,
                        cae = entity.cae,
                        fechavencimientocae = entity.fecha_vencimiento_cae,
                        codigobarras = entity.codigo_barras,
                        estado_afip = entity.estado_afip,
                        observacionesafip = entity.observacionesafip,
                        erroresafip = entity.erroresafip,
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
            string query = "SELECT * FROM FACTURAS " + 
                "WHERE ID = @id";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Factura>(query, new { id = id }).SingleOrDefault();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int UpdateComprobanteAfip(Factura factura)
        {
            string query = "UPDATE FACTURAS SET NUMERO = @numero, CAE = @cae, " + 
                "FECHA_VENCIMIENTO_CAE = @fechavencimientocae, CODIGO_BARRAS = @codigobarras, " + 
                "ESTADO_AFIP = @estadoafip, OBSERVACIONESAFIP = @observacionesafip, " +
                "ERRORESAFIP = @erroresafip, ESTADO = @estado WHERE ID = @id";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { 
                        numero = factura.numero, 
                        cae = factura.cae, 
                        fechavencimientocae = factura.fecha_vencimiento_cae, 
                        codigobarras = factura.codigo_barras, 
                        estadoafip = factura.estado_afip,
                        observacionesafip = factura.observacionesafip,
                        erroresafip = factura.erroresafip,
                        estado = factura.estado,
                        id = factura.id
                    });

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
