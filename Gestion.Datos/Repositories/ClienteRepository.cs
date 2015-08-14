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

namespace Gestion.Datos.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {

    }

    public class ClienteRepository : IClienteRepository
    {

        protected readonly IDbConnection _db;

        public ClienteRepository()
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


        public IEnumerable<Cliente> FindAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public int Modify(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
