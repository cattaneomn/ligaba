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

namespace AplicationDesktop1.Abm_Clientes
{
    public partial class BajaProductoClienteForm : Form
    {
        public BajaProductoClienteForm()
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

            ModDataGridView.agregarBoton(ProductosDataGridView, "Eliminar");
            this.ProductosDataGridView.Columns["nombre"].Width = 250;

            if (ProductosDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Eliminar");
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

            ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Eliminar");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.ProductosDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@clienteid", Convert.ToInt32(ClientesComboBox.SelectedValue)));
                param.Add(new SqlParameter("@productoid", Convert.ToString(ProductosDataGridView.CurrentRow.Cells["codigo"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaProductoCliente", param, this.Text);

                if (TerminoBien == true)
                {
                    MessageBox.Show("Se ha dado de baja el producto '" + Convert.ToString(ProductosDataGridView.CurrentRow.Cells["nombre"].Value) + "' para el cliente '" + ClientesComboBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProductosDataGridView.Rows.Remove(ProductosDataGridView.CurrentRow);
                    if (ProductosDataGridView.Rows.Count <= 0)
                    {
                        ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Eliminar");
                    }

                }
            }
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

        private void BajaProductoClienteForm_Load(object sender, EventArgs e)
        {
            CargarClientesComboBox();
            this.ClientesComboBox.Select();
        }
    }
}
