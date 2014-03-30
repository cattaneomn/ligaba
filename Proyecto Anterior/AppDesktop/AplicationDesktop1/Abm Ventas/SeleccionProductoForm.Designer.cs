namespace AplicationDesktop1.Abm_Ventas
{
    partial class SeleccionProductoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionProductoForm));
            this.ProductosDataGridView = new System.Windows.Forms.DataGridView();
            this.FiltroGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FiltroTextBox = new System.Windows.Forms.TextBox();
            this.AgregarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.SeleccionGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CantidadUpDown = new System.Windows.Forms.NumericUpDown();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.ProductoTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosDataGridView)).BeginInit();
            this.FiltroGroupBox.SuspendLayout();
            this.SeleccionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductosDataGridView
            // 
            this.ProductosDataGridView.AllowUserToAddRows = false;
            this.ProductosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductosDataGridView.Location = new System.Drawing.Point(12, 107);
            this.ProductosDataGridView.Name = "ProductosDataGridView";
            this.ProductosDataGridView.ReadOnly = true;
            this.ProductosDataGridView.Size = new System.Drawing.Size(760, 265);
            this.ProductosDataGridView.TabIndex = 1;
            this.ProductosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductosDataGridView_CellContentClick);
            this.ProductosDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductosDataGridView_KeyDown);
            // 
            // FiltroGroupBox
            // 
            this.FiltroGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltroGroupBox.Controls.Add(this.label1);
            this.FiltroGroupBox.Controls.Add(this.FiltroTextBox);
            this.FiltroGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FiltroGroupBox.Name = "FiltroGroupBox";
            this.FiltroGroupBox.Size = new System.Drawing.Size(760, 89);
            this.FiltroGroupBox.TabIndex = 1;
            this.FiltroGroupBox.TabStop = false;
            this.FiltroGroupBox.Text = "Filtro de Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filtro";
            // 
            // FiltroTextBox
            // 
            this.FiltroTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroTextBox.Location = new System.Drawing.Point(81, 39);
            this.FiltroTextBox.Name = "FiltroTextBox";
            this.FiltroTextBox.Size = new System.Drawing.Size(190, 22);
            this.FiltroTextBox.TabIndex = 0;
            this.FiltroTextBox.TextChanged += new System.EventHandler(this.FiltroTextBox_TextChanged);
            this.FiltroTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FiltroTextBox_KeyDown);
            // 
            // AgregarButton
            // 
            this.AgregarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AgregarButton.Location = new System.Drawing.Point(661, 527);
            this.AgregarButton.Name = "AgregarButton";
            this.AgregarButton.Size = new System.Drawing.Size(111, 23);
            this.AgregarButton.TabIndex = 11;
            this.AgregarButton.Text = "Agregar Producto";
            this.AgregarButton.UseVisualStyleBackColor = true;
            this.AgregarButton.Click += new System.EventHandler(this.AgregarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(12, 527);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 12;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // SeleccionGroupBox
            // 
            this.SeleccionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeleccionGroupBox.Controls.Add(this.label4);
            this.SeleccionGroupBox.Controls.Add(this.label3);
            this.SeleccionGroupBox.Controls.Add(this.label2);
            this.SeleccionGroupBox.Controls.Add(this.CantidadUpDown);
            this.SeleccionGroupBox.Controls.Add(this.PrecioTextBox);
            this.SeleccionGroupBox.Controls.Add(this.ProductoTextBox);
            this.SeleccionGroupBox.Location = new System.Drawing.Point(12, 378);
            this.SeleccionGroupBox.Name = "SeleccionGroupBox";
            this.SeleccionGroupBox.Size = new System.Drawing.Size(760, 143);
            this.SeleccionGroupBox.TabIndex = 13;
            this.SeleccionGroupBox.TabStop = false;
            this.SeleccionGroupBox.Text = "Seleccion ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nombre";
            // 
            // CantidadUpDown
            // 
            this.CantidadUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CantidadUpDown.Location = new System.Drawing.Point(504, 43);
            this.CantidadUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.CantidadUpDown.Name = "CantidadUpDown";
            this.CantidadUpDown.Size = new System.Drawing.Size(120, 22);
            this.CantidadUpDown.TabIndex = 16;
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioTextBox.Location = new System.Drawing.Point(101, 94);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.ReadOnly = true;
            this.PrecioTextBox.Size = new System.Drawing.Size(190, 22);
            this.PrecioTextBox.TabIndex = 15;
            // 
            // ProductoTextBox
            // 
            this.ProductoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductoTextBox.Location = new System.Drawing.Point(101, 42);
            this.ProductoTextBox.Name = "ProductoTextBox";
            this.ProductoTextBox.ReadOnly = true;
            this.ProductoTextBox.Size = new System.Drawing.Size(190, 22);
            this.ProductoTextBox.TabIndex = 14;
            // 
            // SeleccionProductoForm
            // 
            this.AcceptButton = this.AgregarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.SeleccionGroupBox);
            this.Controls.Add(this.AgregarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.FiltroGroupBox);
            this.Controls.Add(this.ProductosDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeleccionProductoForm";
            this.Text = "Seleccion Producto";
            this.Load += new System.EventHandler(this.SeleccionProductoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductosDataGridView)).EndInit();
            this.FiltroGroupBox.ResumeLayout(false);
            this.FiltroGroupBox.PerformLayout();
            this.SeleccionGroupBox.ResumeLayout(false);
            this.SeleccionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductosDataGridView;
        private System.Windows.Forms.GroupBox FiltroGroupBox;
        private System.Windows.Forms.Button AgregarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FiltroTextBox;
        private System.Windows.Forms.GroupBox SeleccionGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CantidadUpDown;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.TextBox ProductoTextBox;
    }
}