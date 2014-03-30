using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace AplicationDesktop1.Abm_Clientes
{
    public partial class AsignarProductoClienteForm : Form
    {
        public AsignarProductoClienteForm(string Prod)
        {
            InitializeComponent();

            Producto = Prod;
        }

        //Variables
        List<string> Clientes = new List<string>();
        List<decimal> Precios = new List<decimal>();
        String Producto;


        private void AsignarProductoClienteForm_Load(object sender, EventArgs e)
        {
            CargarClientesCheckBox();
            this.ProductoTextBox.Text = Producto;
        }

        private void CargarClientesCheckBox()
        {

            string Consulta = "SELECT razon_social FROM ingeniar.Cliente WHERE estado=1";
            List<SqlParameter> param = new List<SqlParameter>();
            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            foreach (DataRow row in ds.Rows)
            {
                this.ClientesCheckedListBox.Items.Add(row[0], false);
            }

        }

        private int Validaciones()
        {
            int Cant_Filas = ClientesCheckedListBox.Items.Count;
            int i;
            int Cant_Destildado = 0;

            for (i = 0; i < Cant_Filas; i++)
            {
                if (ClientesCheckedListBox.GetItemChecked(i) != true)
                {
                    Cant_Destildado++;
                }
            }

            if (Cant_Destildado == Cant_Filas)
            {
                MessageBox.Show("Debe seleccionar aunque sea un cliente para poder dar de alta el producto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }
            return 1;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            if (Validaciones() == -1) return;
            
            AgregarClientesColeccion();

            AltaPrecioProductoForm abrir = new AltaPrecioProductoForm(Clientes,Precios,Producto);
            DialogResult Respuesta = abrir.ShowDialog();

            if (Respuesta == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
            }
        }



        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.ClientesCheckedListBox.Items.Count; i++)
            {
                this.ClientesCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);

            }

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarClientesColeccion()
        {
            int Cant_Filas = ClientesCheckedListBox.Items.Count;
            int i;

            for (i = 0; i < Cant_Filas; i++)
            {
                if (ClientesCheckedListBox.GetItemChecked(i) == true)
                {
                    Clientes.Add(ClientesCheckedListBox.Items[i].ToString());
                }

            }
        }

    }
}
