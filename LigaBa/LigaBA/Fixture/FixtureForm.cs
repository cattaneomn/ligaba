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

namespace LigaBA.Fixture
{
    public partial class FixtureForm : Form
    {

        public FixtureForm()
        {
            InitializeComponent();
        }

        private void PartidosForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CargadorDeDatos.CargarTorneoComboBox(TorneosComboBox, this.Text);            

            this.TorneosComboBox.Select();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
	            
	        if (Validaciones() == -1) return;

            string Fecha = "";
            string Equipo = "";

            if (FechaComboBox.SelectedValue != null)
            {
                Fecha = FechaComboBox.SelectedValue.ToString();
            }

            if (EquipoComboBox.SelectedValue != null)
            {
                Equipo = EquipoComboBox.SelectedValue.ToString();
            }

            List<SqlParameter> param = new List<SqlParameter>();
	        param.Add(new SqlParameter("@Torneo", TorneosComboBox.SelectedValue.ToString()));
	        param.Add(new SqlParameter("@Categoria", CategoriasComboBox.SelectedValue.ToString()));
            param.Add(new SqlParameter("@Fecha", Fecha));
            param.Add(new SqlParameter("@Equipo", Equipo));   

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarFixture", param, "Fixture", this.Text);

            if (ds.Tables.Count == 0)
 	        {
	            this.Fixture_DataGridView.DataSource = null;
 	            MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
 	            return;
 	        }
 	
	        Fixture_DataGridView.DataSource = ds.Tables["Fixture"];
	        Fixture_DataGridView.Columns["vs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
 	        this.Fixture_DataGridView.Columns["id"].Visible = false;
            this.Fixture_DataGridView.Columns["LocalId"].Visible = false;
            this.Fixture_DataGridView.Columns["VisitanteId"].Visible = false;
 	        this.Fixture_DataGridView.Focus();
        }

        private int Validaciones()
 	    {
	            if (TorneosComboBox.SelectedValue == null)
 	            {
	                MessageBox.Show("Debe seleccionar un torneo obligatoriamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
	                return -1;
 	            }

	            if (CategoriasComboBox.SelectedValue == null)
 	            {
	                MessageBox.Show("Debe seleccionar una categoria obligatoriamente..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
	                return -1;
 	            }
                return 1;
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
            
            ModDataGridView.limpiarDataGridView(Fixture_DataGridView, "");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImprimirPartidoButton_Click(object sender, EventArgs e)
        {
            if (this.Fixture_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Fixture_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            idTorneo = TorneosComboBox.SelectedValue.ToString();
            idCategoria = CategoriasComboBox.SelectedValue.ToString();

            nombreTorneo = TorneosComboBox.Text;
            nombreCategoria = CategoriasComboBox.Text;

            fecha = FechaComboBox.Text;
            equipo = EquipoComboBox.SelectedValue != null? EquipoComboBox.SelectedValue.ToString() : "";

            Thread hilo = new Thread(AbrirFormReporte);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }

        public string idTorneo;
        public string idCategoria;
        public string fecha;
        public string equipo;

        public string nombreTorneo;
        public string nombreCategoria;


        private void AbrirFormReporte()
        {
                        
            string torneo = this.idTorneo;
            string categoria = this.idCategoria;
            string nombreT = this.nombreTorneo;
            string nombreC = this.nombreCategoria;
            string e = this.equipo;
            string f = this.fecha;
            

            ReporteFixtureForm abrir = new ReporteFixtureForm(torneo,categoria,nombreT,nombreC,e,f);
            abrir.ShowDialog();
        }


        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (this.Fixture_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Fixture_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string idPartido = Fixture_DataGridView.CurrentRow.Cells["id"].Value.ToString();
            string fecha = Fixture_DataGridView.CurrentRow.Cells["Fecha"].Value.ToString();
            string local = Fixture_DataGridView.CurrentRow.Cells["LocalId"].Value.ToString();
            string visitante = Fixture_DataGridView.CurrentRow.Cells["VisitanteId"].Value.ToString();
            
            ModificarLocaliaForm abrir = new ModificarLocaliaForm(idPartido,fecha,local,visitante);
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                this.BuscarButton.PerformClick();
            }
        }        
    
        private void TorneosComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (TorneosComboBox.SelectedValue != null)
            {
                CargadorDeDatos.CargarFechasComboBox(FechaComboBox, TorneosComboBox.SelectedValue.ToString(), this.Text);
            }
        }

        private void CategoriasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CategoriasComboBox.SelectedValue != null)
            {
                CargadorDeDatos.CargarEquipoDeCategoriaComboBox(EquipoComboBox, this.Text, CategoriasComboBox.SelectedValue.ToString());
            }
        }        
             
    }
}
