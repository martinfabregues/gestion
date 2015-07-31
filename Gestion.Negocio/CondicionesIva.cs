using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class CondicionesIva
    {

        public static int Add(CondicionIva entity)
        {
            try
            {
                ICondicionIvaRepository _repository = new CondicionIvaRepository();
                return _repository.Add(entity);
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public static IEnumerable<CondicionIva> FindAll()
        {
            try
            {
                ICondicionIvaRepository _repository = new CondicionIvaRepository();
                return _repository.FindAll();
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public static IEnumerable<CondicionIva> FindAllFiltro(string condicion_iva)
        {
            try
            {
                ICondicionIvaRepository _repository = new CondicionIvaRepository();
                return _repository.FindAllFiltro(condicion_iva);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
