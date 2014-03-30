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

namespace AplicationDesktop1.Abm_Usuarios
{
    public partial class BajaUsuarioForm : Form
    {
        public BajaUsuarioForm()
        {
            InitializeComponent();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.UsuariosGroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
            }

            ModDataGridView.limpiarDataGridView(Usuario_DataGridView,"Eliminar");

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BuscarButton_Click(object sender, EventArgs e)
        {

            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@usuario", this.NombreUsuarioTextBox.Text)); 

            Usuario_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta,param,this.Text);

            if (Usuario_DataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "Eliminar");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ModDataGridView.agregarBoton(Usuario_DataGridView, "Eliminar");
        }


        private string ArmarConsulta()
        {
            string Consulta = "SELECT username,estado FROM ingeniar.usuarios ";

            if (NombreUsuarioTextBox.TextLength > 0)
            {
                Consulta += "WHERE username='" + NombreUsuarioTextBox.Text + "'";
            }

            return Consulta;
        }

        private void Usuario_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.Usuario_DataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@usuario", Convert.ToString(Usuario_DataGridView.CurrentRow.Cells["username"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaUsuario", param, this.Text);

                if (TerminoBien == true)
                {
                    MessageBox.Show("Se ha dado de baja el usuario '" + Convert.ToString(Usuario_DataGridView.CurrentRow.Cells["username"].Value) + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Usuario_DataGridView.Rows.Remove(Usuario_DataGridView.CurrentRow);
                    if (Usuario_DataGridView.Rows.Count <= 0)
                    {
                        ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "Eliminar");
                    }

                }        
            }
        }



    }
}
