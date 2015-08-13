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
using DapperExtensions;
using Dapper;

namespace Gestion.Datos.Repositories
{
    public interface ITipoDocumentoRepository : IRepository<TipoDocumento>
    {
        IEnumerable<TipoDocumento> FindAllFiltro(string tipo_documento);
    }

    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {

        protected readonly IDbConnection _db;

        public TipoDocumentoRepository()
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


        public IEnumerable<TipoDocumento> FindAll()
        {
            string query = "SELECT * FROM TIPOSDOCUMENTO";
            
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<TipoDocumento>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(TipoDocumento entity)
        {
            string query = "INSERT INTO TIPOSDOCUMENTO (TIPO_DOCUMENTO, CODIGO_AFIP, ACTIVO) VALUES (@tipodocumento, @codigoafip, @activo)";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { 
                        tipodocumento = entity.tipo_documento, 
                        codigoafip = entity.codigo_afip, 
                        activo = entity.activo });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(TipoDocumento entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoDocumento> FindAllFiltro(string tipo_documento)
        {
            string query = "SELECT * FROM TIPOSDOCUMENTO " +
                "WHERE ((TIPO_DOCUMENTO LIKE @tipo_documento) OR (@tipo_documento IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<TipoDocumento>(query, new { tipo_documento = '%' + tipo_documento + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public TipoDocumento FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
