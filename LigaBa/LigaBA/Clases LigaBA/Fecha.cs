using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaBA.ClasesLigaBA
{
    public class Fecha
    {
        private int fecha;
        private Equipo local;
        private Equipo visitante;


        public Fecha(int fecha, Equipo l, Equipo v)
        {
            this.fecha = fecha;
            this.local = l;
            this.visitante = v;
        }

        public bool jugaronJuntos(Equipo equipo1, Equipo equipo2)
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

        public bool jugo(Equipo equipo1)
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
        public Equipo get_local()
        {
            return local;
        }
        public Equipo get_visitante()
        {
            return visitante;
        }

        public void set_local(Equipo e)
        {
            local = e;
        }
        public void set_visitante(Equipo e)
        {
            visitante = e;
        }
    }
}
