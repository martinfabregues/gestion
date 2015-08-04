using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class Alicuotas
    {

        public static IEnumerable<Alicuota> FindAll()
        {
            try
            {
                IAlicuotaRepository _repository = new AlicuotaRepository();
                return _repository.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static IEnumerable<Alicuota> FindAllFiltro(string alicuota)
        {
            try
            {
                IAlicuotaRepository _repository = new AlicuotaRepository();
                return _repository.FindAllFiltro(alicuota);
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public static int Add(Alicuota entity)
        {
            try
            {
                IAlicuotaRepository _repository = new AlicuotaRepository();
                return _repository.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
