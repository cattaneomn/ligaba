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
using AplicationDesktop1.Abm_Clientes.ModificarProducto;
namespace AplicationDesktop1.Abm_Clientes
{
    public partial class BusquedaModificarProductoClienteForm : Form
    {
        public BusquedaModificarProductoClienteForm(bool TodosProductos)
        {
            InitializeComponent();

            Todos = TodosProductos;
        }

        bool Todos;
        public static string TipoModificacion;
        public static decimal Porcentaje;

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

            if (ProductosDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Seleccionar");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ModDataGridView.agregarBoton(ProductosDataGridView, "Seleccionar");
            this.ProductosDataGridView.Columns["nombre"].Width = 250;

            if (Todos == true)
            {
                this.ProductosDataGridView.Columns["Seleccionar"].Visible = false;
                this.ModificarPreciosButton.Enabled = true;
                this.ClientesComboBox.Enabled = false;
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

            if (Todos == true)
            {
                if( ModDataGridView.tieneLaColumna(ProductosDataGridView,"precio nuevo") == true )
                {
                    this.ProductosDataGridView.Columns.Remove("precio nuevo");
                }
                this.ClientesComboBox.Enabled = true;
                this.ModificarPreciosButton.Enabled = false;
                this.BuscarButton.Visible = true;
                this.GuardarButton.Visible = false;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarPrecioProductoForm_Load(object sender, EventArgs e)
        {
            CargarClientesComboBox();
            if (Todos == true)
            {
                this.ModificarPreciosButton.Visible = true;
            }
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
                ModificarPrecioForm abrir = new ModificarPrecioForm(ClientesComboBox.Text,this.ProductosDataGridView.CurrentRow.Cells["nombre"].Value.ToString(),Convert.ToDecimal(this.ProductosDataGridView.CurrentRow.Cells["precio"].Value));
                DialogResult Respuesta =  abrir.ShowDialog();

                if (Respuesta == DialogResult.OK)
                {
                    this.BuscarButton.PerformClick();
                }

            }
        }

        private void ModificarPreciosButton_Click(object sender, EventArgs e)
        {
            ModificarTodosPreciosForm abrir = new ModificarTodosPreciosForm();
            DialogResult Respuesta = abrir.ShowDialog();

            if (Respuesta == DialogResult.OK)
            {
                this.ModificarPreciosButton.Enabled = false;
                this.ClientesComboBox.Enabled = false;
                this.BuscarButton.Visible = false;
                this.GuardarButton.Visible = true;
                AumentarPreciosDataGrid();
            }
        }

        private void AumentarPreciosDataGrid()
        {
            this.ProductosDataGridView.Columns.Add("precio nuevo", "precio nuevo");
            if (TipoModificacion == "Aumentar")
            {
                foreach (DataGridViewRow row in this.ProductosDataGridView.Rows)
                {
                    row.Cells["precio nuevo"].Value = Decimal.Round(Convert.ToDecimal(row.Cells["precio"].Value) + ((Convert.ToDecimal(row.Cells["precio"].Value) * Porcentaje) / 100),2);
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.ProductosDataGridView.Rows)
                {
                    row.Cells["precio nuevo"].Value = Decimal.Round(Convert.ToDecimal(row.Cells["precio"].Value) - ((Convert.ToDecimal(row.Cells["precio"].Value) * Porcentaje) / 100),2);
                }
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            int Cant_TerminoBien = 0;
            bool TerminoBien;

            foreach (DataGridViewRow row in this.ProductosDataGridView.Rows)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@cliente", this.ClientesComboBox.Text));
                param.Add(new SqlParameter("@producto", row.Cells["nombre"].Value.ToString()));
                param.Add(new SqlParameter("@precio", Convert.ToDecimal(row.Cells["precio nuevo"].Value)));
                TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarPrecioProducto", param, this.Text);
                if (TerminoBien == true)
                {
                    Cant_TerminoBien++;
                }
            
            }

            if (Cant_TerminoBien == this.ProductosDataGridView.Rows.Count)
            {
                MessageBox.Show("Se han modificado los productos correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarButton.PerformClick();
                
            }  
        }

    }
}
