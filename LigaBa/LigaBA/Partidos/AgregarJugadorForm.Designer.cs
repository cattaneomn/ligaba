namespace LigaBA.Partidos
{
    partial class AgregarJugadorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarJugadorForm));
            this.Jugadores_DataGridView = new System.Windows.Forms.DataGridView();
            this.FiltroGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InstitucionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EquipoTextBox = new System.Windows.Forms.TextBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Jugadores_DataGridView)).BeginInit();
            this.FiltroGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Jugadores_DataGridView
            // 
            this.Jugadores_DataGridView.AllowUserToAddRows = false;
            this.Jugadores_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Jugadores_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Jugadores_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Jugadores_DataGridView.Location = new System.Drawing.Point(12, 141);
            this.Jugadores_DataGridView.Name = "Jugadores_DataGridView";
            this.Jugadores_DataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugadores_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Jugadores_DataGridView.Size = new System.Drawing.Size(660, 284);
            this.Jugadores_DataGridView.TabIndex = 11;
            // 
            // FiltroGroupBox
            // 
            this.FiltroGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltroGroupBox.Controls.Add(this.label3);
            this.FiltroGroupBox.Controls.Add(this.textBox1);
            this.FiltroGroupBox.Controls.Add(this.label2);
            this.FiltroGroupBox.Controls.Add(this.InstitucionTextBox);
            this.FiltroGroupBox.Controls.Add(this.label1);
            this.FiltroGroupBox.Controls.Add(this.EquipoTextBox);
            this.FiltroGroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FiltroGroupBox.Name = "FiltroGroupBox";
            this.FiltroGroupBox.Size = new System.Drawing.Size(660, 123);
            this.FiltroGroupBox.TabIndex = 12;
            this.FiltroGroupBox.TabStop = false;
            this.FiltroGroupBox.Text = "Filtro de Datos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Equipo";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(412, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 22);
            this.textBox1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Dni";
            // 
            // InstitucionTextBox
            // 
            this.InstitucionTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstitucionTextBox.Location = new System.Drawing.Point(120, 78);
            this.InstitucionTextBox.Name = "InstitucionTextBox";
            this.InstitucionTextBox.Size = new System.Drawing.Size(188, 22);
            this.InstitucionTextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Apellido";
            // 
            // EquipoTextBox
            // 
            this.EquipoTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipoTextBox.Location = new System.Drawing.Point(120, 37);
            this.EquipoTextBox.Name = "EquipoTextBox";
            this.EquipoTextBox.Size = new System.Drawing.Size(188, 22);
            this.EquipoTextBox.TabIndex = 0;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.Location = new System.Drawing.Point(12, 431);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 25);
            this.CancelarButton.TabIndex = 13;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // AgregarJugadorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.FiltroGroupBox);
            this.Controls.Add(this.Jugadores_DataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgregarJugadorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Jugador";
            this.Load += new System.EventHandler(this.AgregarJugadorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Jugadores_DataGridView)).EndInit();
            this.FiltroGroupBox.ResumeLayout(false);
            this.FiltroGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Jugadores_DataGridView;
        private System.Windows.Forms.GroupBox FiltroGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InstitucionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EquipoTextBox;
        private System.Windows.Forms.Button CancelarButton;
    }
}