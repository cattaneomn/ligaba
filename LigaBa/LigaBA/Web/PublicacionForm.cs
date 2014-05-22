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
            string Consulta1 = "select * from liga.institucion";

            List<SqlParameter> param1 = new List<SqlParameter>();

            DataTable Dt = BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta1, param1, this.Text);


            ColumnMapItem id = new ColumnMapItem();
            ColumnMapItem nombre = new ColumnMapItem();
            ColumnMapItem direccion = new ColumnMapItem();
            ColumnMapItem localidad = new ColumnMapItem();
            ColumnMapItem delegado = new ColumnMapItem();
            ColumnMapItem coordinador = new ColumnMapItem();
            ColumnMapItem telefono = new ColumnMapItem();
            ColumnMapItem email = new ColumnMapItem();
            ColumnMapItem borrado = new ColumnMapItem();



            id.DataType = "int";
            id.DestinationColumn = "id";
            id.SourceColumn = "id";

            nombre.DataType = "text";
            nombre.DestinationColumn = "nombre";
            nombre.SourceColumn = "nombre";


            direccion.DataType = "text";
            direccion.DestinationColumn = "direccion";
            direccion.SourceColumn = "direccion";


            delegado.DataType = "text";
            delegado.DestinationColumn = "delegado";
            delegado.SourceColumn = "delegado";


            coordinador.DataType = "text";
            coordinador.DestinationColumn = "coordinador";
            coordinador.SourceColumn = "coordinador";

            telefono.DataType = "text";
            telefono.DestinationColumn = "telefono";
            telefono.SourceColumn = "telefono";

            email.DataType = "text";
            email.DestinationColumn = "email";
            email.SourceColumn = "email";

            borrado.DataType = "int";
            borrado.DestinationColumn = "borrado";
            borrado.SourceColumn = "borrado";


            ColumnMapItemCollection collection = new ColumnMapItemCollection();
            collection.Add(id);
            collection.Add(nombre);
            collection.Add(direccion);
            collection.Add(localidad);
            collection.Add(delegado);
            collection.Add(coordinador);
            collection.Add(telefono);
            collection.Add(email);
            collection.Add(borrado);


            MySqlBulkCopy upload = new MySqlBulkCopy();
            upload.DestinationTableName = "session";
            upload.Upload(reader);
            reader.Close();
            connection.Close();
            connection.Dispose();
            sourceConnection.Close();
            sourceConnection.Dispose();



            if (Equipos_DataGridView.DataSource == null)
            {
                MessageBox.Show("No se encontraron resultados que coincidan con la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        
    
    
    
    
    }      
}
