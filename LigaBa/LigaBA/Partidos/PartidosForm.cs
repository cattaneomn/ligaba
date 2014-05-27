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

        string nombreTorneo;
        string nombreCategoria;
        string TorneoId;
        string CategoriaId;

        private void PartidosForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CargadorDeDatos.CargarTorneoComboBox(TorneosComboBox, this.Text);

            this.TorneosComboBox.Select();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
	            
	        if (Validaciones() == -1) return;
	            
	        string Fecha;

	        if (FechaComboBox.SelectedValue == null)
	        {
	            Fecha = "-1";
	        }
	        else
	        {
	            Fecha = FechaComboBox.Text;
	        }
 	
            List<SqlParameter> param = new List<SqlParameter>();
	        param.Add(new SqlParameter("@Torneo", TorneosComboBox.SelectedValue.ToString()));
	        param.Add(new SqlParameter("@Categoria", CategoriasComboBox.SelectedValue.ToString()));
	        param.Add(new SqlParameter("@Fecha", Fecha));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarPartidos", param, "Partidos", this.Text);


            if (ds.Tables.Count == 0)
 	        {
	            this.Partidos_DataGridView.DataSource = null;
 	            MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
 	            return;
 	        }
 	
	        Partidos_DataGridView.DataSource = ds.Tables["Partidos"];
	        Partidos_DataGridView.Columns["Resultado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;          
 	        this.Partidos_DataGridView.Columns["id"].Visible = false;
            this.Partidos_DataGridView.Columns["LocalId"].Visible = false;
            this.Partidos_DataGridView.Columns["VisitanteId"].Visible = false;
            this.Partidos_DataGridView.Columns["Local"].Width = 170;
            this.Partidos_DataGridView.Columns["Visitante"].Width = 170;
 	        this.Partidos_DataGridView.Focus();
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

            this.FechaComboBox.Enabled = false;
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

            //Buscar Tipo Torneo

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", TorneosComboBox.SelectedValue.ToString()));
            SqlParameter respuestaParametro = new SqlParameter("@respuesta", -1);
            respuestaParametro.Direction = ParameterDirection.Output;
            param.Add(respuestaParametro);

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BuscarTipoTorneo", param, this.Text);

            object respuestaSP = respuestaParametro.Value;
            int respuesta = Convert.ToInt32(respuestaSP);

            //respuesta == 1 es que torneo es Baby
            if (respuesta == 1)
            {
                nombreTorneo = TorneosComboBox.Text;
                nombreCategoria = CategoriasComboBox.Text;
                TorneoId = this.TorneosComboBox.SelectedValue.ToString();
                CategoriaId = this.CategoriasComboBox.SelectedValue.ToString();

                Thread hilo = new Thread(AbrirFormReporte);
                hilo.SetApartmentState(System.Threading.ApartmentState.STA);
                hilo.Start();
            }
            else
            {
                AbrirFormPreguntaImprimir();
            }
        }
        
      
        private void AbrirFormPreguntaImprimir()
        {
            string VisitanteId = Partidos_DataGridView.CurrentRow.Cells["VisitanteId"].Value.ToString();
            string LocalId = Partidos_DataGridView.CurrentRow.Cells["LocalId"].Value.ToString();
            string Visitante = Partidos_DataGridView.CurrentRow.Cells["Visitante"].Value.ToString();
            string Local = Partidos_DataGridView.CurrentRow.Cells["Local"].Value.ToString();
            string Fecha = Partidos_DataGridView.CurrentRow.Cells["Fecha"].Value.ToString();

            nombreTorneo = TorneosComboBox.Text;
            nombreCategoria = CategoriasComboBox.Text;
            TorneoId = this.TorneosComboBox.SelectedValue.ToString();
            CategoriaId = this.CategoriasComboBox.SelectedValue.ToString();

            PreguntaImprimirForm abrir = new PreguntaImprimirForm(LocalId, VisitanteId, Local, Visitante, Fecha,nombreTorneo, nombreCategoria,TorneoId,CategoriaId);
            abrir.ShowDialog();
        }

        private void AbrirFormReporte()
        {
            string VisitanteId = Partidos_DataGridView.CurrentRow.Cells["VisitanteId"].Value.ToString();
            string LocalId = Partidos_DataGridView.CurrentRow.Cells["LocalId"].Value.ToString();
            string Visitante = Partidos_DataGridView.CurrentRow.Cells["Visitante"].Value.ToString();
            string Local = Partidos_DataGridView.CurrentRow.Cells["Local"].Value.ToString();
            string Fecha = Partidos_DataGridView.CurrentRow.Cells["Fecha"].Value.ToString();


            ReportePartidoForm abrir = new ReportePartidoForm(LocalId,VisitanteId,Local,Visitante,nombreTorneo,nombreCategoria,Fecha,TorneoId,CategoriaId,"Baby");
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
            
            if (Partidos_DataGridView.CurrentRow.Cells["Resultado"].Value.ToString() == " - ")
            {
                MessageBox.Show("El Partido seleccionado no fue jugado todavia, no puede modificarlo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Torneo = this.TorneosComboBox.Text;
            string Categoria = this.CategoriasComboBox.Text;
            string Fecha = Partidos_DataGridView.CurrentRow.Cells["Fecha"].Value.ToString();
            string Local = Partidos_DataGridView.CurrentRow.Cells["Local"].Value.ToString();
            string Visitante = Partidos_DataGridView.CurrentRow.Cells["Visitante"].Value.ToString();
            string LocalId = Partidos_DataGridView.CurrentRow.Cells["LocalId"].Value.ToString();
            string VisitanteId = Partidos_DataGridView.CurrentRow.Cells["VisitanteId"].Value.ToString();
            string PartidoId = Partidos_DataGridView.CurrentRow.Cells["id"].Value.ToString();


            ModificarPartidoForm abrir = new ModificarPartidoForm(Torneo, Categoria, Fecha, Local, Visitante, LocalId, VisitanteId, PartidoId);
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                this.BuscarButton.PerformClick();
            }
            
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

            if (Partidos_DataGridView.CurrentRow.Cells["LocalId"].Value.ToString() == "0" || Partidos_DataGridView.CurrentRow.Cells["VisitanteId"].Value.ToString() == "0")
            {
                MessageBox.Show("El Partido no puede jugarse.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (Partidos_DataGridView.CurrentRow.Cells["Resultado"].Value.ToString() != " - ")
            {
                MessageBox.Show("El Partido seleccionado ya fue jugado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Torneo = this.TorneosComboBox.Text;
            string Categoria = this.CategoriasComboBox.Text;
            string Fecha = Partidos_DataGridView.CurrentRow.Cells["Fecha"].Value.ToString();
            string Local = Partidos_DataGridView.CurrentRow.Cells["Local"].Value.ToString();
            string Visitante = Partidos_DataGridView.CurrentRow.Cells["Visitante"].Value.ToString();
            string LocalId = Partidos_DataGridView.CurrentRow.Cells["LocalId"].Value.ToString();
            string VisitanteId = Partidos_DataGridView.CurrentRow.Cells["VisitanteId"].Value.ToString();
            string PartidoId = Partidos_DataGridView.CurrentRow.Cells["id"].Value.ToString();


            JugarPartidoForm abrir = new JugarPartidoForm(Torneo,Categoria,Fecha,Local,Visitante,LocalId,VisitanteId,PartidoId);
             DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                this.BuscarButton.PerformClick();
            }
            
        }

        private void TorneosComboBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            this.FechaComboBox.Enabled = true;
            string SeleccionadoAnterior = this.FechaComboBox.Text;
            FechaComboBox.DataSource = null;

            CargadorDeDatos.CargarFechasComboBox(FechaComboBox, this.TorneosComboBox.SelectedValue.ToString(), this.Text);

            int ultimo = Convert.ToInt32(FechaComboBox.GetItemText(FechaComboBox.Items[FechaComboBox.Items.Count - 1]));


            if (SeleccionadoAnterior != "")
            {
                if (Convert.ToInt32(SeleccionadoAnterior) <= ultimo)
                {
                    int Posicion = FechaComboBox.FindString(SeleccionadoAnterior);
                    this.FechaComboBox.SelectedIndex = Posicion;
                }
            }
	
        }

        string idTorneo;
        string nomTorneo;
        string fecha;

        private void ImprimirPosicionesButton_Click(object sender, EventArgs e)
        {
            if (TorneosComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un torneo obligatoriamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (FechaComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una fecha obligatoriamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idTorneo = TorneosComboBox.SelectedValue.ToString();
            nomTorneo = TorneosComboBox.Text;
            fecha = FechaComboBox.Text;

            Thread hilo = new Thread(AbrirFormReporteXCategoria);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }        


        private void AbrirFormReporteXCategoria()
        {
            ReporteFechaForm abrir = new ReporteFechaForm(nomTorneo, idTorneo,fecha);
            abrir.ShowDialog();
        }
    }
}
