using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LigaBA.Clases;

namespace LigaBA.Abm_Equipos
{
    public partial class AltaEquipoForm : Form
    {
        public AltaEquipoForm()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@institucion", InstitucionComboBox.SelectedValue.ToString()));
            param.Add(new SqlParameter("@categoria", CategoriasComboBox.SelectedValue.ToString()));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaEquipo", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha dado de alta el equipo '" + NombreTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarButton.PerformClick();
                this.InstitucionComboBox.Focus();
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
                if (objeto is ComboBox)
                {
                    ((ComboBox)objeto).SelectedItem = null;
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int Validaciones()
        {

            if (NombreTextBox.Text == "" || InstitucionComboBox.SelectedItem == null || CategoriasComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe completar los campos obligatorios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            return 1;
        }

        private void AltaEquipoForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CargadorDeDatos.CargarInstitucionComboBox(InstitucionComboBox, this.Text);
        }

    }
}
