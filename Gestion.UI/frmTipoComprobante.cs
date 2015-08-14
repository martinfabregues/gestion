﻿using Gestion.Entidad;
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
    public partial class frmTipoComprobante : Form
    {
        public frmTipoComprobante()
        {
            InitializeComponent();
        }

        private void IniciarControles()
        {
            txtCodigoAfip.Text = string.Empty;
            txtTipoComprobante.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;

            this.ActiveControl = txtTipoComprobante;
        }

        private void frmTipoComprobante_Load(object sender, EventArgs e)
        {
            IniciarControles();
        }

        private Boolean ValidarForm()
        {
            bool resultado = true;
            error.Clear();

            if(string.IsNullOrEmpty(txtTipoComprobante.Text))
            {
                resultado = false;
                error.SetError(txtTipoComprobante, "Debe completar el campo Tipo de Comprobante.");
            }

            if(string.IsNullOrEmpty(txtCodigoAfip.Text))
            {
                resultado = false;
                error.SetError(txtCodigoAfip, "Debe completar el campo Código AFIP.");
            }

            return resultado;
        }

        private void txtCodigoAfip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                error.SetError(txtCodigoAfip, "Solo se permiten numeros en campo Código AFIP.");
                e.Handled = true;
                return;
            }
        }


        private void RegistrarTipoComprobante()
        {
            try
            {
                TipoComprobante tipo_comprobante = new TipoComprobante();
                tipo_comprobante.activo = Convert.ToInt32(ckbActivo.Checked);
                tipo_comprobante.codigo_afip = Convert.ToInt32(txtCodigoAfip.Text);
                tipo_comprobante.tipo_comprobante = txtTipoComprobante.Text;

                int resultado = TiposComprobante.Add(tipo_comprobante);
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
            txtTipoComprobante.Text = string.Empty;
            txtCodigoAfip.Text = string.Empty;
            ckbActivo.CheckState = CheckState.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ValidarForm() == true)
            {
                RegistrarTipoComprobante();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
