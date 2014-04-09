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

namespace LigaBA.Abm_Equipos
{
    public partial class JugadoresResporteForm : Form
    {
        public JugadoresResporteForm(string id,string institucion,string equipo,string categoria)
        {
            InitializeComponent();

            this.id = id;
            this.institucion = institucion;
            this.equipo = equipo;
            this.categoria = categoria;
        }

        string id;
        string institucion;
        string equipo;
        string categoria;


        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //DataSet

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Equipo", id));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_Reportejugadores", param, "Jugadores", this.Text);

            //Reporte Jugadores
            Jugadores Repo = new Jugadores();

            //Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Instituciones");

            //Variables
            TextObject InstitucionRepo;
            InstitucionRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Institucion"];
            InstitucionRepo.Text = institucion;

            TextObject EquipoRepo;
            EquipoRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Equipo"];
            EquipoRepo.Text = equipo;

            TextObject CategoriaRepo;
            CategoriaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Categoria"];
            CategoriaRepo.Text = categoria;

            Repo.SetDataSource(ds.Tables[0]);

            //doy Resporte al form
            crystalReportViewer1.ReportSource = Repo;
        }
    }
}
