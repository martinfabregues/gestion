using Gestion.Datos.Repositories;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Negocio
{
    public class TiposDocumento
    {


        public static IEnumerable<TipoDocumento> FindAll()
        {
            try
            {
                ITipoDocumentoRepository _repository = new TipoDocumentoRepository();
                return _repository.FindAll();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static int Add(TipoDocumento entity)
        {
            try
            {
                ITipoDocumentoRepository _repository = new TipoDocumentoRepository();
                return _repository.Add(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static IEnumerable<TipoDocumento> FindAllFiltro(string tipo_documento)
        {
            try
            {
                ITipoDocumentoRepository _repository = new TipoDocumentoRepository();
                return _repository.FindAllFiltro(tipo_documento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static TipoDocumento FindById(int id)
        {
            try
            {
                ITipoDocumentoRepository _repository = new TipoDocumentoRepository();
                return _repository.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
