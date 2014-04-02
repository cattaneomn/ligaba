﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Clases;
using System.Data.SqlClient;

namespace LigaBA.Abm_Torneo
{
    public partial class TorneosForm : Form
    {
        public TorneosForm()
        {
            InitializeComponent();
        }

     

        private void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();

            Torneos_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);


            if (Torneos_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Torneos_DataGridView.Columns["TipoDeTablaGeneral"].Width = 250;
            this.Torneos_DataGridView.Columns["id"].Visible = false;
            this.Torneos_DataGridView.Columns["idTC"].Visible = false;
            this.Torneos_DataGridView.Focus();
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT T.id as id,TC.id as idTC,T.nombre as Nombre,TT.nombre as TipoDeTorneo,T.tablageneral as TablaGeneral,T.tipodetablageneral as TipoDeTablaGeneral,C.nombre as Categoria FROM LigaBA.Torneo as T ";
            Consulta += "INNER JOIN LigaBA.TipoDeTorneo as TT ON T.tipodetorneo = TT.id ";
            Consulta += "INNER JOIN LigaBA.TorneoXCategoria as TC ON T.id = TC.torneogeneral  ";
            Consulta += "INNER JOIN LigaBA.Categoria as C ON c.id = TC.categoria WHERE 1=1 "; 

            if (NombreTextBox.TextLength > 0)
            {
                Consulta += "AND T.nombre LIKE '%" + NombreTextBox.Text + "%' ";
            }
            if (CategoriasComboBox.SelectedValue != null)
            {
                Consulta += "AND  TC.categoria =" + CategoriasComboBox.SelectedValue.ToString();
            }

            if (TipoTorneoComboBox.SelectedValue != null)
            {
                Consulta += "AND  TT.id =" + TipoTorneoComboBox.SelectedValue.ToString();
            }

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

            ModDataGridView.limpiarDataGridView(Torneos_DataGridView, "");
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TorneosForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarTipoTorneoComboBox(TipoTorneoComboBox, this.Text);
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            this.NombreTextBox.Select();
        }

        private void AgregarButton_Click_1(object sender, EventArgs e)
        {
            AltaTorneoForm abrir = new AltaTorneoForm();
            abrir.ShowDialog();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (this.Torneos_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Torneos_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string id = Torneos_DataGridView.CurrentRow.Cells["idTC"].Value.ToString();

            ExaminarTorneoForm abrir = new ExaminarTorneoForm(id);
            abrir.ShowDialog();
        }
    }
}
