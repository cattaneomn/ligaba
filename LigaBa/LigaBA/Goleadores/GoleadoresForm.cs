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

namespace LigaBA.Goleadores
{
    public partial class GoleadoresForm : Form
    {
        public GoleadoresForm()
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

            this.TorneosComboBox.Select();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", TorneosComboBox.SelectedValue.ToString()));
            param.Add(new SqlParameter("@Categoria", CategoriasComboBox.SelectedValue.ToString()));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarGoleadores", param, "Goleadores", this.Text);


            if (ds.Tables["Goleadores"].Rows.Count == 0)
            {
                this.Goleadores_DataGridView.DataSource = null;
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Goleadores_DataGridView.DataSource = ds.Tables["Goleadores"];
            this.Goleadores_DataGridView.Focus();
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

            ModDataGridView.limpiarDataGridView(Goleadores_DataGridView, "");
        }

        private void ImprimirGoleadoresButton_Click(object sender, EventArgs e)
        {
            if (this.Goleadores_DataGridView.Rows.Count == 0)
            {
                return;
            }

            idTorneo = TorneosComboBox.SelectedValue.ToString();
            idCategoria = CategoriasComboBox.SelectedValue.ToString();

            nombreTorneo = TorneosComboBox.Text;
            nombreCategoria = CategoriasComboBox.Text;

            Thread hilo = new Thread(AbrirFormReporte);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }

        private void AbrirFormReporte()
        {
            ReporteGoleadoresForm abrir = new ReporteGoleadoresForm(idTorneo,idCategoria,nombreTorneo,nombreCategoria);
            abrir.ShowDialog();
        }









    }
}
