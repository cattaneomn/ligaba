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
    public partial class ModificarEquipoForm : Form
    {
        public ModificarEquipoForm(string Id,string Institucion,string Categoria,string Nombre)
        {
            InitializeComponent();

            IdEquipo = Id;
            
            InstitucionEquipo = Institucion;
            CategoriaEquipo = Categoria;
            NombreEquipo = Nombre;
            this.NombreTextBox.Text = Nombre;
        }

        string IdEquipo;
        string CategoriaEquipo;
        string InstitucionEquipo;
        string NombreEquipo;

        private void ModificarEquipoForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CargadorDeDatos.CargarInstitucionComboBox(InstitucionComboBox, this.Text);
            this.InstitucionComboBox.Text = InstitucionEquipo;
            this.CategoriasComboBox.Text = CategoriaEquipo;
            this.InstitucionComboBox.Enabled = false;
            this.CategoriasComboBox.Enabled = false;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@id", IdEquipo));
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@categoria", CategoriasComboBox.SelectedValue.ToString()));
            param.Add(new SqlParameter("@institucion", InstitucionComboBox.SelectedValue.ToString()));
            

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarEquipo", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha modificado el equipo '" + NombreEquipo + "' por '" + NombreTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            } 
        }

        private int Validaciones()
        {

            if (NombreTextBox.Text == "")
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
    }
}
