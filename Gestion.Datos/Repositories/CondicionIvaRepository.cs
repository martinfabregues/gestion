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
    public interface ICondicionIvaRepository : IRepository<CondicionIva>
    {
        IEnumerable<CondicionIva> FindAllFiltro(string condicion_iva);
    }
    public class CondicionIvaRepository : ICondicionIvaRepository
    {

        protected readonly IDbConnection _db;

        public CondicionIvaRepository()
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


        public IEnumerable<CondicionIva> FindAll()
        {
            string query = "SELECT * FROM CONDICIONESIVA";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<CondicionIva>(query);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int Add(CondicionIva entity)
        {
            string query = "INSERT INTO CONDICIONESIVA (CONDICION_IVA, ACTIVO) VALUES (@condicioniva, @activo)";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { condicioniva = entity.condicion_iva, activo = entity.activo });
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int Modify(CondicionIva entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CondicionIva> FindAllFiltro(string condicion_iva)
        {
            string query = "SELECT * FROM CONDICIONESIVA " +
                "WHERE ((CONDICION_IVA LIKE @condicion_iva) OR (@condicion_iva IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<CondicionIva>(query, new { condicion_iva = '%' + condicion_iva + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public CondicionIva FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
