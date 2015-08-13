using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class Alicuota
    {
        public int id { get; set; }
        public string alicuota { get; set; }
        public double porcentaje { get; set; }
        public int codigo_afip { get; set; }
        public int activo { get; set; }
    }
}
