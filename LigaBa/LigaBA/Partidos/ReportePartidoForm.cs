using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LigaBA.Reportes;
using LigaBA.Clases;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace LigaBA.Partidos
{
    public partial class ReportePartidoForm : Form
    {
        public ReportePartidoForm(string Local,string Visitante)
        {
            InitializeComponent();
            
            this.Local = Local;
            this.Visitante = Visitante;

        }

        string Local;
        string Visitante;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //DataSet

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Equipo", Local));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_Reportejugadores", param, "p_ReporteJugadores", this.Text);

            //Reporte Jugadores
            FichaPartido Repo = new FichaPartido();

            //Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Instituciones");

            //Variables
           /* TextObject InstitucionRepo;
            InstitucionRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Institucion"];
            InstitucionRepo.Text = institucion;

            TextObject EquipoRepo;
            EquipoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Equipo"];
            EquipoRepo.Text = equipo;

            TextObject CategoriaRepo;
            CategoriaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Categoria"];
            CategoriaRepo.Text = categoria;*/

            Repo.SetDataSource(ds.Tables[0]);

            //doy Resporte al form
            crystalReportViewer1.ReportSource = Repo;
        }

    }
}
