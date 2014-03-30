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
    public partial class BusquedaAsignarProductoClienteForm : Form
    {
        public BusquedaAsignarProductoClienteForm()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();
            ProductosDataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);
            this.ProductosDataGridView.Columns["nombre"].Width = 250;

            if (ProductosDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Asignar Producto");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ModDataGridView.agregarBoton(ProductosDataGridView, "Asignar Producto");
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

            ModDataGridView.limpiarDataGridView(ProductosDataGridView, "Asignar Producto");
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


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.ProductosDataGridView.Columns["Asignar Producto"].Index && e.RowIndex >= 0)
            {
                AsignarProductoClienteForm abrir = new AsignarProductoClienteForm(this.ProductosDataGridView.CurrentRow.Cells["nombre"].Value.ToString());
                DialogResult Respuesta = abrir.ShowDialog();
            }
        }

        private void BusquedaAsignarProductoClienteForm_Load(object sender, EventArgs e)
        {
            this.NombreTextBox.Select();
        }
    }
}
