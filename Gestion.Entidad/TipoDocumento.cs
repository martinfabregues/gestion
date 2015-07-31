using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class TipoDocumento
    {
        public int id { get; set; }
        public string tipo_documento { get; set; }
        public string codigo_afip { get; set; }
        public int activo { get; set; }
    }
}
