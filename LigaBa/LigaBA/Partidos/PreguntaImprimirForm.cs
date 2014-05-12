using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LigaBA.Partidos
{
    public partial class PreguntaImprimirForm : Form
    {
        public PreguntaImprimirForm(string LocalId, string VisitanteId, string Local, string Visitante, string Fecha, string nombretorneo, string nombrecategoria, string TorneoId, string CategoriaId)
        {
            InitializeComponent();

            this.LocalId = LocalId;
            this.VisitanteId = VisitanteId;
            this.Local = Local;
            this.Visitante = Visitante;
            this.Fecha = Fecha;
            this.nombreCategoria = nombrecategoria;
            this.nombreTorneo = nombretorneo;
            this.TorneoId = TorneoId;
            this.CategoriaId = CategoriaId;
        }

        string LocalId;
        string VisitanteId;
        string Local;
        string Visitante;
        string Fecha;
        string nombreTorneo;
        string nombreCategoria;
        string TorneoId;
        string CategoriaId;

        private void PreguntaImprimirForm_Load(object sender, EventArgs e)
        {
            this.LocalButton.Text = Local;
            this.VisitanteButton.Text = Visitante;
        }

        private void LocalButton_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormReporteLocal);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();

            this.Close();
        }

        private void VisitanteButton_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirFormReporteVisitante);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();

            this.Close();
        }

        private void AbrirFormReporteLocal()
        {
            ReportePartidoForm abrir = new ReportePartidoForm(LocalId, VisitanteId, Local, Visitante, nombreTorneo, nombreCategoria, Fecha,TorneoId,CategoriaId,"Local");
            abrir.ShowDialog();
        }

        private void AbrirFormReporteVisitante()
        {
            ReportePartidoForm abrir = new ReportePartidoForm(LocalId, VisitanteId, Local, Visitante, nombreTorneo, nombreCategoria, Fecha,TorneoId,CategoriaId, "Visitante");
            abrir.ShowDialog();
        }

    }
}
