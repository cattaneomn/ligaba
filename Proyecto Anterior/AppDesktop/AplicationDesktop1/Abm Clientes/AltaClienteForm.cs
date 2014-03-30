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
    public partial class AltaClienteForm : Form
    {
        public AltaClienteForm()
        {
            InitializeComponent();
            this.RazonSocialTextBox.Select();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.ClienteGroupBox.Controls)
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

            param.Add(new SqlParameter("@razon_social", this.RazonSocialTextBox.Text));
            param.Add(new SqlParameter("@direccion", this.DireccionTextBox.Text));
            param.Add(new SqlParameter("@telefono", this.TelefonoTextBox.Text));
            param.Add(new SqlParameter("@email", this.MailTextBox.Text));
                       
            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaCliente", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha dado de alta el cliente '" + RazonSocialTextBox.Text + "' correctamente.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarButton.PerformClick();
                this.RazonSocialTextBox.Focus();
            }         

        }

        private int Validaciones()
        {
           
                if ( this.RazonSocialTextBox.Text == "")
                {
                    MessageBox.Show("Debe completar el campo razon social.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
                if (this.TelefonoTextBox.Text == "")
                {
                    MessageBox.Show("Debe completar el campo telefono.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }

            return 1;
        }

        


    }
}
