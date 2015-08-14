namespace Gestion.UI
{
    partial class frmFacturasAutorizar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.punto_venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vencimiento_cae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autorizar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.numero_comprobante,
            this.tipo_comprobante,
            this.punto_venta,
            this.cliente,
            this.subtotal,
            this.Total,
            this.cae,
            this.vencimiento_cae,
            this.Estado,
            this.autorizar});
            this.dgvFacturas.Location = new System.Drawing.Point(9, 76);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.Size = new System.Drawing.Size(1024, 509);
            this.dgvFacturas.TabIndex = 0;
            this.dgvFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // numero_comprobante
            // 
            this.numero_comprobante.HeaderText = "N° Comp.";
            this.numero_comprobante.Name = "numero_comprobante";
            this.numero_comprobante.ReadOnly = true;
            // 
            // tipo_comprobante
            // 
            this.tipo_comprobante.HeaderText = "T. Comp.";
            this.tipo_comprobante.Name = "tipo_comprobante";
            this.tipo_comprobante.ReadOnly = true;
            // 
            // punto_venta
            // 
            this.punto_venta.HeaderText = "Pto. Vta.";
            this.punto_venta.Name = "punto_venta";
            this.punto_venta.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // cae
            // 
            this.cae.HeaderText = "CAE";
            this.cae.Name = "cae";
            this.cae.ReadOnly = true;
            // 
            // vencimiento_cae
            // 
            this.vencimiento_cae.HeaderText = "F. Venc. CAE";
            this.vencimiento_cae.Name = "vencimiento_cae";
            this.vencimiento_cae.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // autorizar
            // 
            this.autorizar.HeaderText = "Autorizar";
            this.autorizar.Name = "autorizar";
            this.autorizar.ReadOnly = true;
            this.autorizar.Text = "Autorizar AFIP";
            this.autorizar.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(9, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1024, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // frmFacturasAutorizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 597);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvFacturas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmFacturasAutorizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFacturasAutorizar";
            this.Load += new System.EventHandler(this.frmFacturasAutorizar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn punto_venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cae;
        private System.Windows.Forms.DataGridViewTextBoxColumn vencimiento_cae;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn autorizar;
    }
}