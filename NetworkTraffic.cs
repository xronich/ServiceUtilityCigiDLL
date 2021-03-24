using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public class NetworkTraffic
    {
        public event Action DcsStartEvent;
        public event Action DcsStopEvent;

        private Dictionary<string, float> idDataSend = new Dictionary<string, float>();

        private ListView networkTraffic_listView;
        private TextBox packageSize_textBox;
        private TextBox speed_textBox;
        private Config config;

        private int hostCount = 0;
        private int packageSize = 0;
        private int totalByte = 0;
        private int prevTotalByte = 0;
        private string idDatasendMessage = "";
        private bool init;

        public NetworkTraffic(Config Config, ListView NetworkTraffic_listView, TextBox PackageSize_textBox, TextBox Speed_textBox)
        {
            config = Config;

            networkTraffic_listView = NetworkTraffic_listView;
            packageSize_textBox = PackageSize_textBox;
            speed_textBox = Speed_textBox;
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getNetworkTraffic();

        public void updateNetworkTraffic()
        {
            networkTraffic_listView.Items.Clear();

            IntPtr resultString = getNetworkTraffic();

            if (resultString == null)
                return;

            Dictionary<string, string> networkTrafficDict = resultString.ToStringString();

            if (networkTrafficDict["SharedMemoryInit"] == "1")
            {
                if(!init)
                    DcsStartEvent?.Invoke();

                enableControls(true);

                hostCount = networkTrafficDict["HostCount"].ToInt32();
                packageSize = networkTrafficDict["PackageSize"].ToInt32();
                totalByte = networkTrafficDict["TotalByte"].ToInt32();
                idDatasendMessage = networkTrafficDict["IpDatasendMessage"];

                idDataSend = idDatasendMessage.ToStringFloat();
                updateControls();
                prevTotalByte = totalByte;
                init = true;
            }
            else
            {
                if (!init)
                    DcsStopEvent?.Invoke();

                clearData();
                enableControls(false);
                init = false;
            }
        }

        private void clearData()
        {
            hostCount = 0; 
            packageSize = 0;
            totalByte = 0;
            prevTotalByte = 0;
            idDataSend.Clear();

            updateControls();
        }

        private int getSpeed()
        {
            return (totalByte - prevTotalByte) / 1000;
        }

        private void enableControls(bool enable)
        {
            networkTraffic_listView.Enabled = enable;
        }

        private void updateControls()
        {
            packageSize_textBox.Text = packageSize.ToString();
            speed_textBox.Text = getSpeed().ToString();

            if (config.Init)
            {
                foreach (var id in idDataSend)
                {
                    ListViewItem listViewItem = new ListViewItem();

                    listViewItem.Text = id.Key;
                    listViewItem.SubItems.Add($"{ Math.Round(id.Value) } %");

                    networkTraffic_listView.Items.Add(listViewItem);
                }
            }
        }
    }
}
