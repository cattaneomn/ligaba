﻿namespace LigaBA.Partidos
{
    partial class PreguntaImprimirForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreguntaImprimirForm));
            this.LocalButton = new System.Windows.Forms.Button();
            this.VisitanteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LocalButton
            // 
            this.LocalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LocalButton.BackColor = System.Drawing.SystemColors.Control;
            this.LocalButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LocalButton.Location = new System.Drawing.Point(59, 13);
            this.LocalButton.Name = "LocalButton";
            this.LocalButton.Size = new System.Drawing.Size(149, 31);
            this.LocalButton.TabIndex = 8;
            this.LocalButton.Text = "Local";
            this.LocalButton.UseVisualStyleBackColor = true;
            this.LocalButton.Click += new System.EventHandler(this.LocalButton_Click);
            // 
            // VisitanteButton
            // 
            this.VisitanteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VisitanteButton.BackColor = System.Drawing.SystemColors.Control;
            this.VisitanteButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitanteButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.VisitanteButton.Location = new System.Drawing.Point(214, 13);
            this.VisitanteButton.Name = "VisitanteButton";
            this.VisitanteButton.Size = new System.Drawing.Size(149, 31);
            this.VisitanteButton.TabIndex = 9;
            this.VisitanteButton.Text = "Visitante";
            this.VisitanteButton.UseVisualStyleBackColor = true;
            this.VisitanteButton.Click += new System.EventHandler(this.VisitanteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Seleccione el equipo que desea imprimir la ficha de partido.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.LocalButton);
            this.panel1.Controls.Add(this.VisitanteButton);
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 63);
            this.panel1.TabIndex = 11;
            // 
            // PreguntaImprimirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(428, 162);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreguntaImprimirForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.PreguntaImprimirForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LocalButton;
        private System.Windows.Forms.Button VisitanteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}