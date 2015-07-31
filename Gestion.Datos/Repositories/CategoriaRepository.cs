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
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> FindAllFiltro(string categoria);
    }

    public class CategoriaRepository : ICategoriaRepository
    {

        protected readonly IDbConnection _db;

        public CategoriaRepository()
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

        public IEnumerable<Categoria> FindAll()
        {
            string query = "SELECT * FROM CATEGORIAS";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Categoria>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(Categoria entity)
        {
            string query = "INSERT INTO CATEGORIAS (CATEGORIA, ACTIVO) VALUES (@categoria, @activo)";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { categoria = entity.categoria, activo = entity.activo });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> FindAllFiltro(string categoria)
        {
            string query = "SELECT * FROM CATEGORIAS " +
               "WHERE ((CATEGORIA LIKE @categoria) OR (@categoria IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Categoria>(query, new { categoria = '%' + categoria + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
