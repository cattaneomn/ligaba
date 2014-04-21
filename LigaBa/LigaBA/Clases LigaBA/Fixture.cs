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
        private List<Equipo> equipos = new List<Equipo>();
        public List<Fecha> fixture;
        private int[] tolerancia;
        MostrarFixture form;

        private int cantidadDePartidos;
        private int cantidadDePartidosSimultaneos;
        private int cantidadDeFechas;
        private int cantidadEquipos;

        //Atributos de estadisticas
        private int estadisticaCarrera = 0;
        private int estadisticaVueltas = 0;
        public int reinicios = 0;        

        public Fixture(MostrarFixture form, List<Fecha> f)
        {
            this.fixture = f;
            this.form = form;
        }

        public Fixture(MostrarFixture form)
        {
            this.form = form;

            equipos.Add(new Equipo(1, "boca"));
            equipos.Add(new Equipo(2, "river"));
            equipos.Add(new Equipo(3, "san lorenzo"));
            equipos.Add(new Equipo(4, "tigre"));
            equipos.Add(new Equipo(5, "estudiantes"));
            equipos.Add(new Equipo(6, "racing"));
            equipos.Add(new Equipo(7, "colon"));
            equipos.Add(new Equipo(8, "belgrano"));
            equipos.Add(new Equipo(9, "allboys"));
            equipos.Add(new Equipo(10, "rosario"));
            /*equipos.Add(new Equipo(11, "pirulo"));
            equipos.Add(new Equipo(12, "hola"));
            equipos.Add(new Equipo(13, "xxxx"));
            equipos.Add(new Equipo(14, "yyyy"));
            equipos.Add(new Equipo(15, "aaa"));
            equipos.Add(new Equipo(16, "bbb"));
            equipos.Add(new Equipo(17, "ccc"));
            equipos.Add(new Equipo(18, "ddd"));
            equipos.Add(new Equipo(19, "eee"));
            equipos.Add(new Equipo(20, "fff"));*/

            inicializar();
        }

        public Fixture(MostrarFixture form, List<Equipo> equipos)
        {
            this.form = form;
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
                Equipo local;
                Equipo visitante;
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
                            List<Equipo> aux = equipos.FindAll(e => !noDisponibles.Contains(equipos.IndexOf(e)));
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
                                List<Equipo> aux = equipos.FindAll(e => !noDisponibles.Contains(equipos.IndexOf(e)));
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
                form.ActualizarFixture(fixture);
                form.ActualizarMutex();
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

        public void imprimirFixture()
        {
            //form.richTextBoxUpdate("Reinicios: " + reinicios + " Condiciones de carrera: " + estadisticaCarrera + " Vueltas totales: " + estadisticaVueltas + "\n\n");
            foreach (Fecha fecha in fixture)
            {
                form.richTextBoxUpdate("Fecha:" + fecha.get_fecha() + " -> " + (fecha.get_local()).get_nombre() + " vs " + (fecha.get_visitante()).get_nombre() + "\n");
            }
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

        private bool noPuedenJugar(int f, Equipo local, Equipo visitante)
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

        private bool toleranciaDeEstado(Equipo equipo)
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
