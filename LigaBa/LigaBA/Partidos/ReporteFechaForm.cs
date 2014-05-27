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
    public partial class ReporteFechaForm : Form
    {
        public ReporteFechaForm(string nombreTorneo,string idTorneo)
        {
            InitializeComponent();

            this.nombreTorneo = nombreTorneo;
            this.idTorneo = idTorneo;
        }

        string nombreTorneo;
        string idTorneo;



        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", idTorneo));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ReporteFechaPosicionesXCategoria", param, "PosicionesXCategoria", this.Text);
            
            //Me fijo si tiene tabla general
            CargadorDeDatos.CargarTorneoGeneralComboBox(this.TorneosComboBox, this.Text);
            this.TorneosComboBox.SelectedValue = idTorneo;
            DataSet ds2 = null;

            if (this.TorneosComboBox.SelectedValue != null)
            {
                List<SqlParameter> param2 = new List<SqlParameter>();
                param2.Add(new SqlParameter("@Torneo", idTorneo));
                ds2 = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarPosicionesGeneral", param2, "PosicionesGeneral", this.Text);
            }
            FechaReporte Repo = new FechaReporte();

            //Variables
            TextObject TorneoRepo;
            TorneoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["nombreTorneo"];
            TorneoRepo.Text = nombreTorneo;


            if (this.TorneosComboBox.SelectedValue != null)
            {
                Repo.Subreports[0].SetDataSource(ds2.Tables[0]);
            }
            
            
            Repo.SetDataSource(ds.Tables[0]);

            //doy Resporte al form
            crystalReportViewer1.ReportSource = Repo;
        }
    }
}
