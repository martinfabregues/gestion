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
        Producto FindByCodigo(string codigo);
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
            string query = "SELECT * FROM PRODUCTOS P INNER JOIN CATEGORIAS C ON P.categoria_id = C.id " +
                            "INNER JOIN MARCA M ON P.marca_id = M.id " +
                            "INNER JOIN PROVEEDORES V ON P.proveedor_id = V.id " +
                            "INNER JOIN ALICUOTA A ON P.alicuota_id = A.id " +
                            "WHERE ((PRODUCTO LIKE @producto) OR (@producto IS NULL))";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    //return _db.Query<Producto>(query, new { producto = '%' + producto + '%' });

                    return _db.Query<Producto, Categoria, Marca, Proveedor, Alicuota, Producto>(query, (_producto, _categoria, _marca, _proveedor, _alicuota) =>
                    {
                        _producto.categoria = _categoria;
                        _producto.marca = _marca;
                        _producto.proveedor = _proveedor;
                        _producto.alicuota = _alicuota;
                        return _producto;
                    }, new { producto = '%' + producto + '%' }, splitOn: "id");

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
            string query = "INSERT INTO PRODUCTOS (CODIGO, PRODUCTO, CATEGORIA_ID, MARCA_ID, PROVEEDOR_ID, ALICUOTA_ID, STOCK, STOCK_CRITICO, ACTIVO) " + 
                           "VALUES (@codigo, @producto, @categoria, @marca, @proveedor, @alicuota, @stock, @stock_critico, @activo)";
            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Execute(query, 
                        new { 
                            codigo = entity.codigo, 
                            producto = entity.producto,
                            categoria = entity.categoria_id,
                            marca = entity.marca_id,
                            proveedor = entity.proveedor_id,
                            alicuota = entity.alicuota_id,
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


        public Producto FindByCodigo(string codigo)
        {
            string query = "SELECT * FROM PRODUCTOS WHERE CODIGO LIKE @cod";

            try
            {
                using (IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ToString()))
                {
                    return _db.Query<Producto>(query, new { cod = codigo }).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
