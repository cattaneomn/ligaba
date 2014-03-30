namespace AplicationDesktop1.Abm_Ventas
{
    partial class AltaFacturaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaFacturaForm));
            this.FacturaGroupBox = new System.Windows.Forms.GroupBox();
            this.NumFactTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.TelefonoTextBox = new System.Windows.Forms.TextBox();
            this.TelefonoLabel = new System.Windows.Forms.Label();
            this.DireccionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ClientesComboBox = new System.Windows.Forms.ComboBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.FacturaDataGridView = new System.Windows.Forms.DataGridView();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FacturaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FacturaGroupBox
            // 
            this.FacturaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FacturaGroupBox.Controls.Add(this.NumFactTextBox);
            this.FacturaGroupBox.Controls.Add(this.label4);
            this.FacturaGroupBox.Controls.Add(this.DireccionTextBox);
            this.FacturaGroupBox.Controls.Add(this.TelefonoTextBox);
            this.FacturaGroupBox.Controls.Add(this.TelefonoLabel);
            this.FacturaGroupBox.Controls.Add(this.DireccionLabel);
            this.FacturaGroupBox.Controls.Add(this.label2);
            this.FacturaGroupBox.Controls.Add(this.FechaDateTimePicker);
            this.FacturaGroupBox.Controls.Add(this.label1);
            this.FacturaGroupBox.Controls.Add(this.ClientesComboBox);
            this.FacturaGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacturaGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FacturaGroupBox.Name = "FacturaGroupBox";
            this.FacturaGroupBox.Size = new System.Drawing.Size(760, 167);
            this.FacturaGroupBox.TabIndex = 22;
            this.FacturaGroupBox.TabStop = false;
            this.FacturaGroupBox.Text = "Factura";
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
            this.DireccionTextBox.Visible = false;
            // 
            // TelefonoTextBox
            // 
            this.TelefonoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TelefonoTextBox.Location = new System.Drawing.Point(461, 81);
            this.TelefonoTextBox.Name = "TelefonoTextBox";
            this.TelefonoTextBox.ReadOnly = true;
            this.TelefonoTextBox.Size = new System.Drawing.Size(164, 22);
            this.TelefonoTextBox.TabIndex = 23;
            this.TelefonoTextBox.Visible = false;
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
            this.TelefonoLabel.Visible = false;
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
            this.DireccionLabel.Visible = false;
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
            this.FechaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FechaDateTimePicker.Location = new System.Drawing.Point(162, 124);
            this.FechaDateTimePicker.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.FechaDateTimePicker.Name = "FechaDateTimePicker";
            this.FechaDateTimePicker.Size = new System.Drawing.Size(241, 22);
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
            // ClientesComboBox
            // 
            this.ClientesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesComboBox.FormattingEnabled = true;
            this.ClientesComboBox.Location = new System.Drawing.Point(98, 38);
            this.ClientesComboBox.Name = "ClientesComboBox";
            this.ClientesComboBox.Size = new System.Drawing.Size(133, 24);
            this.ClientesComboBox.TabIndex = 0;
            this.ClientesComboBox.SelectionChangeCommitted += new System.EventHandler(this.ClientesComboBox_SelectionChangeCommitted);
            // 
            // AgregarButton
            // 
            this.AgregarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AgregarButton.Enabled = false;
            this.AgregarButton.Location = new System.Drawing.Point(580, 185);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(111, 23);
            this.AgregarButton.TabIndex = 4;
            this.AgregarButton.Text = "Agregar Producto";
            this.AgregarButton.UseVisualStyleBackColor = true;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // EliminarButton
            // 
            this.EliminarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EliminarButton.Enabled = false;
            this.EliminarButton.Location = new System.Drawing.Point(697, 185);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(75, 23);
            this.EliminarButton.TabIndex = 5;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.UseVisualStyleBackColor = true;
            this.EliminarButton.Click += new System.EventHandler(this.EliminarButton_Click);
            // 
            // FacturaDataGridView
            // 
            this.FacturaDataGridView.AllowUserToAddRows = false;
            this.FacturaDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FacturaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FacturaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FacturaDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.FacturaDataGridView.Location = new System.Drawing.Point(12, 214);
            this.FacturaDataGridView.Name = "FacturaDataGridView";
            this.FacturaDataGridView.ReadOnly = true;
            this.FacturaDataGridView.Size = new System.Drawing.Size(760, 281);
            this.FacturaDataGridView.TabIndex = 18;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(12, 527);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 6;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 527);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 7;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarButton.BackColor = System.Drawing.SystemColors.Control;
            this.GuardarButton.Enabled = false;
            this.GuardarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarButton.Location = new System.Drawing.Point(697, 527);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 2;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTextBox.Location = new System.Drawing.Point(624, 501);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.ReadOnly = true;
            this.TotalTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TotalTextBox.Size = new System.Drawing.Size(148, 22);
            this.TotalTextBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(561, 502);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "TOTAL";
            // 
            // AltaFacturaForm
            // 
            this.AcceptButton = this.AgregarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.FacturaGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotalTextBox);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.FacturaDataGridView);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.AgregarButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltaFacturaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Productos";
            this.Load += new System.EventHandler(this.AltaFacturaForm_Load);
            this.FacturaGroupBox.ResumeLayout(false);
            this.FacturaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox FacturaGroupBox;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.TextBox TelefonoTextBox;
        private System.Windows.Forms.Label TelefonoLabel;
        private System.Windows.Forms.Label DireccionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker FechaDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ClientesComboBox;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.Button EliminarButton;
        private System.Windows.Forms.DataGridView FacturaDataGridView;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumFactTextBox;
        private System.Windows.Forms.Label label4;
    }
}