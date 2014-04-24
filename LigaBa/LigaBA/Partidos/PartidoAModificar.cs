using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaBA.Partidos
{
    public class PartidoAModificar
    {
        public string idPartido;
        public string idTorneo;
        public string idCategoria;
        public string fecha;
        public string idLocal;
        public string idVisitante;

        public string goleslocal;
        public string golesvisitante;

        public string nombreTorneo;
        public string nombreCategoria;
        public string nombreLocal;
        public string nombreVisitante;

        public PartidoAModificar(string idP,string idT, string idC, string f, string idL, string idV,string golesL,string golesV,string nombreT, string nombreC, string nombreL,string nombreV)
        {
            idPartido = idP;
            idTorneo = idT;
            idCategoria = idC;
            fecha = f;
            idLocal = idL;
            idVisitante = idV;

            goleslocal = golesL;
            golesvisitante = golesV;

            nombreTorneo = nombreT;
            nombreCategoria = nombreC;
            nombreLocal = nombreL;
            nombreVisitante = nombreV;
        }   
    

    }
}
