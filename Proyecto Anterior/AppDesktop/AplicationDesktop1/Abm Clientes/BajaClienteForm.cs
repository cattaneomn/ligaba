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
    public partial class BajaClienteForm : Form
    {
        public BajaClienteForm()
        {
            InitializeComponent();
            this.RazonSocialTextBox.Select();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();

            ClienteDataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (ClienteDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(ClienteDataGridView, "Eliminar");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ModDataGridView.agregarBoton(ClienteDataGridView, "Eliminar");
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

            ModDataGridView.limpiarDataGridView(ClienteDataGridView, "Eliminar");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT razon_social,direccion,telefono,email FROM ingeniar.Cliente WHERE estado=1 ";

            if (RazonSocialTextBox.TextLength > 0)
            {
                Consulta += "AND razon_social LIKE '%" + RazonSocialTextBox.Text + "%'";
            }

            return Consulta;
        }

        private void ClienteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.ClienteDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@razon_social",Convert.ToString(ClienteDataGridView.CurrentRow.Cells["razon_social"].Value))); 
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaCliente", param, this.Text);

                if (TerminoBien == true)
                {
                    MessageBox.Show("Se ha dado de baja el cliente '" + Convert.ToString(ClienteDataGridView.CurrentRow.Cells["razon_social"].Value) + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClienteDataGridView.Rows.Remove(ClienteDataGridView.CurrentRow);
                    if (ClienteDataGridView.Rows.Count <= 0)
                    {
                        ModDataGridView.limpiarDataGridView(ClienteDataGridView, "Eliminar");
                    }
                
                }         
            }

        }




    }
}
