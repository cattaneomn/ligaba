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
    public partial class ModificarUsuarioPermisosForm : Form
    {
        public ModificarUsuarioPermisosForm(string Usuario, bool Estado)
        {
            InitializeComponent();
            EstadoUsuario = Estado;
            NombreUsuario = Usuario;
        }

        string NombreUsuario;
        bool EstadoUsuario;

        private void ModificarUsuarioForm_Load(object sender, EventArgs e)
        {
            List<SqlParameter> param3 = new List<SqlParameter>();
            param3.Add(new SqlParameter("@usuario", NombreUsuario));
            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_ConsultarFuncionalidadesXUsuario", param3,"Usuarios",this.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[1].ToString() == "true")
                {
                    this.CheckedListBox.Items.Add(row[0], true);
                }
                else
                {
                    this.CheckedListBox.Items.Add(row[0], false);
                }
            }

            this.NombreUsuarioTextBox.Text = NombreUsuario;
            this.HabilitadoCheckBox.Checked = EstadoUsuario;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            int Estado;

            if (this.HabilitadoCheckBox.Checked == true)
            {
                Estado = 1;
            }
            else
            {
                Estado = 0;
            }

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@usuario", NombreUsuario));
            param.Add(new SqlParameter("@estado", Estado));
            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarHabilitadoUsuario", param, this.Text);

            List<SqlParameter> param3 = new List<SqlParameter>();
            param3.Add(new SqlParameter("@usuario", NombreUsuario));
            bool TerminoBienBorrado = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaFuncionalidadXUsuario", param3, this.Text);

            for (int i = 0; i < this.CheckedListBox.CheckedItems.Count; i++)
            {
                List<SqlParameter> param2 = new List<SqlParameter>();
                param2.Add(new SqlParameter("@usuario", this.NombreUsuarioTextBox.Text));
                param2.Add(new SqlParameter("@funcionalidad", this.CheckedListBox.CheckedItems[i].ToString()));

                BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaFuncionalidadesXUsuario", param2, this.Text);
            }

            if (TerminoBienBorrado == true && TerminoBien == true)
            {
                MessageBox.Show("Se ha modificado el usuario '" + NombreUsuarioTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            } 


        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
