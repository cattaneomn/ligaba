using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LigaBA.Reportes;


namespace LigaBA.Abm_Jugador
{
    public partial class ReporteForm : Form
    {

        string nombre;
        string dni;
        string institucion;
        string fechaNac;

        public ReporteForm(string nombre,string dni,string institucion,string fechaNac)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.dni = dni;
            this.institucion = institucion;
            this.fechaNac = fechaNac;
        }

       

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {


            Carnet Repo = new Carnet();

            //Variables
            TextObject InstitucionRepo;
            InstitucionRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Institucion"];
            InstitucionRepo.Text = institucion;

            TextObject NombreRepo;
            NombreRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Nombre"];
            NombreRepo.Text = nombre;

            TextObject DniRepo;
            DniRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Dni"];
            DniRepo.Text = dni;

            TextObject FechaNacRepo;
            FechaNacRepo = (TextObject)Repo.ReportDefinition.ReportObjects["FechaNacimiento"];
            FechaNacRepo.Text = fechaNac;

            Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Carnet");

           // Repo.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = Repo;

        }
    }
}
