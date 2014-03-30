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

namespace LigaBA.Abm_Usuarios
{
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.GroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
            }

            ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "");

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

            Usuario_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);
            
            if (Usuario_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Usuario_DataGridView.Focus();
        }


        private string ArmarConsulta()
        {
            string Consulta = "SELECT username as Usuario FROM LigaBA.usuarios ";

            if (NombreUsuarioTextBox.TextLength > 0)
            {
                Consulta += "WHERE username='" + NombreUsuarioTextBox.Text + "'";
            }

            return Consulta;
        }


        private void AgregarButton_Click(object sender, EventArgs e)
        {
            AltaUsuariosForm abrir = new AltaUsuariosForm();
            abrir.ShowDialog();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (this.Usuario_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Usuario_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

            string UsuarioBorrado = Usuario_DataGridView.CurrentRow.Cells["Usuario"].Value.ToString();

            DialogResult Resultado = MessageBox.Show("¿Esta seguro que desea eliminar el usuario '" + UsuarioBorrado + "'?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@usuario", Convert.ToString(Usuario_DataGridView.CurrentRow.Cells["Usuario"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaUsuario", param, this.Text);

                if (TerminoBien == true)
                {
                    
                    Usuario_DataGridView.Rows.Remove(Usuario_DataGridView.CurrentRow);
                    MessageBox.Show("Se ha dado de baja el usuario '" + UsuarioBorrado + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if(this.Usuario_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Usuario_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ModificarPasswordUsuarioForm abrir = new ModificarPasswordUsuarioForm(Usuario_DataGridView.CurrentRow.Cells["Usuario"].Value.ToString());
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                ModDataGridView.limpiarDataGridView(Usuario_DataGridView, "");
            }
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            this.Usuario_DataGridView.MultiSelect = false;
        }



    }
}
