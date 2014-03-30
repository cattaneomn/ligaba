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

namespace AplicationDesktop1.Abm_Ventas
{
    public partial class ReporteForm : Form
    {
        public ReporteForm(string Numero_Fact, DateTime Fecha_Fact, String Cliente_Fact, String Total_Fact)
        {
            InitializeComponent();
            
            Numero = Numero_Fact;
            Cliente = Cliente_Fact;
            Fecha = Fecha_Fact;
            Total = Total_Fact;

        }

        string Numero;
        string Cliente;
        DateTime Fecha;
        string Total;
        string Direccion;
        string Telefono;
        int Codigo;

        


        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            string Consulta2 = "SELECT codigo FROM ingeniar.Cliente WHERE estado=1 AND razon_social='";
            Consulta2 += Cliente + "'";
            List<SqlParameter> param2 = new List<SqlParameter>();
            DataTable ds2 = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta2, param2, this.Text);

            foreach (DataRow row in ds2.Rows)
            {
                Codigo = Convert.ToInt32(row["codigo"]);
        
            }
      
            List<SqlParameter> param3 = new List<SqlParameter>();
            param3.Add(new SqlParameter("@Cod_Cliente", Codigo ));
            DataSet ds3 = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarCliente", param3, "Cliente", this.Text);

            foreach (DataRow row in ds3.Tables[0].Rows)
            {
                Direccion = row["direccion"].ToString();
                Telefono = row["telefono"].ToString();
            }

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@numero", Numero));
            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarItemFactura", param, "Factura", this.Text);
            
            CrystalReport2 Repo = new CrystalReport2();

            //Variables
            TextObject ClienteRepo;
            ClienteRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Cliente"];
            ClienteRepo.Text = Cliente;
            
            TextObject NumeroRepo;
            NumeroRepo=(TextObject)Repo.ReportDefinition.ReportObjects["FactNum"];
            NumeroRepo.Text = Numero;

            TextObject FechaRepo;
            FechaRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Fecha"];
            FechaRepo.Text = Fecha.ToShortDateString();

            TextObject DirRepo;
            DirRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Direccion"];
            DirRepo.Text = Direccion;

            TextObject TelRepo;
            TelRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Telefono"];
            TelRepo.Text = Telefono;

            TextObject TotalRepo;
            TotalRepo = (TextObject)Repo.ReportDefinition.ReportObjects["Total"];
            TotalRepo.Text = Total;
            //

            Repo.ExportToDisk(ExportFormatType.PortableDocFormat, "Factura2");

            Repo.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = Repo;
            //crystalReportViewer1.ShowExportButton = false;

        }
    }
}
