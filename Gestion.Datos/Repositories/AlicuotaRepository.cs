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
    public interface IAlicuotaRepository : IRepository<Alicuota>
    {
        IEnumerable<Alicuota> FindAllFiltro(string alicuota);
    }

    public class AlicuotaRepository : IAlicuotaRepository
    {
        protected readonly IDbConnection _db;

        public AlicuotaRepository()
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

        public IEnumerable<Alicuota> FindAllFiltro(string alicuota)
        {
            string query = "SELECT * FROM ALICUOTA " +
               "WHERE ((PRODUCTO LIKE @alicuota) OR (@alicuota IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Alicuota>(query, new { alicuota = '%' + alicuota + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Alicuota> FindAll()
        {
            string query = "SELECT * FROM ALICUOTA";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Alicuota>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(Alicuota entity)
        {
            string query = "INSERT INTO ALICUOTA (ALICUOTA, CODIGO_AFIP, ACTIVO) " +
                           "VALUES (@alicuota, @codigo_afip, @activo)";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query,
                        new
                        {
                            alicuota = entity.alicuota,
                            codigo_afip = entity.codigo_afip,
                            activo = entity.activo
                        });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(Alicuota entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
