﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Clases_LigaBA;
using System.Data.SqlClient;

namespace LigaBA.Partidos
{
    public partial class ModificarPartidoForm : Form
    {
        public ModificarPartidoForm(string Torneo,string Categoria,string Fecha,string Local,string Visitante,string LocalId, string VisitanteId,string PartidoId)
        {
            InitializeComponent();

            this.Torneo = Torneo;
            this.Categoria = Categoria;
            this.Fecha = Fecha;
            this.Local = Local;
            this.Visitante = Visitante;
            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
            this.PartidoId = PartidoId;
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
        string PartidoId;
        int GolesLocalAnterior;
        int GolesVisitanteAnterior;
        
        List<JugadorXPartido> jugadorXPartido = new List<JugadorXPartido>();


        private void JugarPartidoForm_Load(object sender, EventArgs e)
        {         
            this.TorneoLabel.Text = Torneo;
            this.CategoriaLabel.Text = Categoria;
            this.FechaLabel.Text = Fecha;
            this.LocalLabel.Text = Local;
            this.VisitanteLabel.Text = Visitante;

            CargarResultados();
            CargarColumnasDataGrid(Goles_DataGridView);
            CargarColumnasDataGrid(Amarillas_DataGridView);
            CargarColumnasDataGrid(Rojas_DataGridView);
            
            CargarGoles();
            CargarAmarillas();
            CargarRojas();


            this.LocalNumericUpDown.Select();
        }

        private void CargarGoles()
        {
            string Consulta =  "SELECT E.nombre as Equipo,E.id as idEquipo,J.nombre as Nombre,J.apellido as Apellido,J.dni as Dni,PJ.goles as Cantidad,PJ.jugador as IdJugador FROM LigaBA.PartidoXJugador as PJ ";
            Consulta += "JOIN LigaBA.Jugador as J ON J.id=PJ.jugador ";
            Consulta += "JOIN LigaBA.JugadorXEquipo as JE ON J.id=JE.jugador ";
            Consulta += "JOIN LigaBA.Equipo as E ON E.id=JE.equipo ";
            Consulta += "WHERE PJ.goles > 0 AND PJ.partido=" + PartidoId;

            List<SqlParameter> param = new List<SqlParameter>();

            DataTable Dt = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (Dt != null)
            {
                foreach (DataRow row in Dt.Rows)
                {
                    Goles_DataGridView.Rows.Add(row["Equipo"], row["Nombre"], row["Apellido"], row["Dni"], row["Cantidad"], row["IdJugador"], row["idEquipo"]);
                    //Agrego A coleccion o modifico
                    int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(row["IdJugador"]));
                    if (index == -1)
                    {
                        jugadorXPartido.Add(new JugadorXPartido(Convert.ToInt32(row["IdJugador"]), Convert.ToInt32(row["IdEquipo"]), Convert.ToInt32(row["Cantidad"]), 0, 0));
                    }
                    else
                    {
                        //modificar
                        jugadorXPartido[index].sumar_cantGoles(Convert.ToInt32(row["Cantidad"]));
                    }
                }
            }
         
        }

        private void CargarAmarillas()
        {
            string Consulta = "SELECT E.nombre as Equipo,E.id as idEquipo,J.nombre as Nombre,J.apellido as Apellido,J.dni as Dni,PJ.amarillas as Cantidad,PJ.jugador as IdJugador FROM LigaBA.PartidoXJugador as PJ ";
            Consulta += "JOIN LigaBA.Jugador as J ON J.id=PJ.jugador ";
            Consulta += "JOIN LigaBA.JugadorXEquipo as JE ON J.id=JE.jugador ";
            Consulta += "JOIN LigaBA.Equipo as E ON E.id=JE.equipo ";
            Consulta += "WHERE PJ.amarillas > 0 AND PJ.partido=" + PartidoId;

            List<SqlParameter> param = new List<SqlParameter>();

            DataTable Dt = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (Dt != null)
            {
                foreach (DataRow row in Dt.Rows)
                {
                    Amarillas_DataGridView.Rows.Add(row["Equipo"], row["Nombre"], row["Apellido"], row["Dni"], row["Cantidad"], row["IdJugador"], row["idEquipo"]);

                    //Agrego A coleccion o modifico
                    int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(row["IdJugador"]));
                    if (index == -1)
                    {
                        jugadorXPartido.Add(new JugadorXPartido(Convert.ToInt32(row["IdJugador"]), Convert.ToInt32(row["IdEquipo"]), 0, Convert.ToInt32(row["Cantidad"]), 0));
                    }
                    else
                    {
                        //modificar
                        jugadorXPartido[index].sumar_cantAmarillas(Convert.ToInt32(row["Cantidad"]));
                    }
                }
            }
        }

