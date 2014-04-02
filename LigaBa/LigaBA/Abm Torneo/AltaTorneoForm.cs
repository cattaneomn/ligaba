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

namespace LigaBA.Abm_Torneo
{
    public partial class AltaTorneoForm : Form
    {
        public AltaTorneoForm()
        {
            InitializeComponent();
        }

        private void AltaTorneoForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarTipoTorneoComboBox(TipoTorneoComboBox, this.Text);
            CargadorDeDatos.CargarCategoriaCheckedListBox(CategoriasCheckedListBox, this.Text);
            CargadorDeDatos.CargarInstitucionesCheckedListBox(InstitucionesCheckedListBox, this.Text);
            this.TipoTablaComboBox.Enabled = false;
            this.NombreTextBox.Select();

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            CargarEquiposForm abrir = new CargarEquiposForm(
              this.InstitucionesCheckedListBox,
              this.CategoriasCheckedListBox,
              this.NombreTextBox.Text,
              this.TipoTorneoComboBox.SelectedValue.ToString(),
              this.TablaGeneralComboBox.SelectedItem.ToString(),
              this.TipoTablaComboBox.SelectedItem.ToString());
            
            
            
            
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                this.Close();
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

            int i;
            
            for (i = 0; i < this.InstitucionesCheckedListBox.Items.Count; i++)
            {
                this.InstitucionesCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);

            }

            for (i = 0; i < this.CategoriasCheckedListBox.Items.Count; i++)
            {
                this.CategoriasCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);

            }

            this.TipoTablaComboBox.Enabled = false;
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

            if(CategoriasCheckedListBox.CheckedItems.Count<=0)
            {
                MessageBox.Show("Debe seleccionar al menos una categoria.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }

            if (InstitucionesCheckedListBox.CheckedItems.Count <= 1)
            {
                MessageBox.Show("Debe seleccionar al menos dos instituciones.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }

            return 1;
        }

        private void TablaGeneralComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.TablaGeneralComboBox.Text == "Si")
            {
                this.TipoTablaComboBox.Enabled = true;
            }
            else
            {
                this.TipoTablaComboBox.Enabled = false;
                this.TipoTablaComboBox.SelectedItem = null;
            }
        }


    
    }

}
