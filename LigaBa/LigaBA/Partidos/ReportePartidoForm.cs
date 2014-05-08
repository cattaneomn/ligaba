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
        public ReportePartidoForm(string LocalId,string VisitanteId,string Local,string Visitante,string Torneo,string Categoria,string Fecha,string Flag)
        {
            InitializeComponent();
            
            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
            this.Local = Local;
            this.Visitante = Visitante;
            this.Torneo = Torneo;
            this.Categoria = Categoria;
            this.Fecha = Fecha;
            this.Flag = Flag;
        }

        string LocalId;
        string VisitanteId;
        string Local;
        string Visitante;
        string Torneo;
        string Categoria;
        string Fecha;
        string Flag;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            if (Flag != "Baby")
            {

                //DataSet
                List<SqlParameter> param = new List<SqlParameter>();

                if (Flag == "Local")
                {
                    param.Add(new SqlParameter("@Equipo", LocalId));
                }
                else
                {
                    param.Add(new SqlParameter("@Equipo", VisitanteId));
                }

                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ReporteFichaPartido", param, "p_ReporteFichaPartido", this.Text);

                //Reporte Jugadores
                FichaPartido Repo = new FichaPartido();

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

                if (Flag == "Local")
                {
                    TextObject LocalRepo;
                    LocalRepo = (TextObject)Repo.ReportDefinition.ReportObjects["LocalText"];
                    LocalRepo.Text = Local;
                }
                else
                {
                    TextObject LocalRepo;
                    LocalRepo = (TextObject)Repo.ReportDefinition.ReportObjects["LocalText"];
                    LocalRepo.Text = Visitante;
                }

                TextObject EquipoRepo;
                EquipoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["EquipoText"];
                EquipoRepo.Text = Flag + ":";

                Repo.SetDataSource(ds);

                //doy Resporte al form
                crystalReportViewer1.ReportSource = Repo;
            }
            else
            {
                //DataSet
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@Equipo", LocalId));
                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ReporteFichaPartido", param, "p_ReporteFichaPartido", this.Text);

                //2 Consulta
                List<SqlParameter> param2 = new List<SqlParameter>();
                param2.Add(new SqlParameter("@Equipo", VisitanteId));
                DataSet ds2 = BaseDeDatos.GetInstance.ejecutarConsulta("p_ReporteFichaPartido", param2, "p_ReporteFichaPartido",this.Text);

                //Reporte Jugadores
                FichaPartidoBaby Repo = new FichaPartidoBaby();

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


                //visitante
                Repo.Subreports[1].SetDataSource(ds2.Tables[0]);
                //local
                Repo.Subreports[0].SetDataSource(ds.Tables[0]);

                //doy Resporte al form
                crystalReportViewer1.ReportSource = Repo;
            }

            
        }

    }
}
