using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LigaBA.Clases;


namespace LigaBA.Abm_Torneo
{
    public partial class CargarEquiposForm : Form
    {

        List<string> CategoriasLista = new List<string>();
        List<string> InstitucionesLista = new List<string>();

        public CargarEquiposForm(CheckedListBox Instituciones, CheckedListBox Categorias)
        {
            InitializeComponent();

            foreach (var itemChecked in Categorias.CheckedItems)
            {
                var row = (itemChecked as DataRowView).Row;
                CategoriasLista.Add(row["id"].ToString());
            }
            foreach (var itemChecked in Instituciones.CheckedItems)
            {
                var row = (itemChecked as DataRowView).Row;
                InstitucionesLista.Add(row["id"].ToString());
            }
        }

         


        private void CargarEquiposForm_Load(object sender, EventArgs e)
        {
            ConsultarEquipos();
            ModDataGridView.agregarCheckbox(Equipos_DataGridView, "Seleccionado");

        }

        DataTable dt;

        private void ConsultarEquipos()
        {
            string institucionesConsulta = ConsultarInstituciones();
            string categoriasConsulta = ConsultarCategorias();

            string consulta = "SELECT E.id as id,E.nombre as Equipo,I.nombre as Institucion,C.nombre as Categoria FROM LigaBA.Equipo as E ";

            consulta += "INNER JOIN LigaBA.Categoria as C ON E.categoria = C.id ";
            consulta += "INNER JOIN LigaBA.Institucion as I ON E.institucion=I.id ";
            consulta += "WHERE E.institucion IN ("+institucionesConsulta+") AND ";
            consulta += " E.categoria IN (" + categoriasConsulta + ")";
            consulta += " ORDER BY C.nombre";

            List<SqlParameter> param = new List<SqlParameter>();

            dt = BaseDeDatos.GetInstance.ExecuteCustomQuery(consulta, param, this.Text);
            Equipos_DataGridView.DataSource = dt;
            this.Equipos_DataGridView.Columns["id"].Visible = false;
            this.Equipos_DataGridView.Focus();
        }

        private string ConsultarInstituciones()
        {
            string consulta = "SELECT id FROM LigaBA.Institucion WHERE ";

            foreach (string id in InstitucionesLista)
            {
                if ((InstitucionesLista.Count-1) != InstitucionesLista.IndexOf(id))
                {
                    consulta += "id=" + id + " OR ";
                }
                else
                {
                    consulta += "id=" + id;
                }
            }

            return consulta;
        }
        private string ConsultarCategorias()
        {
            string consulta = "SELECT id FROM LigaBA.Categoria WHERE ";

            foreach (string id in CategoriasLista)
            {
                if ((CategoriasLista.Count-1) != CategoriasLista.IndexOf(id))
                {
                    consulta += "id=" + id + " OR ";
                }
                else
                {
                    consulta += "id=" + id;
                }
            }

            return consulta;
        }

        private void FiltroTextBox_TextChanged(object sender, EventArgs e)
        {
                dt.DefaultView.RowFilter = FiltroCambios();
                this.Equipos_DataGridView.DataSource = dt;
        }

        private void InstitucionTextBox_TextChanged(object sender, EventArgs e)
        {
                dt.DefaultView.RowFilter = FiltroCambios();
                this.Equipos_DataGridView.DataSource = dt;    
        }

        private void CategoriasTextBox_TextChanged(object sender, EventArgs e)
        {  
                dt.DefaultView.RowFilter = FiltroCambios();
                this.Equipos_DataGridView.DataSource = dt; 
        }

        private string FiltroCambios()
        {
            string consulta = "";

            if (this.FiltroTextBox.Text != "")
            {
                 consulta += "Equipo LIKE '%" + this.FiltroTextBox.Text + "%'";
            }
            
            if (this.CategoriasTextBox.Text != "")
            {
                if (consulta != "") { consulta += " AND "; }
                consulta += "Categoria LIKE '%" + this.CategoriasTextBox.Text + "%'";
            }
            
            if (this.InstitucionTextBox.Text != "")
            {
                if (consulta != "") { consulta += " AND "; }
                consulta += "Institucion LIKE '%" + this.InstitucionTextBox.Text + "%'";
            }
            return consulta;
        }

        private void Equipos_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.ColumnIndex == this.Equipos_DataGridView.Columns["Seleccionado"].Index && e.RowIndex >= 0)
            {

                DataGridViewCheckBoxCell ch1 = (DataGridViewCheckBoxCell) Equipos_DataGridView.CurrentRow.Cells["Seleccionado"];

                if (ch1.Value == null)
                    ch1.Value = false;
                switch (ch1.Value.ToString())
                {
                    case "True":
                        ch1.Value = false;
                        break;
                    case "False":
                        ch1.Value = true;
                        break;
                }
           }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

        }
      

    }
}
