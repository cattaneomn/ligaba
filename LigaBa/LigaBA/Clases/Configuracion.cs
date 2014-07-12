using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaBA
{
    class Configuracion
    {
        private static Configuracion instance;

        public static Configuracion Instance
        {
            get
            {
                if (instance == null)
                    instance = new Configuracion();
                return instance;
            }
        }

        public string obtenerConnectionString()
        {
            return LigaBA.Properties.Settings.Default.ConnectionString;
        }

    }
}
