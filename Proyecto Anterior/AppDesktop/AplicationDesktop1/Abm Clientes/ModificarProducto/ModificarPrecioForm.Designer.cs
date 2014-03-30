namespace AplicationDesktop1.Abm_Clientes
{
    partial class ModificarPrecioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarPrecioForm));
            this.PrecioGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductoTextBox = new System.Windows.Forms.TextBox();
            this.PrecioUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClienteTextBox = new System.Windows.Forms.TextBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.PrecioGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrecioUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PrecioGroupBox
            // 
            this.PrecioGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrecioGroupBox.Controls.Add(this.label3);
            this.PrecioGroupBox.Controls.Add(this.ProductoTextBox);
            this.PrecioGroupBox.Controls.Add(this.PrecioUpDown);
            this.PrecioGroupBox.Controls.Add(this.label2);
            this.PrecioGroupBox.Controls.Add(this.label1);
            this.PrecioGroupBox.Controls.Add(this.ClienteTextBox);
            this.PrecioGroupBox.Location = new System.Drawing.Point(12, 12);
            this.PrecioGroupBox.Name = "PrecioGroupBox";
            this.PrecioGroupBox.Size = new System.Drawing.Size(360, 209);
            this.PrecioGroupBox.TabIndex = 10;
            this.PrecioGroupBox.TabStop = false;
            this.PrecioGroupBox.Text = "Precio del Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Producto";
            // 
            // ProductoTextBox
            // 
            this.ProductoTextBox.Enabled = false;
            this.ProductoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductoTextBox.Location = new System.Drawing.Point(91, 91);
            this.ProductoTextBox.Name = "ProductoTextBox";
            this.ProductoTextBox.ReadOnly = true;
            this.ProductoTextBox.Size = new System.Drawing.Size(204, 22);
            this.ProductoTextBox.TabIndex = 4;
            // 
            // PrecioUpDown
            // 
            this.PrecioUpDown.DecimalPlaces = 2;
            this.PrecioUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioUpDown.Location = new System.Drawing.Point(91, 155);
            this.PrecioUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.PrecioUpDown.Name = "PrecioUpDown";
            this.PrecioUpDown.Size = new System.Drawing.Size(131, 22);
            this.PrecioUpDown.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Precio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente";
            // 
            // ClienteTextBox
            // 
            this.ClienteTextBox.Enabled = false;
            this.ClienteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClienteTextBox.Location = new System.Drawing.Point(91, 37);
            this.ClienteTextBox.Name = "ClienteTextBox";
            this.ClienteTextBox.ReadOnly = true;
            this.ClienteTextBox.Size = new System.Drawing.Size(204, 22);
            this.ClienteTextBox.TabIndex = 1;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarButton.Location = new System.Drawing.Point(297, 227);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 23);
            this.GuardarButton.TabIndex = 11;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
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
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 227);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 13;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // ModificarPrecioForm
            // 
            this.AcceptButton = this.GuardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.PrecioGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarPrecioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Precio";
            this.Load += new System.EventHandler(this.ModificarPrecioForm_Load);
            this.PrecioGroupBox.ResumeLayout(false);
            this.PrecioGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrecioUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PrecioGroupBox;
        private System.Windows.Forms.NumericUpDown PrecioUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ClienteTextBox;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProductoTextBox;
        private System.Windows.Forms.Button LimpiarButton;
    }
}