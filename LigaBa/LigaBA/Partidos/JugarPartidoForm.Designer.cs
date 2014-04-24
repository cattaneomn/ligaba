namespace LigaBA.Partidos
{
    partial class JugarPartidoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JugarPartidoForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GolesTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Equipos_DataGridView = new System.Windows.Forms.DataGridView();
            this.EliminarGolesButton = new System.Windows.Forms.Button();
            this.AgregarGolesButton = new System.Windows.Forms.Button();
            this.AmarillasTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EliminarAmarillasButton = new System.Windows.Forms.Button();
            this.AgregarAmarillasButton = new System.Windows.Forms.Button();
            this.RojasTab = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.EliminarRojasButton = new System.Windows.Forms.Button();
            this.AgregarRojasButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.GolesVisitanteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GolesLocalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.VisitanteLabel = new System.Windows.Forms.Label();
            this.LocalLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TorneoLabel = new System.Windows.Forms.Label();
            this.CategoriaLabel = new System.Windows.Forms.Label();
            this.FechaLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GolesTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Equipos_DataGridView)).BeginInit();
            this.AmarillasTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.RojasTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GolesVisitanteNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GolesLocalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GolesTab
            // 
            this.GolesTab.Controls.Add(this.tabPage1);
            this.GolesTab.Controls.Add(this.AmarillasTab);
            this.GolesTab.Controls.Add(this.RojasTab);
            this.GolesTab.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GolesTab.Location = new System.Drawing.Point(12, 147);
            this.GolesTab.Name = "GolesTab";
            this.GolesTab.SelectedIndex = 0;
            this.GolesTab.Size = new System.Drawing.Size(710, 327);
            this.GolesTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Equipos_DataGridView);
            this.tabPage1.Controls.Add(this.EliminarGolesButton);
            this.tabPage1.Controls.Add(this.AgregarGolesButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(702, 299);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Goles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Equipos_DataGridView
            // 
            this.Equipos_DataGridView.AllowUserToAddRows = false;
            this.Equipos_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Equipos_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Equipos_DataGridView.Location = new System.Drawing.Point(6, 47);
            this.Equipos_DataGridView.Name = "Equipos_DataGridView";
            this.Equipos_DataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Equipos_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Equipos_DataGridView.Size = new System.Drawing.Size(690, 249);
            this.Equipos_DataGridView.TabIndex = 10;
            // 
            // EliminarGolesButton
            // 
            this.EliminarGolesButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarGolesButton.Image = ((System.Drawing.Image)(resources.GetObject("EliminarGolesButton.Image")));
            this.EliminarGolesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EliminarGolesButton.Location = new System.Drawing.Point(117, 6);
            this.EliminarGolesButton.Name = "EliminarGolesButton";
            this.EliminarGolesButton.Size = new System.Drawing.Size(105, 35);
            this.EliminarGolesButton.TabIndex = 11;
            this.EliminarGolesButton.Text = "  Eliminar";
            this.EliminarGolesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EliminarGolesButton.UseVisualStyleBackColor = true;
            // 
            // AgregarGolesButton
            // 
            this.AgregarGolesButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarGolesButton.Image = ((System.Drawing.Image)(resources.GetObject("AgregarGolesButton.Image")));
            this.AgregarGolesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AgregarGolesButton.Location = new System.Drawing.Point(6, 6);
            this.AgregarGolesButton.Name = "AgregarGolesButton";
            this.AgregarGolesButton.Size = new System.Drawing.Size(105, 35);
            this.AgregarGolesButton.TabIndex = 10;
            this.AgregarGolesButton.Text = "  Agregar";
            this.AgregarGolesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AgregarGolesButton.UseVisualStyleBackColor = true;
            this.AgregarGolesButton.Click += new System.EventHandler(this.AgregarGolesButton_Click);
            // 
            // AmarillasTab
            // 
            this.AmarillasTab.Controls.Add(this.dataGridView1);
            this.AmarillasTab.Controls.Add(this.EliminarAmarillasButton);
            this.AmarillasTab.Controls.Add(this.AgregarAmarillasButton);
            this.AmarillasTab.Location = new System.Drawing.Point(4, 24);
            this.AmarillasTab.Name = "AmarillasTab";
            this.AmarillasTab.Padding = new System.Windows.Forms.Padding(3);
            this.AmarillasTab.Size = new System.Drawing.Size(702, 299);
            this.AmarillasTab.TabIndex = 1;
            this.AmarillasTab.Text = "Tarjetas Amarillas";
            this.AmarillasTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Size = new System.Drawing.Size(690, 249);
            this.dataGridView1.TabIndex = 14;
            // 
            // EliminarAmarillasButton
            // 
            this.EliminarAmarillasButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarAmarillasButton.Image = ((System.Drawing.Image)(resources.GetObject("EliminarAmarillasButton.Image")));
            this.EliminarAmarillasButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EliminarAmarillasButton.Location = new System.Drawing.Point(117, 6);
            this.EliminarAmarillasButton.Name = "EliminarAmarillasButton";
            this.EliminarAmarillasButton.Size = new System.Drawing.Size(105, 35);
            this.EliminarAmarillasButton.TabIndex = 13;
            this.EliminarAmarillasButton.Text = "  Eliminar";
            this.EliminarAmarillasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EliminarAmarillasButton.UseVisualStyleBackColor = true;
            // 
            // AgregarAmarillasButton
            // 
            this.AgregarAmarillasButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarAmarillasButton.Image = ((System.Drawing.Image)(resources.GetObject("AgregarAmarillasButton.Image")));
            this.AgregarAmarillasButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AgregarAmarillasButton.Location = new System.Drawing.Point(6, 6);
            this.AgregarAmarillasButton.Name = "AgregarAmarillasButton";
            this.AgregarAmarillasButton.Size = new System.Drawing.Size(105, 35);
            this.AgregarAmarillasButton.TabIndex = 12;
            this.AgregarAmarillasButton.Text = "  Agregar";
            this.AgregarAmarillasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AgregarAmarillasButton.UseVisualStyleBackColor = true;
            // 
            // RojasTab
            // 
            this.RojasTab.Controls.Add(this.dataGridView2);
            this.RojasTab.Controls.Add(this.EliminarRojasButton);
            this.RojasTab.Controls.Add(this.AgregarRojasButton);
            this.RojasTab.Location = new System.Drawing.Point(4, 24);
            this.RojasTab.Name = "RojasTab";
            this.RojasTab.Padding = new System.Windows.Forms.Padding(3);
            this.RojasTab.Size = new System.Drawing.Size(702, 299);
            this.RojasTab.TabIndex = 2;
            this.RojasTab.Text = "Tarjetas Rojas";
            this.RojasTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 47);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.Size = new System.Drawing.Size(690, 249);
            this.dataGridView2.TabIndex = 14;
            // 
            // EliminarRojasButton
            // 
            this.EliminarRojasButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarRojasButton.Image = ((System.Drawing.Image)(resources.GetObject("EliminarRojasButton.Image")));
            this.EliminarRojasButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EliminarRojasButton.Location = new System.Drawing.Point(117, 6);
            this.EliminarRojasButton.Name = "EliminarRojasButton";
            this.EliminarRojasButton.Size = new System.Drawing.Size(105, 35);
            this.EliminarRojasButton.TabIndex = 13;
            this.EliminarRojasButton.Text = "  Eliminar";
            this.EliminarRojasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EliminarRojasButton.UseVisualStyleBackColor = true;
            // 
            // AgregarRojasButton
            // 
            this.AgregarRojasButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarRojasButton.Image = ((System.Drawing.Image)(resources.GetObject("AgregarRojasButton.Image")));
            this.AgregarRojasButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AgregarRojasButton.Location = new System.Drawing.Point(6, 6);
            this.AgregarRojasButton.Name = "AgregarRojasButton";
            this.AgregarRojasButton.Size = new System.Drawing.Size(105, 35);
            this.AgregarRojasButton.TabIndex = 12;
            this.AgregarRojasButton.Text = "  Agregar";
            this.AgregarRojasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AgregarRojasButton.UseVisualStyleBackColor = true;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelarButton.AutoSize = true;
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelarButton.Location = new System.Drawing.Point(12, 476);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 25);
            this.CancelarButton.TabIndex = 9;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GuardarButton.BackColor = System.Drawing.SystemColors.Control;
            this.GuardarButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GuardarButton.Location = new System.Drawing.Point(647, 476);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 24);
            this.GuardarButton.TabIndex = 7;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.label6);
            this.GroupBox.Controls.Add(this.label5);
            this.GroupBox.Controls.Add(this.FechaLabel);
            this.GroupBox.Controls.Add(this.CategoriaLabel);
            this.GroupBox.Controls.Add(this.TorneoLabel);
            this.GroupBox.Controls.Add(this.GolesVisitanteNumericUpDown);
            this.GroupBox.Controls.Add(this.GolesLocalNumericUpDown);
            this.GroupBox.Controls.Add(this.label4);
            this.GroupBox.Controls.Add(this.VisitanteLabel);
            this.GroupBox.Controls.Add(this.LocalLabel);
            this.GroupBox.Controls.Add(this.label3);
            this.GroupBox.Controls.Add(this.label2);
            this.GroupBox.Controls.Add(this.label1);
            this.GroupBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox.Location = new System.Drawing.Point(12, 12);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(710, 129);
            this.GroupBox.TabIndex = 24;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Partido";
            // 
            // GolesVisitanteNumericUpDown
            // 
            this.GolesVisitanteNumericUpDown.Location = new System.Drawing.Point(406, 81);
            this.GolesVisitanteNumericUpDown.Name = "GolesVisitanteNumericUpDown";
            this.GolesVisitanteNumericUpDown.Size = new System.Drawing.Size(65, 21);
            this.GolesVisitanteNumericUpDown.TabIndex = 8;
            // 
            // GolesLocalNumericUpDown
            // 
            this.GolesLocalNumericUpDown.Location = new System.Drawing.Point(307, 81);
            this.GolesLocalNumericUpDown.Name = "GolesLocalNumericUpDown";
            this.GolesLocalNumericUpDown.Size = new System.Drawing.Size(65, 21);
            this.GolesLocalNumericUpDown.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Vs";
            // 
            // VisitanteLabel
            // 
            this.VisitanteLabel.AutoSize = true;
            this.VisitanteLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitanteLabel.Location = new System.Drawing.Point(610, 81);
            this.VisitanteLabel.Name = "VisitanteLabel";
            this.VisitanteLabel.Size = new System.Drawing.Size(0, 16);
            this.VisitanteLabel.TabIndex = 4;
            // 
            // LocalLabel
            // 
            this.LocalLabel.AutoSize = true;
            this.LocalLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalLabel.Location = new System.Drawing.Point(148, 82);
            this.LocalLabel.Name = "LocalLabel";
            this.LocalLabel.Size = new System.Drawing.Size(0, 16);
            this.LocalLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Torneo:";
            // 
            // TorneoLabel
            // 
            this.TorneoLabel.AutoSize = true;
            this.TorneoLabel.Location = new System.Drawing.Point(150, 34);
            this.TorneoLabel.Name = "TorneoLabel";
            this.TorneoLabel.Size = new System.Drawing.Size(0, 15);
            this.TorneoLabel.TabIndex = 9;
            // 
            // CategoriaLabel
            // 
            this.CategoriaLabel.AutoSize = true;
            this.CategoriaLabel.Location = new System.Drawing.Point(375, 34);
            this.CategoriaLabel.Name = "CategoriaLabel";
            this.CategoriaLabel.Size = new System.Drawing.Size(0, 15);
            this.CategoriaLabel.TabIndex = 10;
            // 
            // FechaLabel
            // 
            this.FechaLabel.AutoSize = true;
            this.FechaLabel.Location = new System.Drawing.Point(590, 34);
            this.FechaLabel.Name = "FechaLabel";
            this.FechaLabel.Size = new System.Drawing.Size(0, 15);
            this.FechaLabel.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(95, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Local:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(537, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Visitante:";
            // 
            // JugarPartidoForm
            // 
            this.AcceptButton = this.GuardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelarButton;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.GolesTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JugarPartidoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jugar Partido";
            this.Load += new System.EventHandler(this.JugarPartidoForm_Load);
            this.GolesTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Equipos_DataGridView)).EndInit();
            this.AmarillasTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.RojasTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GolesVisitanteNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GolesLocalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl GolesTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage AmarillasTab;
        private System.Windows.Forms.TabPage RojasTab;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button EliminarGolesButton;
        private System.Windows.Forms.Button AgregarGolesButton;
        private System.Windows.Forms.Button EliminarAmarillasButton;
        private System.Windows.Forms.Button AgregarAmarillasButton;
        private System.Windows.Forms.Button EliminarRojasButton;
        private System.Windows.Forms.Button AgregarRojasButton;
        private System.Windows.Forms.DataGridView Equipos_DataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.NumericUpDown GolesLocalNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label VisitanteLabel;
        private System.Windows.Forms.Label LocalLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown GolesVisitanteNumericUpDown;
        private System.Windows.Forms.Label TorneoLabel;
        private System.Windows.Forms.Label CategoriaLabel;
        private System.Windows.Forms.Label FechaLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}