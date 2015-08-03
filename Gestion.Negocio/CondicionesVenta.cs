using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class CondicionesVenta
    {

        public static IEnumerable<CondicionVenta> FindAll()
        {
            try
            {
                ICondicionVentaRepository _repository = new CondicionVentaRepository();
                return _repository.FindAll();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<CondicionVenta> FindAllFiltro(string condicion_venta)
        {
            try
            {
                ICondicionVentaRepository _repository = new CondicionVentaRepository();
                return _repository.FindAllFiltro(condicion_venta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
