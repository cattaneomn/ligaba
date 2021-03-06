﻿using System;
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


namespace LigaBA.Fixture
{
    public partial class ReporteFixtureForm : Form
    {
        public ReporteFixtureForm(string torneo,string categoria,string nombreTorneo,string nombreCategoria,string e,string f)
        {
            InitializeComponent();
            
            this.torneo = torneo;
            this.categoria = categoria;
            this.nombreTorneo = nombreTorneo;
            this.nombreCategoria = nombreCategoria;
            this.fecha = f;
            this.equipo = e;
        }

        string torneo;
        string categoria;
        string nombreTorneo;
        string nombreCategoria;
        string fecha;
        string equipo;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //DataSet

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", torneo));
            param.Add(new SqlParameter("@Categoria", categoria));
            param.Add(new SqlParameter("@Fecha", fecha));
            param.Add(new SqlParameter("@Equipo", equipo));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarFixture", param, "Fixture", this.Text);

            //Reporte Jugadores
            FixtureReporte Repo = new FixtureReporte();

            //Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Instituciones");

            //Variables
            TextObject TorneoRepo;            
            TorneoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreTorneo"];
            TorneoRepo.Text = nombreTorneo;

           /* TextObject CategoriaRepo;            
            CategoriaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreCategoria"];
            CategoriaRepo.Text = nombreCategoria;*/

            Repo.SetDataSource(ds.Tables[0]);

            //doy Resporte al form
            crystalReportViewer1.ReportSource = Repo;
        }

    }
}
