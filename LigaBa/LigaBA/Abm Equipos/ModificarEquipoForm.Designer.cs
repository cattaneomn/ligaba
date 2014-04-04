namespace LigaBA.Abm_Equipos
{
    partial class ModificarEquipoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarEquipoForm));
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.CategoriasComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InstitucionComboBox = new System.Windows.Forms.ComboBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.NombreJugadorLabel = new System.Windows.Forms.Label();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 325);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 25);
            this.LimpiarButton.TabIndex = 5;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
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
            this.CancelarButton.TabIndex = 6;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
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
            this.GuardarButton.TabIndex = 4;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.CategoriasComboBox);
            this.GroupBox.Controls.Add(this.label6);
            this.GroupBox.Controls.Add(this.label3);
            this.GroupBox.Controls.Add(this.InstitucionComboBox);
            this.GroupBox.Controls.Add(this.NombreTextBox);
            this.GroupBox.Controls.Add(this.NombreJugadorLabel);
            this.GroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox.Location = new System.Drawing.Point(12, 12);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(560, 309);
            this.GroupBox.TabIndex = 23;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Datos del Equipo";
            // 
            // CategoriasComboBox
            // 
            this.CategoriasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriasComboBox.FormattingEnabled = true;
            this.CategoriasComboBox.Location = new System.Drawing.Point(211, 105);
            this.CategoriasComboBox.Name = "CategoriasComboBox";
            this.CategoriasComboBox.Size = new System.Drawing.Size(172, 23);
            this.CategoriasComboBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(125, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Categoria";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(125, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Institución";
            // 
            // InstitucionComboBox
            // 
            this.InstitucionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InstitucionComboBox.FormattingEnabled = true;
            this.InstitucionComboBox.Location = new System.Drawing.Point(211, 67);
            this.InstitucionComboBox.Name = "InstitucionComboBox";
            this.InstitucionComboBox.Size = new System.Drawing.Size(172, 23);
            this.InstitucionComboBox.TabIndex = 1;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(211, 145);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(172, 21);
            this.NombreTextBox.TabIndex = 3;
            // 
            // NombreJugadorLabel
            // 
            this.NombreJugadorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NombreJugadorLabel.AutoSize = true;
            this.NombreJugadorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreJugadorLabel.Location = new System.Drawing.Point(125, 147);
            this.NombreJugadorLabel.Name = "NombreJugadorLabel";
            this.NombreJugadorLabel.Size = new System.Drawing.Size(62, 16);
            this.NombreJugadorLabel.TabIndex = 15;
            this.NombreJugadorLabel.Text = "Nombre*";
            // 
            // ModificarEquipoForm
            // 
            this.AcceptButton = this.GuardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.GroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarEquipoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Equipo";
            this.Load += new System.EventHandler(this.ModificarEquipoForm_Load);
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.ComboBox CategoriasComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox InstitucionComboBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label NombreJugadorLabel;
    }
}