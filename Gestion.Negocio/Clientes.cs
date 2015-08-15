using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Clientes
    {

        public static Cliente FindById(int id)
        {
            try
            {
                IClienteRepository _repository = new ClienteRepository();
                return _repository.FindById(id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
