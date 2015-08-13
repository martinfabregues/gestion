using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class Factura
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public string numero { get; set; }
        public int tipocomprobante_id { get; set; }
        public int puntoventa_id { get; set; }
        public int condicionventa_id { get; set; }
        public int cliente_id { get; set; }
        public int concepto { get; set; }
        public double subtotal { get; set; }
        public double iva { get; set; }      
        public double otros_tributos { get; set; }
        public double total { get; set; }
        public string observaciones { get; set; }
        public string cae { get; set; }
        public DateTime fecha_vencimiento_cae { get; set; }
        public string codigo_barras { get; set; }
        public string estado { get; set; }
    }
}
