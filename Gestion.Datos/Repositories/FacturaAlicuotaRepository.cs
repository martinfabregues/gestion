using Gestion.Datos.Interfases;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;

namespace Gestion.Datos.Repositories
{
    public interface IFacturaAlicuotaRepository : IRepository<FacturaAlicuota>
    {

    }

    public class FacturaAlicuotaRepository : IFacturaAlicuotaRepository
    {

        protected readonly IDbConnection _db;

        public FacturaAlicuotaRepository()
        {
            try
            {
                _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<FacturaAlicuota> FindAll()
        {
            throw new NotImplementedException();
        }

        public int Add(FacturaAlicuota entity)
        {
            string query = "INSERT INTO FACTURASALICUOTAS (FACTURA_ID, ALICUOTA_ID, BASE_IMPONIBLE, IMPORTE) " +
                "VALUES (@factura_id, @alicuota_id, @base_imponible, @importe)";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, new { 
                        factura_id = entity.factura_id, 
                        alicuota_id = entity.alicuota_id, 
                        base_imponible = entity.base_imponible, 
                        importe = entity.importe });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(FacturaAlicuota entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public FacturaAlicuota FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
