using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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

            this.Jugadores_DataGridView.Columns["id"].Visible = false;
            this.Jugadores_DataGridView.Focus();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        
        
    
    }
}
