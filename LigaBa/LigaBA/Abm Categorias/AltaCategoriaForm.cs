using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LigaBA.Abm_Categorias
{
    public partial class AltaCategoriaForm : Form
    {
        public AltaCategoriaForm()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Categoria", this.CategoriaTextBox.Text));


            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaCategoria", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha dado de alta la categoria '" + CategoriaTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarButton.PerformClick();
                this.CategoriaTextBox.Focus();
            } 

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


        private int Validaciones()
        {
            foreach (Control objeto in this.GroupBox.Controls)
            {
                if (objeto is TextBox && ((TextBox)objeto).Text == "")
                {
                    MessageBox.Show("Debe completar el campo vacio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -1;
                }
            }
            return 1;
        }

        private void AltaCategoriaForm_Load(object sender, EventArgs e)
        {
            this.CategoriaTextBox.Select();
        }
    }
}
