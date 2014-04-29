using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


namespace LigaBA
{
    class BaseDeDatos
    {
        private static BaseDeDatos instance;
        private static SqlConnection connection;
        private string esquema;
        private List<string> listaDeCaracteresInvalidos = new List<string>();

        private BaseDeDatos(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            this.esquema = "LigaBA.";
            //Todo agregar caracteres invalidos
            this.listaDeCaracteresInvalidos.Add("'");
            this.listaDeCaracteresInvalidos.Add("--");
            this.listaDeCaracteresInvalidos.Add("#");
        }

        public static BaseDeDatos GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new BaseDeDatos(Configuracion.Instance.obtenerConnectionString());
                return instance;
            }
        }
        
        public bool ejecutarProcedimiento(string spName, List<SqlParameter> parameters,string NombreForm)
        {
            if (ValidarParametros(parameters))
            {
                SqlCommand cmd = null;
                bool Termine;
                try
                {
                    connection.Open();
                    cmd = new SqlCommand(this.esquema + spName, connection);
                    cmd.Parameters.AddRange(parameters.ToArray());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    Termine = true;
                    return Termine;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs.GetInstance.LogError(ex.Message, NombreForm);

                    Termine = false;
                    return Termine;

                }
                finally
                {
                    if (cmd != null) cmd.Connection.Close();
                }
            }
            else
            {
                return false;
            }
        }

        public DataSet ejecutarConsulta(string spName, List<SqlParameter> parameters,string nombre,string NombreForm)
        {
            if (ValidarParametros(parameters))
            {
                SqlDataAdapter da = null;
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    da = new SqlDataAdapter(this.esquema + spName, connection);
                    da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.Fill(ds, nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs.GetInstance.LogError(ex.Message, NombreForm);
                }
                finally
                {
                    if (da != null) da.SelectCommand.Connection.Close();
                }
                return ds;
            }else{
                return null;
            }
        }


        public DataSet ejecutarConsultaCargarDosTablas(string spName, List<SqlParameter> parameters, string nombre, string NombreForm,DataSet ds)
        {
            if (ValidarParametros(parameters))
            {
                SqlDataAdapter da = null;
                try
                {
                    connection.Open();
                    da = new SqlDataAdapter(this.esquema + spName, connection);
                    da.SelectCommand.Parameters.AddRange(parameters.ToArray());
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.Fill(ds, nombre);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs.GetInstance.LogError(ex.Message, NombreForm);
                }
                finally
                {
                    if (da != null) da.SelectCommand.Connection.Close();
                }
                return ds;
            }
            else
            {
                return null;
            }
        }

        public DataTable ExecuteCustomQuery(string strQuery, List<SqlParameter> parameters,string NombreForm)
        {
            if (ValidarParametros(parameters))
            {
                SqlDataAdapter da = null;
                try
                {
                    connection.Open();
                    da = new SqlDataAdapter(strQuery, connection);
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
            else
            {
                return null;
            }
        }       

        private bool ValidarParametros(List<SqlParameter> parametros)
        {
            foreach (SqlParameter param in parametros)
            {
                foreach (string caracterInvalido in listaDeCaracteresInvalidos)
                {
                    if (param.Value.ToString().Contains(caracterInvalido))
                    {
                        MessageBox.Show("Error la consulta contiene caracteres extraños.");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
