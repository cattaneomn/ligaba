﻿using System;
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

           //Zip files
           ZipFiles();

           //Enviar archivos
           SendFile();
  
           //Borrar csv de tablas
           foreach (string tabla in tablas)
           {
                DeleteFile(tabla,".csv");
           }

           DeleteFile("Send", ".zip");
        }

        private void SendFile()
        {
            string address= "http://127.0.0.1:81/Ingeniar/Prueba.php";
            string filePath = ".\\Send.zip";
       
            WebClient myWebClient = new WebClient();
            // Upload the file to the URL using the HTTP 1.0 POST.
            byte[] responseArray = myWebClient.UploadFile(address, "POST", filePath);

            richTextBox1.Text = System.Text.Encoding.ASCII.GetString(responseArray);
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

        private void DeleteFile(string tabla,string extension)
        {
            if (System.IO.File.Exists(@".\\" + tabla + extension))
            {
                try
                {
                    System.IO.File.Delete(@".\\" + tabla + extension);  
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
            tablas.Add("partido");
            tablas.Add("partidoxjugador");
            tablas.Add("jugadorxequipo");
        }
    
    }      
}
