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


namespace LigaBA.Web
{
    public partial class PublicacionForm : Form
    {
        public PublicacionForm()
        {
            InitializeComponent();
        }

        List<string> tablas = new List<string>();
        string user;
        string password;
        string server;

        private void BuscarButton_Click(object sender, EventArgs e)
        {

           //Crear csv de tablas
           foreach (string tabla in tablas)
           {
                ExecuteCommand(ArmarConsulta(tabla));
           }

           //Enviar archivos
           SendFile();

           //Borrar csv de tablas
           foreach (string tabla in tablas)
           {
                DeleteFile(tabla);
           }
           
        }

        private void SendFile()
        {
            string address= "http://127.0.0.1:81/Ingeniar/Prueba.php";
            string filePath = ".\\institucion.csv";
            //string filePath = "C:\\Users\\sa\\Documents\\GitHub\\ligaba\\TO DO.txt";

            WebClient myWebClient = new WebClient();
            // Upload the file to the URL using the HTTP 1.0 POST.
            byte[] responseArray = myWebClient.UploadFile(address, "POST", filePath);

            richTextBox1.Text = System.Text.Encoding.ASCII.GetString(responseArray);
        }


        private string ArmarConsulta(string tabla)
        {
            string Command = "bcp \"select * from ligabadb.LigaBA." + tabla + "\" queryout \".\\" + tabla + ".csv\" -U "+ user + " -P " + password +" -c -S " + server;
            return Command;
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

        private void DeleteFile(string tabla)
        {
            if (System.IO.File.Exists(@".\\" + tabla + ".csv"))
            {
                try
                {
                    System.IO.File.Delete(@".\\" + tabla + ".csv");  
                }
                catch (System.IO.IOException e)
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
            tablas.Add("torneo");
            tablas.Add("torneoxcategoria");
            tablas.Add("torneoxcategoriaxjugador");
            tablas.Add("torneoxcategoriaxequipo");
            tablas.Add("usuarios");
            tablas.Add("partido");
            tablas.Add("partidoxjugador");
            tablas.Add("jugadorxequipo");
        }
    

/*
            private void Enviar(string[] args)
            {
                string URLAuth = "https://technet.rapaport.com/HTTP/Authenticate.aspx";
                WebClient webClient = new WebClient();

                NameValueCollection formData = new NameValueCollection();
                formData["Username"] = "myUser";
                formData["Password"] = "myPassword";

                byte[] responseBytes = webClient.UploadValues(URLAuth, "POST", formData);
                string resultAuthTicket = Encoding.UTF8.GetString(responseBytes);
                webClient.Dispose();

                string URL = "http://technet.rapaport.com/HTTP/Upload/Upload.aspx?Method=file";
                string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
                System.Net.WebRequest webRequest = System.Net.WebRequest.Create(URL);

                webRequest.Method = "POST";
                webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

                string FilePath = "C:\\test.csv";
                formData.Clear();
                formData["ticket"] = resultAuthTicket;
                formData["ReplaceAll"] = "false";

                Stream postDataStream = GetPostStream(FilePath, formData, boundary);

                webRequest.ContentLength = postDataStream.Length;
                Stream reqStream = webRequest.GetRequestStream();

                postDataStream.Position = 0;

                byte[] buffer = new byte[1024];
                int bytesRead = 0;

                while ((bytesRead = postDataStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                reqStream.Write(buffer, 0, bytesRead);
                }

                postDataStream.Close();
                reqStream.Close();

                StreamReader sr = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string Result = sr.ReadToEnd();
            }

            private static Stream GetPostStream(string filePath, NameValueCollection formData, string boundary)
            {
                Stream postDataStream = new System.IO.MemoryStream();

                //adding form data
                string formDataHeaderTemplate = Environment.NewLine + "--" + boundary + Environment.NewLine +
                "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment .NewLine + "{1}";

                foreach (string key in formData.Keys)
                {
                byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(string.Format(formDataHeaderTemplate,
                key, formData[key]));
                postDataStream.Write(formItemBytes, 0, formItemBytes.Length);
                }

                //adding file data
                FileInfo fileInfo = new FileInfo(filePath);

                string fileHeaderTemplate = Environment.NewLine + "--" + boundary + Environment.NewLine +
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                Environment.NewLine + "Content-Type: application/vnd.ms-excel" + Environment.NewLine + Environment.NewLine;

                byte[] fileHeaderBytes = System.Text.Encoding.UTF8.GetBytes(string.Format(fileHeaderTemplate,
                "UploadCSVFile", fileInfo.FullName));

                postDataStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);

                FileStream fileStream = fileInfo.OpenRead();

                byte[] buffer = new byte[1024];

                int bytesRead = 0;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                postDataStream.Write(buffer, 0, bytesRead);
                }

                fileStream.Close();

                byte[] endBoundaryBytes = System.Text.Encoding.UTF8.GetBytes("--" + boundary + "--");
                postDataStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);

                return postDataStream;
            }
            }*/
    
    }      
}
