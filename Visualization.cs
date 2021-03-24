using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public enum VisMode
    {
        READ = 1,
        WRITE = 2,
    };
    public class Visualization : ITab
    {
        private List<CheckBox> listCheckBoxes;

        private CheckBox correctorMode_CheckBox;
        private CheckBox fps_CheckBox;
        private CheckBox disableCigi_CheckBox;
        private CheckBox wareSphereMode_checkBox;
        private CheckBox miParallaxObserver_checkBox;

        private bool correctorMode = false;
        private bool fps = false;
        private bool disableCigi = false;
        private bool wareSphere = false;
        private bool miParallaxObserver = false;

        public Visualization(CheckBox CorrectorMode_CheckBox, CheckBox Fps_CheckBox, CheckBox DisableCigi_CheckBox, CheckBox WareSphereMode_checkBox, CheckBox MiParallaxObserver_checkBox)
        {
            correctorMode_CheckBox = CorrectorMode_CheckBox;
            fps_CheckBox = Fps_CheckBox;
            disableCigi_CheckBox = DisableCigi_CheckBox;
            wareSphereMode_checkBox = WareSphereMode_checkBox;
            miParallaxObserver_checkBox = MiParallaxObserver_checkBox;

            listCheckBoxes = new List<CheckBox>() { CorrectorMode_CheckBox, fps_CheckBox, disableCigi_CheckBox, wareSphereMode_checkBox, miParallaxObserver_checkBox };

            SubscribeCheckBoxes();
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr setVisualizationValue(bool correctorMode = false, bool fps = false, bool disableCigi = false, bool wareSphere = false, bool miParallaxObserver = false, bool writeMode = false);

        private void SubscribeCheckBoxes()
        {
            foreach (var checkbox in listCheckBoxes)
                checkbox.Click += Visualization_CheckBox_Click;
        }

        private void Visualization_CheckBox_Click(object sender, EventArgs e)
        {
            LoadVisualizationValue(VisMode.WRITE);
        }

        public void LoadVisualizationValue(VisMode mode)
        {
            IntPtr resultString = setVisualizationValue();

            if (resultString == null)
                return;

            Dictionary<string, string> visualization = resultString.ToStringString();

            if (visualization["SharedMemoryInit"] == "1")
            {
                EnableControl(true);

                if(listCheckBoxes.Any(s => s.Checked))
                    mode = VisMode.WRITE;

                switch (mode)
                {
                    case VisMode.READ:
                        correctorMode = visualization["CorrectorMode"].ToBool();
                        fps = visualization["Fps"].ToBool();
                        disableCigi = visualization["DisableCigi"].ToBool();
                        wareSphere = visualization["WareSphereMode"].ToBool();
                        miParallaxObserver = visualization["MiParallaxObserver"].ToBool();
                        updateControls();
                        break;

                    case VisMode.WRITE:
                        updateValues();
                        setVisualizationValue(correctorMode, fps, disableCigi, wareSphere, miParallaxObserver, true);
                        break;
                }
            }
            else
            {
                EnableControl(false);
            }
        }

        private void updateControls()
        {
            correctorMode_CheckBox.Checked = correctorMode;
            fps_CheckBox.Checked = fps;
            disableCigi_CheckBox.Checked = disableCigi;
            wareSphereMode_checkBox.Checked = wareSphere;
            miParallaxObserver_checkBox.Checked = miParallaxObserver;
        }

        private void updateValues()
        {
            correctorMode = correctorMode_CheckBox.Checked;
            fps = fps_CheckBox.Checked;
            disableCigi = disableCigi_CheckBox.Checked;
            wareSphere = wareSphereMode_checkBox.Checked;
            miParallaxObserver = miParallaxObserver_checkBox.Checked;
        }

        public override void EnableControl(bool enable)
        {
            foreach (var checkbox in listCheckBoxes)
                checkbox.Enabled = enable;
        }
    }
}

