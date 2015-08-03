using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class Producto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string producto { get; set; }
        public decimal stock { get; set; }
        public decimal stock_critico { get; set; }
        public int activo { get; set; }

        public virtual Marca marca { get; set; }
        public virtual Alicuota alicuota { get; set; }
        public virtual Categoria categoria { get; set; }
        public virtual Proveedor proveedor { get; set; }
    }
}
