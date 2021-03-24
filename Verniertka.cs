using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public class Verniertka : ITab
    {
        private Label label;
        private TextBox textBox;
        private Button button;

        public bool Init { get; private set; }

        private float value = 0.0f;

        public Verniertka(Label Label, TextBox TextBox, Button Button)
        {
            label = Label;
            textBox = TextBox;
            button = Button;

            label.Text = textBox.Text = value.ToString();

            button.Click += Button_Click;
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr setVerniertkaValue(float value = 0, bool writeMode = false);

        private void Button_Click(object sender, EventArgs e)
        {
            value = checkValue(textBox.Text);
            label.Text = value.ToString();

            setVerniertkaValue(value, true);
        }

        public void LoadVerniertkaValue()
        {
            IntPtr resultString = setVerniertkaValue();

            if (resultString == null)
                return;

            Dictionary<string, float> result = resultString.ToStringFloat();

            if (result["SharedMemoryInit"] == 0)
            {
                EnableControl(false);
            }
            else
            {
                EnableControl(true);
                label.Text = textBox.Text = result["Verniertka"].ToString();
            }
        }

        public override void EnableControl(bool enable)
        {
            Init = enable;
            textBox.Enabled = enable;
            label.Enabled = enable;
            button.Enabled = enable;
        }
    }
}
