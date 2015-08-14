using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class FacturasAlicuotas
    {

        public static int Add(FacturaAlicuota entity)
        {
            try
            {
                IFacturaAlicuotaRepository _repository = new FacturaAlicuotaRepository();
                return _repository.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static IEnumerable<FacturaAlicuota> FindAllByIdFactura(int id)
        {
            try
            {
                IFacturaAlicuotaRepository _repository = new FacturaAlicuotaRepository();
                return _repository.FindAllByIdFactura(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