        private void CargarRojas()
        {
            string Consulta = "SELECT E.nombre as Equipo,J.nombre as Nombre,J.apellido as Apellido,J.dni as Dni,PJ.rojas as Cantidad,PJ.jugador as IdJugador,E.id as idEquipo FROM LigaBA.PartidoXJugador as PJ ";
            Consulta += "JOIN LigaBA.Jugador as J ON J.id=PJ.jugador ";
            Consulta += "JOIN LigaBA.JugadorXEquipo as JE ON J.id=JE.jugador ";
            Consulta += "JOIN LigaBA.Equipo as E ON E.id=JE.equipo ";
            Consulta += "WHERE PJ.rojas > 0 AND PJ.partido=" + PartidoId;

            List<SqlParameter> param = new List<SqlParameter>();

            DataTable Dt = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            if (Dt != null)
            {
                foreach (DataRow row in Dt.Rows)
                {
                    Rojas_DataGridView.Rows.Add(row["Equipo"], row["Nombre"], row["Apellido"], row["Dni"], row["Cantidad"], row["IdJugador"], row["idEquipo"]);

                    //Agrego A coleccion o modifico
                    int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(Convert.ToInt32(row["IdJugador"])));
                    if (index == -1)
                    {
                        jugadorXPartido.Add(new JugadorXPartido(Convert.ToInt32(row["IdJugador"]), Convert.ToInt32(row["IdEquipo"]), 0, 0, Convert.ToInt32(row["Cantidad"])));
                    }
                    else
                    {
                        //modificar
                        jugadorXPartido[index].sumar_cantRojas(Convert.ToInt32(row["Cantidad"]));
                    }

                }
            }
        }

        private void CargarResultados()
        {           
            string Consulta = "SELECT goleslocal as GolesLocal,golesvisiante as GolesVisitante FROM LigaBA.Partido WHERE id=" + PartidoId;

            List<SqlParameter> param = new List<SqlParameter>();

            DataTable Dt = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            foreach (DataRow row in Dt.Rows)
            {
                this.LocalNumericUpDown.Value = Convert.ToInt32(row["GolesLocal"]);
                this.VisitanteNumericUpDown.Value = Convert.ToInt32(row["GolesVisitante"]);
            }

            GolesLocalAnterior = Convert.ToInt32(this.LocalNumericUpDown.Value);
            GolesVisitanteAnterior = Convert.ToInt32(this.VisitanteNumericUpDown.Value);

        }


        private void CargarColumnasDataGrid(DataGridView DataGrid)
        {
            DataGrid.Columns.Add("Equipo", "Equipo");
            DataGrid.Columns.Add("Nombre", "Nombre");
            DataGrid.Columns.Add("Apellido", "Apellido");
            DataGrid.Columns.Add("Dni", "Dni");
            DataGrid.Columns.Add("Cantidad", "Cantidad");
            DataGrid.Columns.Add("IdJugador", "IdJugador");
            DataGrid.Columns.Add("IdEquipo", "IdEquipo");

            DataGrid.Columns["idJugador"].Visible = false;
            DataGrid.Columns["idEquipo"].Visible = false;
        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {

            ModificarPartido();
            
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@idPartido", PartidoId));
            param.Add(new SqlParameter("@golesLocal", this.LocalNumericUpDown.Value));
            param.Add(new SqlParameter("@golesVisitante", this.VisitanteNumericUpDown.Value));
            param.Add(new SqlParameter("@localId", LocalId));
            param.Add(new SqlParameter("@visitanteId", VisitanteId));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_JugarPartido", param, this.Text);

            if (TerminoBien == true)
            {
                InsertarPartidoXJugador();
                MessageBox.Show("Se ha modificado el partido '" + Local + "' Vs '" + Visitante + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }

        }

        private void ModificarPartido()
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@idPartido", PartidoId));
            param.Add(new SqlParameter("@golesLocal", GolesLocalAnterior));
            param.Add(new SqlParameter("@golesVisitante", GolesVisitanteAnterior));
            param.Add(new SqlParameter("@localId", LocalId));
            param.Add(new SqlParameter("@visitanteId", VisitanteId));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarPartido", param, this.Text);

            if (TerminoBien == true)
            {
                ModificarPartidoXJugador();
            }

        }

        private void ModificarPartidoXJugador()
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@idPartido", PartidoId));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarPartidoXJugador", param, this.Text);     
        }

        private void InsertarPartidoXJugador()
        {
            
            foreach (JugadorXPartido jugador in jugadorXPartido)
            {
               //MessageBox.Show("jugador:" + jugador.get_id().ToString() + "cantGoles:" + jugador.get_cantGoles().ToString() + "cantAmarillas:" + jugador.get_cantAmarillas().ToString() + " CantRojas:" + jugador.get_cantRojas().ToString());
               
               if (!(jugador.get_cantGoles() != 0 && jugador.get_cantAmarillas() != 0 && jugador.get_cantRojas() != 0))
               {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@idPartido", PartidoId));
                param.Add(new SqlParameter("@idJugador", jugador.get_id()));
                param.Add(new SqlParameter("@idEquipo", jugador.get_equipo()));
                param.Add(new SqlParameter("@cantGoles", jugador.get_cantGoles()));
                param.Add(new SqlParameter("@cantAmarillas", jugador.get_cantAmarillas()));
                param.Add(new SqlParameter("@cantRojas", jugador.get_cantRojas()));

                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaPartidoXJugador", param, this.Text);

               }
            }
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

            //modifico Coleccion
            int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(Convert.ToInt32(Goles_DataGridView.CurrentRow.Cells["idJugador"].Value)));
            //modificar
            jugadorXPartido[index].restar_cantGoles(Convert.ToInt32(Goles_DataGridView.CurrentRow.Cells["Cantidad"].Value));

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

            //modifico Coleccion
            int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(Convert.ToInt32(Amarillas_DataGridView.CurrentRow.Cells["idJugador"].Value)));
            //modificar
            jugadorXPartido[index].restar_cantAmarillas(Convert.ToInt32(Amarillas_DataGridView.CurrentRow.Cells["Cantidad"].Value));

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

            //modifico Coleccion
            int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(Convert.ToInt32(Rojas_DataGridView.CurrentRow.Cells["idJugador"].Value)));
            //modificar
            jugadorXPartido[index].restar_cantRojas(1);

            Rojas_DataGridView.Rows.Remove(Rojas_DataGridView.CurrentRow);
        }

        
        private void AgregarGolesButton_Click(object sender, EventArgs e)
        {
            JugadorGoles = new Jugador(0, "", "", "", "",0);
            AgregarJugadorForm abrir = new AgregarJugadorForm(this.LocalId,this.VisitanteId,"Goles",this.Name,PartidoId);
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
            JugadorAmarillas = new Jugador(0, "", "", "", "",0);
            AgregarJugadorForm abrir = new AgregarJugadorForm(this.LocalId, this.VisitanteId,"Amarillas",this.Name,PartidoId);
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
            JugadorRojas = new Jugador(0, "", "", "", "",0);
            AgregarJugadorForm abrir = new AgregarJugadorForm(this.LocalId, this.VisitanteId,"Rojas",this.Name,PartidoId);
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                if (!ValidacionesRojas()) { return; }

                //Agrego A coleccion o modifico
                int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(JugadorRojas.get_id()));
                if (index == -1)
                {
                    jugadorXPartido.Add(new JugadorXPartido(JugadorRojas.get_id(), JugadorRojas.get_id_equipo(), 0, 0, 1));
                }
                else
                {
                    //modificar
                    jugadorXPartido[index].sumar_cantRojas(1);
                }

               
                Rojas_DataGridView.Rows.Add(JugadorRojas.get_equipo(),JugadorRojas.get_nombre(),JugadorRojas.get_apellido(),JugadorRojas.get_dni(),"1",JugadorRojas.get_id().ToString());
            }
        }

        private void AddGolButton_Click(object sender, EventArgs e)
        {
            if (!ValidacionesGoles()) { return; }

            //Agrego A coleccion o modifico
            int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(JugadorGoles.get_id()));
            if (index == -1)
            {
                jugadorXPartido.Add(new JugadorXPartido(JugadorGoles.get_id(), JugadorGoles.get_id_equipo(), Convert.ToInt32(this.CantidadGolesTextBox.Text), 0, 0));
            }
            else
            {
                //modificar
                jugadorXPartido[index].sumar_cantGoles(Convert.ToInt32(this.CantidadGolesTextBox.Text));
            }


            Goles_DataGridView.Rows.Add(JugadorGoles.get_equipo(), JugadorGoles.get_nombre(), JugadorGoles.get_apellido(), JugadorGoles.get_dni(), this.CantidadGolesTextBox.Text, JugadorGoles.get_id().ToString());
            
            this.CantidadGolesTextBox.ReadOnly = true;
            this.CantidadGolesTextBox.Text = "Cantidad";
            this.NombreGolesTextBox.Text = "Nombre, Apellido";
        }

        private void AddAmarrillaButton_Click(object sender, EventArgs e)
        {
            if (!ValidacionesAmarrillas()) { return; }

            //Agrego A coleccion o modifico
            int index = jugadorXPartido.FindIndex(r => r.get_id().Equals(JugadorAmarillas.get_id()));
            if (index == -1)
            {
                jugadorXPartido.Add(new JugadorXPartido(JugadorAmarillas.get_id(), JugadorAmarillas.get_id_equipo(), 0, Convert.ToInt32(this.CantidadAmarillaTextBox.Text), 0));
            }
            else
            {
                //modificar
                jugadorXPartido[index].sumar_cantAmarillas(Convert.ToInt32(this.CantidadAmarillaTextBox.Text));
            }

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

           return true;
        }


    }
}
