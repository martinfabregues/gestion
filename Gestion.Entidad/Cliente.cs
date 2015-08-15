using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Entidad
{
    public class Cliente
    {
        public int id { get; set; }
        public string apellido { get; set; }
        public string nombres { get; set; }
        public int tipodocumento_id { get; set; }
        public long documento { get; set; }


        public virtual TipoDocumento tipodocumento { get; set; }
    }
}
