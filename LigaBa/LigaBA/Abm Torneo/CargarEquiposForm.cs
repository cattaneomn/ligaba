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
        string nombre;
        string tipodetorneo;
        string tablageneral;
        string tipodetablageneral;

        DataTable tablaDeEquipos;

        public CargarEquiposForm(CheckedListBox Instituciones, CheckedListBox Categorias,string nombre,string tipodetorneo,string tablageneral,string tipodetablageneral)
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

            this.nombre = nombre;
            this.tipodetorneo = tipodetorneo;
            this.tablageneral = tablageneral;
            this.tipodetablageneral = tipodetablageneral;

        }

        private void CargarEquiposForm_Load(object sender, EventArgs e)
        {
            ConsultarEquipos();
            ModDataGridView.agregarCheckbox(Equipos_DataGridView, "Seleccionado");
        }        

        private void ConsultarEquipos()
        {
            string institucionesConsulta = ConsultarInstituciones();
            string categoriasConsulta = ConsultarCategorias();

            string consulta = "SELECT E.id as id,C.id as idCat,E.nombre as Equipo,I.nombre as Institucion,C.nombre as Categoria,1 as elegido FROM LigaBA.Equipo as E ";

            consulta += "INNER JOIN LigaBA.Categoria as C ON E.categoria = C.id ";
            consulta += "INNER JOIN LigaBA.Institucion as I ON E.institucion=I.id ";
            consulta += "WHERE E.institucion IN ("+institucionesConsulta+") AND ";
            consulta += " E.categoria IN (" + categoriasConsulta + ")";
            consulta += " ORDER BY C.nombre";

            List<SqlParameter> param = new List<SqlParameter>();

            this.tablaDeEquipos = BaseDeDatos.GetInstance.ExecuteCustomQuery(consulta, param, this.Text);
            Equipos_DataGridView.DataSource = tablaDeEquipos;
            this.Equipos_DataGridView.Columns["id"].Visible = false;
            this.Equipos_DataGridView.Columns["idCat"].Visible = false;
            this.Equipos_DataGridView.Columns["elegido"].Visible = false;
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

        private void EquipoTextBox_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void InstitucionTextBox_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void CategoriasTextBox_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            ((DataTable)Equipos_DataGridView.DataSource).DefaultView.RowFilter = FiltroCambios();
            actualizarCheckBoxsDeDataGrid();
        }
        private string FiltroCambios()
        {
            string consulta = "";

            if (this.EquipoTextBox.Text != "")
            {
                 consulta += "Equipo LIKE '%" + this.EquipoTextBox.Text + "%'";
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
                        cambiarEstadoEnTablaDeEquipos(Equipos_DataGridView.CurrentRow.Cells["id"].Value.ToString(),"0");
                        break;
                    case "False":
                        ch1.Value = true;
                        cambiarEstadoEnTablaDeEquipos(Equipos_DataGridView.CurrentRow.Cells["id"].Value.ToString(), "1");
                        break;
                }
           }
        }

        private void cambiarEstadoEnTablaDeEquipos(string id_equipo, string estado)//estado 0 o 1
        {
            foreach (DataRow row in this.tablaDeEquipos.Rows)
            {
                if (row["id"].ToString() == id_equipo)
                {
                    row["elegido"] = estado;
                }
            }
        }

        private void actualizarCheckBoxsDeDataGrid()
        {
            Equipos_DataGridView.Columns.Remove(Equipos_DataGridView.Columns["Seleccionado"]);
            ModDataGridView.agregarCheckbox(Equipos_DataGridView, "Seleccionado");
            foreach (DataGridViewRow row in Equipos_DataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells[6];
                string valor = obtenerValorDeCheckBox(row.Cells["id"].Value.ToString());
                if(valor != "")
                {
                    checkBox.Value = (valor=="0" ? false : true);
                }
            }
        }

        private string obtenerValorDeCheckBox(string id)
        {
            foreach (DataRow row in this.tablaDeEquipos.Rows)
            {
                if (row["id"].ToString() == id)
                {
                    return row["elegido"].ToString();
                }
            }
            return "";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@nombre", nombre));
            param.Add(new SqlParameter("@tipodetorneo", tipodetorneo));
            param.Add(new SqlParameter("@tablageneral", tablageneral));
            param.Add(new SqlParameter("@tipodetablageneral", tipodetablageneral));
            SqlParameter respuestaParametro = new SqlParameter("@respuesta", -1);
            respuestaParametro.Direction = ParameterDirection.Output;
            param.Add(respuestaParametro);

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaTorneo", param, this.Text);

            object respuestaSP = respuestaParametro.Value;
            int respuesta = Convert.ToInt32(respuestaSP);
      
            if (TerminoBien == true)
            {
               // MessageBox.Show("Se ha creado el torneo '" + nombre + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TerminoBien = InsertarTorneoXCategoria(respuesta);
                DialogResult = DialogResult.OK;
            } 
        }

        private bool InsertarTorneoXCategoria(int respuesta)
        {

            bool TerminoBien = true;

            foreach (string categoria in CategoriasLista)
            {
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@torneogeneral", respuesta));
                param.Add(new SqlParameter("@categoria", categoria));
                SqlParameter respuestaParametro = new SqlParameter("@respuesta", -1);
                respuestaParametro.Direction = ParameterDirection.Output;
                param.Add(respuestaParametro);

                TerminoBien &= BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaTorneoXCategoria", param, this.Text);

                object respuestaSP = respuestaParametro.Value;
                respuesta = Convert.ToInt32(respuestaSP);


                if (TerminoBien == true)
                {
                    
                    TerminoBien &= InsertarTorneoXCategoriaXEquipo(respuesta);
                }
            }
            return TerminoBien;
        }

        private bool InsertarTorneoXCategoriaXEquipo(int respuesta)
        {

            bool TerminoBien = true;

            foreach (DataGridViewRow row in Equipos_DataGridView.Rows)
            {
                if (row.Cells["Seleccionado"].Value.ToString() == "True")
                {
                    string equipo = row.Cells["id"].Value.ToString();
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@torneoxcategoria", respuesta));
                    param.Add(new SqlParameter("@equipo", equipo));
                    
                    TerminoBien &= BaseDeDatos.GetInstance.ejecutarProcedimiento("p_AltaTorneoXCategoriaXEquipo", param, this.Text);

                    if (TerminoBien == true)
                    {
                        MessageBox.Show("Se ha creado el torneo '" + nombre + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            return TerminoBien;
        }

        private int Validaciones()
        {
            foreach (string categoria in CategoriasLista)
            {
                int cantEquipos=0;
                foreach (DataGridViewRow row in Equipos_DataGridView.Rows)
                {
                    if (row.Cells["Seleccionado"].Value.ToString() == "True" && row.Cells["idCat"].Value.ToString() == categoria)
                    {
                        cantEquipos++;
                    }
                }
                if (cantEquipos <= 1)
                {
                    MessageBox.Show("Error: debe seleccionar al menos 2(dos) equipos de cada categoria elegida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            
            return 1;
        }

    }
}
