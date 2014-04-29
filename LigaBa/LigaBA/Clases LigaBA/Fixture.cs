using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Abm_Torneo;

namespace LigaBA.ClasesLigaBA
{
    public class Fixture
    {
        /**************************************************************************************
         * Documentacion clase Fixture
         * **************************************************************************************/

        /*
         * CONSTRUCTORES
         * 
         *         
         * Fixture(List<Institucion> equipos) -> Cuando se va a crear el fixture
         * 
         * Fixture(List<Fecha> f) -> Cuando el fixture ya esta creado y solo se necesitan los metodos de manejo del fixture
         * 
         * */

        /*
         * ATRIBUTOS
         * +IMP:Atributos importantes
         * 
         *  List<Institucion> equipos ->Conjunto de Instituciones que participan del torneo, siempre son par, ej:Institucion Comodin(id->0,nombre->"Libre")
         *  
         * List<Fecha> fixture ->Conjunto de Partidos que forman el fixture. Fecha(fecha,local,visitante)
         * 
         * int[] tolerancia -> Array de tolerancia tolerancia[indice_equipo] = {n -> numero de tolerancias de localia repetida}
         * 
         * int estadisticaCarrera -> cantidad de veces que se produjo una condicion de carrega(borrar toda una fecha)(90 vueltas)
         * 
         * int estadisticaVueltas -> cantidad de vueltas totales por reinicio, vuelta -> cantidad de veces que se trato de calcular una fecha sin borrarla.
         * 
         * int reinicios -> cantidad de veces que se borro todo el fixture para calcularlo desde 0 (condicionesDeCarrera = 1000)        
         * 
         * METODOS
         * +IMP:Metodos importantes
         * 
         * 
         * void inicializar() -> Inicializa los atributos y realiza los calculos previos (cantidad de fechas, cantidad de partidos, etc...)
         * 
         * IMP: bool armarFixture() -> Crea el fixture y lo guarda en una lista de objetos Fecha
         *      return True -> El fixture se creo correctamente.
         *      return False -> Si intento mas de 1000 veces crear el fixture desde 0, no tiene solucion.
         * 
         * void limpiar() -> reinicia las listas principales para volver a generar el fixture.
         * 
         * string imprimirFixture() -> devuelve un string con todo el fixture para mostrar.
         * 
         * IMP: int condicionDeCarrera(int f, List<int> noDisponibles) -> se produce una condicion de carrera cuando ha intentado reacer una fecha del fixture mas de 90 veces (ej: equipos{1,2,3,4,5,6} fecha_1{1-vs-2,3-vs-4,5-vs-6} fecha_2{1-vs-3,2-vs-4,5-vs-6} 5-vs-6 YA JUGO y los demas ya estan asignados
         *                                                              ->Este metodo borra toda una fecha del fixture para recalcularla completamente.
         *        param: int f -> fecha a borrar y recalcular
         *        param: List<int> noDisponibles -> equipos que ya estan jugando (se reinicia)
         *        
         *        return int -> Cantidad de partidos que hay que volver a recalcular.
         *        
         * void reiniciarTolerancia(int[] tolerancia) -> Reinicia la matriz de tolerancia asiganndo aleatoreamente la tolerancia a los equipos.
         *        param: int[] tolerancia -> Matris de tolerancia,matriz[indice_equipo]=> 0 sin tolerancia, 1 con tolerancia
         *        
         * bool noPuedenJugar(int f, Institucion local, Institucion visitante) -> Controla si:
         *                                                                             +Jugo el Local O el Vistante en esta fecha (f)
         *                                                                              +Local fue local en la fecha anterior (f-1) y no tiene tolerancia
         *                                                                              +Visitante fue visitante en la fecha anterior (f-1) y no tiene tolerancia
         *                                                                              +Jugo Local vs Visitante O Visitante vs Local en alguna fecha
         * 
         *      param: int f ->Fecha actual.
         *      return True -> alguno no puede jugar.
         *      return False -> pueden jugar.
         * 
         * bool toleranciaDeEstado(Institucion equipo) -> Se fija si el equipo tiene tolerancia para repetir la localia, SI: se la decrementa
         *      return True -> Tiene tolerancia
         *      return False -> No tiene tolerancia
         *      
         * List<Fecha> GetFechas() 
         *      return List<Fecha> -> Fixture 
         *
         * 
         **/

