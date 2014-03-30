using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LigaBA.Abm_Tipo_Torneo
{
    public partial class TipoTorneoForm : Form
    {
        public TipoTorneoForm()
        {
            InitializeComponent();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            AltaTipoTorneoForm abrir = new AltaTipoTorneoForm();
            abrir.ShowDialog();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (this.TipoTorneo_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.TipoTorneo_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string CategoriaBorrada = TipoTorneo_DataGridView.CurrentRow.Cells["Id"].Value.ToString();

            DialogResult Resultado = MessageBox.Show("¿Esta seguro que desea eliminar el tipo de torneo '" + CategoriaBorrada + "'?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@id", Convert.ToString(TipoTorneo_DataGridView.CurrentRow.Cells["Id"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaTipoDeTorneo", param, this.Text);

                if (TerminoBien == true)
                {
                    TipoTorneo_DataGridView.Rows.Remove(TipoTorneo_DataGridView.CurrentRow);
                    MessageBox.Show("Se ha dado de baja el tipo de torneo '" + CategoriaBorrada + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (this.TipoTorneo_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.TipoTorneo_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ModificarTipoTorneoForm abrir = new ModificarTipoTorneoForm(this.TipoTorneo_DataGridView.CurrentRow.Cells["Id"].Value.ToString(), this.TipoTorneo_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString());
            abrir.ShowDialog();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@id", this.TipoTorneoTextBox.Text));

            TipoTorneo_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (TipoTorneo_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.TipoTorneo_DataGridView.Focus();
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

            ModDataGridView.limpiarDataGridView(TipoTorneo_DataGridView, "");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT id as Id,nombre as Nombre FROM LigaBA.TipoDeTorneo ";

            if (TipoTorneoTextBox.TextLength > 0)
            {
                Consulta += "WHERE nombre LIKE'" + TipoTorneoTextBox.Text + "'";
            }

            return Consulta;
        }

        private void CategoriasForm_Load(object sender, EventArgs e)
        {
            this.TipoTorneo_DataGridView.MultiSelect = false;
            this.TipoTorneoTextBox.Select();
        }


    }
}
