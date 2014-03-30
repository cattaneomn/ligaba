using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace AplicationDesktop1.Abm_Ventas
{
    public partial class DetalleForm : Form
    {
        public DetalleForm(string Numero_Fact, DateTime Fecha_Fact ,String Cliente_Fact,String Total_Fact)
        {
            InitializeComponent();

            Numero = Numero_Fact;
            Cliente = Cliente_Fact;
            Fecha = Fecha_Fact;
            Total = Total_Fact;

            this.CancelarButton.Select();
        }

        string Numero;
        string Cliente;
        DateTime Fecha;
        string Total;


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetalleForm_Load(object sender, EventArgs e)
        {
            CargarClientesComboBox();
            ClientesComboBox.Text = Cliente;
            CargarGroupBox();
            CargarDataGrid();
            FacturaDataGridView.Columns["Producto"].Width = 250;
        }

        private void CargarGroupBox()
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Cod_Cliente", Convert.ToInt32(this.ClientesComboBox.SelectedValue)));
            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarCliente", param, "Cliente", this.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.DireccionTextBox.Text = row["direccion"].ToString();
                this.TelefonoTextBox.Text = row["telefono"].ToString();

            }

            this.FechaDateTimePicker.Value = Fecha;
            this.NumFactTextBox.Text = Numero.ToString();
            this.TotalTextBox.Text = Total.ToString() ;


        }

        private void CargarClientesComboBox()
        {
            string Consulta = "SELECT codigo,razon_social FROM ingeniar.Cliente WHERE estado=1";
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            ClientesComboBox.DataSource = ds;
            ClientesComboBox.ValueMember = "codigo";
            ClientesComboBox.DisplayMember = "razon_social";
            ClientesComboBox.SelectedItem = null;

        }

        private void CargarDataGrid()
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@numero", Numero));
            FacturaDataGridView.DataSource = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarItemFactura", param, "Factura", this.Text);
            FacturaDataGridView.DataMember = "Factura";
        }
    }
}
