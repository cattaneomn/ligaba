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

using AplicationDesktop1.Abm_Ventas;

namespace AplicationDesktop1.Abm_Ventas
{
    public partial class SeleccionProductoForm : Form
    {
        public SeleccionProductoForm(int Cod_Cliente,string FormLlamado)
        {
            InitializeComponent();
            Codigo = Cod_Cliente;
            Form = FormLlamado;
        }

        string Form;
        int Codigo;
        int Id;
        DataSet ds;
   
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (this.ProductoTextBox.Text == "" || this.PrecioTextBox.Text =="")
            {
                MessageBox.Show("Debe seleccionar un producto antes de agregarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            if (this.CantidadUpDown.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Form == "Alta")
            {
                AltaFacturaForm.Producto = this.ProductoTextBox.Text;
                AltaFacturaForm.Precio = Convert.ToDecimal(this.PrecioTextBox.Text);
                AltaFacturaForm.Cantidad = Convert.ToInt32(this.CantidadUpDown.Value);
                AltaFacturaForm.Codigo = Id;
            }
            
            if (Form == "Modificar")
            {
                ModificarFacturaForm.Producto2 = this.ProductoTextBox.Text;
                ModificarFacturaForm.Precio2 = Convert.ToDecimal(this.PrecioTextBox.Text);
                ModificarFacturaForm.Cantidad2 = Convert.ToInt32(this.CantidadUpDown.Value);
                ModificarFacturaForm.Codigo2 = Id;
            }

            DialogResult = DialogResult.OK;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionProductoForm_Load(object sender, EventArgs e)
        {
            
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@cliente",Codigo));
            ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_CargarProductosFactura", param,"Productos", this.Text);


            this.ProductosDataGridView.DataSource = ds;
            this.ProductosDataGridView.DataMember = "Productos";
            ModDataGridView.agregarBoton(ProductosDataGridView, "Seleccionar");
            ProductosDataGridView.Columns["nombre"].Width = 200;
            ProductosDataGridView.Columns["detalle"].Width = 200;
            this.FiltroTextBox.Focus();
        }


        private void FiltroTextBox_TextChanged(object sender, EventArgs e)
        {

            if (this.FiltroTextBox.Text != "")
            {
                ds.Tables["Productos"].DefaultView.RowFilter = "nombre LIKE '%" + this.FiltroTextBox.Text + "%'";
                this.ProductosDataGridView.DataSource = ds.Tables["Productos"];
                OrdernarColumnas();
            }
            else
            {
                ds.Tables["Productos"].DefaultView.RowFilter = "";
                this.ProductosDataGridView.DataSource = ds.Tables["Productos"];
                OrdernarColumnas();
            
            }
        }

        private void ProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.ProductosDataGridView.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                this.ProductoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["nombre"].Value.ToString();
                this.PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["precio"].Value.ToString();
                Id = Convert.ToInt32(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value);
                this.CantidadUpDown.Focus();
            }
        }

        private void OrdernarColumnas()
        {
            this.ProductosDataGridView.Columns["codigo"].DisplayIndex = 0;
            this.ProductosDataGridView.Columns["nombre"].DisplayIndex = 1;
            this.ProductosDataGridView.Columns["detalle"].DisplayIndex = 2;
            this.ProductosDataGridView.Columns["precio"].DisplayIndex = 3;
            this.ProductosDataGridView.Columns["Seleccionar"].DisplayIndex = 4;

        }

     

        private void FiltroTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && this.ProductosDataGridView.RowCount > 0)
            {
                this.ProductoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["nombre"].Value.ToString();
                this.PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["precio"].Value.ToString();
                Id = Convert.ToInt32(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value);
                this.CantidadUpDown.Focus();
             
            }
        }

 
        private void ProductosDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && this.ProductosDataGridView.RowCount > 0)
            {
                this.ProductoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["nombre"].Value.ToString();
                this.PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["precio"].Value.ToString();
                Id = Convert.ToInt32(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value);
                this.CantidadUpDown.Focus();
            }
            
        }

        

    }
}
