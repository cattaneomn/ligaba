namespace AplicationDesktop1.Abm_Estadisticas
{
    partial class EstadisticasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstadisticasForm));
            this.EstadisticasDataGridView = new System.Windows.Forms.DataGridView();
            this.DatosGroupBox = new System.Windows.Forms.GroupBox();
            this.HastaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DesdeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClientesComboBox = new System.Windows.Forms.ComboBox();
            this.ClienteLabel = new System.Windows.Forms.Label();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.TipoGroupBox = new System.Windows.Forms.GroupBox();
            this.ProductosXClienteRadioButton = new System.Windows.Forms.RadioButton();
            this.DiaRadioButton = new System.Windows.Forms.RadioButton();
            this.ProductosRadioButton = new System.Windows.Forms.RadioButton();
            this.VentasRadioButton = new System.Windows.Forms.RadioButton();
            this.MostrarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EstadisticasDataGridView)).BeginInit();
            this.DatosGroupBox.SuspendLayout();
            this.TipoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EstadisticasDataGridView
            // 
            this.EstadisticasDataGridView.AllowUserToAddRows = false;
            this.EstadisticasDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EstadisticasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EstadisticasDataGridView.Location = new System.Drawing.Point(12, 175);
            this.EstadisticasDataGridView.Name = "EstadisticasDataGridView";
            this.EstadisticasDataGridView.ReadOnly = true;
            this.EstadisticasDataGridView.Size = new System.Drawing.Size(860, 346);
            this.EstadisticasDataGridView.TabIndex = 0;
            // 
            // DatosGroupBox
            // 
            this.DatosGroupBox.Controls.Add(this.HastaDateTimePicker);
            this.DatosGroupBox.Controls.Add(this.DesdeDateTimePicker);
            this.DatosGroupBox.Controls.Add(this.label2);
            this.DatosGroupBox.Controls.Add(this.label3);
            this.DatosGroupBox.Controls.Add(this.ClientesComboBox);
            this.DatosGroupBox.Controls.Add(this.ClienteLabel);
            this.DatosGroupBox.Location = new System.Drawing.Point(320, 12);
            this.DatosGroupBox.Name = "DatosGroupBox";
            this.DatosGroupBox.Size = new System.Drawing.Size(552, 157);
            this.DatosGroupBox.TabIndex = 1;
            this.DatosGroupBox.TabStop = false;
            this.DatosGroupBox.Text = "Datos";
            // 
            // HastaDateTimePicker
            // 
            this.HastaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HastaDateTimePicker.Location = new System.Drawing.Point(260, 90);
            this.HastaDateTimePicker.Name = "HastaDateTimePicker";
            this.HastaDateTimePicker.Size = new System.Drawing.Size(251, 22);
            this.HastaDateTimePicker.TabIndex = 4;
            // 
            // DesdeDateTimePicker
            // 
            this.DesdeDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesdeDateTimePicker.Location = new System.Drawing.Point(260, 42);
            this.DesdeDateTimePicker.Name = "DesdeDateTimePicker";
            this.DesdeDateTimePicker.Size = new System.Drawing.Size(251, 22);
            this.DesdeDateTimePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hasta";
            // 
            // ClientesComboBox
            // 
            this.ClientesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesComboBox.FormattingEnabled = true;
            this.ClientesComboBox.Location = new System.Drawing.Point(69, 41);
            this.ClientesComboBox.Name = "ClientesComboBox";
            this.ClientesComboBox.Size = new System.Drawing.Size(121, 24);
            this.ClientesComboBox.TabIndex = 1;
            this.ClientesComboBox.Visible = false;
            // 
            // ClienteLabel
            // 
            this.ClienteLabel.AutoSize = true;
            this.ClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClienteLabel.Location = new System.Drawing.Point(14, 42);
            this.ClienteLabel.Name = "ClienteLabel";
            this.ClienteLabel.Size = new System.Drawing.Size(49, 16);
            this.ClienteLabel.TabIndex = 0;
            this.ClienteLabel.Text = "Cliente";
            this.ClienteLabel.Visible = false;
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 527);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 8;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(12, 527);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 9;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // TipoGroupBox
            // 
            this.TipoGroupBox.Controls.Add(this.ProductosXClienteRadioButton);
            this.TipoGroupBox.Controls.Add(this.DiaRadioButton);
            this.TipoGroupBox.Controls.Add(this.ProductosRadioButton);
            this.TipoGroupBox.Controls.Add(this.VentasRadioButton);
            this.TipoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.TipoGroupBox.Name = "TipoGroupBox";
            this.TipoGroupBox.Size = new System.Drawing.Size(302, 157);
            this.TipoGroupBox.TabIndex = 5;
            this.TipoGroupBox.TabStop = false;
            this.TipoGroupBox.Text = "Tipo de Estadistica";
            // 
            // ProductosXClienteRadioButton
            // 
            this.ProductosXClienteRadioButton.AutoSize = true;
            this.ProductosXClienteRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductosXClienteRadioButton.Location = new System.Drawing.Point(29, 93);
            this.ProductosXClienteRadioButton.Name = "ProductosXClienteRadioButton";
            this.ProductosXClienteRadioButton.Size = new System.Drawing.Size(226, 20);
            this.ProductosXClienteRadioButton.TabIndex = 2;
            this.ProductosXClienteRadioButton.TabStop = true;
            this.ProductosXClienteRadioButton.Text = "Producto mas vendido por cliente";
            this.ProductosXClienteRadioButton.UseVisualStyleBackColor = true;
            this.ProductosXClienteRadioButton.CheckedChanged += new System.EventHandler(this.ProductosXClienteRadioButton_CheckedChanged);
            // 
            // DiaRadioButton
            // 
            this.DiaRadioButton.AutoSize = true;
            this.DiaRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiaRadioButton.Location = new System.Drawing.Point(29, 122);
            this.DiaRadioButton.Name = "DiaRadioButton";
            this.DiaRadioButton.Size = new System.Drawing.Size(143, 20);
            this.DiaRadioButton.TabIndex = 3;
            this.DiaRadioButton.TabStop = true;
            this.DiaRadioButton.Text = "Dia de mayor venta";
            this.DiaRadioButton.UseVisualStyleBackColor = true;
            this.DiaRadioButton.CheckedChanged += new System.EventHandler(this.DiaRadioButton_CheckedChanged);
            // 
            // ProductosRadioButton
            // 
            this.ProductosRadioButton.AutoSize = true;
            this.ProductosRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductosRadioButton.Location = new System.Drawing.Point(29, 64);
            this.ProductosRadioButton.Name = "ProductosRadioButton";
            this.ProductosRadioButton.Size = new System.Drawing.Size(161, 20);
            this.ProductosRadioButton.TabIndex = 1;
            this.ProductosRadioButton.TabStop = true;
            this.ProductosRadioButton.Text = "Producto mas vendido";
            this.ProductosRadioButton.UseVisualStyleBackColor = true;
            this.ProductosRadioButton.CheckedChanged += new System.EventHandler(this.ProductosRadioButton_CheckedChanged);
            // 
            // VentasRadioButton
            // 
            this.VentasRadioButton.AutoSize = true;
            this.VentasRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VentasRadioButton.Location = new System.Drawing.Point(29, 35);
            this.VentasRadioButton.Name = "VentasRadioButton";
            this.VentasRadioButton.Size = new System.Drawing.Size(68, 20);
            this.VentasRadioButton.TabIndex = 0;
            this.VentasRadioButton.TabStop = true;
            this.VentasRadioButton.Text = "Ventas";
            this.VentasRadioButton.UseVisualStyleBackColor = true;
            this.VentasRadioButton.CheckedChanged += new System.EventHandler(this.VentasRadioButton_CheckedChanged);
            // 
            // MostrarButton
            // 
            this.MostrarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MostrarButton.Location = new System.Drawing.Point(797, 527);
            this.MostrarButton.Name = "MostrarButton";
            this.MostrarButton.Size = new System.Drawing.Size(75, 23);
            this.MostrarButton.TabIndex = 10;
            this.MostrarButton.Text = "Mostrar";
            this.MostrarButton.UseVisualStyleBackColor = true;
            this.MostrarButton.Click += new System.EventHandler(this.MostrarButton_Click);
            // 
            // EstadisticasForm
            // 
            this.AcceptButton = this.MostrarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.MostrarButton);
            this.Controls.Add(this.TipoGroupBox);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.DatosGroupBox);
            this.Controls.Add(this.EstadisticasDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EstadisticasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.EstadisticasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EstadisticasDataGridView)).EndInit();
            this.DatosGroupBox.ResumeLayout(false);
            this.DatosGroupBox.PerformLayout();
            this.TipoGroupBox.ResumeLayout(false);
            this.TipoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView EstadisticasDataGridView;
        private System.Windows.Forms.GroupBox DatosGroupBox;
        private System.Windows.Forms.ComboBox ClientesComboBox;
        private System.Windows.Forms.Label ClienteLabel;
        private System.Windows.Forms.DateTimePicker HastaDateTimePicker;
        private System.Windows.Forms.DateTimePicker DesdeDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.GroupBox TipoGroupBox;
        private System.Windows.Forms.RadioButton DiaRadioButton;
        private System.Windows.Forms.RadioButton ProductosRadioButton;
        private System.Windows.Forms.RadioButton VentasRadioButton;
        private System.Windows.Forms.Button MostrarButton;
        private System.Windows.Forms.RadioButton ProductosXClienteRadioButton;
    }
}