        private List<Institucion> equipos = new List<Institucion>();
        public List<Fecha> fixture;
        private int[] tolerancia;
        
        private int cantidadDePartidos;
        private int cantidadDePartidosSimultaneos;
        private int cantidadDeFechas;
        private int cantidadEquipos;

        //Atributos de estadisticas
        private int estadisticaCarrera = 0;
        private int estadisticaVueltas = 0;
        public int reinicios = 0;        

        public Fixture(List<Fecha> f)
        {
            this.fixture = f;
        }

        public Fixture(List<Institucion> equipos)
        {

            this.equipos.Clear();
            this.equipos = equipos;
            inicializar();
        }

        private void inicializar()
        {
            fixture = new List<Fecha>();
            cantidadEquipos = equipos.Count;

            long x = factorial(cantidadEquipos - 2);
            long y = factorial(cantidadEquipos);

            cantidadDePartidos = (int)(y / x) / 2;
            cantidadDePartidosSimultaneos = cantidadEquipos / 2;
            cantidadDeFechas = cantidadDePartidos / cantidadDePartidosSimultaneos;
            tolerancia = new int[cantidadEquipos];

        }


        public bool armarFixture()
        {
            if (equipos.Count > 1)
            {
                Random random1 = new Random();
                Random random2 = new Random();
                int aleatorio1;
                int aleatorio2;
                Institucion local;
                Institucion visitante;
                List<int> noDisponibles = new List<int>();
                bool ok = true;

                for (int i = 1; i <= cantidadDeFechas; i++)
                {
                    reiniciarTolerancia(tolerancia);
                    noDisponibles.Clear();
                    for (int j = 1; j <= cantidadDePartidosSimultaneos; j++)
                    {
                        if (noDisponibles.Count == equipos.Count - 2)
                        {
                            List<Institucion> aux = equipos.FindAll(e => !noDisponibles.Contains(equipos.IndexOf(e)));
                            if (ok)
                            {
                                ok = false;
                                aleatorio1 = equipos.IndexOf(aux.ElementAt(0));
                                aleatorio2 = equipos.IndexOf(aux.ElementAt(1));
                            }
                            else
                            {
                                aleatorio1 = equipos.IndexOf(aux.ElementAt(0));
                                aleatorio2 = equipos.IndexOf(aux.ElementAt(1));
                                ok = true;
                            }
                        }
                        else
                        {
                            do
                            {
                                aleatorio1 = random1.Next(equipos.Count);
                                aleatorio2 = random1.Next(equipos.Count);
                            } while ((aleatorio1 == aleatorio2 || noDisponibles.Contains(aleatorio1) || noDisponibles.Contains(aleatorio2)) && !(noDisponibles.Count == (equipos.Count - 2)));
                        }

                        local = equipos[aleatorio1];
                        visitante = equipos[aleatorio2];

                        int vueltas = 1;
                        while (noPuedenJugar(i, local, visitante))
                        {
                            if (vueltas == 90)
                            {
                                j -= condicionDeCarrera(i, noDisponibles);
                                vueltas = 1;

                                estadisticaCarrera++;
                                if (estadisticaCarrera == 10000)//1500 ->12
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                vueltas++;
                                estadisticaVueltas++;
                            }

                            if (noDisponibles.Count == equipos.Count - 2)
                            {
                                List<Institucion> aux = equipos.FindAll(e => !noDisponibles.Contains(equipos.IndexOf(e)));
                                if (ok)
                                {
                                    ok = false;
                                    aleatorio1 = equipos.IndexOf(aux.ElementAt(0));
                                    aleatorio2 = equipos.IndexOf(aux.ElementAt(1));
                                }
                                else
                                {
                                    aleatorio1 = equipos.IndexOf(aux.ElementAt(0));
                                    aleatorio2 = equipos.IndexOf(aux.ElementAt(1));
                                    ok = true;
                                }
                            }
                            else
                            {
                                do
                                {
                                    aleatorio1 = random1.Next(equipos.Count);
                                    aleatorio2 = random1.Next(equipos.Count);
                                } while ((aleatorio1 == aleatorio2 || noDisponibles.Contains(aleatorio1) || noDisponibles.Contains(aleatorio2)) && !(noDisponibles.Count == (equipos.Count - 2)));
                            }

                            local = equipos[aleatorio1];
                            visitante = equipos[aleatorio2];
                        }
                        Fecha fecha = new Fecha(i, local, visitante);
                        fixture.Add(fecha);
                        noDisponibles.Add(aleatorio1);
                        noDisponibles.Add(aleatorio2);
                    }
                }
                GenerarFixture.ActualizarFixture(fixture);
                GenerarFixture.ActualizarMutex();
                return true;
            }
            MessageBox.Show("Se necesita mas de un equipo para generar el fixture");
            return false;
        }

