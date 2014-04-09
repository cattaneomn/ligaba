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
using System.Security.Cryptography;
using LigaBA.Clases;

namespace LigaBA.Abm_Jugador
{
    public partial class ModificarJugadorForm : Form
    {
        string id;
        string dni;
        string nombre;
        string apellido;
        string fecha_nacimiento;
        string institucion;
        string categoria;
        string equipo;
        string amarillas;
        string rojas;

        public ModificarJugadorForm(string id,string dni,string nombre,string apellido,string fecha_nac)//(string id,string dni,string nombre,string apellido,string fecha_nac,string amarillas,string rojas)
        {
            InitializeComponent();

            this.id = id;
            this.dni = dni;            
            this.nombre = nombre;
            this.apellido = apellido;
            this.fecha_nacimiento = fecha_nac;
            //this.amarillas = amarillas;
            //this.rojas = rojas;

            consultarEquipo(dni);

        }

        private void ModificarJugadorForm_Load(object sender, EventArgs e)
        {

            this.DniTextBox.Text = dni;
            this.NombreTextBox.Text = nombre;
            this.ApellidoTextBox.Text = apellido;
            this.FechaNacimeintiDateTimePicker.Text = this.fecha_nacimiento;
            this.AmarillasTextBox.Text = amarillas;
            this.RojasTextBox.Text = rojas;

            CargarInstitucionesComboBox();
            CargarCategoriaComboBox();

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@id", this.id));
            param.Add(new SqlParameter("@dni", this.DniTextBox.Text));
            param.Add(new SqlParameter("@dni_anterior", this.dni));
            param.Add(new SqlParameter("@nombre", this.NombreTextBox.Text));
            param.Add(new SqlParameter("@apellido", this.ApellidoTextBox.Text));
            param.Add(new SqlParameter("@fecha_de_nacimiento", this.FechaNacimeintiDateTimePicker.Value));              

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarJugador", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha modificado al jugador '" + DniTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            } 
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int Validaciones()
        {
            foreach (Control objeto in this.UsuariosGroupBox.Controls)
            {
                if (objeto is TextBox && ((TextBox)objeto).Text == "")
                {
                    MessageBox.Show("Debe completar los campos vacios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }          

            return 1;
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
       

        private void consultarEquipo(string dni)
        {
            string consulta = "SELECT Equipo.id as id,Equipo.institucion as institucion,Equipo.categoria as categoria FROM LigaBA.Equipo as Equipo INNER JOIN LigaBA.JugadorXEquipo ON equipo = Equipo.id WHERE jugador = " + id;
            List<SqlParameter> param = new List<SqlParameter>();

            DataTable ds = BaseDeDatos.GetInstance.ExecuteCustomQuery(consulta, param, "Equipo");

            this.equipo = ds.Rows[0]["id"].ToString();
            this.institucion = ds.Rows[0]["institucion"].ToString();
            this.categoria = ds.Rows[0]["categoria"].ToString();
        }

        private void CargarEquiposComboBox()
        {
            if (institucion != "" && categoria != "")
            {
                CargadorDeDatos.CargarEquipoComboBox(EquipoComboBox, this.Text, institucion, categoria);
            }
        }
        private void CargarInstitucionesComboBox()
        {
            CargadorDeDatos.CargarInstitucionComboBox(InstitucionComboBox, this.Text);
            InstitucionComboBox.SelectedValue = Convert.ToInt32(this.institucion);
        }

        private void CargarCategoriaComboBox()
        {
            CargadorDeDatos.CargarCategoriaComboBox(CategoriasComboBox, this.Text);
            CategoriasComboBox.SelectedValue = Convert.ToInt32(this.categoria);
        }   
    }
}
