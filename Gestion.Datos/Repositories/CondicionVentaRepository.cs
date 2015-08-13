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
    public interface ICondicionVentaRepository : IRepository<CondicionVenta>
    {
        IEnumerable<CondicionVenta> FindAllFiltro(string condicion_venta);
    }

    public class CondicionVentaRepository : ICondicionVentaRepository
    {

        protected readonly IDbConnection _db;

        public CondicionVentaRepository()
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

        public IEnumerable<CondicionVenta> FindAll()
        {
            string query = "SELECT * FROM CONDICIONESVENTA";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<CondicionVenta>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(CondicionVenta entity)
        {
            string query = "INSERT INTO CONDICIONESVENTA (CONDICION_VENTA, ACTIVO) VALUES (@condicionventa, @activo)";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { condicionventa = entity.condicion_venta, activo = entity.activo });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(CondicionVenta entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CondicionVenta> FindAllFiltro(string condicion_venta)
        {
            string query = "SELECT * FROM CONDICIONESVENTA " +
               "WHERE ((CONDICION_VENTA LIKE @condicion_venta) OR (@condicion_venta IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<CondicionVenta>(query, new { condicion_venta = '%' + condicion_venta + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public CondicionVenta FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
