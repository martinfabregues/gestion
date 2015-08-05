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
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        IEnumerable<Proveedor> FindAllFiltro(string proveedor);
    }

    public class ProveedorRepository : IProveedorRepository
    {
        protected readonly IDbConnection _db;

        public ProveedorRepository()
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

        public IEnumerable<Proveedor> FindAllFiltro(string proveedor)
        {
            string query = "SELECT * FROM PROVEEDORES " +
               "WHERE ((RAZON_SOCIAL LIKE @proveedor) OR (NOMBRE_FANTASIA LIKE @proveedor) OR (@proveedor IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Proveedor>(query, new { proveedor = '%' + proveedor + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Proveedor> FindAll()
        {
            string query = "SELECT * FROM PROVEEDORES";
            // P, PROVINCIAS V, LOCALIDADES L, CONDICIONESIVA I " + 
                            //"WHERE P.PROVINCIA = V.ID AND P.LOCALIDAD = L.ID AND P.CONDICION_IVA = I.ID

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Proveedor>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(Proveedor entity)
        {
            string query = "INSERT INTO PROVEEDORES (RAZON_SOCIAL, NOMBRE_FANTASIA, DIRECCION, BARRIO, PROVINCIA, LOCALIDAD, CODIGO_POSTAL, COD_AREA, TELEFONO, WEB, EMAIL, CONDICION_IVA, CUIT, ING_BRUTOS, OBSERVACIONES, FECHA_ALTA, ACTIVO) " +
                           "VALUES (@razon_social, @nombre_fantasia, @direccion, @barrio, @provincia, @localidad, @codigo_posta, @cod_area, @telefono, @web, @email, @condicion_iva, @cuit, @ing_brutos, @observaciones, @fecha_alta, @activo)";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query,
                        new
                        {
                            razon_social = entity.razon_social, 
                            nombre_fantasia = entity.nombre_fantasia, 
                            direccion = entity.direccion, 
                            barrio = entity.barrio, 
                            provincia = entity.provincia.id,  
                            localidad = entity.localidad.id, 
                            codigo_posta = entity.codigo_postal, 
                            cod_area = entity.cod_area, 
                            telefono = entity.telefono, 
                            web = entity.web, 
                            email = entity.email, 
                            condicion_iva = entity.condicion_iva.id, 
                            cuit = entity.cuit, 
                            ing_brutos = entity.ing_brutos, 
                            observaciones = entity.observaciones, 
                            fecha_alta = entity.fecha_alta, 
                            activo = entity.activo
                            
                        });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(Proveedor entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
