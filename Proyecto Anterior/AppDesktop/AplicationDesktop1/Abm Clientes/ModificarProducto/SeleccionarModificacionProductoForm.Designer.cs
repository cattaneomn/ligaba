namespace AplicationDesktop1.Abm_Clientes
{
    partial class SeleccionarModificacionProductoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarModificacionProductoForm));
            this.TipoGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TodosLosProductosRadioButton = new System.Windows.Forms.RadioButton();
            this.UnProductoRadioButton = new System.Windows.Forms.RadioButton();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.TipoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TipoGroupBox
            // 
            this.TipoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TipoGroupBox.Controls.Add(this.label1);
            this.TipoGroupBox.Controls.Add(this.TodosLosProductosRadioButton);
            this.TipoGroupBox.Controls.Add(this.UnProductoRadioButton);
            this.TipoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.TipoGroupBox.Name = "TipoGroupBox";
            this.TipoGroupBox.Size = new System.Drawing.Size(460, 209);
            this.TipoGroupBox.TabIndex = 6;
            this.TipoGroupBox.TabStop = false;
            this.TipoGroupBox.Text = "Tipo de Modificacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione el tipo de modificacion que desea realizar :";
            // 
            // TodosLosProductosRadioButton
            // 
            this.TodosLosProductosRadioButton.AutoSize = true;
            this.TodosLosProductosRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodosLosProductosRadioButton.Location = new System.Drawing.Point(60, 137);
            this.TodosLosProductosRadioButton.Name = "TodosLosProductosRadioButton";
            this.TodosLosProductosRadioButton.Size = new System.Drawing.Size(357, 20);
            this.TodosLosProductosRadioButton.TabIndex = 1;
            this.TodosLosProductosRadioButton.TabStop = true;
            this.TodosLosProductosRadioButton.Text = "Modificar el precio de todos los productos de un cliente.";
            this.TodosLosProductosRadioButton.UseVisualStyleBackColor = true;
            // 
            // UnProductoRadioButton
            // 
            this.UnProductoRadioButton.AutoSize = true;
            this.UnProductoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnProductoRadioButton.Location = new System.Drawing.Point(60, 82);
            this.UnProductoRadioButton.Name = "UnProductoRadioButton";
            this.UnProductoRadioButton.Size = new System.Drawing.Size(309, 20);
            this.UnProductoRadioButton.TabIndex = 0;
            this.UnProductoRadioButton.TabStop = true;
            this.UnProductoRadioButton.Text = "Modificar el precio de un producto de un cliente.";
            this.UnProductoRadioButton.UseVisualStyleBackColor = true;
            // 
            // AceptarButton
            // 
            this.AceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AceptarButton.Location = new System.Drawing.Point(397, 227);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 11;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(12, 227);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 12;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // SeleccionarModificacionProductoForm
            // 
            this.AcceptButton = this.AceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.TipoGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeleccionarModificacionProductoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Modificacion Producto";
            this.TipoGroupBox.ResumeLayout(false);
            this.TipoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox TipoGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TodosLosProductosRadioButton;
        private System.Windows.Forms.RadioButton UnProductoRadioButton;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button CancelarButton;
    }
}