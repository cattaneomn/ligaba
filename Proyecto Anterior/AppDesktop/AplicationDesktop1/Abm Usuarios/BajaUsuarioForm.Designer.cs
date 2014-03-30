namespace AplicationDesktop1.Abm_Usuarios
{
    partial class BajaUsuarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BajaUsuarioForm));
            this.UsuariosGroupBox = new System.Windows.Forms.GroupBox();
            this.NombreUsuarioTextBox = new System.Windows.Forms.TextBox();
            this.NombreUsuarioLabel = new System.Windows.Forms.Label();
            this.Usuario_DataGridView = new System.Windows.Forms.DataGridView();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.UsuariosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Usuario_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UsuariosGroupBox
            // 
            this.UsuariosGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsuariosGroupBox.Controls.Add(this.NombreUsuarioTextBox);
            this.UsuariosGroupBox.Controls.Add(this.NombreUsuarioLabel);
            this.UsuariosGroupBox.Location = new System.Drawing.Point(12, 12);
            this.UsuariosGroupBox.Name = "UsuariosGroupBox";
            this.UsuariosGroupBox.Size = new System.Drawing.Size(760, 137);
            this.UsuariosGroupBox.TabIndex = 1;
            this.UsuariosGroupBox.TabStop = false;
            this.UsuariosGroupBox.Text = "Datos del Usuario";
            // 
            // NombreUsuarioTextBox
            // 
            this.NombreUsuarioTextBox.Location = new System.Drawing.Point(162, 63);
            this.NombreUsuarioTextBox.Name = "NombreUsuarioTextBox";
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
            this.NombreUsuarioLabel.Location = new System.Drawing.Point(33, 64);
            this.NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            this.NombreUsuarioLabel.Size = new System.Drawing.Size(123, 16);
            this.NombreUsuarioLabel.TabIndex = 0;
            this.NombreUsuarioLabel.Text = "Nombre de usuario";
            // 
            // Usuario_DataGridView
            // 
            this.Usuario_DataGridView.AllowUserToAddRows = false;
            this.Usuario_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Usuario_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Usuario_DataGridView.Location = new System.Drawing.Point(12, 155);
            this.Usuario_DataGridView.Name = "Usuario_DataGridView";
            this.Usuario_DataGridView.ReadOnly = true;
            this.Usuario_DataGridView.Size = new System.Drawing.Size(760, 366);
            this.Usuario_DataGridView.TabIndex = 2;
            this.Usuario_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Usuario_DataGridView_CellContentClick);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscarButton.Location = new System.Drawing.Point(697, 527);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 3;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Location = new System.Drawing.Point(93, 527);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 4;
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
            this.CancelarButton.TabIndex = 5;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // BajaUsuarioForm
            // 
            this.AcceptButton = this.BuscarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.Usuario_DataGridView);
            this.Controls.Add(this.UsuariosGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BajaUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baja Usuario";
            this.UsuariosGroupBox.ResumeLayout(false);
            this.UsuariosGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Usuario_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox UsuariosGroupBox;
        private System.Windows.Forms.TextBox NombreUsuarioTextBox;
        private System.Windows.Forms.Label NombreUsuarioLabel;
        private System.Windows.Forms.DataGridView Usuario_DataGridView;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button CancelarButton;
    }
}