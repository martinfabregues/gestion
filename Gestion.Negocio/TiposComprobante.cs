using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class TiposComprobante
    {

        public static IEnumerable<TipoComprobante> FindAllFiltro(string tipo_comprobante)
        {
            try
            {
                ITipoComprobanteRepository _repository = new TipoComprobanteRepository();
                return _repository.FindAllFiltro(tipo_comprobante);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<TipoComprobante> FindAll()
        {
            try
            {
                ITipoComprobanteRepository _repository = new TipoComprobanteRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int Add(TipoComprobante entity)
        {
            try
            {
                ITipoComprobanteRepository _repository = new TipoComprobanteRepository();
                return _repository.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }





    }
}
