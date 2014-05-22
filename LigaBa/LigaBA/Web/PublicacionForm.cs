using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using MySql.Data.MySqlClient;

using IndiansInc;
using IndiansInc.Internals;

namespace LigaBA.Web
{
    public partial class PublicacionForm : Form
    {
        public PublicacionForm()
        {
            InitializeComponent();
        }

        
        MySqlConnection Connection = new MySqlConnection();
        string connectionString;


        DataTable ExecuteCustomQuery(string strQuery, List<SqlParameter> parameters, string NombreForm)
        {
                MySqlDataAdapter da = null;
                try
                {
                    connectionString = "Server=127.0.0.1; Port=3306; Database=ligabadbweb ;Uid=root; Pwd=;";
                    Connection.ConnectionString = connectionString;
                    Connection.Open();
                    da = new MySqlDataAdapter(strQuery, Connection);
                    da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                    da.SelectCommand.CommandType = CommandType.Text;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        return dt;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    Logs.GetInstance.LogError(ex.Message, NombreForm);
                    throw new Exception("Hubo inconvenientes al querer ejecutar la query: '" + strQuery + "'", ex);
                    // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    if (da != null) da.SelectCommand.Connection.Close();
                }
            }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

        
            string Consulta = "Select * from ligabadbweb.institucion";

            List<SqlParameter> param = new List<SqlParameter>();

            Equipos_DataGridView.DataSource = ExecuteCustomQuery(Consulta, param, this.Text);


            if (Equipos_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        
    
    
    
    
    }      
}
