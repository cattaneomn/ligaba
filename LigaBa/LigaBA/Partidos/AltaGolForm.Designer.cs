namespace LigaBA.Partidos
{
    partial class AltaGolForm
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
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.UsuariosGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EquipoComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.JugadoresComboBox = new System.Windows.Forms.ComboBox();
            this.GolesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.RojasNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AmarillasNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.UsuariosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GolesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RojasNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmarillasNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.Location = new System.Drawing.Point(12, 326);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 25);
            this.CancelarButton.TabIndex = 10;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarButton.BackColor = System.Drawing.SystemColors.Control;
            this.GuardarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarButton.Location = new System.Drawing.Point(497, 326);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 9;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            // 
            // UsuariosGroupBox
            // 
            this.UsuariosGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UsuariosGroupBox.Controls.Add(this.AmarillasNumericUpDown);
            this.UsuariosGroupBox.Controls.Add(this.RojasNumericUpDown);
            this.UsuariosGroupBox.Controls.Add(this.label8);
            this.UsuariosGroupBox.Controls.Add(this.GolesNumericUpDown);
            this.UsuariosGroupBox.Controls.Add(this.label4);
            this.UsuariosGroupBox.Controls.Add(this.JugadoresComboBox);
            this.UsuariosGroupBox.Controls.Add(this.label7);
            this.UsuariosGroupBox.Controls.Add(this.EquipoComboBox);
            this.UsuariosGroupBox.Controls.Add(this.label5);
            this.UsuariosGroupBox.Controls.Add(this.label6);
            this.UsuariosGroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuariosGroupBox.Location = new System.Drawing.Point(12, 11);
            this.UsuariosGroupBox.Name = "UsuariosGroupBox";
            this.UsuariosGroupBox.Size = new System.Drawing.Size(560, 309);
            this.UsuariosGroupBox.TabIndex = 8;
            this.UsuariosGroupBox.TabStop = false;
            this.UsuariosGroupBox.Text = "Datos del Jugador en el Partido";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(124, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Equipo";
            // 
            // EquipoComboBox
            // 
            this.EquipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquipoComboBox.Enabled = false;
            this.EquipoComboBox.FormattingEnabled = true;
            this.EquipoComboBox.Location = new System.Drawing.Point(264, 75);
            this.EquipoComboBox.Name = "EquipoComboBox";
            this.EquipoComboBox.Size = new System.Drawing.Size(172, 23);
            this.EquipoComboBox.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Tarjetas Rojas";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(124, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Tarjetas Amarillas";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Jugador";
            // 
            // JugadoresComboBox
            // 
            this.JugadoresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JugadoresComboBox.Enabled = false;
            this.JugadoresComboBox.FormattingEnabled = true;
            this.JugadoresComboBox.Location = new System.Drawing.Point(264, 114);
            this.JugadoresComboBox.Name = "JugadoresComboBox";
            this.JugadoresComboBox.Size = new System.Drawing.Size(172, 23);
            this.JugadoresComboBox.TabIndex = 39;
            // 
            // GolesNumericUpDown
            // 
            this.GolesNumericUpDown.Location = new System.Drawing.Point(264, 153);
            this.GolesNumericUpDown.Name = "GolesNumericUpDown";
            this.GolesNumericUpDown.Size = new System.Drawing.Size(172, 21);
            this.GolesNumericUpDown.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 42;
            this.label8.Text = "Goles";
            // 
            // RojasNumericUpDown
            // 
            this.RojasNumericUpDown.Location = new System.Drawing.Point(264, 207);
            this.RojasNumericUpDown.Name = "RojasNumericUpDown";
            this.RojasNumericUpDown.Size = new System.Drawing.Size(172, 21);
            this.RojasNumericUpDown.TabIndex = 43;
            // 
            // AmarillasNumericUpDown
            // 
            this.AmarillasNumericUpDown.Location = new System.Drawing.Point(264, 180);
            this.AmarillasNumericUpDown.Name = "AmarillasNumericUpDown";
            this.AmarillasNumericUpDown.Size = new System.Drawing.Size(172, 21);
            this.AmarillasNumericUpDown.TabIndex = 44;
            // 
            // AltaGolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.UsuariosGroupBox);
            this.Name = "AltaGolForm";
            this.Text = "Datos del jugador";
            this.Load += new System.EventHandler(this.AltaGolForm_Load);
            this.UsuariosGroupBox.ResumeLayout(false);
            this.UsuariosGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GolesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RojasNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmarillasNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.GroupBox UsuariosGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox JugadoresComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox EquipoComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown GolesNumericUpDown;
        private System.Windows.Forms.NumericUpDown AmarillasNumericUpDown;
        private System.Windows.Forms.NumericUpDown RojasNumericUpDown;
    }
}