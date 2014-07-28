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
         * 
         * Ver libro de Paenza pagina 239 del libro =( ---> =S ---> =)

         /***/

        private List<Institucion> equipos = new List<Institucion>();
        public List<Fecha> fixture;
        private int[] tolerancia;

        private int cantidadDePartidos;
        private int cantidadDePartidosSimultaneos;
        private int cantidadDeFechas;
        private int cantidadEquipos;

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
                //Inicializaciones
                Institucion local = null;
                Institucion visitante = null;

                int total = equipos.Count;
                int[,] matrizFixture = new int[total, total - 1];//Para empezar del 1 y no del 0
                List<int> equiposQueJugaron = new List<int>();

                List<int> equiposDePrimeraMitad = new List<int>();
                List<int> equiposDeSegundaMitad = new List<int>();

                //Repartir entre las listas
                for (int i = 0; i < total / 2; i++)
                {
                    equiposDePrimeraMitad.Add(i);
                }
                for (int i = total / 2; i < total; i++)
                {
                    equiposDeSegundaMitad.Add(i);
                }

                //Calculo de fixture para 1 equipo
                int contrincante = 1;
                int equipo_comodin = total;
                int equipo = 1;
                int[] filaParaUnEquipo = new int[total - 1];

                for (int columna = 0; columna < total - 1; columna++)
                {
                    filaParaUnEquipo[columna] = contrincante;
                    contrincante++;
                }

                //Calculo de matriz del fixture
                for (int fila = 0; fila < total; fila++)
                {
                    for (int columna = 0; columna < total - 1; columna++)
                    {
                        if (filaParaUnEquipo[columna] == fila + 1)
                        {
                            matrizFixture[fila, columna] = equipo_comodin;
                        }
                        else
                        {
                            matrizFixture[fila, columna] = filaParaUnEquipo[columna];
                        }
                    }

                    filaParaUnEquipo = cambiarOrden(filaParaUnEquipo, total);
                }

                int equipoQueJugoContraComodin = -1;
                //MessageBox.Show(imprimirMatriz(matrizFixture,total));

                for (int columna = 0; columna < total - 1; columna++)
                {
                    for (int fila = 0; fila < total; fila++)
                    {
                        contrincante = matrizFixture[fila, columna];

                        if (!equiposQueJugaron.Contains(contrincante - 1) && !equiposQueJugaron.Contains(fila))
                        {
                            //Solo para la primera fecha
                            if (columna + 1 == 1)
                            {
                                if (equiposDePrimeraMitad.Contains(fila))
                                {
                                    local = equipos[fila];
                                    visitante = equipos[contrincante - 1];
                                }
                                else if (equiposDeSegundaMitad.Contains(fila))
                                {
                                    local = equipos[contrincante - 1];
                                    visitante = equipos[fila];
                                }
                            }

                            //Luego de la primera fecha
                            if (columna + 1 > 1 && contrincante != equipo_comodin)
                            {
                                if (jugoAntesDeLocal(equipos[fila], columna + 1))
                                {
                                    visitante = equipos[fila];
                                    local = equipos[contrincante - 1];
                                }
                                else if (jugoAntesDeVisitante(equipos[fila], columna + 1))
                                {
                                    local = equipos[fila];
                                    visitante = equipos[contrincante - 1];
                                }
                            }

                            if (fila == equipoQueJugoContraComodin)
                            {
                                if (equiposDePrimeraMitad.Contains(fila))
                                {
                                    local = equipos[fila];
                                    visitante = equipos[contrincante - 1];
                                }
                                else if (equiposDeSegundaMitad.Contains(fila))
                                {
                                    local = equipos[fila];
                                    visitante = equipos[contrincante - 1];
                                }
                            }

                            //Caso especial al jugar contra el comodin
                            if (contrincante == equipo_comodin)
                            {
                                if (equiposDePrimeraMitad.Contains(fila))
                                {
                                    local = equipos[fila];
                                    visitante = equipos[contrincante - 1];
                                }
                                else if (equiposDeSegundaMitad.Contains(fila))
                                {
                                    visitante = equipos[fila];
                                    local = equipos[contrincante - 1];
                                }

                                equipoQueJugoContraComodin = fila;
                            }

                            equiposQueJugaron.Add(fila);
                            equiposQueJugaron.Add(contrincante - 1);

                            Fecha fecha = new Fecha(columna + 1, local, visitante);
                            fixture.Add(fecha);
                        }
                    }
                    equiposQueJugaron = new List<int>();
                }
                GenerarFixture.ActualizarFixture(fixture);
                GenerarFixture.ActualizarMutex();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool jugoAntesDeLocal(Institucion equipo, int fechaActual)
        {
            foreach (Fecha fecha in fixture)
            {
                if (fecha.get_fecha() == fechaActual - 1 && fecha.jugo(equipo))
                {
                    return fecha.get_local() == equipo;
                }
            }
            return false;
        }

        public bool jugoAntesDeVisitante(Institucion equipo, int fechaActual)
        {
            foreach (Fecha fecha in fixture)
            {
                if (fecha.get_fecha() == fechaActual - 1 && fecha.jugo(equipo))
                {
                    return fecha.get_visitante() == equipo;
                }
            }
            return false;
        }

        public int[] cambiarOrden(int[] array, int cant)
        {
            int ultimo = array[array.Length - 1];
            int x;

            for (x = array.Length - 1; x > 0; x--)
            {
                array[x] = array[x - 1];
            }

            array[0] = ultimo;

            return array;
        }
        public string imprimirMatriz(int[,] matriz, int cant)
        {
            string msg = "";
            for (int i = 0; i < cant; i++)
            {
                for (int j = 0; j < cant - 1; j++)
                {
                    msg += matriz[i, j] + "  ";
                }
                msg += "\n\n";
            }
            return msg;
        }
        public void limpiar()
        {
            fixture = new List<Fecha>();
        }

        public string imprimirFixture()
        {
            string msg = "";
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
            //Random random = new Random();
            int contador = 0;
            /*while (contador < (cantidadEquipos / 2))
            {
                /*int i = random.Next(0, cantidadEquipos - 1);
                if (tolerancia[i] == 0)
                {
                    tolerancia[i] = 1;
                    contador++;
                }*/

            //}
            //tolerancia[1] = 1;
            //tolerancia[2] = 1;
        }

        private bool noPuedenJugar(int f, Institucion local, Institucion visitante)
        {
            for (int i = 0; i < fixture.Count; i++)
            {
                //Son el mismo
                if (local.get_id() == visitante.get_id())
                {
                    return true;
                }

                //Jugo antes LOCAL o VISITANTE
                if (fixture[i].get_fecha() == f && fixture[i].jugo(local) || fixture[i].get_fecha() == f && fixture[i].jugo(visitante))
                {
                    return true;
                }

                //Jugaron juntos antes
                if (fixture[i].jugaronJuntos(local, visitante))
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
            }

            return false;
        }

        private bool toleranciaDeEstado(Institucion equipo)
        {
            /*if (tolerancia[equipos.IndexOf(equipo)] < 1)
            {
                return false;
            }
            else
            {
                //tolerancia[equipos.IndexOf(equipo)]--;
            }*/
            int contador = 0;
            for (int i = 0; i < this.equipos.Count; i++)
            {
                if (tolerancia[equipos.IndexOf(equipo)] == 1)
                {
                    contador++;
                }
            }

            if (contador >= this.equipos.Count / 2)
            {
                return false;
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
