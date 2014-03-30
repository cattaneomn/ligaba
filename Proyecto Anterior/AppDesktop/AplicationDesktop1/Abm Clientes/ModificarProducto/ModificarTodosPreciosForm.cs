using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicationDesktop1.Abm_Clientes.ModificarProducto
{
    public partial class ModificarTodosPreciosForm : Form
    {
        public ModificarTodosPreciosForm()
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

            if (AumentarRadioButton.Checked == true)
            {
                BusquedaModificarProductoClienteForm.TipoModificacion = "Aumentar";
                BusquedaModificarProductoClienteForm.Porcentaje = Convert.ToDecimal(this.PorcentajeTextBox.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                BusquedaModificarProductoClienteForm.TipoModificacion = "Disminuir";
                BusquedaModificarProductoClienteForm.Porcentaje = Convert.ToDecimal(this.PorcentajeTextBox.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
