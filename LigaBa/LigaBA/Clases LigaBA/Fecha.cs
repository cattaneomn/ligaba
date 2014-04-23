using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaBA.ClasesLigaBA
{
    public class Fecha
    {
        private int fecha;
        private Institucion local;
        private Institucion visitante;


        public Fecha(int fecha, Institucion l, Institucion v)
        {
            this.fecha = fecha;
            this.local = l;
            this.visitante = v;
        }

        public bool jugaronJuntos(Institucion equipo1, Institucion equipo2)
        {
            if (local.get_id() == equipo1.get_id() && visitante.get_id() == equipo2.get_id())
            {
                return true;
            }
            if (local.get_id() == equipo2.get_id() && visitante.get_id() == equipo1.get_id())
            {
                return true;
            }
            return false;
        }

        public bool jugo(Institucion equipo1)
        {
            if (local.get_id() == equipo1.get_id())
            {
                return true;
            }
            if (visitante.get_id() == equipo1.get_id())
            {
                return true;
            }
            return false;
        }

        public int get_fecha()
        {
            return fecha;
        }
        public Institucion get_local()
        {
            return local;
        }
        public Institucion get_visitante()
        {
            return visitante;
        }

        public void set_local(Institucion e)
        {
            local = e;
        }
        public void set_visitante(Institucion e)
        {
            visitante = e;
        }
    }
}
