﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Threading;

namespace AplicationDesktop1.Abm_Ventas
{
    public partial class VisualizarFacturaForm : Form
    {
        public VisualizarFacturaForm()
        {
            InitializeComponent();
            this.ClientesComboBox.Select();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();

            FacturaDataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (FacturaDataGridView.DataSource == null)
            {
                ModDataGridView.limpiarDataGridView(FacturaDataGridView, "Detalle");
                ModDataGridView.limpiarDataGridView(FacturaDataGridView, "Imprimir");
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModDataGridView.agregarBoton(FacturaDataGridView, "Detalle");
            ModDataGridView.agregarBoton(FacturaDataGridView, "Imprimir");
            
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.FacturaGroupBox.Controls)
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
            this.FechaDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.FechaDateTimePicker.CustomFormat = " ";
            ModDataGridView.limpiarDataGridView(FacturaDataGridView, "Detalle");
            ModDataGridView.limpiarDataGridView(FacturaDataGridView, "Imprimir");
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT numero,fecha,ingeniar.f_NombreCliente(cliente)cliente,total FROM ingeniar.Factura WHERE 1=1 ";

            if (ClientesComboBox.SelectedItem != null)
            {
                Consulta += "AND cliente = '" + ClientesComboBox.SelectedValue.ToString() + "' ";
            }

            if (NumFactTextBox.TextLength > 0)
            {
                Consulta += "AND numero = " + NumFactTextBox.Text + " ";
            }
            
            if (this.FechaDateTimePicker.Format != DateTimePickerFormat.Custom)
            {
                Consulta += "AND fecha = '" + FechaDateTimePicker.Value + "' ";
            }

            return Consulta;
        }


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacturaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.FacturaDataGridView.Columns["Detalle"].Index && e.RowIndex >= 0)
            {
                DetalleForm abrir = new DetalleForm(FacturaDataGridView.CurrentRow.Cells["numero"].Value.ToString(), Convert.ToDateTime(FacturaDataGridView.CurrentRow.Cells["fecha"].Value), FacturaDataGridView.CurrentRow.Cells["cliente"].Value.ToString(), FacturaDataGridView.CurrentRow.Cells["total"].Value.ToString());
                abrir.ShowDialog();
            }

            if (e.ColumnIndex == this.FacturaDataGridView.Columns["Imprimir"].Index && e.RowIndex >= 0)
            {
                Thread hilo = new Thread(AbrirFormReporte);
                hilo.SetApartmentState(System.Threading.ApartmentState.STA);
                hilo.Start(); 
            } 
        }

        private void AbrirFormReporte()
        {
            ReporteForm abrir = new ReporteForm(FacturaDataGridView.CurrentRow.Cells["numero"].Value.ToString(), Convert.ToDateTime(FacturaDataGridView.CurrentRow.Cells["fecha"].Value), FacturaDataGridView.CurrentRow.Cells["cliente"].Value.ToString(), FacturaDataGridView.CurrentRow.Cells["total"].Value.ToString());
            abrir.ShowDialog();
        }

        private void BajaFacturaForm_Load(object sender, EventArgs e)
        {
            CargarClientesComboBox();
            this.FechaDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.FechaDateTimePicker.CustomFormat = " ";
        }

        private void CargarClientesComboBox()
        {
            string Consulta = "SELECT codigo,razon_social FROM ingeniar.Cliente WHERE estado=1";
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            ClientesComboBox.DataSource = ds;
            ClientesComboBox.ValueMember = "codigo";
            ClientesComboBox.DisplayMember = "razon_social";
            ClientesComboBox.SelectedItem = null;

        }

        private void FechaDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            this.FechaDateTimePicker.Format = DateTimePickerFormat.Long;
        }
    }
}