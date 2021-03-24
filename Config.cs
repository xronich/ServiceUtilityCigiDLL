using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ServiceUtilityCigiDLL
{
    public class Config
    {
        private Dictionary<int, string> idHostConfig = new Dictionary<int, string>();
        public int Port { get; private set; }
        public int HostCount { get { return idHostConfig != null ? idHostConfig.Count : 0; } }
        public bool Init { get; private set; }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getConfig();

        public Dictionary<int, string> getIdHostConfig()
        {
            return idHostConfig;
        }

        public void LoadConfig()
        {
            IntPtr resultString = getConfig();

            if (resultString == null)
                return;

            Dictionary<string, string> configDict = resultString.ToStringString();

            if (configDict["SharedMemoryInit"] == "1")
            {
                Port = Int32.Parse(configDict["LogPort"]);

                idHostConfig = configDict["IdHostMessage"].ToIntString();

                Init = true;
            }
            else
                Init = false;
        }
    }
}
