using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceUtilityCigiDLL
{
    public class PlatformGroupBoxBinder : ITab
    {
        private Label Label;
        private TextBox TextBox;
        private Button Button;

        public event Action updatePlatformInput;
        public double Value { get; private set; }

        public PlatformGroupBoxBinder(Label label, TextBox textBox, Button button)
        {
            this.TextBox = textBox;
            this.Label = label;
            this.Button = button;

            Button.Click += Button_Click;

            resetValue();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Value = checkValue(TextBox.Text);
            Label.Text = Value.ToString();
            updatePlatformInput?.Invoke();
        }

        public void resetValue()
        {
            TextBox.Text = Label.Text = "0,0";
            Button_Click(this, null);
        }

        public override void EnableControl(bool enable)
        {
            Label.Enabled = enable;
            TextBox.Enabled = enable;
            Button.Enabled = enable;
        }
    }
}
