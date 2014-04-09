using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows.Forms;

namespace LigaBA
{
    class ModDataGridView
    {
        //Actualizar columna
        public static void actualizarCheckbox(DataGridView dg, string columna, string key, DataTable tablaActualizada, string columnaEnTablaActualizada)
        {
            dg.Columns.Remove(dg.Columns[columna]);
            ModDataGridView.agregarCheckbox(dg, columna);
            foreach (DataGridViewRow row in dg.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells[columna];
                string valor = buscarValorCheckbox(tablaActualizada, key, row.Cells[key].Value.ToString(), columnaEnTablaActualizada);
                if (valor != "")//Si no lo encuentra no lo actualiza
                {
                    checkBox.Value = (valor == "0" ? false : true);
                }
            }
        }

        private static string buscarValorCheckbox(DataTable dt, string key, string valor, string columna)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row[key].ToString() == valor)
                {
                    return row[columna].ToString();
                }
            }
            return "";
        }
        //Ocultado de columnas
        public static void ocultarColumna(DataGridView dg, string nombre)
        {
            foreach (DataGridViewColumn col in dg.Columns)
            {
                if (col.Name == nombre)
                {
                    col.Visible = false; ;
                    break;
                }
            }
        }
        
        
        //Agregado de columnas
        public static void agregarBoton(DataGridView dg, string NombreBoton)
        {
            if (!ModDataGridView.tieneLaColumna(dg,NombreBoton))
            {
                var buttonCol = new DataGridViewButtonColumn();
                buttonCol.Name = NombreBoton;
                buttonCol.HeaderText = NombreBoton;
                buttonCol.Text = NombreBoton;
                buttonCol.UseColumnTextForButtonValue = true;

                dg.Columns.Add(buttonCol);

                foreach (DataGridViewRow row in dg.Rows)
                {
                    DataGridViewButtonCell button = (row.Cells[NombreBoton] as DataGridViewButtonCell);
                }
            }
        }

        public static void agregarCheckbox(DataGridView dg, string NombreColumna)
        {
            if (!ModDataGridView.tieneLaColumna(dg, NombreColumna))
            {
                var buttonCol = new DataGridViewCheckBoxColumn();
                buttonCol.Name = NombreColumna;
                buttonCol.HeaderText = NombreColumna;

                buttonCol.TrueValue = true;
                buttonCol.ReadOnly = false;

                dg.Columns.Add(buttonCol);

                foreach (DataGridViewRow row in dg.Rows)
                {
                    DataGridViewButtonCell button = (row.Cells[NombreColumna] as DataGridViewButtonCell);
                    row.Cells[NombreColumna].Value = true;
                }
            }
        }
        
        
        //Elminacion de columnas
        public static void borrarBoton(DataGridView dg, string NombreBoton)
        {
            if (ModDataGridView.tieneLaColumna(dg,NombreBoton))
            {
                dg.Columns.Remove(NombreBoton);
            }
        }
        
        public static void limpiarDataGridView(DataGridView dg, string NombreBoton)
        {
            dg.DataSource = null;
            ModDataGridView.borrarBoton(dg,NombreBoton);
        }
        
        
        //Metodos de validacion
        public static bool tieneLaColumna(DataGridView dg,string NombreBoton)
        {
            foreach (DataGridViewColumn col in dg.Columns)
            {
                if (col.Name == NombreBoton)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
