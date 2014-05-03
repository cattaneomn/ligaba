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

namespace LigaBA.Goleadores
{
    public partial class ReporteGoleadoresForm : Form
    {
        public ReporteGoleadoresForm(string torneo,string categoria,string nombreTorneo,string nombreCategoria)
        {
            InitializeComponent();

            this.torneo = torneo;
            this.categoria = categoria;
            this.nombreTorneo = nombreTorneo;
            this.nombreCategoria = nombreCategoria;
        }

        string torneo;
        string categoria;
        string nombreTorneo;
        string nombreCategoria;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //DataSet

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", torneo));
            param.Add(new SqlParameter("@Categoria", categoria));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarGoleadores", param, "Goleadores", this.Text);

            //Reporte Jugadores
            GoleadoresReporte Repo = new GoleadoresReporte();

            //Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Instituciones");

            //Variables
            TextObject TorneoRepo;
            TorneoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreTorneo"];
            TorneoRepo.Text = nombreTorneo;

            TextObject CategoriaRepo;
            CategoriaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreCategoria"];
            CategoriaRepo.Text = nombreCategoria;

            Repo.SetDataSource(ds.Tables[0]);

            //doy Resporte al form
            crystalReportViewer1.ReportSource = Repo;
        }

    }
}
