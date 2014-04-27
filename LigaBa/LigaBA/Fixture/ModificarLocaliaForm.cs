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

namespace LigaBA.Fixture
{
    public partial class ModificarLocaliaForm : Form
    {
        private string idPartido;
        private string fecha;
        private string idLocal;
        private string idVisitante;

        public ModificarLocaliaForm(string partido,string fecha,string local,string visitante)
        {
            InitializeComponent();
            idPartido = partido;
            this.fecha = fecha;
            idLocal = local;
            idVisitante = visitante;
            CargadorDeDatos.CargarEquipoPartidoComboBox(LocalComboBox,this.Text,partido);
            CargadorDeDatos.CargarEquipoPartidoComboBox(VisitanteComboBox, this.Text, partido);            
        }

        private void ModificarLocaliaForm_Load(object sender, EventArgs e)
        {        
            FechaTextBox.Text = fecha;
            LocalComboBox.SelectedValue = idLocal;
            VisitanteComboBox.SelectedValue = idVisitante;
        }

        private void LocalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LocalComboBox.SelectedValue != null && LocalComboBox.SelectedValue.ToString() != idLocal)
            {
                VisitanteComboBox.SelectedValue = idLocal;
            }
            else
            {
                VisitanteComboBox.SelectedValue = idVisitante;
            }
        }

        private void VisitanteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (VisitanteComboBox.SelectedValue != null && VisitanteComboBox.SelectedValue.ToString() != idVisitante)
            {
                LocalComboBox.SelectedValue = idVisitante;
            }*/
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (!Validaciones()) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@partido", idPartido));
            param.Add(new SqlParameter("@equipolocal",LocalComboBox.SelectedValue.ToString()));
            param.Add(new SqlParameter("@equipovisitante", VisitanteComboBox.SelectedValue.ToString()));            

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarLocalia", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha modificado la localia del partido correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validaciones()
        {
            if (idLocal == LocalComboBox.SelectedValue.ToString())
            {
                MessageBox.Show("El equipo local no ha cambiado.");
                return false;
            }
            if (idVisitante == VisitanteComboBox.SelectedValue.ToString())
            {
                MessageBox.Show("El visitante local no ha cambiado.");
                return false;
            }
            return true;
        }
    }
}
