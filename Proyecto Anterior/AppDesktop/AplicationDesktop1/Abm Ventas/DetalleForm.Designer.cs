namespace AplicationDesktop1.Abm_Ventas
{
    partial class DetalleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleForm));
            this.FacturaGroupBox = new System.Windows.Forms.GroupBox();
            this.ClientesComboBox = new System.Windows.Forms.ComboBox();
            this.NumFactTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.TelefonoTextBox = new System.Windows.Forms.TextBox();
            this.TelefonoLabel = new System.Windows.Forms.Label();
            this.DireccionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.FacturaDataGridView = new System.Windows.Forms.DataGridView();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.FacturaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FacturaGroupBox
            // 
            this.FacturaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FacturaGroupBox.Controls.Add(this.ClientesComboBox);
            this.FacturaGroupBox.Controls.Add(this.NumFactTextBox);
            this.FacturaGroupBox.Controls.Add(this.label4);
            this.FacturaGroupBox.Controls.Add(this.DireccionTextBox);
            this.FacturaGroupBox.Controls.Add(this.TelefonoTextBox);
            this.FacturaGroupBox.Controls.Add(this.TelefonoLabel);
            this.FacturaGroupBox.Controls.Add(this.DireccionLabel);
            this.FacturaGroupBox.Controls.Add(this.label2);
            this.FacturaGroupBox.Controls.Add(this.FechaDateTimePicker);
            this.FacturaGroupBox.Controls.Add(this.label1);
            this.FacturaGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacturaGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FacturaGroupBox.Name = "FacturaGroupBox";
            this.FacturaGroupBox.Size = new System.Drawing.Size(760, 167);
            this.FacturaGroupBox.TabIndex = 23;
            this.FacturaGroupBox.TabStop = false;
            this.FacturaGroupBox.Text = "Factura";
            // 
            // ClientesComboBox
            // 
            this.ClientesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientesComboBox.Enabled = false;
            this.ClientesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesComboBox.FormattingEnabled = true;
            this.ClientesComboBox.Location = new System.Drawing.Point(98, 36);
            this.ClientesComboBox.Name = "ClientesComboBox";
            this.ClientesComboBox.Size = new System.Drawing.Size(133, 24);
            this.ClientesComboBox.TabIndex = 30;
            // 
            // NumFactTextBox
            // 
            this.NumFactTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumFactTextBox.Location = new System.Drawing.Point(120, 81);
            this.NumFactTextBox.Name = "NumFactTextBox";
            this.NumFactTextBox.ReadOnly = true;
            this.NumFactTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NumFactTextBox.Size = new System.Drawing.Size(143, 22);
            this.NumFactTextBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nº Factura";
            // 
            // DireccionTextBox
            // 
            this.DireccionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DireccionTextBox.Location = new System.Drawing.Point(461, 38);
            this.DireccionTextBox.Name = "DireccionTextBox";
            this.DireccionTextBox.ReadOnly = true;
            this.DireccionTextBox.Size = new System.Drawing.Size(248, 22);
            this.DireccionTextBox.TabIndex = 24;
            // 
            // TelefonoTextBox
            // 
            this.TelefonoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelefonoTextBox.Location = new System.Drawing.Point(461, 81);
            this.TelefonoTextBox.Name = "TelefonoTextBox";
            this.TelefonoTextBox.ReadOnly = true;
            this.TelefonoTextBox.Size = new System.Drawing.Size(164, 22);
            this.TelefonoTextBox.TabIndex = 23;
            // 
            // TelefonoLabel
            // 
            this.TelefonoLabel.AutoSize = true;
            this.TelefonoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelefonoLabel.Location = new System.Drawing.Point(390, 82);
            this.TelefonoLabel.Name = "TelefonoLabel";
            this.TelefonoLabel.Size = new System.Drawing.Size(62, 16);
            this.TelefonoLabel.TabIndex = 12;
            this.TelefonoLabel.Text = "Telefono";
            // 
            // DireccionLabel
            // 
            this.DireccionLabel.AutoSize = true;
            this.DireccionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DireccionLabel.Location = new System.Drawing.Point(390, 39);
            this.DireccionLabel.Name = "DireccionLabel";
            this.DireccionLabel.Size = new System.Drawing.Size(65, 16);
            this.DireccionLabel.TabIndex = 13;
            this.DireccionLabel.Text = "Direccion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de Factura";
            // 
            // FechaDateTimePicker
            // 
            this.FechaDateTimePicker.Enabled = false;
            this.FechaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDateTimePicker.Location = new System.Drawing.Point(162, 124);
            this.FechaDateTimePicker.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.FechaDateTimePicker.Name = "FechaDateTimePicker";
            this.FechaDateTimePicker.Size = new System.Drawing.Size(239, 22);
            this.FechaDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // FacturaDataGridView
            // 
            this.FacturaDataGridView.AllowUserToAddRows = false;
            this.FacturaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FacturaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FacturaDataGridView.Location = new System.Drawing.Point(12, 185);
            this.FacturaDataGridView.Name = "FacturaDataGridView";
            this.FacturaDataGridView.ReadOnly = true;
            this.FacturaDataGridView.Size = new System.Drawing.Size(760, 337);
            this.FacturaDataGridView.TabIndex = 26;
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.Location = new System.Drawing.Point(624, 528);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TotalTextBox.Size = new System.Drawing.Size(148, 22);
            this.TotalTextBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(561, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "TOTAL";
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(12, 531);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 29;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // DetalleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotalTextBox);
            this.Controls.Add(this.FacturaDataGridView);
            this.Controls.Add(this.FacturaGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetalleForm";
            this.Text = "Detalle Factura";
            this.Load += new System.EventHandler(this.DetalleForm_Load);
            this.FacturaGroupBox.ResumeLayout(false);
            this.FacturaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox FacturaGroupBox;
        private System.Windows.Forms.TextBox NumFactTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.TextBox TelefonoTextBox;
        private System.Windows.Forms.Label TelefonoLabel;
        private System.Windows.Forms.Label DireccionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView FacturaDataGridView;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.ComboBox ClientesComboBox;
    }
}