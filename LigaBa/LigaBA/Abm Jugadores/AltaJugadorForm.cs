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
using System.Security.Cryptography;

using LigaBA.Clases;

namespace LigaBA.Abm_Jugador
{
    public partial class AltaJugadorForm : Form
    {
        private string institucion;
        private string categoria;

        public AltaJugadorForm()
        {
            InitializeComponent();
           
        }

        private void AltaJugadorForm_Load(object sender, EventArgs e)
        {
            CargarInstitucionesComboBox();
            CargarCategoriaComboBox();


        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {            
            foreach (Control objeto in this.JugadorGroupBox.Controls)
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

            this.EquipoComboBox.DataSource = null;
            this.EquipoComboBox.Enabled = false;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@dni", this.DniTextBox.Text));
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@apellido", this.ApellidoTextBox.Text));
            param.Add(new SqlParameter("@fecha_de_nacimiento", this.FechaNacimeintiDateTimePicker.Value));
            param.Add(new SqlParameter("@equipo", this.EquipoComboBox.SelectedValue.ToString()));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaJugador", param,this.Text);

            string Nombre = NombreTextBox.Text + " " + ApellidoTextBox.Text;

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha dado de alta el jugador '" + Nombre + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarButton.PerformClick();
                this.InstitucionComboBox.Focus();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al dar de alta el jugador '" + Nombre + "'.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private int Validaciones()
        {
            foreach (Control objeto in this.JugadorGroupBox.Controls)
            {
                if (objeto is TextBox && ((TextBox)objeto).Text == "")
                {
                    MessageBox.Show("Debe completar los campos vacios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
                if (objeto is ComboBox && ((ComboBox)objeto).SelectedValue == null)
                {
                    MessageBox.Show("Debe completar los campos vacios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }

            //Solo numeros
            int v;
            if (!Int32.TryParse(this.DniTextBox.Text.Trim(), out v))
            {
                MessageBox.Show("Error: El Dni solo acepta datos numericos.");
                return -1;
            }

            return 1;
        }


        private void CargarEquiposComboBox()
        {
            if (institucion != null && categoria != null)
            {
                CargadorDeDatos.CargarEquipoComboBox(EquipoComboBox, this.Text, institucion, categoria);
                this.EquipoComboBox.Enabled = true;
            }
            else
            {
                this.EquipoComboBox.Enabled = false;
            }
        }

        private void CargarInstitucionesComboBox()
        {
            CargadorDeDatos.CargarInstitucionComboBox(InstitucionComboBox, this.Text);
        }

        private void CargarCategoriaComboBox()
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
        }

        private void InstitucionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ControlarComboBoxNull();
            CargarEquiposComboBox();
        }

        private void CategoriasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ControlarComboBoxNull();
            CargarEquiposComboBox();
        }


        private void ControlarComboBoxNull()
        {
            if (InstitucionComboBox.SelectedItem != null)
            {
                this.institucion = InstitucionComboBox.SelectedValue.ToString();
            }
            else
            {
                this.institucion = null;
            }

            if (CategoriasComboBox.SelectedItem != null)
            {
                this.categoria = CategoriasComboBox.SelectedValue.ToString();
            }
            else
            {
                this.categoria = null;
            }
        }
    }
}
