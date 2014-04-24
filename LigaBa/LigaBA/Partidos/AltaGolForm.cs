using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LigaBA.Clases;

namespace LigaBA.Partidos
{
    public partial class AltaGolForm : Form
    {
        public PartidoXJugador partidoXJugador;

        public AltaGolForm(PartidoXJugador pxj)
        {
            InitializeComponent();
            partidoXJugador = pxj;
        }

        private void AltaGolForm_Load(object sender, EventArgs e)
        {
            CargadorDeDatos.CargarEquipoXPartidoComboBox(EquipoComboBox,this.Text,partidoXJugador.idPartido);
        }
    }
}
