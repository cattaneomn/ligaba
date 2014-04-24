using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LigaBA.Partidos
{
    public partial class JugarPartidoForm : Form
    {
        private PartidoAModificar partido;

        public JugarPartidoForm(PartidoAModificar p)
        {
            InitializeComponent();
            partido = p;
        }

        private void JugarPartidoForm_Load(object sender, EventArgs e)
        {
            TorneoLabel.Text = partido.nombreTorneo;
            CategoriaLabel.Text = partido.nombreCategoria;
            FechaLabel.Text = partido.fecha;
            LocalLabel.Text = partido.nombreLocal;
            VisitanteLabel.Text = partido.nombreVisitante;
            GolesLocalNumericUpDown.Value = set_goles(partido.goleslocal);
            GolesVisitanteNumericUpDown.Value = set_goles(partido.golesvisitante);
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarGolesButton_Click(object sender, EventArgs e)
        {
            PartidoXJugador pxj = new PartidoXJugador(partido.idPartido);
            
            AltaGolForm form = new AltaGolForm(pxj);
            form.ShowDialog();
        }

        //SETTERS Y GETTERS
        public deciaml set_goles(string goles)
        {
            decimal g = Convert.ToDecimal(goles);
            if (g == -1)
            {
                return 0;
            } return g;
        }
    }
}
