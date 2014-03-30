using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LigaBA.AbmIntituciones
{
    public partial class AltaInstitucionForm : Form
    {
        public AltaInstitucionForm()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@direccion", this.DireccionTextBox.Text));
            param.Add(new SqlParameter("@localidad", this.LocalidadTextBox.Text));
            param.Add(new SqlParameter("@telefono", this.TelefonoTextBox.Text));
            param.Add(new SqlParameter("@email", this.EmailTextBox.Text));
            param.Add(new SqlParameter("@delegado", this.DelegadoTextBox.Text));
            param.Add(new SqlParameter("@coordinador", this.CoordinadorTextBox.Text));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaInstitucion", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha dado de alta la institucion '" + NombreTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarButton.PerformClick();
                this.NombreTextBox.Focus();
            } 

        }


        private int Validaciones()
        {

            if ( NombreTextBox.Text == "" )
            {
                MessageBox.Show("Debe completar el campo nombre.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            return 1;
        }


        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.GroupBox.Controls)
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
    }
}
