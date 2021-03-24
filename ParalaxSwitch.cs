using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;

namespace ServiceUtilityCigiDLL
{
    public class ParalaxSwitch :ITab
    {
        private TextBox switchKey_TextBox;
        private RadioButton observer1_RadioButton, observer2_RadioButton, observer3_RadioButton;
        private Label paralaxState_Label, switchKey_Label;
        private Button updateParalax_Button;
        private Dictionary<string, Key> sysKeyDict = new Dictionary<string, Key>() {{ "LeftCtrl", Key.LeftCtrl },
                                                                                    { "RightCtrl", Key.RightCtrl },
                                                                                    { "LeftShift", Key.LeftShift },
                                                                                    { "RightShift", Key.RightShift }
                                                                                    };

        private string paralaxValue = "";
        private Key button;
        private bool buttonInit;

        public ParalaxSwitch(RadioButton Observer1_RadioButton, RadioButton Observer2_RadioButton, RadioButton Observer3_RadioButton,
           Label ParalaxState_Label, Label SwitchKey_Label, TextBox SwitchKey_TextBox, Button UpdateParalax_Button)
        {
            observer1_RadioButton = Observer1_RadioButton;
            observer2_RadioButton = Observer2_RadioButton;
            observer3_RadioButton = Observer3_RadioButton;
            paralaxState_Label = ParalaxState_Label;
            switchKey_Label = SwitchKey_Label;
            switchKey_TextBox = SwitchKey_TextBox;
            updateParalax_Button = UpdateParalax_Button;

            observer1_RadioButton.CheckedChanged += Observer_RadioButton_CheckedChanged;
            observer2_RadioButton.CheckedChanged += Observer_RadioButton_CheckedChanged;
            observer3_RadioButton.CheckedChanged += Observer_RadioButton_CheckedChanged;

            updateParalax_Button.Click += UpdateParalax_Button_Click;
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr setParalaxValue(int value = 0, bool writeMode = false);

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getParalaxButton();

        public bool setupKeyboardHooks(Key button, string sysKey)
        {
            try
            {
                string message;
                KeyboardUtils.GlobalKeyboardHook.Instance.Hook(new List<Key> {sysKeyDict[sysKey], button},
                    keyboardHookSwitch, out message);

                switchKey_TextBox.Text = sysKey + " + " + button.ToString();
                switchKey_TextBox.Visible = switchKey_Label.Visible = true;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void keyboardHookSwitch()
        {
            if (observer1_RadioButton.Checked)
                observer2_RadioButton.Checked = true;

            else if (observer2_RadioButton.Checked)
                observer3_RadioButton.Checked = true;

            else if (observer3_RadioButton.Checked)
                observer1_RadioButton.Checked = true;

            else
                observer1_RadioButton.Checked = true;

            UpdateParalax_Button_Click(this, null);
        }
        private void UpdateParalax_Button_Click(object sender, EventArgs e)
        {
            paralaxState_Label.Text = paralaxValue;

            switch (paralaxValue)
            {
                case "Observer1":
                    setParalaxValue(1, true);
                    break;
                case "Observer2":
                    setParalaxValue(2, true);
                    break;
                case "Observer3":
                    setParalaxValue(3, true);
                    break;
                default:
                    setParalaxValue(0, true);
                    break;
            }
        }
        public void LoadParalaxButton()
        {
            if(buttonInit)
                return;

            IntPtr resultString = getParalaxButton();

            if (resultString == null)
                return;

            Dictionary<string, string> result = resultString.ToStringString();

            if (result["SharedMemoryInit"] == "1")
            {
                string paralaxButton = result["ParalaxButton"];

                if (Enum.TryParse(paralaxButton.ToUpper(), out button));
                {
                    string systemButton = result["ParalaxSystemButton"];

                    buttonInit = setupKeyboardHooks(button, systemButton);
                }
            }        
        }

        public void LoadParalaxValue()
        {
            IntPtr resultString = setParalaxValue();

            if (resultString == null)
                return;

            Dictionary<string, int> result = resultString.ToStringInt();

            if (result["SharedMemoryInit"] == 1)
            {
                EnableControl(true);

                switch (result["ParalaxValue"])
                {
                    case 1:
                        observer1_RadioButton.Checked = true;
                        paralaxState_Label.Text = observer1_RadioButton.Text;
                        break;
                    case 2:
                        observer2_RadioButton.Checked = true;
                        paralaxState_Label.Text = observer2_RadioButton.Text;
                        break;
                    case 3:
                        observer3_RadioButton.Checked = true;
                        paralaxState_Label.Text = observer3_RadioButton.Text;
                        break;
                    case 0:
                        paralaxState_Label.Text = "Observer0";
                        break;
                }
            }
            else
            {
                EnableControl(false);
            }
        }
        public override void EnableControl(bool enable)
        {
            observer1_RadioButton.Enabled = enable;
            observer2_RadioButton.Enabled = enable;
            observer3_RadioButton.Enabled = enable;
            paralaxState_Label.Enabled = enable;
            updateParalax_Button.Enabled = enable;
        }

        private void Observer_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                paralaxValue = radioButton.Text;
        }
    }
}
