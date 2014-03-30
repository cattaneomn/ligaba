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
    public partial class BusquedaModificarUsuarioForm : Form
    {
        public BusquedaModificarUsuarioForm()
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
            ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "Cambiar Permisos");
            ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "Cambiar Contraseña");

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
                ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "Cambiar Permisos");
                ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "Cambiar Contraseña");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModDataGridView.agregarBoton(Usuario_DataGridView, "Cambiar Permisos");
            ModDataGridView.agregarBoton(Usuario_DataGridView, "Cambiar Contraseña");
            this.Usuario_DataGridView.Columns["Cambiar Contraseña"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            if (e.ColumnIndex == this.Usuario_DataGridView.Columns["Cambiar Permisos"].Index && e.RowIndex >= 0)
            {
                ModificarUsuarioPermisosForm abrir = new ModificarUsuarioPermisosForm(this.Usuario_DataGridView.CurrentRow.Cells["username"].Value.ToString(), Convert.ToBoolean(this.Usuario_DataGridView.CurrentRow.Cells["estado"].Value));
                DialogResult Respuesta = abrir.ShowDialog();

                if (Respuesta == DialogResult.OK)
                {
                    this.LimpiarButton.PerformClick();
                    return;
                }
            }
            if (e.ColumnIndex == this.Usuario_DataGridView.Columns["Cambiar Contraseña"].Index && e.RowIndex >= 0)
            {

                MessageBox.Show("Por razones de seguridad debe volver a loguearse.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginForm abrir1 = new LoginForm();
                DialogResult Respuesta = abrir1.ShowDialog();

                if (Respuesta == DialogResult.OK)
                {
                    ModificarPasswordUsuarioForm abrir = new ModificarPasswordUsuarioForm(this.Usuario_DataGridView.CurrentRow.Cells["username"].Value.ToString());
                    abrir.ShowDialog();
                }
            }
        }



    }
}
