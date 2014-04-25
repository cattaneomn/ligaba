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
using LigaBA.Clases_LigaBA;

namespace LigaBA.Partidos
{
    public partial class AgregarJugadorForm : Form
    {
        public AgregarJugadorForm(string LocalId, string VisitanteId)
        {
            InitializeComponent();

            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
        }

        string LocalId;
        string VisitanteId;

        private void AgregarJugadorForm_Load(object sender, EventArgs e)
        {
           string Consulta = "SELECT J.id,E.nombre as Equipo,J.nombre as Nombre,J.apellido as Apellido,J.dni as Dni FROM ligaBA.JugadorXEquipo as JE ";
                  Consulta += "JOIN LigaBA.Jugador as J ON J.id = JE.jugador ";
                  Consulta += "JOIN LigaBA.Equipo as E ON E.id = JE.equipo ";
                  Consulta += "WHERE E.id=" + LocalId + " OR E.id=" + VisitanteId;

            List<SqlParameter> param = new List<SqlParameter>();

            Jugadores_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (Jugadores_DataGridView.DataSource != null)
            {
                this.Jugadores_DataGridView.Columns["id"].Visible = false;
                ModDataGridView.agregarBoton(Jugadores_DataGridView, "Seleccionar");
                this.Jugadores_DataGridView.Focus();
            }
        }

        private string FiltroCambios()
        {
            string consulta = "";

            if (this.ApellidoTextBox.Text != "")
            {
                consulta += "Apellido LIKE '%" + this.ApellidoTextBox.Text + "%'";
            }

            if (this.DniTextBox.Text != "")
            {
                if (consulta != "") { consulta += " AND "; }
                consulta += "Dni = '" + this.DniTextBox.Text + "'";
            }

            if (this.EquipoTextBox.Text != "")
            {
                if (consulta != "") { consulta += " AND "; }
                consulta += "Equipo LIKE '%" + this.EquipoTextBox.Text + "%'";
            }
            return consulta;
        }

        private void Filtrar()
        {
            ((DataTable)Jugadores_DataGridView.DataSource).DefaultView.RowFilter = FiltroCambios();
        }


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void ApellidoTextBox_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void DniTextBox_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Jugadores_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.Jugadores_DataGridView.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                
                string Nombre = Jugadores_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                string Apellido = Jugadores_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString();
                string Dni = Jugadores_DataGridView.CurrentRow.Cells["Dni"].Value.ToString();
                string Equipo = Jugadores_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString();
                string idJugador = Jugadores_DataGridView.CurrentRow.Cells["id"].Value.ToString();

                //Jugador jugadorSeleccionado = new Jugador(Convert.ToInt32(idJugador),Nombre,Apellido,Dni,Equipo);

                


                DialogResult = DialogResult.OK;
            }
        }
    
        
        
    
    }
}
