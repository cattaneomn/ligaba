﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Clases_LigaBA;

namespace LigaBA.Partidos
{
    public partial class JugarPartidoForm : Form
    {
        public JugarPartidoForm(string Torneo,string Categoria,string Fecha,string Local,string Visitante,string LocalId, string VisitanteId)
        {
            InitializeComponent();

            this.Torneo = Torneo;
            this.Categoria = Categoria;
            this.Fecha = Fecha;
            this.Local = Local;
            this.Visitante = Visitante;
            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
        }
       
        public static Jugador JugadorGoles;
        public static Jugador JugadorAmarillas;
        public static Jugador JugadorRojas;
        string Torneo;
        string Categoria;
        string Fecha;
        string Local;
        string Visitante;
        string LocalId;
        string VisitanteId;

        private void JugarPartidoForm_Load(object sender, EventArgs e)
        {
            this.TorneoLabel.Text = Torneo;
            this.CategoriaLabel.Text = Categoria;
            this.FechaLabel.Text = Fecha;
            this.LocalLabel.Text = Local;
            this.VisitanteLabel.Text = Visitante;

            CargarColumnasDataGrid(Goles_DataGridView);
            CargarColumnasDataGrid(Amarillas_DataGridView);
            CargarColumnasDataGrid(Rojas_DataGridView);

            this.LocalNumericUpDown.Select();
        }

