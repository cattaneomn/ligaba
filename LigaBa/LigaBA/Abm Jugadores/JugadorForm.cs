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

namespace LigaBA.Abm_Jugador
{
    public partial class JugadorForm : Form
    {

        private string institucion;
        private string categoria;

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
            }

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

                if (this.EquipoComboBox.SelectedValue != null)
                {
                    equipo = this.EquipoComboBox.SelectedValue.ToString();
                }

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@dni", DniTextBox.Text));
                param.Add(new SqlParameter("@nombre", NombreTextBox.Text));
                param.Add(new SqlParameter("@apellido", ApellidoTextBox.Text));
                param.Add(new SqlParameter("@fecha_de_nacimiento", FechaNacimientoDateTimePicker.Text));
                param.Add(new SqlParameter("@equipo", equipo));

                DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_BuscarJugador", param, "Jugadores", this.Text);

                if (ds.Tables["Jugadores"].Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                Jugador_DataGridView.DataSource = ds.Tables["Jugadores"];
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
                                                                   Jugador_DataGridView.CurrentRow.Cells["Fecha_de_Nacimiento"].Value.ToString(),                                                                 
                                                                   Jugador_DataGridView.CurrentRow.Cells["Tarjetas_Amarillas"].Value.ToString(),
                                                                   Jugador_DataGridView.CurrentRow.Cells["Tarjetas_Rojas"].Value.ToString()                
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

        private void InstitucionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (InstitucionComboBox.SelectedValue != null)
            {
                this.institucion = InstitucionComboBox.SelectedValue.ToString();
                CargarEquiposComboBox();
            }            
        }

        private void CategoriasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoriasComboBox.SelectedValue != null)
            {
                this.categoria = CategoriasComboBox.SelectedValue.ToString();
                CargarEquiposComboBox();
            } 
        }

        private void CargarEquiposComboBox()
        {
            CargadorDeDatos.CargarEquipoComboBox(InstitucionComboBox, this.Text,institucion,categoria);
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

    }
}
