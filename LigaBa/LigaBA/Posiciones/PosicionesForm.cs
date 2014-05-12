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

namespace LigaBA.Posiciones
{
    public partial class PosicionesForm : Form
    {
        public PosicionesForm()
        {
            InitializeComponent();
        }

        string idTorneo;
        string idCategoria;
        string nombreTorneo;
        string nombreCategoria;

        private void GoleadoresForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CargadorDeDatos.CargarTorneoComboBox(TorneosComboBox, this.Text);

            this.PosicionesCategoriaRadioButton.Checked = true;

            this.TorneosComboBox.Select();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            DataSet ds;

            if (this.PosicionesCategoriaRadioButton.Checked)
            {
                ds = BuscarPosicionesXCategoria();
            }
            else
            {
                ds = BuscarPosicionesGeneral();
            }

            if (ds.Tables["Posiciones"].Rows.Count == 0)
            {
                this.Posiciones_DataGridView.DataSource = null;
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Posiciones_DataGridView.DataSource = ds.Tables["Posiciones"];

            if (this.PosicionesCategoriaRadioButton.Checked)
            {
                CustomDataGridView();
            }
            else
            {
                CustomGeneralDataGridView();
            }
            this.Posiciones_DataGridView.Focus();
        }

        private DataSet BuscarPosicionesXCategoria()
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", TorneosComboBox.SelectedValue.ToString()));
            param.Add(new SqlParameter("@Categoria", CategoriasComboBox.SelectedValue.ToString()));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarPosicionesXCategoria", param, "Posiciones", this.Text);

            return ds;
        }

        private DataSet BuscarPosicionesGeneral()
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", TorneosComboBox.SelectedValue.ToString()));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarPosicionesGeneral", param, "Posiciones", this.Text);

            return ds;
        }


        private void CustomDataGridView()
        {
            this.Posiciones_DataGridView.Columns["Pos"].Width = 50;
            this.Posiciones_DataGridView.Columns["Equipo"].Width = 140;
            this.Posiciones_DataGridView.Columns["PJ"].Width = 50;
            this.Posiciones_DataGridView.Columns["PG"].Width = 50;
            this.Posiciones_DataGridView.Columns["PE"].Width = 50;
            this.Posiciones_DataGridView.Columns["PP"].Width = 50;
            this.Posiciones_DataGridView.Columns["GF"].Width = 50;
            this.Posiciones_DataGridView.Columns["GC"].Width = 50;
            this.Posiciones_DataGridView.Columns["Puntos"].Width = 60;
            Posiciones_DataGridView.Columns["Pos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Posiciones_DataGridView.Columns["PJ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Posiciones_DataGridView.Columns["PG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Posiciones_DataGridView.Columns["PE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Posiciones_DataGridView.Columns["PP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Posiciones_DataGridView.Columns["GF"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Posiciones_DataGridView.Columns["GC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Posiciones_DataGridView.Columns["Puntos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
        }

        private void CustomGeneralDataGridView()
        {
            this.Posiciones_DataGridView.Columns["Pos"].Width = 50;
            this.Posiciones_DataGridView.Columns["Institucion"].Width = 140;           
            this.Posiciones_DataGridView.Columns["Puntos"].Width = 60;

            Posiciones_DataGridView.Columns["Pos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           
            Posiciones_DataGridView.Columns["Puntos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private int Validaciones()
        {
            if (TorneosComboBox.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un torneo obligatoriamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            if (CategoriasComboBox.SelectedValue == null && CategoriasComboBox.Enabled)
            {
                MessageBox.Show("Debe seleccionar una categoria obligatoriamente..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            return 1;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

            ModDataGridView.limpiarDataGridView(Posiciones_DataGridView, "");
        }

        private void ImprimirGoleadoresButton_Click(object sender, EventArgs e)
        {
            if (this.Posiciones_DataGridView.Rows.Count == 0)
            {
                return;
            }

            idTorneo = TorneosComboBox.SelectedValue.ToString();
           

            nombreTorneo = TorneosComboBox.Text;
            nombreCategoria = CategoriasComboBox.Text;

            if (this.PosicionesCategoriaRadioButton.Checked)
            {
                idCategoria = CategoriasComboBox.SelectedValue.ToString();

                Thread hilo = new Thread(AbrirFormReporteXCategoria);
                hilo.SetApartmentState(System.Threading.ApartmentState.STA);
                hilo.Start();
            }
            else
            {
                Thread hilo = new Thread(AbrirFormReporteGeneral);
                hilo.SetApartmentState(System.Threading.ApartmentState.STA);
                hilo.Start();
            }

            
        }

        private void AbrirFormReporteXCategoria()
        {
            ReportePosicionesForm abrir = new ReportePosicionesForm(idTorneo,idCategoria,nombreTorneo,nombreCategoria,(DataTable)this.Posiciones_DataGridView.DataSource,"");
            abrir.ShowDialog();
        }

        private void AbrirFormReporteGeneral()
        {
            ReportePosicionesForm abrir = new ReportePosicionesForm(idTorneo, idCategoria, nombreTorneo, nombreCategoria, (DataTable)this.Posiciones_DataGridView.DataSource, "General");
            abrir.ShowDialog();
        }

        private void PosicionesGeneralRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.CategoriasComboBox.Enabled = false;
            this.Posiciones_DataGridView.DataSource = null;
            this.CategoriasComboBox.DataSource = null;
            //cargotorneos que tienen tabla general
            CargadorDeDatos.CargarTorneoGeneralComboBox(TorneosComboBox, this.Text);
        }

        private void PosicionesCategoriaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.CategoriasComboBox.Enabled = true;
            this.Posiciones_DataGridView.DataSource = null;
            CargadorDeDatos.CargarTorneoComboBox(TorneosComboBox, this.Text);
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
        }









    }
}
