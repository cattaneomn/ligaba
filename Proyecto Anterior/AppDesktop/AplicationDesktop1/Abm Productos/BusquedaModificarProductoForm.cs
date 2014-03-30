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
    public partial class BusquedaModificarProductoForm : Form
    {
        public BusquedaModificarProductoForm()
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
                ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Seleccionar");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ModDataGridView.agregarBoton(ProductosDataGridView, "Seleccionar");
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.ProductoGroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
            }

            ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Seleccionar");
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
            if (e.ColumnIndex == this.ProductosDataGridView.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                ModificarProductoForm abrir = new ModificarProductoForm(Convert.ToInt32(ProductosDataGridView.CurrentRow.Cells["codigo"].Value), ProductosDataGridView.CurrentRow.Cells["nombre"].Value.ToString(), ProductosDataGridView.CurrentRow.Cells["detalle"].Value.ToString());
                DialogResult Respuesta = abrir.ShowDialog();

                if (Respuesta == DialogResult.OK)
                {
                    if (Respuesta == DialogResult.OK)
                    {
                        ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Seleccionar");
                    }

                }

            }
        }

        private void BusquedaModificarProductoForm_Load(object sender, EventArgs e)
        {
            this.NombreTextBox.Select();
        }
    }
}
