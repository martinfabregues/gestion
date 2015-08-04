using Gestion.Entidad;
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
    public partial class frmCondicionVenta : Form
    {
        public frmCondicionVenta()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtCondicionVenta.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;

            this.ActiveControl = txtCondicionVenta;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean ValidarForm()
        {
            error.Clear();
            bool resultado = true;

            if(string.IsNullOrEmpty(txtCondicionVenta.Text))
            {
                resultado = false;
                error.SetError(txtCondicionVenta, "Debe completar el campo Condición de Venta.");
            }

            return resultado;
        }

        private void frmCondicionVenta_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }


        private void RegistrarCondicionVenta()
        {
            try
            {
                CondicionVenta condicion_venta = new CondicionVenta();
                condicion_venta.activo = Convert.ToInt32(ckbActivo.Checked);
                condicion_venta.condicion_venta = txtCondicionVenta.Text;

                int resultado = CondicionesVenta.Add(condicion_venta);
                if (resultado > 0)
                {
                    MessageBox.Show("Los datos se registraron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al registrar los datos. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarControles()
        {
            txtCondicionVenta.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                RegistrarCondicionVenta();
            }
        }

    }
}
