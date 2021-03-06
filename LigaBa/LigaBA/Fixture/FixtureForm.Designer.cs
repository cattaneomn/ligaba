﻿namespace LigaBA.Fixture
{
    partial class FixtureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FixtureForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ModificarButton = new System.Windows.Forms.Button();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.Fixture_DataGridView = new System.Windows.Forms.DataGridView();
            this.ImprimirPartidoButton = new System.Windows.Forms.Button();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.EquipoComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TorneosComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CategoriasComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Fixture_DataGridView)).BeginInit();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModificarButton
            // 
            this.ModificarButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarButton.Image = ((System.Drawing.Image)(resources.GetObject("ModificarButton.Image")));
            this.ModificarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModificarButton.Location = new System.Drawing.Point(12, 157);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(156, 35);
            this.ModificarButton.TabIndex = 5;
            this.ModificarButton.Text = " Modificar Localia";
            this.ModificarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ModificarButton.UseVisualStyleBackColor = true;
            this.ModificarButton.Click += new System.EventHandler(this.ModificarButton_Click);
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LimpiarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LimpiarButton.Location = new System.Drawing.Point(93, 526);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 25);
            this.LimpiarButton.TabIndex = 8;
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
            this.CancelarButton.Location = new System.Drawing.Point(12, 526);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 25);
            this.CancelarButton.TabIndex = 9;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarButton.Location = new System.Drawing.Point(697, 528);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 7;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // Fixture_DataGridView
            // 
            this.Fixture_DataGridView.AllowUserToAddRows = false;
            this.Fixture_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Fixture_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Fixture_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Fixture_DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fixture_DataGridView.Location = new System.Drawing.Point(12, 198);
            this.Fixture_DataGridView.Name = "Fixture_DataGridView";
            this.Fixture_DataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Fixture_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fixture_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Fixture_DataGridView.Size = new System.Drawing.Size(760, 324);
            this.Fixture_DataGridView.TabIndex = 14;
            // 
            // ImprimirPartidoButton
            // 
            this.ImprimirPartidoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImprimirPartidoButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImprimirPartidoButton.Image = ((System.Drawing.Image)(resources.GetObject("ImprimirPartidoButton.Image")));
            this.ImprimirPartidoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImprimirPartidoButton.Location = new System.Drawing.Point(616, 157);
            this.ImprimirPartidoButton.Name = "ImprimirPartidoButton";
            this.ImprimirPartidoButton.Size = new System.Drawing.Size(156, 35);
            this.ImprimirPartidoButton.TabIndex = 6;
            this.ImprimirPartidoButton.Text = " Imprimir Fixture";
            this.ImprimirPartidoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ImprimirPartidoButton.UseVisualStyleBackColor = true;
            this.ImprimirPartidoButton.Click += new System.EventHandler(this.ImprimirPartidoButton_Click);
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.EquipoComboBox);
            this.GroupBox.Controls.Add(this.label4);
            this.GroupBox.Controls.Add(this.FechaComboBox);
            this.GroupBox.Controls.Add(this.label3);
            this.GroupBox.Controls.Add(this.label2);
            this.GroupBox.Controls.Add(this.TorneosComboBox);
            this.GroupBox.Controls.Add(this.label1);
            this.GroupBox.Controls.Add(this.CategoriasComboBox);
            this.GroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox.Location = new System.Drawing.Point(12, 13);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(760, 138);
            this.GroupBox.TabIndex = 23;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Filtros";
            // 
            // EquipoComboBox
            // 
            this.EquipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EquipoComboBox.FormattingEnabled = true;
            this.EquipoComboBox.Location = new System.Drawing.Point(471, 85);
            this.EquipoComboBox.Name = "EquipoComboBox";
            this.EquipoComboBox.Size = new System.Drawing.Size(172, 23);
            this.EquipoComboBox.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Equipo";
            // 
            // FechaComboBox
            // 
            this.FechaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FechaComboBox.FormattingEnabled = true;
            this.FechaComboBox.Location = new System.Drawing.Point(471, 34);
            this.FechaComboBox.Name = "FechaComboBox";
            this.FechaComboBox.Size = new System.Drawing.Size(172, 23);
            this.FechaComboBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Categoria*";
            // 
            // TorneosComboBox
            // 
            this.TorneosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TorneosComboBox.FormattingEnabled = true;
            this.TorneosComboBox.Location = new System.Drawing.Point(142, 34);
            this.TorneosComboBox.Name = "TorneosComboBox";
            this.TorneosComboBox.Size = new System.Drawing.Size(219, 23);
            this.TorneosComboBox.TabIndex = 1;
            this.TorneosComboBox.SelectionChangeCommitted += new System.EventHandler(this.TorneosComboBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Torneo*";
            // 
            // CategoriasComboBox
            // 
            this.CategoriasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriasComboBox.FormattingEnabled = true;
            this.CategoriasComboBox.Location = new System.Drawing.Point(142, 85);
            this.CategoriasComboBox.Name = "CategoriasComboBox";
            this.CategoriasComboBox.Size = new System.Drawing.Size(219, 23);
            this.CategoriasComboBox.TabIndex = 2;
            this.CategoriasComboBox.SelectionChangeCommitted += new System.EventHandler(this.CategoriasComboBox_SelectionChangeCommitted);
            // 
            // FixtureForm
            // 
            this.AcceptButton = this.BuscarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.ImprimirPartidoButton);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.Fixture_DataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FixtureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixture";
            this.Load += new System.EventHandler(this.PartidosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Fixture_DataGridView)).EndInit();
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ModificarButton;
        private System.Windows.Forms.Button LimpiarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridView Fixture_DataGridView;
        private System.Windows.Forms.Button ImprimirPartidoButton;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.ComboBox CategoriasComboBox;
        private System.Windows.Forms.ComboBox TorneosComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox EquipoComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FechaComboBox;
        private System.Windows.Forms.Label label3;
    }
}