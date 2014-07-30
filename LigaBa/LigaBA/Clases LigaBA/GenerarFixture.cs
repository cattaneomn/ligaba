using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace LigaBA.ClasesLigaBA
{
    public class GenerarFixture
    {

        private static List<Institucion> equipos;

        public static bool mutex = false;
        public static Fixture fixtureFinal;
        public static List<Thread> hilos;
        public static int cantidadDeHilos = 1;

        public static void Inicializar(List<Institucion> equipos)
        {
            Institucion ultimo = equipos.Last();

            if (ultimo.get_id() == 0)
            {
                GenerarFixture.equipos = equipos;
            }
            else
            {
                GenerarFixture.equipos = GenerarFixture.ShuffleList(equipos);
            }
            GenerarFixture.fixtureFinal = null;
            GenerarFixture.hilos = new List<Thread>();
        }

        private static List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }


        public static void Generar()
        {
            GenerarFixture.lanzarHilos();
        }

        private static void lanzarHilos()
        {            
            for (int i = 0; i < GenerarFixture.cantidadDeHilos; i++)
            {
                Thread hilo = new Thread(delegate() {GenerarFixture.metodoHilo(new Fixture(equipos)); });
                hilo.Start();
                hilos.Add(hilo);
            }

            Thread hiloControl = new Thread(GenerarFixture.controlHilo);
            hiloControl.Start();
        }

        //Metodos accedidos desde los hilos
        public static void ActualizarFixture(List<Fecha> f)
        {
            if (!mutex){GenerarFixture.fixtureFinal = new Fixture(f);}
        }

        public static void ActualizarMutex()
        {
            if (!mutex) { mutex = true; }
        }

        //Metodos para hilos
        private static void controlHilo()
        {
            while (!mutex && fixtureFinal == null)
            {
                Thread.Sleep(1);
            }
            foreach (Thread t in hilos)
            {
                t.Abort();
            }

            //MessageBox.Show(fixtureFinal.imprimirFixture());

            mutex = false;
            //fixtureFinal = null;
        }

        private static void metodoHilo(Fixture fx)
        {
            fx.limpiar();
            while (!fx.armarFixture())
            {
                fx.limpiar();                
            }
        }
    }
}
