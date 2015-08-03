using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class Proveedor
    {
        public int id { get; set; }
        public string razon_social { get; set; }
        public string nombre_fantasia { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        public int codigo_postal { get; set; }
        public string cod_area { get; set; }
        public string telefono { get; set; }
        public string web { get; set; }
        public string email { get; set; }
        public string cuit { get; set; }
        public string ing_brutos { get; set; }
        public string observaciones { get; set; }
        public DateTime fecha_alta { get; set; }
        public int activo { get; set; }

        public virtual Provincia provincia { get; set; }
        public virtual Localidad localidad { get; set; }
        public virtual CondicionIva condicion_iva { get; set; }
    }
}
