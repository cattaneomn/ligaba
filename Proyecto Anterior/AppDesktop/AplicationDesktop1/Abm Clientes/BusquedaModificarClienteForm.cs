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
    public partial class BusquedaModificarClienteForm : Form
    {
        public BusquedaModificarClienteForm()
        {
            InitializeComponent();
            this.RazonSocialTextBox.Select();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.ClienteGroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
            }

            ModDataGridView.limpiarDataGridView(ClienteDataGridView, "Seleccionar");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@RazonSocial", this.RazonSocialTextBox.Text));

            ClienteDataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (ClienteDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(ClienteDataGridView, "Seleccionar");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ModDataGridView.agregarBoton(ClienteDataGridView, "Seleccionar");
            ClienteDataGridView.Columns["codigo"].Visible = false;
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT codigo,razon_social,direccion,telefono,email FROM ingeniar.Cliente WHERE estado=1 ";

            if (RazonSocialTextBox.TextLength > 0)
            {
                Consulta += "AND razon_social LIKE '%" + RazonSocialTextBox.Text + "%'";
            }

            return Consulta;
        }

        private void ClienteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> Cliente = new List<string>();
            if (e.ColumnIndex == this.ClienteDataGridView.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                Cliente.Add(ClienteDataGridView.CurrentRow.Cells["codigo"].Value.ToString());
                Cliente.Add(ClienteDataGridView.CurrentRow.Cells["razon_social"].Value.ToString());
                Cliente.Add(ClienteDataGridView.CurrentRow.Cells["direccion"].Value.ToString());
                Cliente.Add(ClienteDataGridView.CurrentRow.Cells["telefono"].Value.ToString());
                Cliente.Add(ClienteDataGridView.CurrentRow.Cells["email"].Value.ToString());

                ModificarClienteForm abrir = new ModificarClienteForm(Cliente);
                DialogResult Respuesta = abrir.ShowDialog();

                if (Respuesta == DialogResult.OK)
                {
                    ModDataGridView.limpiarDataGridView(ClienteDataGridView, "Seleccionar");
                }

            }
        }
    }
}
