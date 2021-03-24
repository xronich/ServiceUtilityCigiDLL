using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public partial class PlatformPanel : UserControl
    {
        private Dictionary<string, PlatformGroupBoxBinder> platformInputData = new Dictionary<string, PlatformGroupBoxBinder>();

        public PlatformPanel()
        {
            InitializeComponent();

            platformInputData.Clear();
            platformInputData.Add("XAcceleration", new PlatformGroupBoxBinder(XAcceleration_label, XAcceleration_textBox, XAcceleration_button));
            platformInputData.Add("YAcceleration", new PlatformGroupBoxBinder(YAcceleration_label, YAcceleration_textBox, YAcceleration_button));
            platformInputData.Add("ZAcceleration", new PlatformGroupBoxBinder(ZAcceleration_label, ZAcceleration_textBox, ZAcceleration_button));
            platformInputData.Add("RollAcceleration", new PlatformGroupBoxBinder(RollAcceleration_label, RollAcceleration_textBox, RollAcceleration_button));
            platformInputData.Add("PitchAcceleration", new PlatformGroupBoxBinder(PitchAcceleration_label, PitchAcceleration_textBox, PitchAcceleration_button));
            platformInputData.Add("YawAcceleration", new PlatformGroupBoxBinder(YawAcceleration_label, YawAcceleration_textBox, YawAcceleration_button));
            platformInputData.Add("RollVelocity", new PlatformGroupBoxBinder(RollVelocity_label, RollVelocity_textBox, RollVelocity_button));
            platformInputData.Add("PitchVelocity", new PlatformGroupBoxBinder(PitchVelocity_label, PitchVelocity_textBox, PitchVelocity_button));
            platformInputData.Add("YawVelocity", new PlatformGroupBoxBinder(YawVelocity_label, YawVelocity_textBox, YawVelocity_button));
            platformInputData.Add("IndicatedAirSpeed", new PlatformGroupBoxBinder(IndicatedAirSpeed_label, IndicatedAirSpeed_textBox, IndicatedAirSpeed_button));
            platformInputData.Add("GroundSpeed", new PlatformGroupBoxBinder(GroundSpeed_label, GroundSpeed_textBox, GroundSpeed_button));
            platformInputData.Add("Altitude", new PlatformGroupBoxBinder(Altitude_label, Altitude_textBox, Altitude_button));

            foreach (var value in platformInputData.Values)
                value.updatePlatformInput += UpdatePlatformInputValue;

            platformSenderInit();
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void platformSenderInit();

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getPlatformOutput();

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getPlatformSendMessage();

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool setPlatformInputData(bool sendMessage,
                                            double XAcceleration = 0,
                                            double YAcceleration = 0,
                                            double ZAcceleration = 0,
                                            double RollAcceleration = 0,
                                            double PitchAcceleratio = 0,
                                            double YawAcceleration = 0,
                                            double RollVelocity = 0,
                                            double PitchVelocity = 0,
                                            double YawVelocity = 0,
                                            double IndicatedAirSpeed = 0,
                                            double GroundSpeed = 0,
                                            double Altitude = 0);

        private void resetPlatformData_Click(object sender, EventArgs e)
        {
            foreach (var item in platformInputData)
                item.Value.resetValue();
        }
        public void UpdatePlatformInputValue()
        {
            setPlatformInputData(true,
                                 platformInputData["XAcceleration"].Value,
                                 platformInputData["YAcceleration"].Value,
                                 platformInputData["ZAcceleration"].Value,
                                 platformInputData["RollAcceleration"].Value,
                                 platformInputData["PitchAcceleration"].Value,
                                 platformInputData["YawAcceleration"].Value,
                                 platformInputData["RollVelocity"].Value,
                                 platformInputData["PitchVelocity"].Value,
                                 platformInputData["YawVelocity"].Value,
                                 platformInputData["IndicatedAirSpeed"].Value,
                                 platformInputData["GroundSpeed"].Value,
                                 platformInputData["Altitude"].Value
                                 );
        }

        public void updatePlatform()
        {
            updatePlatformOutput();
            updatePlatformInput();
            //sendAttitudeAndPosition_checkBox_CheckedChanged(this, null);
        }

        private void updatePlatformOutput()
        {
            IntPtr resultString = getPlatformOutput();

            if (resultString == null)
                return;

            Dictionary<string, string> platformOutput = resultString.ToStringString();

            if (platformOutput["SharedMemoryInit"] == "1")
            {
                PlatformOutputMessage_textBox.Text = platformOutput["Message"];
                PositionX_textBox.Text = platformOutput["PositionX"];
                PositionY_textBox.Text = platformOutput["PositionY"];
                PositionZ_textBox.Text = platformOutput["PositionZ"];
                Roll_textBox.Text = platformOutput["Roll"];
                Pitch_textBox.Text = platformOutput["Pitch"];
                Yaw_textBox.Text = platformOutput["Yaw"];
            }
            else
            {
                PlatformOutputMessage_textBox.Text = "";
                PositionX_textBox.Text = "";
                PositionY_textBox.Text = "";
                PositionZ_textBox.Text = "";
                Roll_textBox.Text = "";
                Pitch_textBox.Text = "";
                Yaw_textBox.Text = "";
            }
        }

        private void updatePlatformInput()
        {
            platformInput_textBox.Text = "";

            if (sendAttitudeAndPosition_checkBox.Checked)
            {
                IntPtr resultString = getPlatformSendMessage();

                if (resultString == null)
                    return;

                Dictionary<string, string> platformSendMessage = resultString.ToStringString();

                platformInput_textBox.Text = platformSendMessage["PlatformSendMessage"];
            }
        }

        private void sendAttitudeAndPosition_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = sendAttitudeAndPosition_checkBox.Checked;

            if (enable)
                UpdatePlatformInputValue();
            else
                setPlatformInputData(false);

            XAcceleration_groupBox.Enabled = enable;
            YAcceleration_groupBox.Enabled = enable;
            ZAcceleration_groupBox.Enabled = enable;
            RollAcceleration_groupBox.Enabled = enable;
            PitchAcceleration_groupBox.Enabled = enable;
            YawAcceleration_groupBox.Enabled = enable;
            RollVelocity_groupBox.Enabled = enable;
            PitchVelocity_groupBox.Enabled = enable;
            YawVelocity_groupBox.Enabled = enable;
            IndicatedAirSpeed_groupBox.Enabled = enable;
            GroundSpeed_groupBox.Enabled = enable;
            Altitude_groupBox.Enabled = enable;
            resetPlatformData.Enabled = enable;
        }
    }
}
