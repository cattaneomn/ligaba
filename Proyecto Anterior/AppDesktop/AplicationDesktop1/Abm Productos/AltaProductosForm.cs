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
namespace AplicationDesktop1.Abm_Productos
{
    public partial class AltaProductosForm : Form
    {
        public AltaProductosForm(string QuienMeLLamo1,string Nom, string Det,string Pre)
        {

            InitializeComponent();
           
            QuienMeLLamo = QuienMeLLamo1;
            Nombre = Nom;
            Detalle = Det;
            Precio = Pre;
        }

        string QuienMeLLamo;
        string Nombre;
        string Detalle;
        string Precio;

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@detalle", this.DetalleTextBox.Text));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaProducto", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha dado de alta el Producto '" + this.NombreTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarButton.PerformClick();
                this.NombreTextBox.Focus();          
            }         
        }

        private int Validaciones()
        {

            if (this.NombreTextBox.Text == "")
            {
                MessageBox.Show("Debe completar los campos obligatorios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            
            return 1;
        }



        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.ProductoGroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
            }

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AltaProductosForm_Load(object sender, EventArgs e)
        {
            if (QuienMeLLamo == "VisualizarProductos")
            {
                NombreTextBox.Text = Nombre;
                DetalleTextBox.Text = Detalle;
                PrecioTextBox.Text = Precio;
                
                this.NombreTextBox.ReadOnly = true;
                this.DetalleTextBox.ReadOnly = true;
                this.PrecioLabel.Visible = true;
                this.PrecioTextBox.Visible = true;

                this.GuardarButton.Visible = false;
                this.LimpiarButton.Visible = false;

                this.label3.Visible = false;
                this.label5.Visible = false;
                this.label7.Visible = false;
            }
        }
    }
}
