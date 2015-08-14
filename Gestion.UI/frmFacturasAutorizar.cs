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
            GetFacturasAutorizar();
        }

        private void GetFacturasAutorizar()
        {
            var query = from row in Facturas.FindAll().OrderBy(x => x.fecha).OrderBy(x => x.puntoventa_id)
                        select row;

            dgvFacturas.Rows.Clear();
            foreach(var row in query)
            {
                dgvFacturas.Rows.Add(row.id, row.fecha.ToShortDateString(), row.numero, row.tipocomprobante.tipo_comprobante, 
                    row.puntoventa_id, row.cliente.apellido, row.subtotal, row.total, row.cae,
                    row.fecha_vencimiento_cae.ToShortDateString(), row.estado);
            }

            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

    }
}
