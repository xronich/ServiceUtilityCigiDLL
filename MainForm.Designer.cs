namespace ServiceUtilityCigiDLL
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainControl = new System.Windows.Forms.TabControl();
            this.ChannelFpsPage = new System.Windows.Forms.TabPage();
            this.dcsFpsPage = new System.Windows.Forms.TabPage();
            this.platformPage = new System.Windows.Forms.TabPage();
            this.visualizationPage = new System.Windows.Forms.TabPage();
            this.DisableCigiDLL_checkBox = new System.Windows.Forms.CheckBox();
            this.miParallaxObserver_checkBox = new System.Windows.Forms.CheckBox();
            this.wareSphereMode_checkBox = new System.Windows.Forms.CheckBox();
            this.fps_checkBox = new System.Windows.Forms.CheckBox();
            this.correctorMode_checkBox = new System.Windows.Forms.CheckBox();
            this.verniertkaPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.verniertkaUpdate_Button = new System.Windows.Forms.Button();
            this.verniertkaValue_Label = new System.Windows.Forms.Label();
            this.verniertka_TextBox = new System.Windows.Forms.TextBox();
            this.verniertka_Label = new System.Windows.Forms.Label();
            this.paralaxSwitchPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.switchKey_textBox = new System.Windows.Forms.TextBox();
            this.switchKey_label = new System.Windows.Forms.Label();
            this.Observer3_radioButton = new System.Windows.Forms.RadioButton();
            this.Observer2_radioButton = new System.Windows.Forms.RadioButton();
            this.Observer1_radioButton = new System.Windows.Forms.RadioButton();
            this.updateParalax_button = new System.Windows.Forms.Button();
            this.paralaxState_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.entityMap_tabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.entitiCount_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.entityMap_listView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.networkTrafficPage = new System.Windows.Forms.TabPage();
            this.speed_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.error_label = new System.Windows.Forms.Label();
            this.networkData_listView = new System.Windows.Forms.ListView();
            this.host_newtworkTraffic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.send_newtworkTraffic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.packageSize_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statisticsPage = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.debugPage = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainControl.SuspendLayout();
            this.visualizationPage.SuspendLayout();
            this.verniertkaPage.SuspendLayout();
            this.paralaxSwitchPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.entityMap_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.networkTrafficPage.SuspendLayout();
            this.statisticsPage.SuspendLayout();
            this.debugPage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainControl
            // 
            this.mainControl.Controls.Add(this.ChannelFpsPage);
            this.mainControl.Controls.Add(this.dcsFpsPage);
            this.mainControl.Controls.Add(this.platformPage);
            this.mainControl.Controls.Add(this.visualizationPage);
            this.mainControl.Controls.Add(this.verniertkaPage);
            this.mainControl.Controls.Add(this.paralaxSwitchPage);
            this.mainControl.Controls.Add(this.entityMap_tabPage);
            this.mainControl.Controls.Add(this.networkTrafficPage);
            this.mainControl.Controls.Add(this.statisticsPage);
            this.mainControl.Controls.Add(this.debugPage);
            this.mainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainControl.Location = new System.Drawing.Point(0, 0);
            this.mainControl.Name = "mainControl";
            this.mainControl.SelectedIndex = 0;
            this.mainControl.Size = new System.Drawing.Size(1159, 539);
            this.mainControl.TabIndex = 1;
            this.mainControl.Click += new System.EventHandler(this.mainControl_Click);
            // 
            // ChannelFpsPage
            // 
            this.ChannelFpsPage.AutoScroll = true;
            this.ChannelFpsPage.BackColor = System.Drawing.Color.Transparent;
            this.ChannelFpsPage.Location = new System.Drawing.Point(4, 22);
            this.ChannelFpsPage.Name = "ChannelFpsPage";
            this.ChannelFpsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ChannelFpsPage.Size = new System.Drawing.Size(1151, 513);
            this.ChannelFpsPage.TabIndex = 0;
            this.ChannelFpsPage.Text = "Channel FPS";
            // 
            // dcsFpsPage
            // 
            this.dcsFpsPage.BackColor = System.Drawing.SystemColors.Control;
            this.dcsFpsPage.Location = new System.Drawing.Point(4, 22);
            this.dcsFpsPage.Name = "dcsFpsPage";
            this.dcsFpsPage.Size = new System.Drawing.Size(1151, 513);
            this.dcsFpsPage.TabIndex = 7;
            this.dcsFpsPage.Text = "Dcs FPS";
            // 
            // platformPage
            // 
            this.platformPage.AutoScroll = true;
            this.platformPage.BackColor = System.Drawing.Color.Transparent;
            this.platformPage.Location = new System.Drawing.Point(4, 22);
            this.platformPage.Name = "platformPage";
            this.platformPage.Padding = new System.Windows.Forms.Padding(3);
            this.platformPage.Size = new System.Drawing.Size(1151, 513);
            this.platformPage.TabIndex = 1;
            this.platformPage.Text = "Platform";
            // 
            // visualizationPage
            // 
            this.visualizationPage.BackColor = System.Drawing.Color.Transparent;
            this.visualizationPage.Controls.Add(this.DisableCigiDLL_checkBox);
            this.visualizationPage.Controls.Add(this.miParallaxObserver_checkBox);
            this.visualizationPage.Controls.Add(this.wareSphereMode_checkBox);
            this.visualizationPage.Controls.Add(this.fps_checkBox);
            this.visualizationPage.Controls.Add(this.correctorMode_checkBox);
            this.visualizationPage.Location = new System.Drawing.Point(4, 22);
            this.visualizationPage.Name = "visualizationPage";
            this.visualizationPage.Size = new System.Drawing.Size(1151, 513);
            this.visualizationPage.TabIndex = 2;
            this.visualizationPage.Text = "Visualization";
            // 
            // DisableCigiDLL_checkBox
            // 
            this.DisableCigiDLL_checkBox.AutoSize = true;
            this.DisableCigiDLL_checkBox.Location = new System.Drawing.Point(22, 111);
            this.DisableCigiDLL_checkBox.Name = "DisableCigiDLL_checkBox";
            this.DisableCigiDLL_checkBox.Size = new System.Drawing.Size(104, 17);
            this.DisableCigiDLL_checkBox.TabIndex = 9;
            this.DisableCigiDLL_checkBox.Text = "Disable Cigi DLL";
            this.DisableCigiDLL_checkBox.UseVisualStyleBackColor = true;
            // 
            // miParallaxObserver_checkBox
            // 
            this.miParallaxObserver_checkBox.AutoSize = true;
            this.miParallaxObserver_checkBox.Location = new System.Drawing.Point(22, 88);
            this.miParallaxObserver_checkBox.Name = "miParallaxObserver_checkBox";
            this.miParallaxObserver_checkBox.Size = new System.Drawing.Size(167, 17);
            this.miParallaxObserver_checkBox.TabIndex = 8;
            this.miParallaxObserver_checkBox.Text = "3xMi-8 Parallax Observer Test";
            this.miParallaxObserver_checkBox.UseVisualStyleBackColor = true;
            // 
            // wareSphereMode_checkBox
            // 
            this.wareSphereMode_checkBox.AutoSize = true;
            this.wareSphereMode_checkBox.Location = new System.Drawing.Point(22, 65);
            this.wareSphereMode_checkBox.Name = "wareSphereMode_checkBox";
            this.wareSphereMode_checkBox.Size = new System.Drawing.Size(142, 17);
            this.wareSphereMode_checkBox.TabIndex = 7;
            this.wareSphereMode_checkBox.Text = "Sphere In Aircraft Space";
            this.wareSphereMode_checkBox.UseVisualStyleBackColor = true;
            // 
            // fps_checkBox
            // 
            this.fps_checkBox.AutoSize = true;
            this.fps_checkBox.Location = new System.Drawing.Point(22, 42);
            this.fps_checkBox.Name = "fps_checkBox";
            this.fps_checkBox.Size = new System.Drawing.Size(73, 17);
            this.fps_checkBox.TabIndex = 1;
            this.fps_checkBox.Text = "Show Fps";
            this.fps_checkBox.UseVisualStyleBackColor = true;
            // 
            // correctorMode_checkBox
            // 
            this.correctorMode_checkBox.AutoSize = true;
            this.correctorMode_checkBox.Location = new System.Drawing.Point(22, 19);
            this.correctorMode_checkBox.Name = "correctorMode_checkBox";
            this.correctorMode_checkBox.Size = new System.Drawing.Size(135, 17);
            this.correctorMode_checkBox.TabIndex = 0;
            this.correctorMode_checkBox.Text = "Enable Corrector Mode";
            this.correctorMode_checkBox.UseVisualStyleBackColor = true;
            // 
            // verniertkaPage
            // 
            this.verniertkaPage.BackColor = System.Drawing.Color.Transparent;
            this.verniertkaPage.Controls.Add(this.label2);
            this.verniertkaPage.Controls.Add(this.verniertkaUpdate_Button);
            this.verniertkaPage.Controls.Add(this.verniertkaValue_Label);
            this.verniertkaPage.Controls.Add(this.verniertka_TextBox);
            this.verniertkaPage.Controls.Add(this.verniertka_Label);
            this.verniertkaPage.Location = new System.Drawing.Point(4, 22);
            this.verniertkaPage.Name = "verniertkaPage";
            this.verniertkaPage.Size = new System.Drawing.Size(1151, 513);
            this.verniertkaPage.TabIndex = 5;
            this.verniertkaPage.Text = "Verniertka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Offset:";
            // 
            // verniertkaUpdate_Button
            // 
            this.verniertkaUpdate_Button.Location = new System.Drawing.Point(199, 14);
            this.verniertkaUpdate_Button.Name = "verniertkaUpdate_Button";
            this.verniertkaUpdate_Button.Size = new System.Drawing.Size(75, 23);
            this.verniertkaUpdate_Button.TabIndex = 3;
            this.verniertkaUpdate_Button.Text = "Update";
            this.verniertkaUpdate_Button.UseVisualStyleBackColor = true;
            // 
            // verniertkaValue_Label
            // 
            this.verniertkaValue_Label.AutoSize = true;
            this.verniertkaValue_Label.Location = new System.Drawing.Point(84, 17);
            this.verniertkaValue_Label.Name = "verniertkaValue_Label";
            this.verniertkaValue_Label.Size = new System.Drawing.Size(13, 13);
            this.verniertkaValue_Label.TabIndex = 2;
            this.verniertkaValue_Label.Text = "0";
            // 
            // verniertka_TextBox
            // 
            this.verniertka_TextBox.Location = new System.Drawing.Point(128, 15);
            this.verniertka_TextBox.Name = "verniertka_TextBox";
            this.verniertka_TextBox.Size = new System.Drawing.Size(60, 20);
            this.verniertka_TextBox.TabIndex = 1;
            this.verniertka_TextBox.Text = "0";
            // 
            // verniertka_Label
            // 
            this.verniertka_Label.AutoSize = true;
            this.verniertka_Label.Location = new System.Drawing.Point(19, 16);
            this.verniertka_Label.Name = "verniertka_Label";
            this.verniertka_Label.Size = new System.Drawing.Size(58, 13);
            this.verniertka_Label.TabIndex = 0;
            this.verniertka_Label.Text = "Verniertka:";
            // 
            // paralaxSwitchPage
            // 
            this.paralaxSwitchPage.BackColor = System.Drawing.SystemColors.Control;
            this.paralaxSwitchPage.Controls.Add(this.groupBox1);
            this.paralaxSwitchPage.Location = new System.Drawing.Point(4, 22);
            this.paralaxSwitchPage.Name = "paralaxSwitchPage";
            this.paralaxSwitchPage.Size = new System.Drawing.Size(1151, 513);
            this.paralaxSwitchPage.TabIndex = 6;
            this.paralaxSwitchPage.Text = "Paralax switch";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.switchKey_textBox);
            this.groupBox1.Controls.Add(this.switchKey_label);
            this.groupBox1.Controls.Add(this.Observer3_radioButton);
            this.groupBox1.Controls.Add(this.Observer2_radioButton);
            this.groupBox1.Controls.Add(this.Observer1_radioButton);
            this.groupBox1.Controls.Add(this.updateParalax_button);
            this.groupBox1.Controls.Add(this.paralaxState_label);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(29, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 180);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position";
            // 
            // switchKey_textBox
            // 
            this.switchKey_textBox.Enabled = false;
            this.switchKey_textBox.Location = new System.Drawing.Point(85, 153);
            this.switchKey_textBox.Name = "switchKey_textBox";
            this.switchKey_textBox.Size = new System.Drawing.Size(78, 20);
            this.switchKey_textBox.TabIndex = 12;
            this.switchKey_textBox.Visible = false;
            // 
            // switchKey_label
            // 
            this.switchKey_label.AutoSize = true;
            this.switchKey_label.Location = new System.Drawing.Point(21, 156);
            this.switchKey_label.Name = "switchKey_label";
            this.switchKey_label.Size = new System.Drawing.Size(62, 13);
            this.switchKey_label.TabIndex = 11;
            this.switchKey_label.Text = "Switch key:";
            this.switchKey_label.Visible = false;
            // 
            // Observer3_radioButton
            // 
            this.Observer3_radioButton.AutoSize = true;
            this.Observer3_radioButton.Location = new System.Drawing.Point(54, 96);
            this.Observer3_radioButton.Name = "Observer3_radioButton";
            this.Observer3_radioButton.Size = new System.Drawing.Size(74, 17);
            this.Observer3_radioButton.TabIndex = 10;
            this.Observer3_radioButton.TabStop = true;
            this.Observer3_radioButton.Text = "Observer3";
            this.Observer3_radioButton.UseVisualStyleBackColor = true;
            // 
            // Observer2_radioButton
            // 
            this.Observer2_radioButton.AutoSize = true;
            this.Observer2_radioButton.Location = new System.Drawing.Point(54, 72);
            this.Observer2_radioButton.Name = "Observer2_radioButton";
            this.Observer2_radioButton.Size = new System.Drawing.Size(74, 17);
            this.Observer2_radioButton.TabIndex = 9;
            this.Observer2_radioButton.TabStop = true;
            this.Observer2_radioButton.Text = "Observer2";
            this.Observer2_radioButton.UseVisualStyleBackColor = true;
            // 
            // Observer1_radioButton
            // 
            this.Observer1_radioButton.AutoSize = true;
            this.Observer1_radioButton.Location = new System.Drawing.Point(54, 49);
            this.Observer1_radioButton.Name = "Observer1_radioButton";
            this.Observer1_radioButton.Size = new System.Drawing.Size(74, 17);
            this.Observer1_radioButton.TabIndex = 8;
            this.Observer1_radioButton.TabStop = true;
            this.Observer1_radioButton.Text = "Observer1";
            this.Observer1_radioButton.UseVisualStyleBackColor = true;
            // 
            // updateParalax_button
            // 
            this.updateParalax_button.Location = new System.Drawing.Point(24, 123);
            this.updateParalax_button.Name = "updateParalax_button";
            this.updateParalax_button.Size = new System.Drawing.Size(139, 23);
            this.updateParalax_button.TabIndex = 7;
            this.updateParalax_button.Text = "Update";
            this.updateParalax_button.UseVisualStyleBackColor = true;
            // 
            // paralaxState_label
            // 
            this.paralaxState_label.AutoSize = true;
            this.paralaxState_label.Location = new System.Drawing.Point(53, 27);
            this.paralaxState_label.Name = "paralaxState_label";
            this.paralaxState_label.Size = new System.Drawing.Size(56, 13);
            this.paralaxState_label.TabIndex = 5;
            this.paralaxState_label.Text = "Observer0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "State:";
            // 
            // entityMap_tabPage
            // 
            this.entityMap_tabPage.BackColor = System.Drawing.SystemColors.Control;
            this.entityMap_tabPage.Controls.Add(this.splitContainer2);
            this.entityMap_tabPage.Location = new System.Drawing.Point(4, 22);
            this.entityMap_tabPage.Name = "entityMap_tabPage";
            this.entityMap_tabPage.Size = new System.Drawing.Size(1151, 513);
            this.entityMap_tabPage.TabIndex = 9;
            this.entityMap_tabPage.Text = "Entity map";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.entitiCount_label);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.entityMap_listView);
            this.splitContainer2.Size = new System.Drawing.Size(1151, 513);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 1;
            // 
            // entitiCount_label
            // 
            this.entitiCount_label.AutoSize = true;
            this.entitiCount_label.Location = new System.Drawing.Point(70, 7);
            this.entitiCount_label.Name = "entitiCount_label";
            this.entitiCount_label.Size = new System.Drawing.Size(13, 13);
            this.entitiCount_label.TabIndex = 1;
            this.entitiCount_label.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Entity count:";
            // 
            // entityMap_listView
            // 
            this.entityMap_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.entityMap_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityMap_listView.Location = new System.Drawing.Point(0, 0);
            this.entityMap_listView.Name = "entityMap_listView";
            this.entityMap_listView.Size = new System.Drawing.Size(1151, 484);
            this.entityMap_listView.TabIndex = 0;
            this.entityMap_listView.UseCompatibleStateImageBehavior = false;
            this.entityMap_listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 156;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 181;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 195;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lods";
            this.columnHeader4.Width = 158;
            // 
            // networkTrafficPage
            // 
            this.networkTrafficPage.BackColor = System.Drawing.SystemColors.Control;
            this.networkTrafficPage.Controls.Add(this.speed_textBox);
            this.networkTrafficPage.Controls.Add(this.label3);
            this.networkTrafficPage.Controls.Add(this.error_label);
            this.networkTrafficPage.Controls.Add(this.networkData_listView);
            this.networkTrafficPage.Controls.Add(this.packageSize_textBox);
            this.networkTrafficPage.Controls.Add(this.label4);
            this.networkTrafficPage.Location = new System.Drawing.Point(4, 22);
            this.networkTrafficPage.Name = "networkTrafficPage";
            this.networkTrafficPage.Size = new System.Drawing.Size(1151, 513);
            this.networkTrafficPage.TabIndex = 8;
            this.networkTrafficPage.Text = "Network traffic";
            // 
            // speed_textBox
            // 
            this.speed_textBox.Enabled = false;
            this.speed_textBox.Location = new System.Drawing.Point(263, 38);
            this.speed_textBox.Name = "speed_textBox";
            this.speed_textBox.Size = new System.Drawing.Size(193, 20);
            this.speed_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "[Packege size] x [Host count] = [Total size] (byte):";
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Location = new System.Drawing.Point(634, 33);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(0, 13);
            this.error_label.TabIndex = 1;
            // 
            // networkData_listView
            // 
            this.networkData_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.host_newtworkTraffic,
            this.send_newtworkTraffic});
            this.networkData_listView.Location = new System.Drawing.Point(22, 76);
            this.networkData_listView.Name = "networkData_listView";
            this.networkData_listView.Size = new System.Drawing.Size(434, 292);
            this.networkData_listView.TabIndex = 0;
            this.networkData_listView.UseCompatibleStateImageBehavior = false;
            this.networkData_listView.View = System.Windows.Forms.View.Details;
            // 
            // host_newtworkTraffic
            // 
            this.host_newtworkTraffic.Text = "Host";
            this.host_newtworkTraffic.Width = 227;
            // 
            // send_newtworkTraffic
            // 
            this.send_newtworkTraffic.Text = "Data send";
            this.send_newtworkTraffic.Width = 202;
            // 
            // packageSize_textBox
            // 
            this.packageSize_textBox.Enabled = false;
            this.packageSize_textBox.Location = new System.Drawing.Point(263, 12);
            this.packageSize_textBox.Name = "packageSize_textBox";
            this.packageSize_textBox.Size = new System.Drawing.Size(193, 20);
            this.packageSize_textBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Speed (Kb/s):";
            // 
            // statisticsPage
            // 
            this.statisticsPage.BackColor = System.Drawing.Color.Transparent;
            this.statisticsPage.Controls.Add(this.richTextBox2);
            this.statisticsPage.Location = new System.Drawing.Point(4, 22);
            this.statisticsPage.Name = "statisticsPage";
            this.statisticsPage.Size = new System.Drawing.Size(1151, 513);
            this.statisticsPage.TabIndex = 3;
            this.statisticsPage.Text = "Statistics";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(1151, 513);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // debugPage
            // 
            this.debugPage.BackColor = System.Drawing.Color.Transparent;
            this.debugPage.Controls.Add(this.richTextBox1);
            this.debugPage.Location = new System.Drawing.Point(4, 22);
            this.debugPage.Name = "debugPage";
            this.debugPage.Size = new System.Drawing.Size(1151, 513);
            this.debugPage.TabIndex = 4;
            this.debugPage.Text = "Debug";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1151, 513);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.reloadToolStripMenuItem.Text = "Reload config";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainControl);
            this.splitContainer1.Size = new System.Drawing.Size(1159, 568);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1159, 568);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "ServiceUtilityCigiDLL";
            this.mainControl.ResumeLayout(false);
            this.visualizationPage.ResumeLayout(false);
            this.visualizationPage.PerformLayout();
            this.verniertkaPage.ResumeLayout(false);
            this.verniertkaPage.PerformLayout();
            this.paralaxSwitchPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.entityMap_tabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.networkTrafficPage.ResumeLayout(false);
            this.networkTrafficPage.PerformLayout();
            this.statisticsPage.ResumeLayout(false);
            this.debugPage.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainControl;
        private System.Windows.Forms.TabPage platformPage;
        private System.Windows.Forms.TabPage visualizationPage;
        private System.Windows.Forms.TabPage statisticsPage;
        private System.Windows.Forms.TabPage debugPage;
        private System.Windows.Forms.CheckBox fps_checkBox;
        private System.Windows.Forms.CheckBox correctorMode_checkBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage ChannelFpsPage;
        private System.Windows.Forms.CheckBox wareSphereMode_checkBox;
        private System.Windows.Forms.CheckBox DisableCigiDLL_checkBox;
        private System.Windows.Forms.CheckBox miParallaxObserver_checkBox;
        private System.Windows.Forms.TabPage verniertkaPage;
        private System.Windows.Forms.Label verniertka_Label;
        private System.Windows.Forms.Label verniertkaValue_Label;
        private System.Windows.Forms.TextBox verniertka_TextBox;
        private System.Windows.Forms.Button verniertkaUpdate_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage dcsFpsPage;
        private System.Windows.Forms.TabPage paralaxSwitchPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Observer3_radioButton;
        private System.Windows.Forms.RadioButton Observer2_radioButton;
        private System.Windows.Forms.RadioButton Observer1_radioButton;
        private System.Windows.Forms.Button updateParalax_button;
        private System.Windows.Forms.Label paralaxState_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage networkTrafficPage;
        private System.Windows.Forms.ListView networkData_listView;
        private System.Windows.Forms.ColumnHeader host_newtworkTraffic;
        private System.Windows.Forms.ColumnHeader send_newtworkTraffic;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.TextBox packageSize_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox speed_textBox;
        private System.Windows.Forms.TabPage entityMap_tabPage;
        private System.Windows.Forms.ListView entityMap_listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label entitiCount_label;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label switchKey_label;
        private System.Windows.Forms.TextBox switchKey_textBox;
    }
}

