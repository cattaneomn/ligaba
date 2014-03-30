namespace LigaBA.Abm_Jugador
{
    partial class AltaJugadorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaJugadorForm));
            this.JugadorGroupBox = new System.Windows.Forms.GroupBox();
            this.CategoriasComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EquipoComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.InstitucionComboBox = new System.Windows.Forms.ComboBox();
            this.FechaNacimeintiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ApellidoTextBox = new System.Windows.Forms.TextBox();
            this.DniTextBox = new System.Windows.Forms.TextBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NombreJugadorLabel = new System.Windows.Forms.Label();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.JugadorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // JugadorGroupBox
            // 
            this.JugadorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.JugadorGroupBox.Controls.Add(this.CategoriasComboBox);
            this.JugadorGroupBox.Controls.Add(this.label6);
            this.JugadorGroupBox.Controls.Add(this.label4);
            this.JugadorGroupBox.Controls.Add(this.EquipoComboBox);
            this.JugadorGroupBox.Controls.Add(this.label5);
            this.JugadorGroupBox.Controls.Add(this.InstitucionComboBox);
            this.JugadorGroupBox.Controls.Add(this.FechaNacimeintiDateTimePicker);
            this.JugadorGroupBox.Controls.Add(this.label3);
            this.JugadorGroupBox.Controls.Add(this.ApellidoTextBox);
            this.JugadorGroupBox.Controls.Add(this.DniTextBox);
            this.JugadorGroupBox.Controls.Add(this.NombreTextBox);
            this.JugadorGroupBox.Controls.Add(this.label2);
            this.JugadorGroupBox.Controls.Add(this.label1);
            this.JugadorGroupBox.Controls.Add(this.NombreJugadorLabel);
            this.JugadorGroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JugadorGroupBox.Location = new System.Drawing.Point(12, 12);
            this.JugadorGroupBox.Name = "JugadorGroupBox";
            this.JugadorGroupBox.Size = new System.Drawing.Size(560, 309);
            this.JugadorGroupBox.TabIndex = 0;
            this.JugadorGroupBox.TabStop = false;
            this.JugadorGroupBox.Text = "Datos del Jugador";
            // 
            // CategoriasComboBox
            // 
            this.CategoriasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriasComboBox.FormattingEnabled = true;
            this.CategoriasComboBox.Location = new System.Drawing.Point(218, 67);
            this.CategoriasComboBox.Name = "CategoriasComboBox";
            this.CategoriasComboBox.Size = new System.Drawing.Size(172, 23);
            this.CategoriasComboBox.TabIndex = 13;
            this.CategoriasComboBox.SelectedValueChanged += new System.EventHandler(this.CategoriasComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(78, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Equipo";
            // 
            // EquipoComboBox
            // 
            this.EquipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquipoComboBox.FormattingEnabled = true;
            this.EquipoComboBox.Location = new System.Drawing.Point(218, 102);
            this.EquipoComboBox.Name = "EquipoComboBox";
            this.EquipoComboBox.Size = new System.Drawing.Size(172, 23);
            this.EquipoComboBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Institución";
            // 
            // InstitucionComboBox
            // 
            this.InstitucionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InstitucionComboBox.FormattingEnabled = true;
            this.InstitucionComboBox.Location = new System.Drawing.Point(218, 29);
            this.InstitucionComboBox.Name = "InstitucionComboBox";
            this.InstitucionComboBox.Size = new System.Drawing.Size(172, 23);
            this.InstitucionComboBox.TabIndex = 14;
            this.InstitucionComboBox.SelectedValueChanged += new System.EventHandler(this.InstitucionComboBox_SelectedValueChanged);
            // 
            // FechaNacimeintiDateTimePicker
            // 
            this.FechaNacimeintiDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaNacimeintiDateTimePicker.Location = new System.Drawing.Point(218, 243);
            this.FechaNacimeintiDateTimePicker.Name = "FechaNacimeintiDateTimePicker";
            this.FechaNacimeintiDateTimePicker.Size = new System.Drawing.Size(172, 21);
            this.FechaNacimeintiDateTimePicker.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha de nacimiento*";
            // 
            // ApellidoTextBox
            // 
            this.ApellidoTextBox.Location = new System.Drawing.Point(218, 172);
            this.ApellidoTextBox.Name = "ApellidoTextBox";
            this.ApellidoTextBox.Size = new System.Drawing.Size(172, 21);
            this.ApellidoTextBox.TabIndex = 5;
            // 
            // DniTextBox
            // 
            this.DniTextBox.Location = new System.Drawing.Point(218, 208);
            this.DniTextBox.Name = "DniTextBox";
            this.DniTextBox.Size = new System.Drawing.Size(172, 21);
            this.DniTextBox.TabIndex = 6;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(218, 138);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(172, 21);
            this.NombreTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dni*";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Apellido*";
            // 
            // NombreJugadorLabel
            // 
            this.NombreJugadorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NombreJugadorLabel.AutoSize = true;
            this.NombreJugadorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreJugadorLabel.Location = new System.Drawing.Point(78, 140);
            this.NombreJugadorLabel.Name = "NombreJugadorLabel";
            this.NombreJugadorLabel.Size = new System.Drawing.Size(62, 16);
            this.NombreJugadorLabel.TabIndex = 0;
            this.NombreJugadorLabel.Text = "Nombre*";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarButton.BackColor = System.Drawing.SystemColors.Control;
            this.GuardarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarButton.Location = new System.Drawing.Point(497, 327);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 8;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.Location = new System.Drawing.Point(12, 325);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 25);
            this.CancelarButton.TabIndex = 10;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 325);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 25);
            this.LimpiarButton.TabIndex = 9;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // AltaJugadorForm
            // 
            this.AcceptButton = this.GuardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.JugadorGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltaJugadorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Jugador";
            this.Load += new System.EventHandler(this.AltaJugadorForm_Load);
            this.JugadorGroupBox.ResumeLayout(false);
            this.JugadorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox JugadorGroupBox;
        private System.Windows.Forms.Label NombreJugadorLabel;
        private System.Windows.Forms.TextBox ApellidoTextBox;
        private System.Windows.Forms.TextBox DniTextBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.DateTimePicker FechaNacimeintiDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CategoriasComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EquipoComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox InstitucionComboBox;
    }
}