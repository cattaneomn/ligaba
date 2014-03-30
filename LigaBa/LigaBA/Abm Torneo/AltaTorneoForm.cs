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
            int result = -1;

            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@tipo", this.TipoTorneoComboBox.ValueMember.ToString()));
            SqlParameter result_param = new SqlParameter("@result", "-1");
            //TODO: configurar retorno en result


            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaTorneo", param, this.Text);

            if (result > 0)
            {
                for(int i=0;i < CategoriasCheckedListBox.CheckedItems.Count;i++)
                {
                    string id_categoria = CategoriasCheckedListBox.CheckedItems[i].ToString();
                    
                    List<SqlParameter> param_txc = new List<SqlParameter>();
                    param_txc.Add(new SqlParameter("@torneo_gral", result));
                    param_txc.Add(new SqlParameter("@categoria", id_categoria));

                    bool TerminoBien_TXC = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaTorneoXCategoria", param_txc, this.Text);

                    TerminoBien = TerminoBien_TXC && TerminoBien;
                }

                if (TerminoBien)
                {
                    MessageBox.Show("Se ha dado de alta al torneo '" + NombreTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarButton.PerformClick();
                    this.NombreTextBox.Focus();
                }
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
