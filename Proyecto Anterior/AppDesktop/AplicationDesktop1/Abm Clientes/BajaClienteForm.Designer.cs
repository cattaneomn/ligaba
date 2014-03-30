namespace AplicationDesktop1.Abm_Clientes
{
    partial class BajaClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BajaClienteForm));
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.ClienteDataGridView = new System.Windows.Forms.DataGridView();
            this.ClienteGroupBox = new System.Windows.Forms.GroupBox();
            this.RazonSocialTextBox = new System.Windows.Forms.TextBox();
            this.NombreUsuarioLabel = new System.Windows.Forms.Label();
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteDataGridView)).BeginInit();
            this.ClienteGroupBox.SuspendLayout();
            this.SuspendLayout();
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
            // ClienteDataGridView
            // 
            this.ClienteDataGridView.AllowUserToAddRows = false;
            this.ClienteDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClienteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClienteDataGridView.Location = new System.Drawing.Point(12, 159);
            this.ClienteDataGridView.Name = "ClienteDataGridView";
            this.ClienteDataGridView.ReadOnly = true;
            this.ClienteDataGridView.Size = new System.Drawing.Size(760, 362);
            this.ClienteDataGridView.TabIndex = 9;
            this.ClienteDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClienteDataGridView_CellContentClick);
            // 
            // ClienteGroupBox
            // 
            this.ClienteGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClienteGroupBox.Controls.Add(this.RazonSocialTextBox);
            this.ClienteGroupBox.Controls.Add(this.NombreUsuarioLabel);
            this.ClienteGroupBox.Location = new System.Drawing.Point(12, 16);
            this.ClienteGroupBox.Name = "ClienteGroupBox";
            this.ClienteGroupBox.Size = new System.Drawing.Size(760, 137);
            this.ClienteGroupBox.TabIndex = 10;
            this.ClienteGroupBox.TabStop = false;
            this.ClienteGroupBox.Text = "Datos del Cliente";
            // 
            // RazonSocialTextBox
            // 
            this.RazonSocialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RazonSocialTextBox.Location = new System.Drawing.Point(143, 63);
            this.RazonSocialTextBox.Name = "RazonSocialTextBox";
            this.RazonSocialTextBox.Size = new System.Drawing.Size(141, 22);
            this.RazonSocialTextBox.TabIndex = 1;
            // 
            // NombreUsuarioLabel
            // 
            this.NombreUsuarioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NombreUsuarioLabel.AutoSize = true;
            this.NombreUsuarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreUsuarioLabel.Location = new System.Drawing.Point(49, 64);
            this.NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            this.NombreUsuarioLabel.Size = new System.Drawing.Size(88, 16);
            this.NombreUsuarioLabel.TabIndex = 0;
            this.NombreUsuarioLabel.Text = "Razon Social";
            // 
            // BuscarButton
            // 
            this.BuscarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscarButton.Location = new System.Drawing.Point(697, 527);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 4;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // BajaClienteForm
            // 
            this.AcceptButton = this.BuscarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.ClienteGroupBox);
            this.Controls.Add(this.ClienteDataGridView);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.LimpiarButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BajaClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baja Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.ClienteDataGridView)).EndInit();
            this.ClienteGroupBox.ResumeLayout(false);
            this.ClienteGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.DataGridView ClienteDataGridView;
        private System.Windows.Forms.GroupBox ClienteGroupBox;
        private System.Windows.Forms.TextBox RazonSocialTextBox;
        private System.Windows.Forms.Label NombreUsuarioLabel;
        private System.Windows.Forms.Button BuscarButton;
    }
}