using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LigaBA.Abm_Categorias
{
    public partial class CategoriasForm : Form
    {
        public CategoriasForm()
        {
            InitializeComponent();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            AltaCategoriaForm abrir = new AltaCategoriaForm();
            abrir.ShowDialog();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (this.Categorias_DataGridView.Rows.Count == 0 )
            {
                return;
            }

            if (this.Categorias_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string CategoriaBorrada = Categorias_DataGridView.CurrentRow.Cells["Categoria"].Value.ToString();

            DialogResult Resultado = MessageBox.Show("¿Esta seguro que desea eliminar la categoria '" + CategoriaBorrada + "'?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@Id", Convert.ToString(Categorias_DataGridView.CurrentRow.Cells["id"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaCategoria", param, this.Text);

                if (TerminoBien == true)
                {
                    Categorias_DataGridView.Rows.Remove(Categorias_DataGridView.CurrentRow);
                    MessageBox.Show("Se ha dado de baja la categoria '" + CategoriaBorrada + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (this.Categorias_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Categorias_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

            ModificarCategoriaForm abrir = new ModificarCategoriaForm(this.Categorias_DataGridView.CurrentRow.Cells["id"].Value.ToString(), this.Categorias_DataGridView.CurrentRow.Cells["Categoria"].Value.ToString());
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                ModDataGridView.limpiarDataGridView(Categorias_DataGridView, "");
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();


            Categorias_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);
            

            if (Categorias_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Categorias_DataGridView.Columns["id"].Visible = false;
            this.Categorias_DataGridView.Focus();
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

            ModDataGridView.limpiarDataGridView(Categorias_DataGridView, "");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT id,nombre as Categoria FROM LigaBA.Categoria WHERE borrado=0 ";

            if (CategoriaTextBox.TextLength > 0)
            {
                Consulta += "AND nombre='" + CategoriaTextBox.Text + "'";
            }

            return Consulta;
        }

        private void CategoriasForm_Load(object sender, EventArgs e)
        {
            this.Categorias_DataGridView.MultiSelect = false;
            this.CategoriaTextBox.Select();
        }


    }
}
