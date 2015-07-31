using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class TipoComprobante
    {
        public int id { get; set; }
        public string tipo_comprobante { get;set; }
        public string codigo_afip { get; set; }
        public int activo { get; set; }
    }
}
