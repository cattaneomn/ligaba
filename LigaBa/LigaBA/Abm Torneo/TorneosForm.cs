using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Clases;

namespace LigaBA.Abm_Torneo
{
    public partial class TorneosForm : Form
    {
        public TorneosForm()
        {
            InitializeComponent();
        }

     

        private void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

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

            ModDataGridView.limpiarDataGridView(Torneos_DataGridView, "");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TorneosForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarTipoTorneoComboBox(TipoTorneoComboBox, this.Text);
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            this.NombreTextBox.Select();
        }

        private void AgregarButton_Click_1(object sender, EventArgs e)
        {
            AltaTorneoForm abrir = new AltaTorneoForm();
            abrir.ShowDialog();
        }
    }
}
