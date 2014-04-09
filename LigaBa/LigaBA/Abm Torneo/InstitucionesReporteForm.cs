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

namespace LigaBA.Abm_Torneo
{
    public partial class InstitucionesReporteForm : Form
    {
        public InstitucionesReporteForm()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
            //DataSet

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@TorneoXCategoria", 1));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ReporteInstituciones", param, "Instituciones", this.Text);
            
            //Reporte Instituciones
            Instituciones Repo = new Instituciones();

          //  Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Instituciones");
          
            Repo.SetDataSource(ds.Tables[0]);

            //doy Resporte al form
            crystalReportViewer1.ReportSource = Repo;
        }


    }
}
