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
    public interface IProvinciaRepository : IRepository<Provincia>
    {
        IEnumerable<Provincia> FindAllFiltro(string provincia);
    }

    public class ProvinciaRepository : IProvinciaRepository
    {

        protected readonly IDbConnection _db;

        public ProvinciaRepository()
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

        public IEnumerable<Provincia> FindAll()
        {
            string query = "SELECT * FROM PROVINCIAS";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Provincia>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(Provincia entity)
        {
            string query = "INSERT INTO PROVINCIAS(PROVINCIA, ACTIVO) VALUES (@provincia, @activo)";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { provincia = entity.provincia, activo = entity.activo });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(Provincia entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provincia> FindAllFiltro(string provincia)
        {
            string query = "SELECT * FROM PROVINCIAS " +
               "WHERE ((PROVINCIA LIKE @provincia) OR (@provincia IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Provincia>(query, new { provincia = '%' + provincia + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Provincia FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
