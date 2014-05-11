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

namespace LigaBA.Posiciones
{
    public partial class ReportePosicionesForm : Form
    {
        public ReportePosicionesForm(string torneo,string categoria,string nombreTorneo,string nombreCategoria,DataTable Data,string Flag)
        {
            InitializeComponent();

            this.torneo = torneo;
            this.categoria = categoria;
            this.nombreTorneo = nombreTorneo;
            this.nombreCategoria = nombreCategoria;
            this.ds = Data;
            this.flag = Flag;
        }

        string torneo;
        string categoria;
        string nombreTorneo;
        string nombreCategoria;
        string flag;
        DataTable ds;

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            if (flag == "General")
            {
                PosicionesGeneral Repo = new PosicionesGeneral();

                //Variables
                TextObject TorneoRepo;
                TorneoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreTorneo"];
                TorneoRepo.Text = nombreTorneo;

                Repo.SetDataSource(ds);

                //doy Resporte al form
                crystalReportViewer1.ReportSource = Repo;

            }else
            {
                PosicionesXCategoria Repo = new PosicionesXCategoria();

                //Variables
                TextObject TorneoRepo;
                TorneoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreTorneo"];
                TorneoRepo.Text = nombreTorneo;

                TextObject CategoriaRepo;
                CategoriaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreCategoria"];
                CategoriaRepo.Text = nombreCategoria;

                Repo.SetDataSource(ds);

                //doy Resporte al form
                crystalReportViewer1.ReportSource = Repo;
            }

           

            

           
        }

    }
}
