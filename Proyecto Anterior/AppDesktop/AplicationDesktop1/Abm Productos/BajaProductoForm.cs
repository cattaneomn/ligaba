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

namespace AplicationDesktop1.Abm_Productos
{
    public partial class BajaProductoForm : Form
    {
        public BajaProductoForm()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();
            ProductosDataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (ProductosDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Eliminar");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ModDataGridView.agregarBoton(ProductosDataGridView, "Eliminar");
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.ProductoGroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
                if (objeto is ComboBox)
                {
                    ((ComboBox)objeto).SelectedItem = null;
                }
                if (objeto is NumericUpDown)
                {
                    ((NumericUpDown)objeto).Value = 0;
                }
            }
            
            ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Eliminar");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT codigo,nombre,detalle FROM ingeniAR.Producto WHERE estado=1 ";

            if (NombreTextBox.TextLength > 0)
            {
                Consulta += "AND nombre LIKE '%" + NombreTextBox.Text + "%' ";
            }

           
            return Consulta;
        }

        private void ProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.ProductosDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@codigo", Convert.ToString(ProductosDataGridView.CurrentRow.Cells["codigo"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaProducto", param, this.Text);

                if (TerminoBien == true)
                {
                    MessageBox.Show("Se ha dado de baja el producto '" + Convert.ToString(ProductosDataGridView.CurrentRow.Cells["nombre"].Value) + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProductosDataGridView.Rows.Remove(ProductosDataGridView.CurrentRow);
                    if (ProductosDataGridView.Rows.Count <= 0)
                    {
                        ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Eliminar");
                    }

                }
            }
        }

        private void BajaProductoForm_Load(object sender, EventArgs e)
        {
            this.NombreTextBox.Select();
        }



    }
}
