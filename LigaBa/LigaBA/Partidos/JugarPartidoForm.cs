using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LigaBA.Partidos
{
    public partial class JugarPartidoForm : Form
    {
        public JugarPartidoForm(string Torneo,string Categoria,string Fecha,string Local,string Visitante,string LocalId, string VisitanteId)
        {
            InitializeComponent();

            this.Torneo = Torneo;
            this.Categoria = Categoria;
            this.Fecha = Fecha;
            this.Local = Local;
            this.Visitante = Visitante;
            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
        }

        string Torneo;
        string Categoria;
        string Fecha;
        string Local;
        string Visitante;
        string LocalId;
        string VisitanteId;

        private void JugarPartidoForm_Load(object sender, EventArgs e)
        {
            this.TorneoLabel.Text = Torneo;
            this.CategoriaLabel.Text = Categoria;
            this.FechaLabel.Text = Fecha;
            this.LocalLabel.Text = Local;
            this.VisitanteLabel.Text = Visitante;

            this.LocalNumericUpDown.Select();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EliminarGolesButton_Click(object sender, EventArgs e)
        {
            if (this.Goles_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Goles_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Goles_DataGridView.Rows.Remove(Goles_DataGridView.CurrentRow);
        }

        private void EliminarAmarillasButton_Click(object sender, EventArgs e)
        {
            if (this.Amarillas_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Amarillas_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Amarillas_DataGridView.Rows.Remove(Amarillas_DataGridView.CurrentRow);
        }

        private void EliminarRojasButton_Click(object sender, EventArgs e)
        {
            if (this.Rojas_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Rojas_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rojas_DataGridView.Rows.Remove(Rojas_DataGridView.CurrentRow);
        }

        private void AgregarGolesButton_Click(object sender, EventArgs e)
        {
            AgregarJugadorForm abrir = new AgregarJugadorForm(this.LocalId,this.VisitanteId);
            abrir.ShowDialog();
        }
    }
}
