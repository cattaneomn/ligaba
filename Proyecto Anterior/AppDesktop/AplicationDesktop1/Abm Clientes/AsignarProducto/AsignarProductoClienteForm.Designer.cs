namespace AplicationDesktop1.Abm_Clientes
{
    partial class AsignarProductoClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignarProductoClienteForm));
            this.ClientesLabel = new System.Windows.Forms.Label();
            this.ClientesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.ProductoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ClientesLabel
            // 
            this.ClientesLabel.AutoSize = true;
            this.ClientesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesLabel.Location = new System.Drawing.Point(12, 31);
            this.ClientesLabel.Name = "ClientesLabel";
            this.ClientesLabel.Size = new System.Drawing.Size(407, 16);
            this.ClientesLabel.TabIndex = 6;
            this.ClientesLabel.Text = "Seleccione los clientes para los cuales desea agregar el producto:";
            // 
            // ClientesCheckedListBox
            // 
            this.ClientesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientesCheckedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesCheckedListBox.FormattingEnabled = true;
            this.ClientesCheckedListBox.Location = new System.Drawing.Point(12, 79);
            this.ClientesCheckedListBox.Name = "ClientesCheckedListBox";
            this.ClientesCheckedListBox.Size = new System.Drawing.Size(660, 327);
            this.ClientesCheckedListBox.TabIndex = 7;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarButton.BackColor = System.Drawing.SystemColors.Control;
            this.GuardarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarButton.Location = new System.Drawing.Point(597, 427);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 8;
            this.GuardarButton.Text = "Siguiente";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 427);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 9;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(12, 427);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 10;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // ProductoTextBox
            // 
            this.ProductoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductoTextBox.Location = new System.Drawing.Point(425, 30);
            this.ProductoTextBox.Name = "ProductoTextBox";
            this.ProductoTextBox.ReadOnly = true;
            this.ProductoTextBox.Size = new System.Drawing.Size(247, 22);
            this.ProductoTextBox.TabIndex = 11;
            // 
            // AsignarProductoClienteForm
            // 
            this.AcceptButton = this.GuardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.ProductoTextBox);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.ClientesCheckedListBox);
            this.Controls.Add(this.ClientesLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsignarProductoClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Producto";
            this.Load += new System.EventHandler(this.AsignarProductoClienteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ClientesLabel;
        private System.Windows.Forms.CheckedListBox ClientesCheckedListBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.TextBox ProductoTextBox;
    }
}