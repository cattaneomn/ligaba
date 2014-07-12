using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using Ionic;
using Ionic.Zip;
using Ionic.BZip2;
using Ionic.Crc;
using Ionic.Zlib;
using LigaBA.Clases;
using System.Collections.Specialized;
using System.Threading;


namespace LigaBA.Web
{
    public partial class PublicacionesForm : Form
    {
        public PublicacionesForm()
        {
            InitializeComponent();
        }

        List<string> tablas = new List<string>();
        string user;
        string password;
        string server;
        string consulta;
        string consultaTorneo;

        public static string usernameWeb;
        public static string passwordWeb;

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            if (!Validar()) { return; };

            LoginWebForm abrir = new LoginWebForm();
            DialogResult Resultado = abrir.ShowDialog();
      

            if (Resultado == DialogResult.OK)
            {
            
                Thread hilo = new Thread(Start);
                hilo.SetApartmentState(System.Threading.ApartmentState.STA);
                CheckForIllegalCrossThreadCalls = false;
                hilo.Start();
            }
            
        }

        private void Start()
        {
            this.BuscarButton.Enabled = false;
            this.UseWaitCursor = true;

            ArmarQuery();

            //Crear csv de tablas
            foreach (string tabla in tablas)
            {
                ExecuteCommand(ArmarConsulta(tabla));
            }

            //Zip files
            ZipFiles();

            //Enviar archivos
            SendFile();

            //Borrar csv de tablas
            foreach (string tabla in tablas)
            {
                DeleteFile(tabla, ".csv");
            }

            DeleteFile("Send", ".zip");
            
            LimpiarCheckBoxList();

            this.BuscarButton.Enabled = true;
        }

        private bool Validar()
        {
            if (TorneosCheckedListBox.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar al menos un torneo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }


        private void LimpiarCheckBoxList()
        {
            for (int i = 0; i < this.TorneosCheckedListBox.Items.Count; i++)
            {
                this.TorneosCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);

            }
        }
        
        private void ArmarQuery()
        {
            string torneo = " torneogeneral = ";
            string columnaId = "id = ";
            string conector = " OR ";
            consultaTorneo = "SELECT * FROM ligabadb.Ligaba.torneo WHERE ";
            consulta = "SELECT id FROM ligabadb.Ligaba.torneoxcategoria WHERE ";
            int contador = 0;

            foreach (var itemChecked in this.TorneosCheckedListBox.CheckedItems)
            {
                if (contador == 0)
                {
                    var row = (itemChecked as DataRowView).Row;
                    consultaTorneo += columnaId + row["id"].ToString();
                    consulta += torneo + row["id"].ToString();
                    contador++;
                }
                else
                {
                    var row = (itemChecked as DataRowView).Row;
                    consultaTorneo += conector + columnaId + row["id"].ToString();
                    consulta += conector + torneo + row["id"].ToString(); 
                    contador++;
                }
            }

        }

