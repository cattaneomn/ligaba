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

using LigaBA.Clases;
using System.Threading;

namespace LigaBA.Abm_Jugador
{
    public partial class JugadorForm : Form
    {

        private string institucion;
        private string categoria;

        string nombre;
        string dni;
        string institucionNombre;
        string fecha_de_nacimiento;

        public JugadorForm()
        {
            InitializeComponent();
        }        

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            foreach (Control objeto in this.JugadorGroupBox.Controls)
            {
                if (objeto is TextBox)
                {
                    ((TextBox)objeto).Clear();
                }
                if (objeto is ComboBox)
                {
                    ((ComboBox)objeto).SelectedItem = null;
                }
            }

            this.EquipoComboBox.DataSource = null;
            this.EquipoComboBox.Enabled = false;

            ModDataGridView.limpiarDataGridView(Jugador_DataGridView, "");
            this.FechaNacimientoDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.FechaNacimientoDateTimePicker.CustomFormat = " ";

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BuscarButton_Click(object sender, EventArgs e)
        {

            if (Validaciones())
            {
                string equipo = "";
                string institucion = "";
                string categoria = "";

                if (EquipoComboBox.SelectedValue != null)
                {
                    equipo = this.EquipoComboBox.SelectedValue.ToString();
                }
                if(InstitucionComboBox.SelectedValue != null)
                {
                    institucion = InstitucionComboBox.SelectedValue.ToString();
                }
                if(CategoriasComboBox.SelectedValue != null)
                {
                    categoria = CategoriasComboBox.SelectedValue.ToString();
                }

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@dni", DniTextBox.Text));
                param.Add(new SqlParameter("@nombre", NombreTextBox.Text));
                param.Add(new SqlParameter("@apellido", ApellidoTextBox.Text));
                param.Add(new SqlParameter("@fecha_de_nacimiento", FechaNacimientoDateTimePicker.Text));
                param.Add(new SqlParameter("@institucion", institucion ));
                param.Add(new SqlParameter("@categoria", categoria));
                param.Add(new SqlParameter("@equipo", equipo));

                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarJugador", param, "Jugadores", this.Text);

                if (ds.Tables["Jugadores"].Rows.Count == 0)
                {
                    this.Jugador_DataGridView.DataSource = null;
                    MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Jugador_DataGridView.DataSource = ds.Tables["Jugadores"];
                this.Jugador_DataGridView.Columns["Fecha de Nacimiento"].Width = 170;
                //this.Jugador_DataGridView.Columns["Tarjetas Amarillas"].Width = 150;
                //this.Jugador_DataGridView.Columns["Tarjetas Rojas"].Width = 125;
                this.Jugador_DataGridView.Columns["id"].Visible = false;
                this.Jugador_DataGridView.Columns["Institucion"].Visible = false;
                this.Jugador_DataGridView.Focus();
            }

        }

        private bool Validaciones()
        {
            
            return true;
        }


        private void AgregarButton_Click(object sender, EventArgs e)
        {
            AltaJugadorForm abrir = new AltaJugadorForm();
            abrir.ShowDialog();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (this.Jugador_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Jugador_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string JugadorBorrado =Jugador_DataGridView.CurrentRow.Cells["Id"].Value.ToString();

            DialogResult Resultado = MessageBox.Show("¿Esta seguro que desea eliminar al jugador '" + JugadorBorrado + "'?",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resultado == DialogResult.Yes)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@id", Convert.ToInt32(Jugador_DataGridView.CurrentRow.Cells["Id"].Value)));
                bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BajaJugador", param, this.Text);

                if (TerminoBien == true)
                {
                    
                    Jugador_DataGridView.Rows.Remove(Jugador_DataGridView.CurrentRow);
                    MessageBox.Show("Se ha dado de baja al jugador '" + JugadorBorrado + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Jugador_DataGridView.DataSource = null;
                }
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            if(this.Jugador_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Jugador_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ModificarJugadorForm abrir = new ModificarJugadorForm(
                                                                    Jugador_DataGridView.CurrentRow.Cells["Id"].Value.ToString(),
                                                                   Jugador_DataGridView.CurrentRow.Cells["DNI"].Value.ToString(),
                                                                   Jugador_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString(),
                                                                   Jugador_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString(),
                                                                   Jugador_DataGridView.CurrentRow.Cells["Fecha de Nacimiento"].Value.ToString()                                                                 
                                                                   //Jugador_DataGridView.CurrentRow.Cells["Tarjetas Amarillas"].Value.ToString(),
                                                                   //Jugador_DataGridView.CurrentRow.Cells["Tarjetas Rojas"].Value.ToString()                
                                                                  );
            abrir.ShowDialog();
        }

        private void JugadorForm_Load(object sender, EventArgs e)
        {
            this.Jugador_DataGridView.MultiSelect = false;
            CargarInstitucionesComboBox();
            CargarCategoriaComboBox();

            this.FechaNacimientoDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.FechaNacimientoDateTimePicker.CustomFormat = " ";
        }


        private void CargarEquiposComboBox()
        {
            if (institucion != null && categoria != null)
            {
                CargadorDeDatos.CargarEquipoComboBox(EquipoComboBox, this.Text, institucion, categoria);
                this.EquipoComboBox.Enabled = true;
            }
            else
            {
                this.EquipoComboBox.Enabled = false;
            }
        }

        private void CargarInstitucionesComboBox()
        {
            CargadorDeDatos.CargarInstitucionComboBox(InstitucionComboBox, this.Text);
        }

        private void CargarCategoriaComboBox()
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
        }

        private void FechaNacimientoDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            this.FechaNacimientoDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.Jugador_DataGridView.Rows.Count == 0)
            {
                return;
            }
            if (this.Jugador_DataGridView.CurrentCell == null)
            {
                MessageBox.Show("Debe seleccionar una fila.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.nombre = Jugador_DataGridView.CurrentRow.Cells["Nombre"].Value.ToString() + " " + Jugador_DataGridView.CurrentRow.Cells["Apellido"].Value.ToString();
            this.dni = Jugador_DataGridView.CurrentRow.Cells["Dni"].Value.ToString();
            this.institucionNombre = Jugador_DataGridView.CurrentRow.Cells["Institucion"].Value.ToString();
            this.fecha_de_nacimiento = Convert.ToDateTime(Jugador_DataGridView.CurrentRow.Cells["Fecha de Nacimiento"].Value.ToString()).Date.ToShortDateString();
                                                                   
            Thread hilo = new Thread(AbrirFormReporte);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start(); 
        }

        private void AbrirFormReporte()
        {

            ReporteForm abrir = new ReporteForm(nombre,dni,institucionNombre,fecha_de_nacimiento);
            abrir.ShowDialog();
        }

        private void InstitucionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ControlarComboBoxNull();
            CargarEquiposComboBox();
        }

        private void CategoriasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ControlarComboBoxNull();
            CargarEquiposComboBox();
        }

        private void ControlarComboBoxNull()
        {
            if (InstitucionComboBox.SelectedItem != null)
            {
                this.institucion = InstitucionComboBox.SelectedValue.ToString();
            }
            else
            {
                this.institucion = null;
            }

            if (CategoriasComboBox.SelectedItem != null)
            {
                this.categoria = CategoriasComboBox.SelectedValue.ToString();
            }
            else
            {
                this.categoria = null;
            }
        }

    }
}
