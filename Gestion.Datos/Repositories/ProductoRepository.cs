using Gestion.Datos.Interfases;
using Gestion.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;

namespace Gestion.Datos.Repositories
{
    public interface IProductoRepository : IRepository<Producto>
    {
        IEnumerable<Producto> FindAllFiltro(string producto);
    }

    public class ProductoRepository : IProductoRepository
    {
        protected readonly IDbConnection _db;

        public ProductoRepository()
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

        public IEnumerable<Producto> FindAllFiltro(string producto)
        {
            string query = "SELECT * FROM PRODUCTOS " +
               "WHERE ((PRODUCTO LIKE @producto) OR (@producto IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Producto>(query, new { producto = '%' + producto + '%' });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Producto> FindAll()
        {
            string query = "SELECT * FROM PRODUCTOS";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Producto>(query);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Add(Producto entity)
        {
            string query = "INSERT INTO PRODUCTOS (CDB, PRODUCTO, CATEGORIA, MARCA, PROVEEDOR, ALICUOTA, STOCK, STOCK_CRITICO, ACTIVO) " + 
                           "VALUES (@cdb, @producto, @categoria, @marca, @proveedor, @alicuota, @stock, @stock_critico, @activo)";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, 
                        new { 
                            cdb = entity.cdb, 
                            producto = entity.producto,
                            categoria = entity.categoria.id,
                            marca = entity.marca,
                            proveedor = entity.proveedor.id,
                            alicuota = entity.alicuota.id,
                            stock = entity.stock,
                            stock_critico = entity.stock_critico,
                            activo = entity.activo
                        });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Modify(Producto entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
