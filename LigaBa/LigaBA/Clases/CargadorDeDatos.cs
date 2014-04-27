using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LigaBA.Clases
{
    class CargadorDeDatos
    {

        public static void CargarComboBox(string consulta,List<SqlParameter> param,ComboBox comboBox,string texto,string campoValor,string campoDato)
        {            
            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(consulta, param, texto);

            comboBox.DataSource = ds;
            comboBox.ValueMember = campoValor;
            comboBox.DisplayMember = campoDato;
            comboBox.SelectedItem = null;           
        }

        public static void CargarCheckedListBox(string consulta, List<SqlParameter> param, CheckedListBox checkedListBox, string texto, string campoValor, string campoDato)
        {
            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(consulta, param, texto);

            checkedListBox.DataSource = ds;
            checkedListBox.ValueMember = campoValor;
            checkedListBox.DisplayMember = campoDato;
            checkedListBox.SelectedItem = null; 
        }

        public static void CargarTipoTorneoComboBox(ComboBox comboBox, string txt)
        {
            CargadorDeDatos.CargarComboBox("select id,nombre from LigaBA.TipoDeTorneo", new List<SqlParameter>(), comboBox, txt, "id", "nombre");
        }

        //Cargas de COMBO BOX Especificos
        public static void CargarCategoriaComboBox(ComboBox comboBox,string txt)
        {
            CargadorDeDatos.CargarComboBox("select id,nombre from LigaBA.Categoria WHERE borrado=0", new List<SqlParameter>(), comboBox,txt, "id", "nombre");
        }

        public static void CargarInstitucionComboBox(ComboBox comboBox, string txt)
        {
            CargadorDeDatos.CargarComboBox("select id,nombre from LigaBA.Institucion WHERE borrado=0", new List<SqlParameter>(), comboBox, txt, "id", "nombre");
        }

        public static void CargarFechasComboBox(ComboBox comboBox, string torneo, string txt)
        {
            CargadorDeDatos.CargarComboBox("select distinct fecha as id, fecha from LigaBA.Partido WHERE torneoxcategoria = (select TOP 1 id  from LigaBA.TorneoXCategoria WHERE torneogeneral=" + torneo + ")", new List<SqlParameter>(), comboBox, txt, "id", "fecha");
        }

        public static void CargarEquipoComboBox(ComboBox comboBox, string txt,string institucion ,string categoria)
        {
            int Num;

            if (int.TryParse(institucion, out Num) && int.TryParse(categoria, out Num))
            {
                CargadorDeDatos.CargarComboBox("select id,nombre from LigaBA.Equipo WHERE borrado = '0' AND institucion = " + institucion + " AND categoria = " + categoria, new List<SqlParameter>(), comboBox, txt, "id", "nombre");
            }
        }

        public static void CargarEquipoDeCategoriaComboBox(ComboBox comboBox, string txt, string categoria)
        {
            int Num;

            if (int.TryParse(categoria, out Num))
            {
                CargadorDeDatos.CargarComboBox("select id,nombre from LigaBA.Equipo WHERE borrado = '0' AND categoria = " + categoria, new List<SqlParameter>(), comboBox, txt, "id", "nombre");
            }
        }

        public static void CargarEquipoPartidoComboBox(ComboBox comboBox, string txt, string partido)
        {
            int Num;

            if (int.TryParse(partido, out Num))
            {
                CargadorDeDatos.CargarComboBox("SELECT DISTINCT E.id as id,E.nombre as nombre FROM LigaBA.Partido AS P INNER JOIN LigaBA.Equipo AS E ON P.equipolocal = E.id OR P.equipovisitante = E.id WHERE P.id = " + partido, new List<SqlParameter>(), comboBox, txt, "id", "nombre");
            }
        }

        public static void CargarTorneoComboBox(ComboBox comboBox, string txt)
        {
            CargadorDeDatos.CargarComboBox("select id,nombre from LigaBA.Torneo", new List<SqlParameter>(), comboBox, txt, "id", "nombre");
        }

        //Cargas de CHECKED LIST BOX Especificos
        public static void CargarCategoriaCheckedListBox(CheckedListBox checkedListBox, string txt)
        {
            CargadorDeDatos.CargarCheckedListBox("select id,nombre from LigaBA.Categoria WHERE borrado=0", new List<SqlParameter>(), checkedListBox, txt, "id", "nombre");
        }
        public static void CargarInstitucionesCheckedListBox(CheckedListBox checkedListBox, string txt)
        {
            CargadorDeDatos.CargarCheckedListBox("select id,nombre from LigaBA.Institucion WHERE borrado=0", new List<SqlParameter>(), checkedListBox, txt, "id", "nombre");
        }

    }
}