        private void SendFile()
        {
            try
            {
                string address = Properties.Settings.Default.Url;
                string filePath = ".\\Send.zip";
                NameValueCollection parameters = new NameValueCollection();
                WebClient myWebClient = new WebClient();

                parameters.Add("xx", usernameWeb);
                parameters.Add("yy", passwordWeb);
                myWebClient.QueryString = parameters;
            
                // Upload the file to the URL using the HTTP 1.0 POST.
                byte[] responseArray = myWebClient.UploadFile(address, "POST", filePath);

                this.UseWaitCursor = false;
                
               string respuesta = System.Text.Encoding.ASCII.GetString(responseArray); 
               
                //mostrar respuesta.
                if (respuesta == "1La actualizacion fue exitosa.")
                {
                    MessageBox.Show("La actualizacion se realizo con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Logs.GetInstance.LogError(respuesta, "Publicacion Web");
                    MessageBox.Show("Hubo un error al realizar la actualizacion, por favor vuelva a intentarlo.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void ZipFiles()
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (string tabla in tablas)
                {
                    // add a named entry to the zip file, using a string for content
                    zip.AddFile(tabla + ".csv", ".\\");
                }
                zip.Save(".\\Send.zip");
            }
        }

        private string ArmarConsulta(string tabla)
        {
            string query = " WHERE torneoxcategoria IN (";
            string queryTorneoXCategoria = " WHERE id IN (";
            string queryPartidoxjugador = " WHERE partido IN (SELECT id FROM LigaBA.Partido ";
            string Command;
            if (tabla != "torneo" && tabla != "torneoxcategoria" &&
                tabla != "torneoxcategoriaxequipo" && tabla != "torneoxcategoriaxjugador" && tabla != "partido")
            {
                Command = "bcp \"select * from ligabadb.LigaBA." + tabla + "\" queryout \".\\" + tabla + ".csv\" -U " + user + " -P " + password + " -c -S " + server;
                return Command;
            }
            else
            {
                if (tabla == "torneo")
                {
                    Command = "bcp \"" + consultaTorneo + "\" queryout \".\\" + tabla + ".csv\" -U " + user + " -P " + password + " -c -S " + server;
                    return Command;

                }
                if (tabla == "torneoxcategoria")
                {
                    Command = "bcp \"select * from ligabadb.LigaBA." + tabla + queryTorneoXCategoria + consulta + ")" + "\" queryout \".\\" + tabla + ".csv\" -U " + user + " -P " + password + " -c -S " + server;
                    return Command;

                }
                if (tabla == "partidoxjugador")
                {
                    Command = "bcp \"select * from ligabadb.LigaBA." + tabla + queryPartidoxjugador + query + consulta + ")" + "\" queryout \".\\" + tabla + ".csv\" -U " + user + " -P " + password + " -c -S " + server;
                    return Command;
                }

                    Command = "bcp \"select * from ligabadb.LigaBA." + tabla + query + consulta + ")" + "\" queryout \".\\" + tabla + ".csv\" -U " + user + " -P " + password + " -c -S " + server;
                    return Command;

            }
        }

        static void ExecuteCommand(string _Command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = true;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            string result = proc.StandardOutput.ReadToEnd();
            //Muestra en pantalla la salida del Comando
            Console.WriteLine(result);
        }

        private void DeleteFile(string tabla,string extension)
        {
            if (System.IO.File.Exists(@".\\" + tabla + extension))
            {
                try
                {
                    System.IO.File.Delete(@".\\" + tabla + extension);  
                }
                catch 
                {
                    return;
                }
            }
        }


        private string GetValue(string connectionString, params string[] keyAliases)
        {
            var keyValuePairs = connectionString.Split(';')
                                                .Where(kvp => kvp.Contains('='))
                                                .Select(kvp => kvp.Split(new char[] { '=' }, 2))
                                                .ToDictionary(kvp => kvp[0].Trim(),
                                                              kvp => kvp[1].Trim(),
                                                              StringComparer.InvariantCultureIgnoreCase);
            foreach (var alias in keyAliases)
            {
                string value;
                if (keyValuePairs.TryGetValue(alias, out value))
                    return value;
            }
            return string.Empty;
        }

        private void PublicacionForm_Load(object sender, EventArgs e)
        {
            //coneccion
            string connectionString = Configuracion.Instance.obtenerConnectionString();
            server = GetValue(connectionString, "Data Source");
            user = GetValue(connectionString, "User ID");
            password = GetValue(connectionString, "Password");

            //Carga Tablas
            tablas.Add("categoria");
            tablas.Add("institucion");
            tablas.Add("equipo");
            tablas.Add("jugador");
            tablas.Add("tipodetorneo");
            tablas.Add("jugadorxequipo");
            tablas.Add("torneo");
            tablas.Add("torneoxcategoria");
            tablas.Add("torneoxcategoriaxjugador");
            tablas.Add("torneoxcategoriaxequipo");
            tablas.Add("partido");
            tablas.Add("partidoxjugador");
            

            CargadorDeDatos.CargarTorneosCheckedListBox(TorneosCheckedListBox, this.Text);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }      
}
