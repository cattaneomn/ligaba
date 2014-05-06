﻿using System;
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

            this.TorneosComboBox.Select();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Torneo", TorneosComboBox.SelectedValue.ToString()));
            param.Add(new SqlParameter("@Categoria", CategoriasComboBox.SelectedValue.ToString()));

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarPosicionesXCategoria", param, "Posiciones", this.Text);


            if (ds.Tables["Posiciones"].Rows.Count == 0)
            {
                this.Posiciones_DataGridView.DataSource = null;
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Posiciones_DataGridView.DataSource = ds.Tables["Posiciones"];
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

            this.Posiciones_DataGridView.Focus();
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

            ModDataGridView.limpiarDataGridView(Posiciones_DataGridView, "");
        }

        private void ImprimirGoleadoresButton_Click(object sender, EventArgs e)
        {
            if (this.Posiciones_DataGridView.Rows.Count == 0)
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
