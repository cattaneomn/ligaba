using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace AplicationDesktop1
{
    class ModDataGridView
    {
        
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
