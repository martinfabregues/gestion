using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Facturas
    {
        public static int Add(Factura entity)
        {
            try
            {
                IFacturaRepository _repository = new FacturaRepository();
                return _repository.Add(entity);
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public static IEnumerable<Factura> FindAll()
        {
            try
            {
                IFacturaRepository _repository = new FacturaRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
