using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaBA.Clases_LigaBA
{
    public class Jugador
    {
        private int id;
        private string nombre;
        private string apellido;
        private string dni;
        private string equipo;
        private int id_equipo;

        public Jugador(int id,string nombre, string apellido, string dni,string equipo,int id_equipo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.equipo = equipo;
            this.id_equipo = id_equipo;
        }

        public int get_id() { return id; }
        public int get_id_equipo() { return id_equipo; }
        public string get_nombre() { return nombre; }
        public string get_apellido() { return apellido; }
        public string get_dni() { return dni; }
        public string get_equipo() { return equipo; }

        public void set_id(int id) { this.id = id; }
        public void set_id_equipo(int id_equipo) { this.id_equipo = id_equipo; }
        public void set_nombre(string nombre) { this.nombre = nombre; }
        public void set_apellido(string apellido) { this.apellido = apellido; }
        public void set_dni(string dni) { this.dni = dni; }
        public void set_equipo(string equipo) { this.equipo = equipo; }

    }
}
