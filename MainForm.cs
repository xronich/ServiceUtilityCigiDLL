using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuaInterface;
using ZedGraph;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public partial class MainForm : Form
    {
        private Verniertka verniertka;
        private Visualization visualization;
        private ParalaxSwitch paralaxSwitch;
        private List<Offset> OffsetList = new List<Offset>();
        private NetworkTraffic networkTraffic;
        private EntityMap entityMap;
        private Config config = new Config();

        private Timer timer = new Timer();

        private PlatformPanel platformPanel; 
        private GraphPanel channelGraphPanel, dcsGrafPanel;

        private bool fpsLoggerInit = false;

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            config.LoadConfig();

            updateTitle();

            platformPanel = new PlatformPanel();
            entityMap = new EntityMap(entityMap_listView, entitiCount_label);
            networkTraffic = new NetworkTraffic(config, networkData_listView, packageSize_textBox, speed_textBox);
            paralaxSwitch = new ParalaxSwitch(Observer1_radioButton, Observer2_radioButton, Observer3_radioButton, paralaxState_label, switchKey_label, switchKey_textBox, updateParalax_button);
            verniertka = new Verniertka(verniertkaValue_Label, verniertka_TextBox, verniertkaUpdate_Button);
            visualization = new Visualization(correctorMode_checkBox, fps_checkBox, DisableCigiDLL_checkBox, wareSphereMode_checkBox, miParallaxObserver_checkBox);

            platformPage.Controls.Add(platformPanel);

            networkTraffic.DcsStartEvent += OnDcsStart;
            networkTraffic.DcsStopEvent += OnDcsStop;

            InitDcsPanel();

            if (config.Init)
            {
                InitChannelPanel();

                CreateOffsetControl(config.HostCount, verniertkaPage);

                fpsLoggerInit = FpsLoggerInit(config.Port);
            }

            InitTimer();
        }

        [DllImport("cigiServiceUtilsDll.dll")]
        static extern bool FpsLoggerInit(int port = 0, bool enable = true);

        private void OnDcsStop()
        {
            config.LoadConfig();

            mainControl_Click(this, null);
        }

        private void OnDcsStart()
        {
            config.LoadConfig();

            //обновить состояние контролов в форме и циги после рестарта дкс
            visualization.LoadVisualizationValue(VisMode.READ);

            foreach (var panel in dcsGrafPanel.getFrameGraph())
                panel.clearGraph();

            reloadConfig();
        }

        private void InitTimer()
        {
            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void updateTitle()
        {
            this.Text = (config.Init) ? $"Host init: { config.HostCount }" : "Config don’t init";
        }

        private void InitChannelPanel()
        {
            if (channelGraphPanel != null)
                channelGraphPanel.Dispose();

            int widthGraph = 150 * config.HostCount;

            channelGraphPanel = new GraphPanel(1150, widthGraph);

            foreach (var idHost in config.getIdHostConfig())
            {
                ChannelFrameGraph cGraf = new ChannelFrameGraph(idHost.Value);
                channelGraphPanel.CreateGraph(cGraf);
            }

            ChannelFpsPage.Controls.Add(channelGraphPanel);
        }
        private void InitDcsPanel()
        {
            dcsGrafPanel = new GraphPanel(1150, 400);

            dcsGrafPanel.CreateGraph(new DcsFrameGraph("DcsTime"));
            dcsGrafPanel.CreateGraph(new DcsFrameGraph("CigiTime"));

            dcsFpsPage.Controls.Add(dcsGrafPanel);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            platformPanel.updatePlatform();

            channelGraphPanel?.updateGraphs();

            // обнавляем каждую секунду
            if (Ticker.NeedUpdate)
            {
                dcsGrafPanel.updateGraphs();
                networkTraffic.updateNetworkTraffic();
                entityMap.updateValue();

                paralaxSwitch.LoadParalaxButton();

                updateTitle();
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }      

        private void mainControl_Click(object sender, EventArgs e)
        {
            if (mainControl.SelectedTab == visualizationPage)
            {
                visualization.LoadVisualizationValue(VisMode.READ);
            }

            if (mainControl.SelectedTab == verniertkaPage)
            {
                verniertka.LoadVerniertkaValue();

                foreach (var offset in OffsetList)
                    offset.LoadOffsetValue(verniertka.Init);
            }

            if (mainControl.SelectedTab == paralaxSwitchPage)
            {
                paralaxSwitch.LoadParalaxValue();
            }

            if (mainControl.SelectedTab == platformPage)
            {
                platformPanel.updatePlatform();
            }
        }

        private void reloadConfig()
        {
            config.LoadConfig(); 

            if (config.Init)
            {
                if (fpsLoggerInit)
                    FpsLoggerInit(enable: false);

                InitChannelPanel();

                CreateOffsetControl(config.HostCount, verniertkaPage);

                fpsLoggerInit = FpsLoggerInit(config.Port);
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reloadConfig();

            updateTitle();
        }

        void CreateOffsetControl(int count, TabPage tabPage)
        {
            OffsetList.Clear();

            int yLocation = 0;

            for (int i = 1; i <= count; i++)
            {
                yLocation += 45;

                OffsetList.Add(new Offset(i, yLocation, tabPage));
            }
        }
    }
}
