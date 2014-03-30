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

using System.Threading;

namespace AplicationDesktop1.Abm_Ventas
{
    public partial class AltaFacturaForm : Form
    {
        public AltaFacturaForm()
        {
            InitializeComponent();
        }

        public static string Producto;
        public static decimal Precio;
        public static int Cantidad;
        public static int Codigo;
        public static decimal Total=0;
        string Cliente;
        int NumeroFactura;
        
        int PrintNumeroFactura;
        string PrintTotal;
        DateTime PrintFecha;

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (FacturaDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<SqlParameter> param2 = new List<SqlParameter>();

            param2.Add(new SqlParameter("@cliente", Convert.ToInt32(this.ClientesComboBox.SelectedValue)));
            param2.Add(new SqlParameter("@fecha", this.FechaDateTimePicker.Value));
            param2.Add(new SqlParameter("@total", Total));
            SqlParameter respuestaParametro = new SqlParameter("@respuesta", -1);
            respuestaParametro.Direction = ParameterDirection.Output;
            param2.Add(respuestaParametro);

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaFactura", param2, this.Text);

            object respuestaSP = respuestaParametro.Value;
            int respuesta = Convert.ToInt32(respuestaSP);
            
            PrintNumeroFactura = respuesta;
            PrintTotal = this.TotalTextBox.Text;
            PrintFecha = this.FechaDateTimePicker.Value;

            int Item_Numero = 0;

            foreach (DataGridViewRow Filas in FacturaDataGridView.Rows)
            {
                Item_Numero++;
                List<SqlParameter> param = new List<SqlParameter>();

                param.Add(new SqlParameter("@producto", Convert.ToInt32(Filas.Cells["Codigo"].Value)));
                param.Add(new SqlParameter("@cantidad", Convert.ToInt32(Filas.Cells["Cantidad"].Value)));
                param.Add(new SqlParameter("@precio", Convert.ToDecimal(Filas.Cells["Precio Unitario"].Value)));
                param.Add(new SqlParameter("@item_numero", Item_Numero));
                param.Add(new SqlParameter("@fact_numero", respuesta));
                
                BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaItemFactura", param, this.Text);

            }



            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha dado de alta la factura correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                PrintForm abrir = new PrintForm();
                DialogResult PrintRespuesta = abrir.ShowDialog();

                if ( (PrintRespuesta) == DialogResult.Yes )
                {
                    Thread hilo = new Thread(AbrirFormReporte);
                    hilo.SetApartmentState(System.Threading.ApartmentState.STA);
                    hilo.Start(); 
                }
                
                NumeroFactura = NumeroFactura + 1;
                this.NumFactTextBox.Text = Convert.ToString(NumeroFactura);
                this.LimpiarButton.PerformClick();
                this.ClientesComboBox.Focus();
                

            }         

        }

        private void AbrirFormReporte()
        {
            ReporteForm abrir = new ReporteForm(Convert.ToString(PrintNumeroFactura),PrintFecha,Cliente,PrintTotal);
            abrir.ShowDialog();
        }


        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.FacturaGroupBox.Controls)
            {
                if (objeto is TextBox && objeto.Name != "NumFactTextBox")
                {
                    ((TextBox)objeto).Clear();
                }
                if (objeto is ComboBox)
                {
                    ((ComboBox)objeto).SelectedItem = null;
                }
            }
           
            ModDataGridView.limpiarDataGridView(FacturaDataGridView, "");

            FacturaDataGridView.ColumnHeadersVisible = false;
            FacturaDataGridView.Rows.Clear();

            Total = 0;
            this.TotalTextBox.Text = "";
            this.DireccionTextBox.Visible = false;
            this.DireccionLabel.Visible = false;
            this.TelefonoTextBox.Visible = false;
            this.TelefonoLabel.Visible = false;
            this.AgregarButton.Enabled = false;
            this.EliminarButton.Enabled = false;
            this.GuardarButton.Enabled = false;

        }



        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void AgregarButton_Click(object sender, EventArgs e)
        {

            SeleccionProductoForm abrir = new SeleccionProductoForm(Convert.ToInt32(this.ClientesComboBox.SelectedValue),"Alta");
            DialogResult Respuesta = abrir.ShowDialog();

            if (Respuesta == DialogResult.OK)
            {
                FacturaDataGridView.ColumnHeadersVisible = true;
                Cliente = this.ClientesComboBox.Text;
                this.EliminarButton.Enabled = true;
                this.GuardarButton.Enabled = true;
                FacturaDataGridView.Rows.Add(Codigo,Producto,Precio,Cantidad,Precio*Cantidad);
                Total = Total + (Precio * Cantidad);
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

        private void AltaFacturaForm_Load(object sender, EventArgs e)
        {
            CargarClientesComboBox();
            FacturaDataGridView.Columns.Add("Codigo", "Codigo");
            FacturaDataGridView.Columns.Add("Producto", "Producto");
            FacturaDataGridView.Columns.Add("Precio Unitario", "Precio Unitario");
            FacturaDataGridView.Columns.Add("Cantidad", "Cantidad");
            FacturaDataGridView.Columns.Add("Importe", "Importe");
            this.ClientesComboBox.Select();
            FacturaDataGridView.ColumnHeadersVisible = false;
            
            //NUMERO DE FACTURA
            string Consulta = "SELECT MAX(numero) FROM ingeniar.factura";
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);
         
            foreach (DataRow row in ds.Rows)
            {
                if (Convert.ToString(row[0]) == "")
                {
                    row[0] = 0;
                }
                NumeroFactura = (Convert.ToInt32(row[0]) + 1);
                this.NumFactTextBox.Text = Convert.ToString(NumeroFactura);
            }

            FacturaDataGridView.Columns["Producto"].Width = 250;
            
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
            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarCliente", param,"Cliente",this.Text);
 
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
