namespace LigaBA
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.intitucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jugadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.torneoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeTorneoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TorneosButton = new System.Windows.Forms.Button();
            this.EquiposButton = new System.Windows.Forms.Button();
            this.InstitucionesButton = new System.Windows.Forms.Button();
            this.JugadoresButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intitucionesToolStripMenuItem,
            this.equiposToolStripMenuItem,
            this.jugadoresToolStripMenuItem,
            this.torneoToolStripMenuItem,
            this.Usuarios,
            this.configuracionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // intitucionesToolStripMenuItem
            // 
            this.intitucionesToolStripMenuItem.Name = "intitucionesToolStripMenuItem";
            this.intitucionesToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.intitucionesToolStripMenuItem.Text = "Intituciones";
            this.intitucionesToolStripMenuItem.Click += new System.EventHandler(this.intitucionesToolStripMenuItem_Click);
            // 
            // equiposToolStripMenuItem
            // 
            this.equiposToolStripMenuItem.Name = "equiposToolStripMenuItem";
            this.equiposToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.equiposToolStripMenuItem.Text = "Equipos";
            this.equiposToolStripMenuItem.Click += new System.EventHandler(this.equiposToolStripMenuItem_Click);
            // 
            // jugadoresToolStripMenuItem
            // 
            this.jugadoresToolStripMenuItem.Name = "jugadoresToolStripMenuItem";
            this.jugadoresToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.jugadoresToolStripMenuItem.Text = "Jugadores";
            this.jugadoresToolStripMenuItem.Click += new System.EventHandler(this.jugadoresToolStripMenuItem_Click);
            // 
            // torneoToolStripMenuItem
            // 
            this.torneoToolStripMenuItem.Name = "torneoToolStripMenuItem";
            this.torneoToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.torneoToolStripMenuItem.Text = "Torneos";
            this.torneoToolStripMenuItem.Click += new System.EventHandler(this.torneoToolStripMenuItem_Click);
            // 
            // Usuarios
            // 
            this.Usuarios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(74, 20);
            this.Usuarios.Text = "Usuarios";
            this.Usuarios.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriasToolStripMenuItem,
            this.tipoDeTorneoToolStripMenuItem});
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // tipoDeTorneoToolStripMenuItem
            // 
            this.tipoDeTorneoToolStripMenuItem.Name = "tipoDeTorneoToolStripMenuItem";
            this.tipoDeTorneoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.tipoDeTorneoToolStripMenuItem.Text = "Tipo de torneo";
            this.tipoDeTorneoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeTorneoToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TorneosButton);
            this.panel1.Controls.Add(this.EquiposButton);
            this.panel1.Controls.Add(this.InstitucionesButton);
            this.panel1.Controls.Add(this.JugadoresButton);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 95);
            this.panel1.TabIndex = 1;
            // 
            // TorneosButton
            // 
            this.TorneosButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TorneosButton.Image = ((System.Drawing.Image)(resources.GetObject("TorneosButton.Image")));
            this.TorneosButton.Location = new System.Drawing.Point(331, 3);
            this.TorneosButton.Name = "TorneosButton";
            this.TorneosButton.Size = new System.Drawing.Size(109, 89);
            this.TorneosButton.TabIndex = 11;
            this.TorneosButton.Text = "Torneos";
            this.TorneosButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TorneosButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TorneosButton.UseVisualStyleBackColor = true;
            this.TorneosButton.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // EquiposButton
            // 
            this.EquiposButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquiposButton.Image = ((System.Drawing.Image)(resources.GetObject("EquiposButton.Image")));
            this.EquiposButton.Location = new System.Drawing.Point(112, 3);
            this.EquiposButton.Name = "EquiposButton";
            this.EquiposButton.Size = new System.Drawing.Size(108, 89);
            this.EquiposButton.TabIndex = 2;
            this.EquiposButton.Text = "Equipos";
            this.EquiposButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EquiposButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.EquiposButton.UseVisualStyleBackColor = true;
            this.EquiposButton.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // InstitucionesButton
            // 
            this.InstitucionesButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstitucionesButton.Image = ((System.Drawing.Image)(resources.GetObject("InstitucionesButton.Image")));
            this.InstitucionesButton.Location = new System.Drawing.Point(3, 3);
            this.InstitucionesButton.Name = "InstitucionesButton";
            this.InstitucionesButton.Size = new System.Drawing.Size(108, 89);
            this.InstitucionesButton.TabIndex = 1;
            this.InstitucionesButton.Text = "Instituciones";
            this.InstitucionesButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.InstitucionesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.InstitucionesButton.UseVisualStyleBackColor = true;
            this.InstitucionesButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // JugadoresButton
            // 
            this.JugadoresButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JugadoresButton.Image = ((System.Drawing.Image)(resources.GetObject("JugadoresButton.Image")));
            this.JugadoresButton.Location = new System.Drawing.Point(221, 3);
            this.JugadoresButton.Name = "JugadoresButton";
            this.JugadoresButton.Size = new System.Drawing.Size(109, 89);
            this.JugadoresButton.TabIndex = 3;
            this.JugadoresButton.Text = "Jugadores";
            this.JugadoresButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.JugadoresButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.JugadoresButton.UseVisualStyleBackColor = true;
            this.JugadoresButton.Click += new System.EventHandler(this.JugadoresButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(441, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 89);
            this.button1.TabIndex = 12;
            this.button1.Text = "Fixture";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(551, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 89);
            this.button2.TabIndex = 13;
            this.button2.Text = "Partidos";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(661, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 89);
            this.button3.TabIndex = 14;
            this.button3.Text = "Posiciones";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(771, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 89);
            this.button4.TabIndex = 15;
            this.button4.Text = "Goleadores";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Liga Futbol Buenos Aires";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Usuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jugadoresToolStripMenuItem;
        private System.Windows.Forms.Button JugadoresButton;
        private System.Windows.Forms.Button InstitucionesButton;
        private System.Windows.Forms.ToolStripMenuItem intitucionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeTorneoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equiposToolStripMenuItem;
        private System.Windows.Forms.Button EquiposButton;
        private System.Windows.Forms.ToolStripMenuItem torneoToolStripMenuItem;
        private System.Windows.Forms.Button TorneosButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;

    }
}

