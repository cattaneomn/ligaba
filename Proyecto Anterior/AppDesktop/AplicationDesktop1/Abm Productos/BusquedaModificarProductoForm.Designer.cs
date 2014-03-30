namespace AplicationDesktop1.Abm_Productos
{
    partial class BusquedaModificarProductoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusquedaModificarProductoForm));
            this.ProductoGroupBox = new System.Windows.Forms.GroupBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.NombreUsuarioLabel = new System.Windows.Forms.Label();
            this.ProductosDataGridView = new System.Windows.Forms.DataGridView();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.ProductoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductoGroupBox
            // 
            this.ProductoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductoGroupBox.Controls.Add(this.NombreTextBox);
            this.ProductoGroupBox.Controls.Add(this.NombreUsuarioLabel);
            this.ProductoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ProductoGroupBox.Name = "ProductoGroupBox";
            this.ProductoGroupBox.Size = new System.Drawing.Size(760, 143);
            this.ProductoGroupBox.TabIndex = 12;
            this.ProductoGroupBox.TabStop = false;
            this.ProductoGroupBox.Text = "Datos del Producto";
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreTextBox.Location = new System.Drawing.Point(103, 66);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(141, 22);
            this.NombreTextBox.TabIndex = 1;
            // 
            // NombreUsuarioLabel
            // 
            this.NombreUsuarioLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NombreUsuarioLabel.AutoSize = true;
            this.NombreUsuarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreUsuarioLabel.Location = new System.Drawing.Point(40, 67);
            this.NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            this.NombreUsuarioLabel.Size = new System.Drawing.Size(57, 16);
            this.NombreUsuarioLabel.TabIndex = 0;
            this.NombreUsuarioLabel.Text = "Nombre";
            // 
            // ProductosDataGridView
            // 
            this.ProductosDataGridView.AllowUserToAddRows = false;
            this.ProductosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductosDataGridView.Location = new System.Drawing.Point(12, 161);
            this.ProductosDataGridView.Name = "ProductosDataGridView";
            this.ProductosDataGridView.ReadOnly = true;
            this.ProductosDataGridView.Size = new System.Drawing.Size(760, 360);
            this.ProductosDataGridView.TabIndex = 11;
            this.ProductosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductosDataGridView_CellContentClick);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscarButton.Location = new System.Drawing.Point(697, 527);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 13;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 527);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 14;
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
            this.CancelarButton.TabIndex = 15;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // BusquedaModificarProductoForm
            // 
            this.AcceptButton = this.BuscarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.ProductosDataGridView);
            this.Controls.Add(this.ProductoGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BusquedaModificarProductoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Producto";
            this.Load += new System.EventHandler(this.BusquedaModificarProductoForm_Load);
            this.ProductoGroupBox.ResumeLayout(false);
            this.ProductoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ProductoGroupBox;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label NombreUsuarioLabel;
        private System.Windows.Forms.DataGridView ProductosDataGridView;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button CancelarButton;
    }
}