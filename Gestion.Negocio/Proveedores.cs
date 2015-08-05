using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Proveedores
    {
        public static IEnumerable<Proveedor> FindAll()
        {
            try
            {
                IProveedorRepository _repository = new ProveedorRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int Add(Proveedor _proveedor)
        {
            try
            {
                IProveedorRepository _repository = new ProveedorRepository();
                return _repository.Add(_proveedor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<Proveedor> FindAllFiltro(string proveedor)
        {
            try
            {
                IProveedorRepository _repository = new ProveedorRepository();
                return _repository.FindAllFiltro(proveedor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
