using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Productos
    {
        public static IEnumerable<Producto> FindAll()
        {
            try
            {
                IProductoRepository _repository = new ProductoRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int Add(Producto _producto)
        {
            try
            {
                IProductoRepository _repository = new ProductoRepository();
                return _repository.Add(_producto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<Producto> FindAllFiltro(string producto)
        {
            try
            {
                IProductoRepository _repository = new ProductoRepository();
                return _repository.FindAllFiltro(producto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Producto FindByCodigo(string codigo)
        {
            try
            {
                IProductoRepository _repository = new ProductoRepository();
                return _repository.FindByCodigo(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
