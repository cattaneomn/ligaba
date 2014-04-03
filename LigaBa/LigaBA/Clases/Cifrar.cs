using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace LigaBA.Clases
{
    class Cifrar
    {
        public static void CifrarConnection()
        {
            Configuration cm = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConfigurationSection cs = cm.GetSection("connectionStrings");
            if (!cs.SectionInformation.IsProtected)
            {

                cs.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

                cs.SectionInformation.ForceSave = true;

                cm.Save(ConfigurationSaveMode.Full);

            }
        }
    }
}
