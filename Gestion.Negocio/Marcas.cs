using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Marcas
    {
        public static IEnumerable<Marca> FindAll()
        {
            try
            {
                IMarcaRepository _repository = new MarcaRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int Add(Marca _marca)
        {
            try
            {
                IMarcaRepository _repository = new MarcaRepository();
                return _repository.Add(_marca);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<Marca> FindAllFiltro(string marca)
        {
            try
            {
                IMarcaRepository _repository = new MarcaRepository();
                return _repository.FindAllFiltro(marca);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
