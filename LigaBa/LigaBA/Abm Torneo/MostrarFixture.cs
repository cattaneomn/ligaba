using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.ClasesLigaBA;

using System.Threading;

namespace LigaBA.Abm_Torneo
{
    public partial class MostrarFixture : Form
    {
        private List<Equipo> equipos;

        public bool m = false;
        public Fixture fixtureFinal;
        public List<Thread> hilos;
        public const int cantidadDeHilos = 1;

        public MostrarFixture(List<Equipo> equipos)
        {
            this.equipos = equipos;
            fixtureFinal = null;
            hilos = new List<Thread>();
            InitializeComponent();
        }


        private void MostrarFixture_Load(object sender, EventArgs e)
        {
            lanzarHilos();
        }

        private void lanzarHilos()
        {            
            for (int i = 0; i < cantidadDeHilos; i++)
            {
                Thread hilo = new Thread(delegate() { metodoHilo(new Fixture(this, equipos)); });
                hilo.Start();
                hilos.Add(hilo);
            }

            Thread hiloControl = new Thread(controlHilo);
            hiloControl.Start();
        }

        private void insertarFixture()
        {

        }

        //Metodos accedidos desde los hilos
        delegate void RichTextBoxDelegate(string txt);

        public void richTextBoxUpdate(string txt)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new RichTextBoxDelegate(richTextBoxUpdate), new Object[] { txt });
            }
            else
            {
                richTextBox1.Text += txt.ToString();
            }
        }

        public void ActualizarFixture(List<Fecha> f)
        {
            if (!m){this.fixtureFinal = new Fixture(this, f);}
        }

        public void ActualizarMutex(){
            if (!m) { m = true; }
        }

        //Metodos para hilos
        private void controlHilo()
        {            
            while (!m && fixtureFinal == null)
            {
                Thread.Sleep(1);
            }
            foreach (Thread t in hilos)
            {
                t.Abort();
            }
            fixtureFinal.imprimirFixture();
            m = false;
            //fixtureFinal = null;            
            //insertarFixture();
        }

        private void metodoHilo(Fixture fx)
        {
            fx.limpiar();
            while (!fx.armarFixture())
            {
                fx.limpiar();
                fx.reinicios++;
            }            
        }

    }
}
