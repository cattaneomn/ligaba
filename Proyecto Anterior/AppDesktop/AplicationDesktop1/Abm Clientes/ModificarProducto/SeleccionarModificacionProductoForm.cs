using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicationDesktop1.Abm_Clientes
{
    public partial class SeleccionarModificacionProductoForm : Form
    {
        public SeleccionarModificacionProductoForm()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            int Cant_tildados = 0;
            foreach (Control objeto in this.TipoGroupBox.Controls)
            {
                if (objeto is RadioButton && ((RadioButton)objeto).Checked == true)
                {
                    Cant_tildados++;
                }

            }
            if (Cant_tildados == 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de modificacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (UnProductoRadioButton.Checked == true)
            {
                BusquedaModificarProductoClienteForm abrir = new BusquedaModificarProductoClienteForm(false);
                abrir.ShowDialog();
                this.Close();
            }else
            {
                BusquedaModificarProductoClienteForm abrir = new BusquedaModificarProductoClienteForm(true);
                abrir.ShowDialog();
                this.Close();
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
