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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            error.Clear();
            txtCodigo.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtStockCritico.Text = string.Empty;
            chkActivo.CheckState = CheckState.Checked;

            cargarCategorias();

            cargarMarcas();

            cargarProveedores();

            cargarAlicuotas();

            this.ActiveControl = txtCodigo;
        }

        #region Cargar Combos
        private void cargarCategorias()
        {
            IList<Categoria> _categorias = Categorias.FindAll().ToList();

            if (_categorias.Count <= 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Actualmente no existen categorías en la base de datos, desea cargar una nueva categoría?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                    frmCategoria frm = new frmCategoria();
                    frm.MdiParent = this.MdiParent;
                    frm.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }

            cboCategoria.DataSource = _categorias;
            cboCategoria.ValueMember = "ID";
            cboCategoria.DisplayMember = "CATEGORIA";

            cboCategoria.SelectedIndex = -1;
        }

        private void cargarMarcas()
        {
            IList<Marca> _marcas = Marcas.FindAll().ToList();

            if (_marcas.Count <= 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Actualmente no existen marcas en la base de datos, desea cargar una nueva marca?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                    //frmMarca frm = new frmMarca();
                    //frm.MdiParent = this.MdiParent;
                    //frm.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }

            cboMarca.DataSource = _marcas;
            cboMarca.ValueMember = "ID";
            cboMarca.DisplayMember = "MARCA";

            cboMarca.SelectedIndex = -1;
        }

        private void cargarProveedores()
        {
            IList<Proveedor> _proveedores = Proveedores.FindAll().ToList();

            if (_proveedores.Count <= 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Actualmente no existen proveedores en la base de datos, desea cargar un nuevo proveedor?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                    frmProveedores frm = new frmProveedores();
                    frm.MdiParent = this.MdiParent;
                    frm.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }

            cboProveedor.DataSource = _proveedores;
            cboProveedor.ValueMember = "ID";
            cboProveedor.DisplayMember = "RAZON_SOCIAL";

            cboProveedor.SelectedIndex = -1;
        }

        private void cargarAlicuotas()
        {
            IList<Alicuota> _alicuotas = Alicuotas.FindAll().ToList();

            if (_alicuotas.Count <= 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Actualmente no existen alícuotas en la base de datos, desea cargar una nueva alícuota?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                    //frmAlicuota frm = new frmAlicuota();
                    //frm.MdiParent = this.MdiParent;
                    //frm.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }

            cboAlicuota.DataSource = _alicuotas;
            cboAlicuota.ValueMember = "ID";
            cboAlicuota.DisplayMember = "ALICUOTA";

            cboAlicuota.SelectedIndex = -1;
        }
        #endregion

        private void txtStock_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                txtStock.Text = "0";
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Decimal))
            {
                error.SetError(txtStock, "Solo se permiten valores numéricos en el campo Stock.");
                e.Handled = true;
                return;
            }
        }

        private void txtStockCritico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Decimal))
            {
                error.SetError(txtStock, "Solo se permiten valores numéricos en el campo Stock crítico.");
                e.Handled = true;
                return;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                try
                {
                    Producto _producto = new Producto();
                    _producto.codigo = txtCodigo.Text;
                    _producto.producto = txtProducto.Text;
                    _producto.categoria_id = Convert.ToInt32(cboCategoria.SelectedValue);
                    _producto.marca_id = Convert.ToInt32(cboMarca.SelectedValue);
                    _producto.proveedor_id = Convert.ToInt32(cboProveedor.SelectedValue);
                    _producto.stock = Convert.ToDecimal(txtStock.Text);
                    _producto.stock_critico = Convert.ToDecimal(txtStockCritico.Text);
                    _producto.alicuota_id = Convert.ToInt32(cboAlicuota.SelectedValue);
                    _producto.activo = Convert.ToInt32(chkActivo.Checked);

                    int resultado = Productos.Add(_producto);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Los datos se registraron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inicializar();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al registrar los datos. Intente Nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private Boolean Validar()
        {
            bool resultado = true;
            error.Clear();

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                resultado = false;
                error.SetError(txtCodigo, "Debe completar el campo Código.");
            }
            else
            {
                Producto _producto = new Producto();
                _producto = Productos.FindByCodigo(txtCodigo.Text);
                if (_producto != null)
                {
                    resultado = false;
                    error.SetError(txtCodigo, "Ya existe un producto con el código ingresado.");
                }
            }

            if (string.IsNullOrEmpty(txtProducto.Text))
            {
                resultado = false;
                error.SetError(txtProducto, "Debe completar el campo Producto.");
            }

            if (cboCategoria.SelectedIndex == -1)
            {
                resultado = false;
                error.SetError(cboCategoria, "Debe seleccionar una Categoría.");
            }

            if (cboMarca.SelectedIndex == -1)
            {
                resultado = false;
                error.SetError(cboMarca, "Debe seleccionar una Marca.");
            }

            if (cboProveedor.SelectedIndex == -1)
            {
                resultado = false;
                error.SetError(cboProveedor, "Debe seleccionar un Proveedor.");
            }

            if (cboAlicuota.SelectedIndex == -1)
            {
                resultado = false;
                error.SetError(cboAlicuota, "Debe seleccionar una Alícuota.");
            }

            return resultado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
