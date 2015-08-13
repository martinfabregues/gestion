using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Datos.Interfases
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        int Add(T entity);
        int Modify(T entity);
        int Remove(int id);
        T FindById(int id);
    }
}
