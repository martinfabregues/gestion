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

                //calculo el formato del porcentaje de la alicuota
                double porcentaje = entity.porcentaje / 100;
                entity.porcentaje = porcentaje;

                return _repository.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public static Alicuota FindById(int id)
        {
            try
            {
                IAlicuotaRepository _repository = new AlicuotaRepository();
                return _repository.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
