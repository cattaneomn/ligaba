using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace AplicationDesktop1
{
    class Logs
    {

        private static Logs instance;
        static StreamWriter log;

        public static Logs GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Logs();
                return instance;
            }
        }


        public void LogError(string ErrorLog,string Abm)
        {
            string Usuario = AplicationDesktop1.Properties.Settings.Default.user;
            string Fecha= Convert.ToString(System.DateTime.Now);

            string error = "[" + Usuario + "]-" + "[" + Fecha + "]-" + "[" + Abm + "]-" + "[" + ErrorLog + "]";
            
            try
            {
                if (!File.Exists("Logs.txt"))
                {
                    log = new StreamWriter("Logs.txt");
                }
                else
                {
                    log = File.AppendText("Logs.txt");
                    
                }

                log.WriteLine(error);
                log.Flush();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (log != null) { log.Close(); }
            }


        }

    }
}
