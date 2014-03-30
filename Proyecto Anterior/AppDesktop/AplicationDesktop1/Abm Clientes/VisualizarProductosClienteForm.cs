using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AplicationDesktop1.Abm_Productos;
using System.Data.SqlClient;

namespace AplicationDesktop1.Abm_Clientes
{
    public partial class VisualizarProductosClienteForm : Form
    {
        public VisualizarProductosClienteForm()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if (this.ClientesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para realizar la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@cliente", Convert.ToInt32(this.ClientesComboBox.SelectedValue)));
            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_CargarProductosFactura", param, "Producto", this.Text);

            this.ProductosDataGridView.DataSource = ds;
            this.ProductosDataGridView.DataMember = "Producto";

            ModDataGridView.agregarBoton(ProductosDataGridView, "Seleccionar");
            this.ProductosDataGridView.Columns["nombre"].Width = 250;

            if (ProductosDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Seleccionar");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.ClienteGroupBox.Controls)
            {
                if (objeto is ComboBox)
                {
                    ((ComboBox)objeto).SelectedItem = null;
                }
            }

            ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Seleccionar");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisualizarProductosClienteForm_Load(object sender, EventArgs e)
        {
            CargarClientesComboBox();
            this.ClientesComboBox.Select();
            
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

        private void ProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.ProductosDataGridView.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                AltaProductosForm abrir = new AltaProductosForm("VisualizarProductos", this.ProductosDataGridView.CurrentRow.Cells["nombre"].Value.ToString(), this.ProductosDataGridView.CurrentRow.Cells["detalle"].Value.ToString(), this.ProductosDataGridView.CurrentRow.Cells["precio"].Value.ToString());
                abrir.ShowDialog();
            }
        }

    }
}
