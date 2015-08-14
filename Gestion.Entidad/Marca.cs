using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class Marca
    {
        public int id { get; set; }
        public int proveedor_id { get; set; }
        public string marca { get; set; }
        public int activo { get; set; }
    }
}
