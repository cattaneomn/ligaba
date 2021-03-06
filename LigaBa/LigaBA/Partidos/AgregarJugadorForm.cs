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
using LigaBA.Clases_LigaBA;

namespace LigaBA.Partidos
{
    public partial class AgregarJugadorForm : Form
    {
        public AgregarJugadorForm(string LocalId, string VisitanteId,string ButtonType,string NombreForm,string idPartido)
        {
            InitializeComponent();

            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
            this.ButtonType = ButtonType;
            this.NombreForm = NombreForm;
            this.idPartido = idPartido;
        }

        string LocalId;
        string VisitanteId;
        string ButtonType;
        string NombreForm;
        string idPartido;

        private void AgregarJugadorForm_Load(object sender, EventArgs e)
        {
            //SOLO JUGADORES HABILITADOS Y QUE NO ESTEN BORRADOS.
            string Consulta = "SELECT J.id,E.id as idEquipo,E.nombre as Equipo,J.nombre as Nombre,J.apellido as Apellido,J.dni as Dni,TCJ.habilitado as Habilitado FROM ligaBA.JugadorXEquipo as JE ";
                  Consulta += "JOIN LigaBA.Jugador as J ON J.id = JE.jugador ";
                  Consulta += "JOIN LigaBA.Equipo as E ON E.id = JE.equipo ";
                  Consulta += "JOIN LigaBA.TorneoXCategoriaXJugador as TCJ ON TCJ.jugador = JE.jugador "; 
                  Consulta += "WHERE (E.id=" + LocalId + " OR E.id=" + VisitanteId + ") AND J.borrado=0 AND J.habilitado=1 AND TCJ.torneoxcategoria=(SELECT torneoxcategoria FROM ligaBA.Partido WHERE id=" + idPartido + ")";

            List<SqlParameter> param = new List<SqlParameter>();

            Jugadores_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (Jugadores_DataGridView.DataSource != null)
            {
                this.Jugadores_DataGridView.Columns["id"].Visible = false;
                this.Jugadores_DataGridView.Columns["idEquipo"].Visible = false;
                ModDataGridView.agregarBoton(Jugadores_DataGridView, "Seleccionar");
                this.ApellidoTextBox.Select();
            }
        }

        private string FiltroCambios()
        {
            string consulta = "";

            if (this.ApellidoTextBox.Text != "")
            {
                consulta += "Apellido LIKE '%" + this.ApellidoTextBox.Text + "%'";
            }

            if (this.DniTextBox.Text != "")
            {
                if (consulta != "") { consulta += " AND "; }
                consulta += "Dni = '" + this.DniTextBox.Text + "'";
            }

            if (this.EquipoTextBox.Text != "")
            {
                if (consulta != "") { consulta += " AND "; }
                consulta += "Equipo LIKE '%" + this.EquipoTextBox.Text + "%'";
            }
            return consulta;
        }

        private void Filtrar()
        {
            ((DataTable)Jugadores_DataGridView.DataSource).DefaultView.RowFilter = FiltroCambios();
        }


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void ApellidoTextBox_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void DniTextBox_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Jugadores_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.Jugadores_DataGridView.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                if (Jugadores_DataGridView.CurrentRow.Cells["Habilitado"].Value.ToString() == "False")
                {
                    MessageBox.Show("El Jugador no se puede seleccionar por que no esta habilitado para jugar por acumulacion de tarjetas amarillas o expulsión.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (NombreForm == "JugarPartidoForm")
                {
                    JugarPartido();
                }
                else
                {
                    ModificarPartido();
                }

                DialogResult = DialogResult.OK;
            }

        }

