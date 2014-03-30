using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using AplicationDesktop1.Abm_Usuarios;
using AplicationDesktop1.Abm_Clientes;
using AplicationDesktop1.Abm_Productos;
using AplicationDesktop1.Abm_Ventas;
using AplicationDesktop1.Abm_Estadisticas;
using AplicationDesktop1.Mail;

using System.Threading;
using System.Data.SqlClient;

namespace AplicationDesktop1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }
        
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void altaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormAltaUsuario);
            hilo.Start();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormModificarUsuario);
            hilo.Start();
        }

        private void bajaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormBajaUsuario);
            hilo.Start();
        }

        private void altaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormAltaCliente);
            hilo.Start();
        }

        private void altaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormAltaProducto);
            hilo.Start();
        }

        private void altaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormAltaFactura);
            hilo.Start();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormEstadisticas);
            hilo.Start();
        }

        private void bajaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormBajaCliente);
            hilo.Start();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormModificarCliente);
            hilo.Start();
        }

        private void bajaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormBajaProducto);
            hilo.Start();
        }

        private void bajaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormBajaFactura);
            hilo.Start();
        }

        private void modificarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormModificarFactura);
            hilo.Start();
        }

        private void visualizarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormVisualizarFactura);
            hilo.Start();
        }


        private void AbrirFormAltaFactura()
        {
            AltaFacturaForm abrir = new AltaFacturaForm();
            abrir.ShowDialog();
        }

        private void AbrirFormAltaUsuario()
        {
            AltaUsuariosForm abrir = new AltaUsuariosForm();
            abrir.ShowDialog();
        }

        private void AbrirFormModificarUsuario()
        {
            BusquedaModificarUsuarioForm abrir = new BusquedaModificarUsuarioForm();
            abrir.ShowDialog();
        }

        private void AbrirFormBajaUsuario()
        {
            BajaUsuarioForm abrir = new BajaUsuarioForm();
            abrir.ShowDialog();
        }

        private void AbrirFormAltaCliente()
        {
            AltaClienteForm abrir = new AltaClienteForm();
            abrir.ShowDialog();
        }

        private void AbrirFormAltaProducto()
        {
            AltaProductosForm abrir = new AltaProductosForm(null,null,null,null);
            abrir.ShowDialog();
        }

        private void AbrirFormEstadisticas()
        {
            EstadisticasForm abrir = new EstadisticasForm();
            abrir.ShowDialog();
        }

        private void AbrirFormBajaCliente()
        {
            BajaClienteForm abrir = new BajaClienteForm();
            abrir.ShowDialog();
        }

        private void AbrirFormModificarCliente()
        {
            BusquedaModificarClienteForm abrir = new BusquedaModificarClienteForm();
            abrir.ShowDialog();
        }

        private void AbrirFormBajaProducto()
        {
            BajaProductoForm abrir = new BajaProductoForm();
            abrir.ShowDialog();
        }

        private void AbrirFormBajaFactura()
        {
            BajaFacturaForm abrir = new BajaFacturaForm();
            abrir.ShowDialog();
        }

        private void AbrirFormModificarFactura()
        {
            BusquedaModificarFacturaForm abrir = new BusquedaModificarFacturaForm();
            abrir.ShowDialog();
        }

        private void AbrirFormVisualizarFactura()
        {
            VisualizarFacturaForm abrir = new VisualizarFacturaForm();
            abrir.ShowDialog();
        }

        private void AbrirFormSeleccionarModificacionProductoCliente()
        {
            SeleccionarModificacionProductoForm abrir = new SeleccionarModificacionProductoForm();
            abrir.ShowDialog();
        }

        private void AbrirFormModificarProducto()
        {
            BusquedaModificarProductoForm abrir = new BusquedaModificarProductoForm();
            abrir.ShowDialog();
        }

        private void AbrirFormBajaProductoCliente()
        {
            BajaProductoClienteForm abrir = new BajaProductoClienteForm();
            abrir.ShowDialog();
        }

        private void AbrirFormAsignarProductoCliente()
        {
            BusquedaAsignarProductoClienteForm abrir = new BusquedaAsignarProductoClienteForm();
            abrir.ShowDialog();
        }

        private void AbrirFormVisualizarProductoCliente()
        {
            VisualizarProductosClienteForm abrir = new VisualizarProductosClienteForm();
            abrir.ShowDialog();
        }

        private void AbrirFormMail()
        {
            MailForm abrir = new MailForm();
            abrir.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            VerificarFuncionalidades();
            this.menuStrip1.ForeColor = Color.White;
        }

        private void VerificarFuncionalidades()
        {
            string Consulta = "SELECT F.nombre FROM ingeniAR.FuncionalidadXUsuario as FU JOIN ingeniAR.Funcionalidades as F ON F.id=FU.id_funcionalidad WHERE username='" + AplicationDesktop1.Properties.Settings.Default.user + "'";
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            foreach (DataRow row in ds.Rows)
            {
                //VerificarFuncionalidadesUsuarios(row,this.abmsToolStripMenuItem.DropDownItems);
                VerificarFuncionalidadesUsuarios(row,this.menuStrip1.Items);
            }

        }

        private void VerificarFuncionalidadesUsuarios(DataRow row, ToolStripItemCollection ColeccionItem)
        {
            foreach (ToolStripItem Item in ColeccionItem)
            {

                if (Item.Text == row[0].ToString())
                {
                    Item.Enabled = true;
                }
                ToolStripMenuItem Item2 = (ToolStripMenuItem)Item;
                if (Item2.DropDownItems.Count > 0)
                {
                    //Recursividad
                    VerificarFuncionalidadesUsuarios(row,Item2.DropDown.Items);
                }
            }

            
        }

        private void ventasToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            this.ventasToolStripMenuItem.ForeColor = Color.Black;
        }

        private void ventasToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.ventasToolStripMenuItem.ForeColor = Color.White;
        }

        private void usuariosToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.usuariosToolStripMenuItem.ForeColor = Color.White;
        }

        private void usuariosToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            this.usuariosToolStripMenuItem.ForeColor = Color.Black;
        }

        private void productosToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.productosToolStripMenuItem.ForeColor = Color.White;
        }

        private void productosToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            this.productosToolStripMenuItem.ForeColor = Color.Black;
        }

        private void clientesToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.clientesToolStripMenuItem.ForeColor = Color.White;
        }

        private void clientesToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            this.clientesToolStripMenuItem.ForeColor = Color.Black;
        }

        private void modificarPrecioProductoPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormSeleccionarModificacionProductoCliente);
            hilo.Start();
        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormModificarProducto);
            hilo.Start();
        }

        private void bajaProductoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormBajaProductoCliente);
            hilo.Start();
        }

        private void asignarProductoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormAsignarProductoCliente);
            hilo.Start();
        }

        private void visualizarProductosClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormVisualizarProductoCliente);
            hilo.Start();
        }
        
        private void acercaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox abrir = new AboutBox();
            abrir.ShowDialog();
        }

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormMail);
            hilo.Start();
        }

 

        
        
    }

    
        
    
    
}
