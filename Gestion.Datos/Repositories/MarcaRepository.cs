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
    public interface IMarcaRepository : IRepository<Marca>
    {
        IEnumerable<Marca> FindAllFiltro(string marca);
    }

    public class MarcaRepository : IMarcaRepository
    {
        protected readonly IDbConnection _db;

        public MarcaRepository()
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

        public IEnumerable<Marca> FindAllFiltro(string marca)
        {
            string query = "SELECT * FROM MARCA " +
               "WHERE ((MARCA LIKE @marca) OR (@marca IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Marca>(query, new { marca = '%' + marca + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Marca> FindAll()
        {
            string query = "SELECT * FROM MARCA";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Marca>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(Marca entity)
        {
            string query = "INSERT INTO MARCA (MARCA, ACTIVO) " +
                           "VALUES (@marca, @activo)";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query,
                        new
                        {
                            marca = entity.marca,
                            activo = entity.activo
                        });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(Marca entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
