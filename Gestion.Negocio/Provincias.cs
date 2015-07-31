using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Provincias
    {

        public static IEnumerable<Provincia> FindAll()
        {
            try
            {
                IProvinciaRepository _repository = new ProvinciaRepository();
                return _repository.FindAll();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static int Add(Provincia entity)
        {
            try
            {
                IProvinciaRepository _repository = new ProvinciaRepository();
                return _repository.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<Provincia> FindAllFiltro(string provincia)
        {
            try
            {
                IProvinciaRepository _repository = new ProvinciaRepository();
                return _repository.FindAllFiltro(provincia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
