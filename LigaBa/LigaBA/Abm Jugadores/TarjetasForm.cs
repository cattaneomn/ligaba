using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LigaBA.Abm_Jugador
{
    public partial class TarjetasForm : Form
    {
        public TarjetasForm(int id)
        {
            InitializeComponent();
            idJugador = id;
        }

        private int idJugador;

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TarjetasForm_Load(object sender, EventArgs e)
        {
            string Consulta = "SELECT T.nombre as Torneo, J.nombre AS Nombre,J.apellido AS Apellido, TJ.amarillas AS Amarillas, TJ.rojas as Rojas,TJ.amarillasacumuladas as 'Amarillas Acumuladas',TJ.rojasacumuladas AS 'Rojas Acumuladas',TJ.habilitado AS Habilitado FROM LigaBA.TorneoXCategoriaXJugador AS TJ ";
            Consulta += "INNER JOIN LigaBA.Jugador AS J ON J.id = TJ.jugador ";
            Consulta += "INNER JOIN LigaBA.TorneoXCategoria AS TC ON TC.id = TJ.torneoxcategoria ";
            Consulta += "INNER JOIN LigaBA.Torneo AS T ON T.id = TC.torneogeneral ";
            Consulta += "WHERE TJ.jugador = " + idJugador;


            List<SqlParameter> param = new List<SqlParameter>();

            Tarjetas_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);
            if (Tarjetas_DataGridView.RowCount > 0)
            {
                Tarjetas_DataGridView.Columns["Torneo"].Width = 180;
                Tarjetas_DataGridView.Columns["Habilitado"].Width = 80;
                Tarjetas_DataGridView.Columns["Rojas"].Width = 60;
                Tarjetas_DataGridView.Columns["Amarillas"].Width = 80;
            }
        }
    }
}
