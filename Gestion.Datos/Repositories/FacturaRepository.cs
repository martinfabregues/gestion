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
            string query = "INSERT INTO FACTURA (FECHA, NUMERO, TIPOCOMPROBANTE_ID, PUNTOVENTA_ID, CONDICIONIVA_ID, CLIENTE_ID, CONCEPTO, SUBTOTAL, " +
                            "IVA_27, IVA_21, IVA_105, IVA_5, IVA_25, OTROS_TRIBUTOS, TOTAL, OBSERVACIONES, CAE, FECHA_VENCIMIENTO_CAE, CODIGO_BARRAS, " +
                            "ESTADO) VALUES ();" +
                            "SELECT SCOPE_IDENTITY();";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    
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
    }
}
