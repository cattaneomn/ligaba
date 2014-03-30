using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Clases;
using System.Data.SqlClient;

namespace LigaBA.Abm_Equipos
{
    public partial class EquiposForm : Form
    {
        public EquiposForm()
        {
            InitializeComponent();
        }

        private void EquiposForm_Load(object sender, EventArgs e)
        {
            this.Equipos_DataGridView.MultiSelect = false;
            this.NombreTextBox.Select();
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CargadorDeDatos.CargarInstitucionComboBox(InstitucionComboBox, this.Text);
        }


        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.GroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
                if (objeto is ComboBox)
                {
                    ((ComboBox)objeto).SelectedItem = null;
                }
            }

            ModDataGridView.limpiarDataGridView(Equipos_DataGridView, "");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();

            Equipos_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);


            if (Equipos_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Equipos_DataGridView.Columns["id"].Visible = false;
            this.Equipos_DataGridView.Focus();
        }


        private string ArmarConsulta()
        {
            string Consulta = "SELECT id,nombre as Equipo,LigaBA.f_NombreInstitucion(institucion)Institucion,LigaBA.f_NombreCategoria(categoria)Categoria FROM LigaBA.Equipo WHERE borrado=0";

            if (NombreTextBox.TextLength > 0)
            {
                Consulta += "AND nombre LIKE '%" + NombreTextBox.Text + "%' ";
            }

            if (InstitucionComboBox.SelectedItem != null)
            {
                Consulta += "AND institucion= '" + InstitucionComboBox.SelectedValue.ToString() + "' ";
            }

            if (CategoriasComboBox.SelectedItem != null)
            {
                Consulta += "AND categoria='" + CategoriasComboBox.SelectedValue.ToString() + "' ";
            }


            return Consulta;
        }


        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (this.Equipos_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Equipos_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string Id = Equipos_DataGridView.CurrentRow.Cells["id"].Value.ToString();
            string Equipo = Equipos_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString();
            string Institucion = Equipos_DataGridView.CurrentRow.Cells["Institucion"].Value.ToString();
            string Categoria = Equipos_DataGridView.CurrentRow.Cells["Categoria"].Value.ToString();

            ModificarEquipoForm abrir = new ModificarEquipoForm(Id,Institucion,Categoria,Equipo);
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                ModDataGridView.limpiarDataGridView(Equipos_DataGridView, "");
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (this.Equipos_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Equipos_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string EquipoBorrado = Equipos_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString();
            string Categoria = Equipos_DataGridView.CurrentRow.Cells["Categoria"].Value.ToString();

            DialogResult Resultado = MessageBox.Show("¿Esta seguro que desea eliminar el equipo '" + EquipoBorrado + "'" + " categoria '" + Categoria + "'?, con el se borraran todos sus jugadores.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@id", Convert.ToString(Equipos_DataGridView.CurrentRow.Cells["id"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaEquipo", param, this.Text);

                if (TerminoBien == true)
                {
                    Equipos_DataGridView.Rows.Remove(Equipos_DataGridView.CurrentRow);
                    MessageBox.Show("Se ha dado de baja el equipo '" + EquipoBorrado + "'" + " categoria '" + Categoria + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            AltaEquipoForm abrir = new AltaEquipoForm();
            abrir.ShowDialog();
        }


    }
}
