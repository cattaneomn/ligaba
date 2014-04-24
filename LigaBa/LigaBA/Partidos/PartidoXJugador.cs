using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaBA.Partidos
{
    public class PartidoXJugador
    {
        public string idPartido;
        public string idJugador;
        public int goles;
        public int amarillas;
        public int rojas;

        public PartidoXJugador(string partido)
        {
            idPartido = partido;
        }

        public void CargarMisDatos()
        {

        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT Partido.id as idP,Partido.equipolocal as idLocal,Partido.equipovisitante as idVisitante,torneoxcategoria as idTorCat,TXC.categoria as idCat,";            

            /*if (TorneosComboBox.SelectedItem != null)
            {
                Consulta += " AND TG.id = " + TorneosComboBox.SelectedValue.ToString();
            }

            if (FechaComboBox.SelectedItem != null)
            {
                Consulta += " AND fecha = '" + FechaComboBox.SelectedValue.ToString() + "' ";
            }

            if (CategoriasComboBox.SelectedItem != null)
            {
                Consulta += " AND TXC.categoria = " + CategoriasComboBox.SelectedValue.ToString();
            }

            Consulta += " ORDER BY TG.nombre,idCat,fecha";*/

            return Consulta;
        }

    }
}