        public void limpiar()
        {
            fixture = new List<Fecha>();
            estadisticaCarrera = 0;
            estadisticaVueltas = 0;
        }

        public string imprimirFixture()
        {        
            string msg ="";
            foreach (Fecha fecha in fixture)
            {
                msg += "Fecha:" + fecha.get_fecha() + " -> " + (fecha.get_local()).get_nombre() + " vs " + (fecha.get_visitante()).get_nombre() + "\n";
            }
            return msg;
        }

        private int condicionDeCarrera(int f, List<int> noDisponibles)
        {

            reiniciarTolerancia(tolerancia);
            noDisponibles.Clear();
            return fixture.RemoveAll(fecha => fecha.get_fecha() == f);
        }

        //Metodos secundarios
        private void reiniciarTolerancia(int[] tolerancia)
        {
            for (int i = 0; i < equipos.Count; i++)
            {
                tolerancia[i] = 0;
            }

            //Solo dejamos tolerancia para 1 equipo por fecha
            Random random = new Random();
            int contador = 0;
            while (contador < (cantidadEquipos / 2))
            {
                int i = random.Next(0, cantidadEquipos - 1);
                if (tolerancia[i] == 0)
                {
                    tolerancia[i] = 1;
                    contador++;
                }
            }
        }

        private bool noPuedenJugar(int f, Institucion local, Institucion visitante)
        {
            for (int i = 0; i < fixture.Count; i++)
            {
                //Jugo antes LOCAL o VISITANTE
                if (fixture[i].get_fecha() == f && fixture[i].jugo(local) || fixture[i].get_fecha() == f && fixture[i].jugo(visitante))
                {
                    return true;
                }

                int fechaAnterior = f - 1;
                //Fue VISITANTE
                if ((fixture[i].get_fecha() == (fechaAnterior)) && (fixture[i].get_visitante()).get_id() == visitante.get_id() && !toleranciaDeEstado(visitante))
                {
                    return true;
                }
                //Fue LOCAL
                if ((fixture[i].get_fecha() == (fechaAnterior)) && (fixture[i].get_local()).get_id() == local.get_id() && !toleranciaDeEstado(local))
                {
                    return true;
                }

                //Jugaron juntos antes
                if (fixture[i].jugaronJuntos(local, visitante))
                {
                    return true;
                }


            }

            return false;
        }

        private bool toleranciaDeEstado(Institucion equipo)
        {
            if (tolerancia[equipos.IndexOf(equipo)] < 1)
            {
                return false;
            }
            else
            {
                tolerancia[equipos.IndexOf(equipo)]--;
            }

            return true;
        }
        
        public List<Fecha> GetFechas()
        {
            return fixture;
        }
        
        //Metodos matematicos        
        public long factorial(int num)
        {
            long fact = 1;
            for (int i = 1; i < num + 1; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

    }
}
