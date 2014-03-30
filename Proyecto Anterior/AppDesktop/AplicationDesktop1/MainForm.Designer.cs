namespace AplicationDesktop1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarProductoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaProductoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarPrecioProductoPorClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarProductosClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(78)))), ((int)(((byte)(147)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.estadisticasToolStripMenuItem,
            this.mailToolStripMenuItem,
            this.acercaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaClienteToolStripMenuItem,
            this.bajaClienteToolStripMenuItem,
            this.modificarClienteToolStripMenuItem,
            this.asignarProductoClienteToolStripMenuItem,
            this.bajaProductoClienteToolStripMenuItem,
            this.modificarPrecioProductoPorClienteToolStripMenuItem,
            this.visualizarProductosClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.DropDownClosed += new System.EventHandler(this.clientesToolStripMenuItem_DropDownClosed);
            this.clientesToolStripMenuItem.DropDownOpened += new System.EventHandler(this.clientesToolStripMenuItem_DropDownOpened);
            // 
            // altaClienteToolStripMenuItem
            // 
            this.altaClienteToolStripMenuItem.Enabled = false;
            this.altaClienteToolStripMenuItem.Name = "altaClienteToolStripMenuItem";
            this.altaClienteToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.altaClienteToolStripMenuItem.Text = "Alta Cliente";
            this.altaClienteToolStripMenuItem.Click += new System.EventHandler(this.altaClienteToolStripMenuItem_Click);
            // 
            // bajaClienteToolStripMenuItem
            // 
            this.bajaClienteToolStripMenuItem.Enabled = false;
            this.bajaClienteToolStripMenuItem.Name = "bajaClienteToolStripMenuItem";
            this.bajaClienteToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.bajaClienteToolStripMenuItem.Text = "Baja Cliente";
            this.bajaClienteToolStripMenuItem.Click += new System.EventHandler(this.bajaClienteToolStripMenuItem_Click);
            // 
            // modificarClienteToolStripMenuItem
            // 
            this.modificarClienteToolStripMenuItem.Enabled = false;
            this.modificarClienteToolStripMenuItem.Name = "modificarClienteToolStripMenuItem";
            this.modificarClienteToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.modificarClienteToolStripMenuItem.Text = "Modificar Cliente";
            this.modificarClienteToolStripMenuItem.Click += new System.EventHandler(this.modificarClienteToolStripMenuItem_Click);
            // 
            // asignarProductoClienteToolStripMenuItem
            // 
            this.asignarProductoClienteToolStripMenuItem.Enabled = false;
            this.asignarProductoClienteToolStripMenuItem.Name = "asignarProductoClienteToolStripMenuItem";
            this.asignarProductoClienteToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.asignarProductoClienteToolStripMenuItem.Text = "Asignar Producto Cliente";
            this.asignarProductoClienteToolStripMenuItem.Click += new System.EventHandler(this.asignarProductoClienteToolStripMenuItem_Click);
            // 
            // bajaProductoClienteToolStripMenuItem
            // 
            this.bajaProductoClienteToolStripMenuItem.Enabled = false;
            this.bajaProductoClienteToolStripMenuItem.Name = "bajaProductoClienteToolStripMenuItem";
            this.bajaProductoClienteToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.bajaProductoClienteToolStripMenuItem.Text = "Baja Producto Cliente";
            this.bajaProductoClienteToolStripMenuItem.Click += new System.EventHandler(this.bajaProductoClienteToolStripMenuItem_Click);
            // 
            // modificarPrecioProductoPorClienteToolStripMenuItem
            // 
            this.modificarPrecioProductoPorClienteToolStripMenuItem.Enabled = false;
            this.modificarPrecioProductoPorClienteToolStripMenuItem.Name = "modificarPrecioProductoPorClienteToolStripMenuItem";
            this.modificarPrecioProductoPorClienteToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.modificarPrecioProductoPorClienteToolStripMenuItem.Text = "Modificar Precio Producto Cliente";
            this.modificarPrecioProductoPorClienteToolStripMenuItem.Click += new System.EventHandler(this.modificarPrecioProductoPorClienteToolStripMenuItem_Click);
            // 
            // visualizarProductosClienteToolStripMenuItem
            // 
            this.visualizarProductosClienteToolStripMenuItem.Enabled = false;
            this.visualizarProductosClienteToolStripMenuItem.Name = "visualizarProductosClienteToolStripMenuItem";
            this.visualizarProductosClienteToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.visualizarProductosClienteToolStripMenuItem.Text = "Visualizar Productos Cliente";
            this.visualizarProductosClienteToolStripMenuItem.Click += new System.EventHandler(this.visualizarProductosClienteToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProductoToolStripMenuItem,
            this.bajaProductoToolStripMenuItem,
            this.modificarProductoToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.DropDownClosed += new System.EventHandler(this.productosToolStripMenuItem_DropDownClosed);
            this.productosToolStripMenuItem.DropDownOpened += new System.EventHandler(this.productosToolStripMenuItem_DropDownOpened);
            // 
            // altaProductoToolStripMenuItem
            // 
            this.altaProductoToolStripMenuItem.Enabled = false;
            this.altaProductoToolStripMenuItem.Name = "altaProductoToolStripMenuItem";
            this.altaProductoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.altaProductoToolStripMenuItem.Text = "Alta Producto";
            this.altaProductoToolStripMenuItem.Click += new System.EventHandler(this.altaProductoToolStripMenuItem_Click);
            // 
            // bajaProductoToolStripMenuItem
            // 
            this.bajaProductoToolStripMenuItem.Enabled = false;
            this.bajaProductoToolStripMenuItem.Name = "bajaProductoToolStripMenuItem";
            this.bajaProductoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.bajaProductoToolStripMenuItem.Text = "Baja Producto";
            this.bajaProductoToolStripMenuItem.Click += new System.EventHandler(this.bajaProductoToolStripMenuItem_Click);
            // 
            // modificarProductoToolStripMenuItem
            // 
            this.modificarProductoToolStripMenuItem.Enabled = false;
            this.modificarProductoToolStripMenuItem.Name = "modificarProductoToolStripMenuItem";
            this.modificarProductoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.modificarProductoToolStripMenuItem.Text = "Modificar Producto";
            this.modificarProductoToolStripMenuItem.Click += new System.EventHandler(this.modificarProductoToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaFacturaToolStripMenuItem,
            this.bajaFacturaToolStripMenuItem,
            this.modificarFacturaToolStripMenuItem,
            this.visualizarFacturaToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.DropDownClosed += new System.EventHandler(this.ventasToolStripMenuItem_DropDownClosed);
            this.ventasToolStripMenuItem.DropDownOpened += new System.EventHandler(this.ventasToolStripMenuItem_DropDownOpened);
            // 
            // altaFacturaToolStripMenuItem
            // 
            this.altaFacturaToolStripMenuItem.Enabled = false;
            this.altaFacturaToolStripMenuItem.Name = "altaFacturaToolStripMenuItem";
            this.altaFacturaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.altaFacturaToolStripMenuItem.Text = "Alta Factura";
            this.altaFacturaToolStripMenuItem.Click += new System.EventHandler(this.altaFacturaToolStripMenuItem_Click);
            // 
            // bajaFacturaToolStripMenuItem
            // 
            this.bajaFacturaToolStripMenuItem.Enabled = false;
            this.bajaFacturaToolStripMenuItem.Name = "bajaFacturaToolStripMenuItem";
            this.bajaFacturaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.bajaFacturaToolStripMenuItem.Text = "Baja Factura";
            this.bajaFacturaToolStripMenuItem.Click += new System.EventHandler(this.bajaFacturaToolStripMenuItem_Click);
            // 
            // modificarFacturaToolStripMenuItem
            // 
            this.modificarFacturaToolStripMenuItem.Enabled = false;
            this.modificarFacturaToolStripMenuItem.Name = "modificarFacturaToolStripMenuItem";
            this.modificarFacturaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.modificarFacturaToolStripMenuItem.Text = "Modificar Factura";
            this.modificarFacturaToolStripMenuItem.Click += new System.EventHandler(this.modificarFacturaToolStripMenuItem_Click);
            // 
            // visualizarFacturaToolStripMenuItem
            // 
            this.visualizarFacturaToolStripMenuItem.Enabled = false;
            this.visualizarFacturaToolStripMenuItem.Name = "visualizarFacturaToolStripMenuItem";
            this.visualizarFacturaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.visualizarFacturaToolStripMenuItem.Text = "Visualizar Factura";
            this.visualizarFacturaToolStripMenuItem.Click += new System.EventHandler(this.visualizarFacturaToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaUsuarioToolStripMenuItem,
            this.bajaUsuarioToolStripMenuItem,
            this.modificarUsuarioToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.DropDownClosed += new System.EventHandler(this.usuariosToolStripMenuItem_DropDownClosed);
            this.usuariosToolStripMenuItem.DropDownOpened += new System.EventHandler(this.usuariosToolStripMenuItem_DropDownOpened);
            // 
            // altaUsuarioToolStripMenuItem
            // 
            this.altaUsuarioToolStripMenuItem.Enabled = false;
            this.altaUsuarioToolStripMenuItem.Name = "altaUsuarioToolStripMenuItem";
            this.altaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.altaUsuarioToolStripMenuItem.Text = "Alta Usuario";
            this.altaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.altaUsuarioToolStripMenuItem_Click);
            // 
            // bajaUsuarioToolStripMenuItem
            // 
            this.bajaUsuarioToolStripMenuItem.Enabled = false;
            this.bajaUsuarioToolStripMenuItem.Name = "bajaUsuarioToolStripMenuItem";
            this.bajaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.bajaUsuarioToolStripMenuItem.Text = "Baja Usuario";
            this.bajaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.bajaUsuarioToolStripMenuItem_Click);
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            this.modificarUsuarioToolStripMenuItem.Enabled = false;
            this.modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            this.modificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.modificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            this.modificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.modificarUsuarioToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Enabled = false;
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(87, 21);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            this.estadisticasToolStripMenuItem.Click += new System.EventHandler(this.estadisticasToolStripMenuItem_Click);
            // 
            // mailToolStripMenuItem
            // 
            this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            this.mailToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.mailToolStripMenuItem.Text = "E-Mail";
            this.mailToolStripMenuItem.Click += new System.EventHandler(this.mailToolStripMenuItem_Click);
            // 
            // acercaToolStripMenuItem
            // 
            this.acercaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(78)))), ((int)(((byte)(147)))));
            this.acercaToolStripMenuItem.Name = "acercaToolStripMenuItem";
            this.acercaToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.acercaToolStripMenuItem.Text = "Acerca";
            this.acercaToolStripMenuItem.Click += new System.EventHandler(this.acercaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Gran Cheff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarPrecioProductoPorClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaProductoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarProductoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarProductosClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailToolStripMenuItem;




    }
}