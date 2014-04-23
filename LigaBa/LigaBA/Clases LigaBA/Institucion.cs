using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaBA.ClasesLigaBA
{
    public class Institucion
    {
        private int id;
       
        private string nombre;

        public Institucion(int id,string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int get_id() { return id; }
        public string get_nombre() { return nombre; }
    }
}
