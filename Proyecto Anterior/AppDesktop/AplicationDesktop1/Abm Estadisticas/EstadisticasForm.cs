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

namespace AplicationDesktop1.Abm_Estadisticas
{
    public partial class EstadisticasForm : Form
    {
        public EstadisticasForm()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.TipoGroupBox.Controls)
            {
                if (objeto is RadioButton)
                {
                    ((RadioButton)objeto).Checked = false;
                }

            }
            DesdeDateTimePicker.Value = System.DateTime.Now;
            HastaDateTimePicker.Value = System.DateTime.Now;
            ClientesComboBox.SelectedItem = null;
            EstadisticasDataGridView.DataSource = null;
        }

        private void MostrarButton_Click(object sender, EventArgs e)
        {
            int Cant_tildados = 0;
            foreach (Control objeto in this.TipoGroupBox.Controls)
            {
                if (objeto is RadioButton && ((RadioButton)objeto).Checked == true)
                {
                    Cant_tildados++;
                }
              
            }
            if (Cant_tildados == 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de estadistica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (DesdeDateTimePicker.Value.Date > HastaDateTimePicker.Value.Date)
            {
                MessageBox.Show("La fecha 'desde' no puede ser mayor a la fecha 'hasta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (VentasRadioButton.Checked == true)
            {
                decimal Total = 0;

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@desde", DesdeDateTimePicker.Value));
                param.Add(new SqlParameter("@hasta", HastaDateTimePicker.Value));
                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_EstadisticasVentas", param, "Clientes", this.Text);

                if (ValidarDataSet(ds) == -1) return;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Total = Total + Convert.ToDecimal(row[1]);
                }
                ds.Tables[0].Rows.Add("TOTAL", Total);
                EstadisticasDataGridView.DataSource = ds;
                EstadisticasDataGridView.DataMember = "Clientes";
                EstadisticasDataGridView.Rows[EstadisticasDataGridView.Rows.Count - 1].Cells[0].Style.ForeColor = (Color.Red);
                EstadisticasDataGridView.Rows[EstadisticasDataGridView.Rows.Count - 1].Cells[0].Style.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                EstadisticasDataGridView.Rows[EstadisticasDataGridView.Rows.Count - 1].Cells[1].Style.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);   
            }
            if (ProductosRadioButton.Checked == true)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@desde", DesdeDateTimePicker.Value));
                param.Add(new SqlParameter("@hasta", HastaDateTimePicker.Value));
                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_EstadisticasProductos", param, "Productos", this.Text);
                EstadisticasDataGridView.DataSource = ds;
                EstadisticasDataGridView.DataMember = "Productos";
                if (ValidarDataSet(ds) == -1) return;
            }

            if (ProductosXClienteRadioButton.Checked == true)
            {
                if (ClientesComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@desde", DesdeDateTimePicker.Value));
                param.Add(new SqlParameter("@hasta", HastaDateTimePicker.Value));
                param.Add(new SqlParameter("@cliente", Convert.ToInt32(this.ClientesComboBox.SelectedValue)));
                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_EstadisticasProductosXCliente", param, "ProductosXCliente", this.Text);
                EstadisticasDataGridView.DataSource = ds;
                EstadisticasDataGridView.DataMember = "ProductosXCliente";
                if (ValidarDataSet(ds) == -1) return;     
            }

            if (DiaRadioButton.Checked == true)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@desde", DesdeDateTimePicker.Value));
                param.Add(new SqlParameter("@hasta", HastaDateTimePicker.Value));
                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_EstadisticasDias", param, "Dias", this.Text);
                EstadisticasDataGridView.DataSource = ds;
                EstadisticasDataGridView.DataMember = "Dias";
                if (ValidarDataSet(ds) == -1) return;
            }


       }

        private void EstadisticasForm_Load(object sender, EventArgs e)
        {
            CargarClientesComboBox();
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

        private void ProductosRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ClientesComboBox.Visible = false;
            this.ClienteLabel.Visible = false;
        }

        private void VentasRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ClientesComboBox.Visible = false;
            this.ClienteLabel.Visible = false;
        }

        private void ProductosXClienteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ClientesComboBox.Visible = true;
            this.ClienteLabel.Visible = true;
        }

        private void DiaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ClientesComboBox.Visible = false;
            this.ClienteLabel.Visible = false;
        }

        private int ValidarDataSet(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0 )
            {
                EstadisticasDataGridView.DataSource = null;
                MessageBox.Show("No hay datos en el periodo indicado.", "Estadisticas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            return 1;
        }
    }
}
