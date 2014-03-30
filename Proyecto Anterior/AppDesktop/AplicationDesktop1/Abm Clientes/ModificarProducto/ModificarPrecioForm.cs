using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace AplicationDesktop1.Abm_Clientes
{
    public partial class ModificarPrecioForm : Form
    {
        public ModificarPrecioForm(string ClienteM, string ProductoM, decimal PrecioM)
        {
            InitializeComponent();

            Cliente = ClienteM;
            Producto = ProductoM;
            Precio = PrecioM;
        }

        string Cliente;
        string Producto;
        decimal Precio;

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (this.PrecioUpDown.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@cliente",Cliente));
            param.Add(new SqlParameter("@producto",Producto));
            param.Add(new SqlParameter("@precio",this.PrecioUpDown.Value));
            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarPrecioProducto", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha modificado el producto correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }  


        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            this.PrecioUpDown.Value = 0;
        }

        private void ModificarPrecioForm_Load(object sender, EventArgs e)
        {
            this.ClienteTextBox.Text = Cliente;
            this.ProductoTextBox.Text = Producto;
            this.PrecioUpDown.Value = Precio;
        }
    }
}
