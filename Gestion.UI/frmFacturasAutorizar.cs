using Gestion.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion.UI
{
    public partial class frmFacturasAutorizar : Form
    {
        public frmFacturasAutorizar()
        {
            InitializeComponent();
        }

        private void frmFacturasAutorizar_Load(object sender, EventArgs e)
        {
            GetDatos();
        }

        private void GetDatos()
        {
            var query = from row in Facturas.FindAll()
                        select row;

            foreach(var row in query)
            {
                dgvFacturas.Rows.Add(row.id, row.fecha, row.numero, row.tipocomprobante_id, row.puntoventa_id, row.cliente_id, row.subtotal, row.total, row.cae, row.fecha_vencimiento_cae, row.estado);
            }
        }

    }
}
