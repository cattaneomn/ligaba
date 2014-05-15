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
    public partial class ExaminarTorneoForm : Form
    {
        public ExaminarTorneoForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        string id;

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExaminarTorneoForm_Load(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();

            Equipo_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            this.Equipo_DataGridView.Columns["Equipo"].Width = 170;
            this.Equipo_DataGridView.Columns["Institucion"].Width = 170;

        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT E.nombre as Equipo,I.nombre as Institucion, C.nombre as Categoria FROM LigaBA.TorneoXCategoriaXEquipo as TCE ";
            Consulta += "INNER JOIN LigaBA.Equipo as E ON E.id = TCE.equipo ";
            Consulta += "INNER JOIN LigaBA.Institucion as I ON I.id = E.institucion  ";
            Consulta += "INNER JOIN LigaBA.Categoria as C ON C.id = E.categoria WHERE TCE.TorneoXCategoria=" + id;

            return Consulta;
        }
    }
}
