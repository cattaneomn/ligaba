using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LigaBA.Clases;
using System.Threading;

namespace LigaBA.Partidos
{
    public partial class PartidosForm : Form
    {
        public PartidosForm()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();

            Partidos_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);


            if (Partidos_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Partidos_DataGridView.Columns["id"].Visible = false;
            this.Partidos_DataGridView.Focus();
        }


        private string ArmarConsulta()
        {
            string Consulta = "SELECT id,nombre as Equipo,LigaBA.f_NombreInstitucion(institucion)Institucion,LigaBA.f_NombreCategoria(categoria)Categoria FROM LigaBA.Equipo WHERE borrado=0";

            /*
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

            */
           
            return Consulta;
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

            ModDataGridView.limpiarDataGridView(Partidos_DataGridView, "");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImprimirPartidoButton_Click(object sender, EventArgs e)
        {
            if (this.Partidos_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Partidos_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Thread hilo = new Thread(AbrirFormReporte);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }

        private void AbrirFormReporte()
        {
            string Visitante = "3";//Partidos_DataGridView.CurrentRow.Cells["Visitante"].Value.ToString();
            string Local = "1";//Partidos_DataGridView.CurrentRow.Cells["Local"].Value.ToString();


            ReportePartidoForm abrir = new ReportePartidoForm(Local,Visitante);
            abrir.ShowDialog();
        }


        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (this.Partidos_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Partidos_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           /* string Id = Equipos_DataGridView.CurrentRow.Cells["id"].Value.ToString();
            string Equipo = Equipos_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString();
            string Institucion = Equipos_DataGridView.CurrentRow.Cells["Institucion"].Value.ToString();
            string Categoria = Equipos_DataGridView.CurrentRow.Cells["Categoria"].Value.ToString();

            ModificarEquipoForm abrir = new ModificarEquipoForm(Id, Institucion, Categoria, Equipo);
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                ModDataGridView.limpiarDataGridView(Equipos_DataGridView, "");
            }*/
        }

        private void JugarButton_Click(object sender, EventArgs e)
        {
            if (this.Partidos_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Partidos_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            JugarPartidoForm abrir = new JugarPartidoForm();
            abrir.ShowDialog();
            
        }

        private void PartidosForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CargadorDeDatos.CargarTorneoComboBox(TorneosComboBox, this.Text);

            this.BuscarButton.Select();
        }
    }
}
