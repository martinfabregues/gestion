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
    public interface ITipoComprobanteRepository : IRepository<TipoComprobante>
    {
        IEnumerable<TipoComprobante> FindAllFiltro(string tipo_comprobante);
    }

    public class TipoComprobanteRepository : ITipoComprobanteRepository
    {

        protected readonly IDbConnection _db;

        public TipoComprobanteRepository()
        {
            try
            {
                _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<TipoComprobante> FindAll()
        {
            string query = "SELECT * FROM TIPOSCOMPROBANTE";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<TipoComprobante>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(TipoComprobante entity)
        {
            string query = "INSERT INTO TIPOSCOMPROBANTE (TIPO_COMPROBANTE, CODIGO_AFIP, ACTIVO) " +
                "VALUES (@tipocomprobante, @codigoafip, @activo)";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { 
                        tipocomprobante = entity.tipo_comprobante, 
                        codigoafip = entity.codigo_afip, 
                        activo = entity.activo });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(TipoComprobante entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoComprobante> FindAllFiltro(string tipo_comprobante)
        {
            string query = "SELECT * FROM TIPOSCOMPROBANTE " +
               "WHERE ((TIPO_COMPROBANTE LIKE @tipocomprobante) OR (@tipocomprobante IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<TipoComprobante>(query, new { tipocomprobante = '%' + tipo_comprobante + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
