namespace AplicationDesktop1.Abm_Usuarios
{
    partial class ModificarUsuarioPermisosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarUsuarioPermisosForm));
            this.UsuariosGroupBox = new System.Windows.Forms.GroupBox();
            this.HabilitadoCheckBox = new System.Windows.Forms.CheckBox();
            this.NombreUsuarioTextBox = new System.Windows.Forms.TextBox();
            this.NombreUsuarioLabel = new System.Windows.Forms.Label();
            this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.UsuariosGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsuariosGroupBox
            // 
            this.UsuariosGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsuariosGroupBox.Controls.Add(this.HabilitadoCheckBox);
            this.UsuariosGroupBox.Controls.Add(this.NombreUsuarioTextBox);
            this.UsuariosGroupBox.Controls.Add(this.NombreUsuarioLabel);
            this.UsuariosGroupBox.Location = new System.Drawing.Point(12, 12);
            this.UsuariosGroupBox.Name = "UsuariosGroupBox";
            this.UsuariosGroupBox.Size = new System.Drawing.Size(760, 119);
            this.UsuariosGroupBox.TabIndex = 1;
            this.UsuariosGroupBox.TabStop = false;
            this.UsuariosGroupBox.Text = "Datos del Usuario";
            // 
            // HabilitadoCheckBox
            // 
            this.HabilitadoCheckBox.AutoSize = true;
            this.HabilitadoCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HabilitadoCheckBox.Location = new System.Drawing.Point(509, 50);
            this.HabilitadoCheckBox.Name = "HabilitadoCheckBox";
            this.HabilitadoCheckBox.Size = new System.Drawing.Size(79, 19);
            this.HabilitadoCheckBox.TabIndex = 9;
            this.HabilitadoCheckBox.Text = "Hablitado";
            this.HabilitadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // NombreUsuarioTextBox
            // 
            this.NombreUsuarioTextBox.Location = new System.Drawing.Point(168, 50);
            this.NombreUsuarioTextBox.Name = "NombreUsuarioTextBox";
            this.NombreUsuarioTextBox.ReadOnly = true;
            this.NombreUsuarioTextBox.Size = new System.Drawing.Size(141, 20);
            this.NombreUsuarioTextBox.TabIndex = 1;
            // 
            // NombreUsuarioLabel
            // 
            this.NombreUsuarioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NombreUsuarioLabel.AutoSize = true;
            this.NombreUsuarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreUsuarioLabel.Location = new System.Drawing.Point(28, 51);
            this.NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            this.NombreUsuarioLabel.Size = new System.Drawing.Size(123, 16);
            this.NombreUsuarioLabel.TabIndex = 0;
            this.NombreUsuarioLabel.Text = "Nombre de usuario";
            // 
            // CheckedListBox
            // 
            this.CheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckedListBox.FormattingEnabled = true;
            this.CheckedListBox.Location = new System.Drawing.Point(12, 181);
            this.CheckedListBox.Name = "CheckedListBox";
            this.CheckedListBox.Size = new System.Drawing.Size(760, 340);
            this.CheckedListBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seleccione los permisos que desea que tenga el usuario.";
            // 
            // GuardarButton
            // 
            this.GuardarButton.BackColor = System.Drawing.SystemColors.Control;
            this.GuardarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.GuardarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarButton.Location = new System.Drawing.Point(697, 527);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 7;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(12, 527);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 8;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // ModificarUsuarioPermisosForm
            // 
            this.AcceptButton = this.GuardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CheckedListBox);
            this.Controls.Add(this.UsuariosGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarUsuarioPermisosForm";
            this.Text = "Modificar Permisos Usuario";
            this.Load += new System.EventHandler(this.ModificarUsuarioForm_Load);
            this.UsuariosGroupBox.ResumeLayout(false);
            this.UsuariosGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox UsuariosGroupBox;
        private System.Windows.Forms.TextBox NombreUsuarioTextBox;
        private System.Windows.Forms.Label NombreUsuarioLabel;
        private System.Windows.Forms.CheckedListBox CheckedListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.CheckBox HabilitadoCheckBox;
    }
}