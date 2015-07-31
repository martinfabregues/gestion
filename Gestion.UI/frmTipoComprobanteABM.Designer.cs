namespace Gestion.UI
{
    partial class frmTipoComprobanteABM
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTipoComprobante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTiposComprobante = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_afip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposComprobante)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTipoComprobante);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 68);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(131, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Presiona F1 para ayuda)";
            // 
            // txtTipoComprobante
            // 
            this.txtTipoComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoComprobante.Location = new System.Drawing.Point(134, 24);
            this.txtTipoComprobante.Name = "txtTipoComprobante";
            this.txtTipoComprobante.Size = new System.Drawing.Size(266, 20);
            this.txtTipoComprobante.TabIndex = 1;
            this.txtTipoComprobante.Tag = "";
            this.txtTipoComprobante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTipoComprobante_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Comprobante:";
            // 
            // dgvTiposComprobante
            // 
            this.dgvTiposComprobante.AllowUserToAddRows = false;
            this.dgvTiposComprobante.AllowUserToDeleteRows = false;
            this.dgvTiposComprobante.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvTiposComprobante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTiposComprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiposComprobante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo_comprobante,
            this.codigo_afip,
            this.activo});
            this.dgvTiposComprobante.Location = new System.Drawing.Point(12, 87);
            this.dgvTiposComprobante.Name = "dgvTiposComprobante";
            this.dgvTiposComprobante.ReadOnly = true;
            this.dgvTiposComprobante.RowHeadersVisible = false;
            this.dgvTiposComprobante.Size = new System.Drawing.Size(436, 275);
            this.dgvTiposComprobante.TabIndex = 30;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // tipo_comprobante
            // 
            this.tipo_comprobante.HeaderText = "T. Comprobante";
            this.tipo_comprobante.Name = "tipo_comprobante";
            this.tipo_comprobante.ReadOnly = true;
            // 
            // codigo_afip
            // 
            this.codigo_afip.HeaderText = "Cód. AFIP";
            this.codigo_afip.Name = "codigo_afip";
            this.codigo_afip.ReadOnly = true;
            // 
            // activo
            // 
            this.activo.HeaderText = "Activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Gestion.UI.Properties.Resources.error;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(13, 368);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(94, 24);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::Gestion.UI.Properties.Resources.edit_16;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(113, 368);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(94, 24);
            this.btnModificar.TabIndex = 28;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Gestion.UI.Properties.Resources.add3;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(213, 368);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(94, 24);
            this.btnNuevo.TabIndex = 27;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Image = global::Gestion.UI.Properties.Resources.back;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(354, 368);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 24);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmTipoComprobanteABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(460, 405);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvTiposComprobante);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmTipoComprobanteABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTipoComprobanteABM";
            this.Activated += new System.EventHandler(this.frmTipoComprobanteABM_Activated);
            this.Load += new System.EventHandler(this.frmTipoComprobanteABM_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposComprobante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTipoComprobante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTiposComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_afip;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.HelpProvider help;

    }
}