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
    public partial class ModificarProductoForm : Form
    {
        public ModificarProductoForm(int Cod,string Nom,string Det)
        {
            InitializeComponent();

            Codigo = Cod;
            Nombre = Nom;
            Detalle = Det;
        }

        int Codigo;
        string Nombre;
        string Detalle;
     
        
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@detalle", this.DetalleTextBox.Text));
            param.Add(new SqlParameter("@Codigo", Codigo));
            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarProducto", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha modificado el producto correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
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

        private void ModificarProductoForm_Load(object sender, EventArgs e)
        {
            this.NombreTextBox.Text = Nombre;
            this.DetalleTextBox.Text = Detalle;
        }
    }
}
