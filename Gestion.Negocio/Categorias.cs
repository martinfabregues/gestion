using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Categorias
    {

        public static IEnumerable<Categoria> FindAll()
        {
            try
            {
                ICategoriaRepository _repository = new CategoriaRepository();
                return _repository.FindAll();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static int Add(Categoria entity)
        {
            try
            {
                ICategoriaRepository _repository = new CategoriaRepository();
                return _repository.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<Categoria> FindAllFiltro(string categoria)
        {
            try
            {
                ICategoriaRepository _repository = new CategoriaRepository();
                return _repository.FindAllFiltro(categoria);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
