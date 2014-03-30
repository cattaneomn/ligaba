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
    public partial class ModificarFacturaForm : Form
    {
        public ModificarFacturaForm(string Numero_Fact, DateTime Fecha_Fact, String Cliente_Fact, String Total_Fact)
        {
            InitializeComponent();

            Numero = Numero_Fact;
            Cliente = Cliente_Fact;
            Fecha = Fecha_Fact;
            Total = Convert.ToDecimal(Total_Fact);
        }

        string Numero;
        string Cliente;
        DateTime Fecha;
        decimal Total;

        public static string Producto2;
        public static decimal Precio2;
        public static int Cantidad2;
        public static int Codigo2;

        DataSet ds;

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (FacturaDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<SqlParameter> param2 = new List<SqlParameter>();
            param2.Add(new SqlParameter("@numero", Numero));
            param2.Add(new SqlParameter("@cliente", Convert.ToInt32(this.ClientesComboBox.SelectedValue)));
            param2.Add(new SqlParameter("@fecha", this.FechaDateTimePicker.Value));
            param2.Add(new SqlParameter("@total", Total));
            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarFactura", param2, this.Text);


            List<SqlParameter> param3 = new List<SqlParameter>();
            param3.Add(new SqlParameter("@fact_numero", Numero));
            bool TerminoBienBorrado = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaItemFactura", param3, this.Text);

            int Item_Numero = 0;

            foreach (DataGridViewRow Filas in FacturaDataGridView.Rows)
            {
                Item_Numero++;
                List<SqlParameter> param = new List<SqlParameter>();

                param.Add(new SqlParameter("@producto", Convert.ToInt32(Filas.Cells["Codigo"].Value)));
                param.Add(new SqlParameter("@cantidad", Convert.ToInt32(Filas.Cells["Cantidad"].Value)));
                param.Add(new SqlParameter("@precio", Convert.ToDecimal(Filas.Cells["Precio Unitario"].Value)));
                param.Add(new SqlParameter("@item_numero", Item_Numero));
                param.Add(new SqlParameter("@fact_numero", Numero));

                BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaItemFactura", param, this.Text);

            }

            if (TerminoBien == true && TerminoBienBorrado == true)
            { 
                MessageBox.Show("Se ha moficado la factura Nº '" + this.NumFactTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }  
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarFacturaForm_Load(object sender, EventArgs e)
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
            this.TotalTextBox.Text = Total.ToString();


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
            ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarItemFactura", param, "Factura", this.Text);
            FacturaDataGridView.DataSource = ds;
            FacturaDataGridView.DataMember = "Factura";
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {

            SeleccionProductoForm abrir = new SeleccionProductoForm(Convert.ToInt32(this.ClientesComboBox.SelectedValue),"Modificar");
            DialogResult Respuesta = abrir.ShowDialog();

            if (Respuesta == DialogResult.OK)
            {
                FacturaDataGridView.ColumnHeadersVisible = true;
                Cliente = this.ClientesComboBox.Text;
                this.EliminarButton.Enabled = true;
                this.GuardarButton.Enabled = true;
                
                ds.Tables[0].Rows.Add(Codigo2, Producto2, Precio2, Cantidad2, Precio2 * Cantidad2);
                FacturaDataGridView.DataSource = ds;
                FacturaDataGridView.DataMember = "Factura";
                 
                Total = Total + (Precio2 * Cantidad2);
                this.TotalTextBox.Text = Convert.ToString(Total);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Total = Total - Convert.ToDecimal(this.FacturaDataGridView.CurrentRow.Cells["Importe"].Value);
            this.TotalTextBox.Text = Convert.ToString(Total);

            this.FacturaDataGridView.Rows.Remove(this.FacturaDataGridView.CurrentRow);
            if (this.FacturaDataGridView.Rows.Count == 0)
            {
                this.EliminarButton.Enabled = false;
                this.GuardarButton.Enabled = false;
                this.TotalTextBox.Text = "";
                FacturaDataGridView.ColumnHeadersVisible = false;
            }   
        }

        private void FechaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.FechaDateTimePicker.Value != Fecha)
            {
                this.GuardarButton.Enabled = true;
            }
         }

        private void ClientesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (FacturaDataGridView.Rows.Count > 0)
            {
                this.ClientesComboBox.Text = Cliente;
                MessageBox.Show("No puede cambiar el cliente si ya hay productos cargados en la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Cod_Cliente", Convert.ToInt32(this.ClientesComboBox.SelectedValue)));
            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarCliente", param, "Cliente", this.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.DireccionTextBox.Text = row["direccion"].ToString();
                this.TelefonoTextBox.Text = row["telefono"].ToString();
            }

            this.DireccionTextBox.Visible = true;
            this.DireccionLabel.Visible = true;
            this.TelefonoTextBox.Visible = true;
            this.TelefonoLabel.Visible = true;
            this.AgregarButton.Enabled = true;
        }

























    }
}
