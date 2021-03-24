using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public class Offset : ITab
    {
        private Label label;
        private TextBox textBox;
        private Button button;
        private GroupBox groupBox;

        public int index;
        private float value = 0.0f;

        public Offset(int index, int yLocation, TabPage tabPage)
        {
            this.index = index;

            GroupBox groupBox = GroupBoxInit(index, value, value, yLocation);
            tabPage.Controls.Add(groupBox);

            button.Click += Button_Click;
        }

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern bool setOffsetValue(int index, float value);

        [DllImport("cigiServiceUtilsDll.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr getOffsetValue(int index);

        public void updateValue()
        {
            label.Text = textBox.Text = value.ToString();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            value = checkValue(textBox.Text);
            label.Text = value.ToString();

            setOffsetValue(index, value);
        }

        public void LoadOffsetValue(bool enable)
        {
            setOffsetValue(index, value);

            EnableControl(enable);
        }

        public override void EnableControl(bool enable)
        {
            textBox.Enabled = enable;
            label.Enabled = enable;
            groupBox.Enabled = enable;
        }

        #region CreateGroupBox
        private GroupBox GroupBoxInit(int hostNumber, float labelText, float textBoxText, int yLocation)
        {
            label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(30, 16);
            label.Name = "label";
            label.Size = new System.Drawing.Size(22, 13);
            label.TabIndex = 0;
            label.Text = labelText.ToString();

            textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(70, 13);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(59, 20);
            textBox.TabIndex = 1;
            textBox.Text = textBoxText.ToString();

            button = new Button();
            button.Location = new System.Drawing.Point(140, 12);
            button.Name = "button";
            button.Size = new System.Drawing.Size(75, 23);
            button.TabIndex = 2;
            button.Text = "Update";
            button.UseVisualStyleBackColor = true;

            groupBox = new GroupBox();
            groupBox.Controls.Add(button);
            groupBox.Controls.Add(textBox);
            groupBox.Controls.Add(label);
            groupBox.Location = new System.Drawing.Point(60, yLocation);
            groupBox.Name = "groupBox";
            groupBox.Size = new System.Drawing.Size(240, 41);
            groupBox.TabIndex = 1;
            groupBox.TabStop = false;
            groupBox.Text = hostNumber.ToString();

            return groupBox;
        }
        #endregion
    }
}

