using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        }

        private void VisitanteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (VisitanteComboBox.SelectedValue != null && VisitanteComboBox.SelectedValue.ToString() != idVisitante)
            {
                LocalComboBox.SelectedValue = idVisitante;
            }*/
        }
    }
}
