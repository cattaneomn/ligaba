using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Abm_Usuarios;
using LigaBA.Abm_Categorias;
using LigaBA.Abm_Jugador;
using LigaBA.AbmIntituciones;
using LigaBA.Abm_Tipo_Torneo;
using LigaBA.Abm_Equipos;
using LigaBA.Abm_Torneo;
using LigaBA.Back_Up;
using LigaBA.Partidos;
using LigaBA.Fixture;
using LigaBA.Goleadores;

namespace LigaBA
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            UsuariosForm abrir = new UsuariosForm();
            abrir.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuariosForm abrir = new UsuariosForm();
            abrir.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriasForm abrir = new CategoriasForm();
            abrir.ShowDialog();
        }

        private void jugadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JugadorForm abrir = new JugadorForm();
            abrir.ShowDialog();
        }

        private void JugadoresButton_Click(object sender, EventArgs e)
        {
            JugadorForm abrir = new JugadorForm();
            abrir.ShowDialog();
        }

        private void intitucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstitucionesForm abrir = new InstitucionesForm();
            abrir.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InstitucionesForm abrir = new InstitucionesForm();
            abrir.ShowDialog();
        }

        private void tipoDeTorneoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoTorneoForm abrir = new TipoTorneoForm();
            abrir.ShowDialog();
        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EquiposForm abrir = new EquiposForm();
            abrir.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            EquiposForm abrir = new EquiposForm();
            abrir.ShowDialog();
        }

        private void torneoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TorneosForm abrir = new TorneosForm();
            abrir.ShowDialog();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            TorneosForm abrir = new TorneosForm();
            abrir.ShowDialog();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartidosForm abrir = new PartidosForm();
            abrir.ShowDialog();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            FixtureForm abrir = new FixtureForm();
            abrir.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GoleadoresForm abrir = new GoleadoresForm();
            abrir.ShowDialog();
        }

    }
}