        private void JugarPartido()
        {
            if (ButtonType == "Goles")
            {
                JugarPartidoForm.JugadorGoles.set_nombre(Jugadores_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString());
                JugarPartidoForm.JugadorGoles.set_apellido(Jugadores_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString());
                JugarPartidoForm.JugadorGoles.set_dni(Jugadores_DataGridView.CurrentRow.Cells["Dni"].Value.ToString());
                JugarPartidoForm.JugadorGoles.set_equipo(Jugadores_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString());
                JugarPartidoForm.JugadorGoles.set_id(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["id"].Value.ToString()));
                JugarPartidoForm.JugadorGoles.set_id_equipo(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["idEquipo"].Value.ToString()));
            }
            if (ButtonType == "Amarillas")
            {
                JugarPartidoForm.JugadorAmarillas.set_nombre(Jugadores_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString());
                JugarPartidoForm.JugadorAmarillas.set_apellido(Jugadores_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString());
                JugarPartidoForm.JugadorAmarillas.set_dni(Jugadores_DataGridView.CurrentRow.Cells["Dni"].Value.ToString());
                JugarPartidoForm.JugadorAmarillas.set_equipo(Jugadores_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString());
                JugarPartidoForm.JugadorAmarillas.set_id(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["id"].Value.ToString()));
                JugarPartidoForm.JugadorAmarillas.set_id_equipo(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["idEquipo"].Value.ToString()));
            }
            if (ButtonType == "Rojas")
            {
                JugarPartidoForm.JugadorRojas.set_nombre(Jugadores_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString());
                JugarPartidoForm.JugadorRojas.set_apellido(Jugadores_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString());
                JugarPartidoForm.JugadorRojas.set_dni(Jugadores_DataGridView.CurrentRow.Cells["Dni"].Value.ToString());
                JugarPartidoForm.JugadorRojas.set_equipo(Jugadores_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString());
                JugarPartidoForm.JugadorRojas.set_id(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["id"].Value.ToString()));
                JugarPartidoForm.JugadorRojas.set_id_equipo(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["idEquipo"].Value.ToString()));
            }
        }


        private void ModificarPartido()
        {
            if (ButtonType == "Goles")
            {
                ModificarPartidoForm.JugadorGoles.set_nombre(Jugadores_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString());
                ModificarPartidoForm.JugadorGoles.set_apellido(Jugadores_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString());
                ModificarPartidoForm.JugadorGoles.set_dni(Jugadores_DataGridView.CurrentRow.Cells["Dni"].Value.ToString());
                ModificarPartidoForm.JugadorGoles.set_equipo(Jugadores_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString());
                ModificarPartidoForm.JugadorGoles.set_id(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["id"].Value.ToString()));
                ModificarPartidoForm.JugadorGoles.set_id_equipo(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["idEquipo"].Value.ToString()));
            }
            if (ButtonType == "Amarillas")
            {
                ModificarPartidoForm.JugadorAmarillas.set_nombre(Jugadores_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString());
                ModificarPartidoForm.JugadorAmarillas.set_apellido(Jugadores_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString());
                ModificarPartidoForm.JugadorAmarillas.set_dni(Jugadores_DataGridView.CurrentRow.Cells["Dni"].Value.ToString());
                ModificarPartidoForm.JugadorAmarillas.set_equipo(Jugadores_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString());
                ModificarPartidoForm.JugadorAmarillas.set_id(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["id"].Value.ToString()));
                ModificarPartidoForm.JugadorAmarillas.set_id_equipo(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["idEquipo"].Value.ToString()));
            }
            if (ButtonType == "Rojas")
            {
                ModificarPartidoForm.JugadorRojas.set_nombre(Jugadores_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString());
                ModificarPartidoForm.JugadorRojas.set_apellido(Jugadores_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString());
                ModificarPartidoForm.JugadorRojas.set_dni(Jugadores_DataGridView.CurrentRow.Cells["Dni"].Value.ToString());
                ModificarPartidoForm.JugadorRojas.set_equipo(Jugadores_DataGridView.CurrentRow.Cells["Equipo"].Value.ToString());
                ModificarPartidoForm.JugadorRojas.set_id(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["id"].Value.ToString()));
                ModificarPartidoForm.JugadorRojas.set_id_equipo(Convert.ToInt32(Jugadores_DataGridView.CurrentRow.Cells["idEquipo"].Value.ToString()));
            }

        }
        
    
    }
}
