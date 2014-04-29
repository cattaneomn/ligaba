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
        public ReportePartidoForm(string LocalId,string VisitanteId,string Local,string Visitante,string Torneo,string Categoria,string Fecha)
        {
            InitializeComponent();
            
            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
            this.Local = Local;
            this.Visitante = Visitante;
            this.Torneo = Torneo;
            this.Categoria = Categoria;
            this.Fecha = Fecha;
        }

        string LocalId;
        string VisitanteId;
        string Local;
        string Visitante;
        string Torneo;
        string Categoria;
        string Fecha;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //DataSet
            
            // 1 Consulta
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Equipo", LocalId));
            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_Reportejugadores", param, "p_ReporteJugadores", this.Text);

            //2 Consulta
            List<SqlParameter> param2 = new List<SqlParameter>();
            param2.Add(new SqlParameter("@Equipo", VisitanteId));
            ds = BaseDeDatos.GetInstance.ejecutarConsultaCargarDosTablas("p_ReportejugadoresVisitante", param2, "p_ReporteJugadoresVisitante", this.Text, ds);
            
            //Reporte Jugadores
            FichaPartido Repo = new FichaPartido();

            //Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Instituciones");

            //Variables
            TextObject TorneoRepo;
            TorneoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["TorneoText"];
            TorneoRepo.Text = Torneo;

            TextObject FechaRepo;
            FechaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["FechaText"];
            FechaRepo.Text = Fecha;

            TextObject CategoriaRepo;
            CategoriaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["CategoriaText"];
            CategoriaRepo.Text = Categoria;

            TextObject LocalRepo;
            LocalRepo = (TextObject)Repo.ReportDefinition.ReportObjects["LocalText"];
            LocalRepo.Text = Local;

            TextObject VisitanteRepo;
            VisitanteRepo = (TextObject)Repo.ReportDefinition.ReportObjects["VisitanteText"];
            VisitanteRepo.Text = Visitante;

            Repo.SetDataSource(ds);

            //doy Resporte al form
            crystalReportViewer1.ReportSource = Repo;
        }

    }
}
