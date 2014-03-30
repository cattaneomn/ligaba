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
    public partial class AltaPrecioProductoForm : Form
    {
        public AltaPrecioProductoForm(List<string> Cli, List<decimal> Prec,string Prod)
        {
            InitializeComponent();
            
            Clientes = Cli;
            Precios = Prec;
            Producto = Prod;
           
        }

        List<string> Clientes = new List<string>();
        List<decimal> Precios = new List<decimal>();
        String Producto;
        int i=0;
        int Cant_Elementos;

        private void CargarCliente()
        {
          this.ClienteTextBox.Text = Clientes[i];
          this.PrecioUpDown.Value = 0;
        }


        private void SiguenteButton_Click(object sender, EventArgs e)
        {

            if (this.PrecioUpDown.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Precios.Add(this.PrecioUpDown.Value);

            i++;
            CargarCliente();

            if (i == Cant_Elementos - 1)
            {
                this.SiguenteButton.Visible = false;
                this.GuardarButton.Visible = true;
            }

           
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            this.PrecioUpDown.Value = 0;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaPrecioProductoForm_Load(object sender, EventArgs e)
        {
            CargarCliente();
            this.ProductoTextBox.Text = Producto;
            Cant_Elementos = Clientes.Count;

            if (i == Cant_Elementos -1)
            {
                this.SiguenteButton.Visible = false;
                this.GuardarButton.Visible = true;
            }
            this.ActiveControl = this.PrecioUpDown;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            
            if (this.PrecioUpDown.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Precios.Add(this.PrecioUpDown.Value);

            Cant_Elementos = Clientes.Count;

            for (int j = 0; j < Cant_Elementos; j++)
            {

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@cliente", Clientes[j]));
                param.Add(new SqlParameter("@Producto", Producto));
                param.Add(new SqlParameter("@precio", Precios[j]));

                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AsignarProductoCliente", param, this.Text);

                if (TerminoBien == true)
                {
                    MessageBox.Show("Se ha asignado el producto '" + Producto  + "' al cliente '" + Clientes[j] + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);    
                }
            }

            DialogResult = DialogResult.OK;
        }


    }
}
