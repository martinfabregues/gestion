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
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            FindTiposComprobante();
            FindTiposDocumento();
            FindCondicionesIva();
        }

        private void FindTiposComprobante()
        {
            try
            {
                cboTipoComprobante.DisplayMember = "tipo_comprobante";
                cboTipoComprobante.ValueMember = "id";
                cboTipoComprobante.DataSource = TiposComprobante.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }

        private void FindTiposDocumento()
        {
            try
            {
                cboTipoDocumento.ValueMember = "id";
                cboTipoDocumento.DisplayMember = "tipo_documento";
                cboTipoDocumento.DataSource = TiposDocumento.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }

        private void FindCondicionesIva()
        {
            try
            {
                cboCondicionIva.DisplayMember = "condicion_iva";
                cboCondicionIva.ValueMember = "id";
                cboCondicionIva.DataSource = CondicionesIva.FindAll().Where(x => x.activo == 1).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
        }


    }
}
