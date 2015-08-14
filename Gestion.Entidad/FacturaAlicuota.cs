using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class FacturaAlicuota
    {
        public int id { get; set; }
        public int factura_id { get; set; }
        public int alicuota_id { get; set; }
        public double base_imponible { get; set; }
        public double importe { get; set; }

        public virtual Factura factura { get; set; }
        public virtual Alicuota alicuota { get; set; }
    }
}