        private void CargarColumnasDataGrid(DataGridView DataGrid)
        {
            DataGrid.Columns.Add("Equipo", "Equipo");
            DataGrid.Columns.Add("Nombre", "Nombre");
            DataGrid.Columns.Add("Apellido", "Apellido");
            DataGrid.Columns.Add("Dni", "Dni");
            DataGrid.Columns.Add("Cantidad", "Cantidad");
            DataGrid.Columns.Add("IdJugador", "IdJugador");

            DataGrid.Columns["idJugador"].Visible = false;
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EliminarGolesButton_Click(object sender, EventArgs e)
        {
            if (this.Goles_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Goles_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Goles_DataGridView.Rows.Remove(Goles_DataGridView.CurrentRow);
        }

        private void EliminarAmarillasButton_Click(object sender, EventArgs e)
        {
            if (this.Amarillas_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Amarillas_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Amarillas_DataGridView.Rows.Remove(Amarillas_DataGridView.CurrentRow);
        }

        private void EliminarRojasButton_Click(object sender, EventArgs e)
        {
            if (this.Rojas_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Rojas_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rojas_DataGridView.Rows.Remove(Rojas_DataGridView.CurrentRow);
        }

        
        private void AgregarGolesButton_Click(object sender, EventArgs e)
        {
            JugadorGoles = new Jugador(0, "", "", "", "");
            AgregarJugadorForm abrir = new AgregarJugadorForm(this.LocalId,this.VisitanteId,"Goles");
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                this.CantidadGolesTextBox.ReadOnly = false;
                this.NombreGolesTextBox.Text = JugadorGoles.get_nombre() + ", " + JugadorGoles.get_apellido();
                this.CantidadGolesTextBox.Text = "1";
                this.AddGolButton.Select();
            }
        }

       

        private void AgregarAmarillasButton_Click(object sender, EventArgs e)
        {
            JugadorAmarillas = new Jugador(0, "", "", "", "");
            AgregarJugadorForm abrir = new AgregarJugadorForm(this.LocalId, this.VisitanteId,"Amarillas");
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                this.CantidadAmarillaTextBox.ReadOnly = false;
                this.NombreAmarillaTextBox.Text = JugadorAmarillas.get_nombre() + ", " + JugadorAmarillas.get_apellido();
                this.CantidadAmarillaTextBox.Text = "1";
                this.AddAmarrillaButton.Select();
            }
        }

        private void AgregarRojasButton_Click(object sender, EventArgs e)
        {
            JugadorRojas = new Jugador(0, "", "", "", "");
            AgregarJugadorForm abrir = new AgregarJugadorForm(this.LocalId, this.VisitanteId,"Rojas");
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
               

                Rojas_DataGridView.Rows.Add(JugadorRojas.get_equipo(),JugadorRojas.get_nombre(),JugadorRojas.get_apellido(),JugadorRojas.get_dni(),"1",JugadorRojas.get_id().ToString());
            }
        }

        private void AddGolButton_Click(object sender, EventArgs e)
        {
            if (!ValidacionesGoles()) { return; }

            Goles_DataGridView.Rows.Add(JugadorGoles.get_equipo(), JugadorGoles.get_nombre(), JugadorGoles.get_apellido(), JugadorGoles.get_dni(), this.CantidadGolesTextBox.Text, JugadorGoles.get_id().ToString());
            
            this.CantidadGolesTextBox.ReadOnly = true;
            this.CantidadGolesTextBox.Text = "Cantidad";
            this.NombreGolesTextBox.Text = "Nombre, Apellido";
        }

        private void AddAmarrillaButton_Click(object sender, EventArgs e)
        {
            if (!ValidacionesAmarrillas()) { return; }

            Amarillas_DataGridView.Rows.Add(JugadorAmarillas.get_equipo(), JugadorAmarillas.get_nombre(), JugadorAmarillas.get_apellido(), JugadorAmarillas.get_dni(), this.CantidadAmarillaTextBox.Text, JugadorAmarillas.get_id().ToString());
            this.CantidadAmarillaTextBox.ReadOnly = true;
            this.CantidadAmarillaTextBox.Text = "Cantidad";
            this.NombreAmarillaTextBox.Text = "Nombre, Apellido";
        }


        private bool ValidacionesAmarrillas()
        {
            if (this.NombreAmarillaTextBox.Text == "Nombre, Apellido" && this.CantidadAmarillaTextBox.Text == "Cantidad")
            {
                return false;
            }
            //Solo numeros
            int v;
            if (!Int32.TryParse(this.CantidadAmarillaTextBox.Text.Trim(), out v))
            {
                MessageBox.Show("Error: La cantidad solo puede ser numerica.");
                return false;
            }

            if (Convert.ToInt32(CantidadAmarillaTextBox.Text) < 1)
            {
                MessageBox.Show("Error: La cantidad de tarjetas amarillas debe ser mayor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToInt32(CantidadAmarillaTextBox.Text) > 2)
            {
                MessageBox.Show("Error: No se le puede asignar mas de 2(dos) tarjetas amarillas a un jugador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            int cantidad = 0;

            foreach (DataGridViewRow row in this.Amarillas_DataGridView.Rows)
            {
                if (row.Cells["IdJugador"].Value.ToString() == JugadorAmarillas.get_id().ToString())
                {
                    cantidad = cantidad + Convert.ToInt32(row.Cells["Cantidad"].Value);
                    if (cantidad >= 2)
                    {
                        MessageBox.Show("Error: El jugador ya posee 2(dos) tarjetas amarillas, no se le puede asignar mas de 2(dos) tarjetas amarillas a un jugador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (cantidad == 1 && Convert.ToInt32(this.CantidadAmarillaTextBox.Text) == 2)
                    {
                        MessageBox.Show("Error: El jugador ya posee 1(uno) tarjeta amarilla, no se le puede asignar mas de 2(dos) tarjetas amarillas a un jugador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                }
            }

            return true;
        }

        private bool ValidacionesGoles()
        {
            if (this.NombreGolesTextBox.Text == "Nombre, Apellido" && this.CantidadGolesTextBox.Text == "Cantidad")
            {
                return false;
            }
            //Solo numeros
            int v;
            if (!Int32.TryParse(this.CantidadGolesTextBox.Text.Trim(), out v))
            {
                MessageBox.Show("Error: La cantidad solo puede ser numerica.");
                return false;
            }
            if (Convert.ToInt32(CantidadGolesTextBox.Text) < 1)
            {
                MessageBox.Show("Error: La cantidad de goles debe ser mayor a cero.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private bool ValidacionesRojas()
        {
            //Controlar que ya no este
            foreach (DataGridViewRow row in this.Rojas_DataGridView.Rows)
            {
                if (row.Cells["IdJugador"].Value.ToString() == JugadorRojas.get_id().ToString())
                {
                    MessageBox.Show("Error: El jugador '" + JugadorRojas.get_nombre() + ", " + JugadorRojas.get_apellido() + "' ya se encuntra expulsado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            false true;
        }


    }
}
