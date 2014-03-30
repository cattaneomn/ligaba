using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LigaBA.AbmIntituciones
{
    public partial class InstitucionesForm : Form
    {
        public InstitucionesForm()
        {
            InitializeComponent();
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            AltaInstitucionForm abrir = new AltaInstitucionForm();
            abrir.ShowDialog();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (this.Instituciones_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Instituciones_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

            string InstitucionBorrada = Instituciones_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString();

            DialogResult Resultado = MessageBox.Show("¿Esta seguro que desea eliminar la institucion '" + InstitucionBorrada + "'?, con ella se borraran todos sus equipos y jugadores.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@id", Convert.ToString(Instituciones_DataGridView.CurrentRow.Cells["id"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaInstitucion", param, this.Text);

                if (TerminoBien == true)
                {

                    Instituciones_DataGridView.Rows.Remove(Instituciones_DataGridView.CurrentRow);
                    MessageBox.Show("Se ha dado de baja la institucion '" + InstitucionBorrada + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if (this.Instituciones_DataGridView.Rows.Count == 0)
            {
                return;
            }

            if (this.Instituciones_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string Id= Instituciones_DataGridView.CurrentRow.Cells["id"].Value.ToString();
            string Nombre= Instituciones_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
            string Direccion= Instituciones_DataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
            string Localidad= Instituciones_DataGridView.CurrentRow.Cells["Localidad"].Value.ToString();
            string Telefono= Instituciones_DataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
            string Email= Instituciones_DataGridView.CurrentRow.Cells["Email"].Value.ToString();
            string Delegado= Instituciones_DataGridView.CurrentRow.Cells["Delegado"].Value.ToString();
            string Coordinador = Instituciones_DataGridView.CurrentRow.Cells["Coordinador"].Value.ToString();
            
                
            ModificarInstitucionFom abrir = new ModificarInstitucionFom(Id,Nombre,Direccion,Localidad,Telefono,Email,Delegado,Coordinador);
            DialogResult Resultado = abrir.ShowDialog();
            if (Resultado == DialogResult.OK)
            {
                ModDataGridView.limpiarDataGridView(Instituciones_DataGridView, "");
            }
        }


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.GroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
            }

            ModDataGridView.limpiarDataGridView(Instituciones_DataGridView, "");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

            string Consulta = ArmarConsulta();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@usuario", this.NombreTextBox.Text));

            Instituciones_DataGridView.DataSource = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);
            

            if (Instituciones_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Instituciones_DataGridView.Columns["id"].Visible = false;
            this.Instituciones_DataGridView.Focus();
        }

        private string ArmarConsulta()
        {
            string Consulta = "SELECT id,nombre as Nombre,direccion as Direccion,localidad as Localidad,telefono as Telefono,email as Email,delegado as Delegado,coordinador as Coordinador FROM LigaBA.Institucion WHERE 1=1";

            if (NombreTextBox.TextLength > 0)
            {
                Consulta += "AND nombre LIKE '%" + NombreTextBox.Text + "%' ";
            }
            if (DireccionTextBox.TextLength > 0)
            {
                Consulta += "AND direccion LIKE '%" + DireccionTextBox.Text + "%' ";
            }

            if (TelefonoTextBox.TextLength > 0)
            {
                Consulta += "AND telefono='" + TelefonoTextBox.Text + "' ";
            }


            return Consulta;
        }

        private void Instituciones_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Instituciones_DataGridView.MultiSelect = false;
        }

        private void InstitucionesForm_Load(object sender, EventArgs e)
        {
            this.NombreTextBox.Select();
            this.Instituciones_DataGridView.MultiSelect = false;
        }
    }
}
