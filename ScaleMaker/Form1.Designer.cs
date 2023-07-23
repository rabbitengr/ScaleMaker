namespace ScaleMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picturePreview = new PictureBox();
            saveExportPng = new SaveFileDialog();
            button2 = new Button();
            textInnerRadius = new TextBox();
            label1 = new Label();
            groupTicks = new GroupBox();
            button6 = new Button();
            textTickCX = new TextBox();
            listTickLayers = new ListBox();
            label26 = new Label();
            textTickCY = new TextBox();
            label24 = new Label();
            checkTickActive = new CheckBox();
            textTickName = new TextBox();
            label10 = new Label();
            label9 = new Label();
            buttonTickColor = new Button();
            textNumTicks = new TextBox();
            label8 = new Label();
            textStartAngle = new TextBox();
            label7 = new Label();
            textDegsPerTick = new TextBox();
            label6 = new Label();
            textTickWidth = new TextBox();
            label5 = new Label();
            button4 = new Button();
            textOuterRadius = new TextBox();
            label4 = new Label();
            textImageW = new TextBox();
            label2 = new Label();
            textImageH = new TextBox();
            label3 = new Label();
            button3 = new Button();
            colorTicks = new ColorDialog();
            button5 = new Button();
            button1 = new Button();
            listTextLayers = new ListBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveasToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            saveScaleDialog = new SaveFileDialog();
            openScaleDialog = new OpenFileDialog();
            groupTexts = new GroupBox();
            textTextCX = new TextBox();
            label31 = new Label();
            textTextCY = new TextBox();
            label32 = new Label();
            textTextStrings = new TextBox();
            label19 = new Label();
            textTextFontName = new TextBox();
            label16 = new Label();
            checkTextActive = new CheckBox();
            textTextName = new TextBox();
            label11 = new Label();
            label12 = new Label();
            buttonTextColor = new Button();
            textTextNumTicks = new TextBox();
            label13 = new Label();
            textTextStartAngle = new TextBox();
            label14 = new Label();
            textTextDegsPerTick = new TextBox();
            label15 = new Label();
            button8 = new Button();
            textTextSize = new TextBox();
            label17 = new Label();
            textTextRadius = new TextBox();
            label18 = new Label();
            fontDialog = new FontDialog();
            colorText = new ColorDialog();
            groupArcs = new GroupBox();
            button7 = new Button();
            checkSolid = new CheckBox();
            listArcLayers = new ListBox();
            textArcCX = new TextBox();
            label29 = new Label();
            textArcSweepAngle = new TextBox();
            textArcCY = new TextBox();
            label22 = new Label();
            label30 = new Label();
            checkArcActive = new CheckBox();
            textArcName = new TextBox();
            label20 = new Label();
            label21 = new Label();
            buttonArcColor = new Button();
            textArcStartAngle = new TextBox();
            label23 = new Label();
            textArcWidth = new TextBox();
            label25 = new Label();
            button9 = new Button();
            textArcRadius = new TextBox();
            label27 = new Label();
            colorArcs = new ColorDialog();
            button10 = new Button();
            openBackdrop = new OpenFileDialog();
            labelCenter = new Label();
            checkShowCenter = new CheckBox();
            groupLabels = new GroupBox();
            button11 = new Button();
            textLabelX = new TextBox();
            listLabelLayers = new ListBox();
            label28 = new Label();
            textLabelText = new TextBox();
            textLabelY = new TextBox();
            label33 = new Label();
            label34 = new Label();
            checkLabelActive = new CheckBox();
            textLabelName = new TextBox();
            label35 = new Label();
            label36 = new Label();
            buttonLabelColor = new Button();
            textLabelSize = new TextBox();
            label38 = new Label();
            button12 = new Button();
            textLabelFont = new TextBox();
            label39 = new Label();
            colorLabels = new ColorDialog();
            textScaleFactor = new TextBox();
            button13 = new Button();
            ((System.ComponentModel.ISupportInitialize)picturePreview).BeginInit();
            groupTicks.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupTexts.SuspendLayout();
            groupArcs.SuspendLayout();
            groupLabels.SuspendLayout();
            SuspendLayout();
            // 
            // picturePreview
            // 
            picturePreview.BackColor = Color.Black;
            picturePreview.Location = new Point(1382, 57);
            picturePreview.Name = "picturePreview";
            picturePreview.Size = new Size(1024, 1024);
            picturePreview.SizeMode = PictureBoxSizeMode.Zoom;
            picturePreview.TabIndex = 1;
            picturePreview.TabStop = false;
            // 
            // saveExportPng
            // 
            saveExportPng.DefaultExt = "png";
            saveExportPng.Filter = "PNG files|*.png";
            // 
            // button2
            // 
            button2.Location = new Point(1731, 1097);
            button2.Name = "button2";
            button2.Size = new Size(163, 34);
            button2.TabIndex = 102;
            button2.Text = "Export to PNG";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textInnerRadius
            // 
            textInnerRadius.Location = new Point(166, 109);
            textInnerRadius.Name = "textInnerRadius";
            textInnerRadius.Size = new Size(150, 31);
            textInnerRadius.TabIndex = 22;
            textInnerRadius.Text = "58";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 112);
            label1.Name = "label1";
            label1.Size = new Size(110, 25);
            label1.TabIndex = 4;
            label1.Text = "Inner Radius";
            // 
            // groupTicks
            // 
            groupTicks.Controls.Add(button6);
            groupTicks.Controls.Add(textTickCX);
            groupTicks.Controls.Add(listTickLayers);
            groupTicks.Controls.Add(label26);
            groupTicks.Controls.Add(textTickCY);
            groupTicks.Controls.Add(label24);
            groupTicks.Controls.Add(checkTickActive);
            groupTicks.Controls.Add(textTickName);
            groupTicks.Controls.Add(label10);
            groupTicks.Controls.Add(label9);
            groupTicks.Controls.Add(buttonTickColor);
            groupTicks.Controls.Add(textNumTicks);
            groupTicks.Controls.Add(label8);
            groupTicks.Controls.Add(textStartAngle);
            groupTicks.Controls.Add(label7);
            groupTicks.Controls.Add(textDegsPerTick);
            groupTicks.Controls.Add(label6);
            groupTicks.Controls.Add(textTickWidth);
            groupTicks.Controls.Add(label5);
            groupTicks.Controls.Add(button4);
            groupTicks.Controls.Add(textOuterRadius);
            groupTicks.Controls.Add(label4);
            groupTicks.Controls.Add(textInnerRadius);
            groupTicks.Controls.Add(label1);
            groupTicks.Location = new Point(38, 117);
            groupTicks.Name = "groupTicks";
            groupTicks.Size = new Size(1320, 319);
            groupTicks.TabIndex = 5;
            groupTicks.TabStop = false;
            groupTicks.Text = "Tickmarks";
            // 
            // button6
            // 
            button6.Location = new Point(1192, 265);
            button6.Name = "button6";
            button6.Size = new Size(108, 34);
            button6.TabIndex = 6;
            button6.Text = "Delete";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textTickCX
            // 
            textTickCX.Location = new Point(614, 163);
            textTickCX.Name = "textTickCX";
            textTickCX.Size = new Size(61, 31);
            textTickCX.TabIndex = 26;
            textTickCX.Text = "30";
            // 
            // listTickLayers
            // 
            listTickLayers.FormattingEnabled = true;
            listTickLayers.ItemHeight = 25;
            listTickLayers.Location = new Point(993, 30);
            listTickLayers.Name = "listTickLayers";
            listTickLayers.Size = new Size(307, 229);
            listTickLayers.TabIndex = 5;
            listTickLayers.SelectedIndexChanged += listTickLayers_SelectedIndexChanged;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(529, 169);
            label26.Name = "label26";
            label26.Size = new Size(79, 25);
            label26.TabIndex = 24;
            label26.Text = "Center X";
            // 
            // textTickCY
            // 
            textTickCY.Location = new Point(800, 166);
            textTickCY.Name = "textTickCY";
            textTickCY.Size = new Size(58, 31);
            textTickCY.TabIndex = 27;
            textTickCY.Text = "30";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(716, 169);
            label24.Name = "label24";
            label24.Size = new Size(78, 25);
            label24.TabIndex = 22;
            label24.Text = "Center Y";
            // 
            // checkTickActive
            // 
            checkTickActive.AutoSize = true;
            checkTickActive.Checked = true;
            checkTickActive.CheckState = CheckState.Checked;
            checkTickActive.Location = new Point(458, 49);
            checkTickActive.Name = "checkTickActive";
            checkTickActive.Size = new Size(86, 29);
            checkTickActive.TabIndex = 21;
            checkTickActive.Text = "Active";
            checkTickActive.UseVisualStyleBackColor = true;
            // 
            // textTickName
            // 
            textTickName.Location = new Point(104, 50);
            textTickName.Name = "textTickName";
            textTickName.Size = new Size(320, 31);
            textTickName.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(39, 53);
            label10.Name = "label10";
            label10.Size = new Size(59, 25);
            label10.TabIndex = 19;
            label10.Text = "Name";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(280, 169);
            label9.Name = "label9";
            label9.Size = new Size(90, 25);
            label9.TabIndex = 17;
            label9.Text = "Tick Color";
            // 
            // buttonTickColor
            // 
            buttonTickColor.BackColor = Color.White;
            buttonTickColor.Location = new Point(376, 164);
            buttonTickColor.Name = "buttonTickColor";
            buttonTickColor.Size = new Size(97, 34);
            buttonTickColor.TabIndex = 25;
            buttonTickColor.UseVisualStyleBackColor = false;
            buttonTickColor.Click += button5_Click;
            // 
            // textNumTicks
            // 
            textNumTicks.Location = new Point(625, 215);
            textNumTicks.Name = "textNumTicks";
            textNumTicks.Size = new Size(97, 31);
            textNumTicks.TabIndex = 30;
            textNumTicks.Text = "12";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(529, 218);
            label8.Name = "label8";
            label8.Size = new Size(94, 25);
            label8.TabIndex = 15;
            label8.Text = "Num Ticks";
            // 
            // textStartAngle
            // 
            textStartAngle.Location = new Point(127, 215);
            textStartAngle.Name = "textStartAngle";
            textStartAngle.Size = new Size(97, 31);
            textStartAngle.TabIndex = 28;
            textStartAngle.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 218);
            label7.Name = "label7";
            label7.Size = new Size(99, 25);
            label7.TabIndex = 13;
            label7.Text = "Start Angle";
            // 
            // textDegsPerTick
            // 
            textDegsPerTick.Location = new Point(376, 215);
            textDegsPerTick.Name = "textDegsPerTick";
            textDegsPerTick.Size = new Size(97, 31);
            textDegsPerTick.TabIndex = 29;
            textDegsPerTick.Text = "30";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(280, 218);
            label6.Name = "label6";
            label6.Size = new Size(90, 25);
            label6.TabIndex = 11;
            label6.Text = "Degs/Tick";
            // 
            // textTickWidth
            // 
            textTickWidth.Location = new Point(127, 166);
            textTickWidth.Name = "textTickWidth";
            textTickWidth.Size = new Size(97, 31);
            textTickWidth.TabIndex = 24;
            textTickWidth.Text = "1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 169);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 9;
            label5.Text = "Tick width";
            // 
            // button4
            // 
            button4.Location = new Point(761, 213);
            button4.Name = "button4";
            button4.Size = new Size(163, 34);
            button4.TabIndex = 31;
            button4.Text = "Add";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textOuterRadius
            // 
            textOuterRadius.Location = new Point(480, 109);
            textOuterRadius.Name = "textOuterRadius";
            textOuterRadius.Size = new Size(150, 31);
            textOuterRadius.TabIndex = 23;
            textOuterRadius.Text = "63";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(353, 112);
            label4.Name = "label4";
            label4.Size = new Size(115, 25);
            label4.TabIndex = 6;
            label4.Text = "Outer Radius";
            // 
            // textImageW
            // 
            textImageW.Location = new Point(104, 70);
            textImageW.Name = "textImageW";
            textImageW.Size = new Size(77, 31);
            textImageW.TabIndex = 1;
            textImageW.Text = "128";
            textImageW.TextChanged += textImageW_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 73);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 7;
            label2.Text = "Width";
            // 
            // textImageH
            // 
            textImageH.Location = new Point(266, 70);
            textImageH.Name = "textImageH";
            textImageH.Size = new Size(77, 31);
            textImageH.TabIndex = 2;
            textImageH.Text = "128";
            textImageH.TextChanged += textImageH_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(200, 73);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 9;
            label3.Text = "Height";
            // 
            // button3
            // 
            button3.Location = new Point(349, 68);
            button3.Name = "button3";
            button3.Size = new Size(84, 34);
            button3.TabIndex = 3;
            button3.Text = "New!";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // colorTicks
            // 
            colorTicks.AnyColor = true;
            colorTicks.FullOpen = true;
            // 
            // button5
            // 
            button5.Location = new Point(1382, 1097);
            button5.Name = "button5";
            button5.Size = new Size(163, 34);
            button5.TabIndex = 100;
            button5.Text = "Redraw";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(1192, 271);
            button1.Name = "button1";
            button1.Size = new Size(108, 34);
            button1.TabIndex = 8;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listTextLayers
            // 
            listTextLayers.FormattingEnabled = true;
            listTextLayers.ItemHeight = 25;
            listTextLayers.Location = new Point(993, 30);
            listTextLayers.Name = "listTextLayers";
            listTextLayers.Size = new Size(307, 229);
            listTextLayers.TabIndex = 7;
            listTextLayers.SelectedIndexChanged += listTextLayers_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(2437, 33);
            menuStrip1.TabIndex = 34;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveasToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(185, 34);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(185, 34);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(185, 34);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveasToolStripMenuItem
            // 
            saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
            saveasToolStripMenuItem.Size = new Size(185, 34);
            saveasToolStripMenuItem.Text = "Save &as...";
            saveasToolStripMenuItem.Click += saveasToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(182, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(185, 34);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // saveScaleDialog
            // 
            saveScaleDialog.DefaultExt = "*.scl";
            saveScaleDialog.Filter = "Scale files|*.scl|All files|*.*";
            // 
            // openScaleDialog
            // 
            openScaleDialog.DefaultExt = "*.scl";
            openScaleDialog.FileName = "openFileDialog1";
            openScaleDialog.Filter = "Scale files|*.scl|All files|*.*";
            // 
            // groupTexts
            // 
            groupTexts.Controls.Add(button1);
            groupTexts.Controls.Add(textTextCX);
            groupTexts.Controls.Add(listTextLayers);
            groupTexts.Controls.Add(label31);
            groupTexts.Controls.Add(textTextCY);
            groupTexts.Controls.Add(label32);
            groupTexts.Controls.Add(textTextStrings);
            groupTexts.Controls.Add(label19);
            groupTexts.Controls.Add(textTextFontName);
            groupTexts.Controls.Add(label16);
            groupTexts.Controls.Add(checkTextActive);
            groupTexts.Controls.Add(textTextName);
            groupTexts.Controls.Add(label11);
            groupTexts.Controls.Add(label12);
            groupTexts.Controls.Add(buttonTextColor);
            groupTexts.Controls.Add(textTextNumTicks);
            groupTexts.Controls.Add(label13);
            groupTexts.Controls.Add(textTextStartAngle);
            groupTexts.Controls.Add(label14);
            groupTexts.Controls.Add(textTextDegsPerTick);
            groupTexts.Controls.Add(label15);
            groupTexts.Controls.Add(button8);
            groupTexts.Controls.Add(textTextSize);
            groupTexts.Controls.Add(label17);
            groupTexts.Controls.Add(textTextRadius);
            groupTexts.Controls.Add(label18);
            groupTexts.Location = new Point(38, 442);
            groupTexts.Name = "groupTexts";
            groupTexts.Size = new Size(1320, 328);
            groupTexts.TabIndex = 21;
            groupTexts.TabStop = false;
            groupTexts.Text = "Text Arcs";
            // 
            // textTextCX
            // 
            textTextCX.Location = new Point(675, 161);
            textTextCX.Name = "textTextCX";
            textTextCX.Size = new Size(60, 31);
            textTextCX.TabIndex = 45;
            textTextCX.Text = "30";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(590, 164);
            label31.Name = "label31";
            label31.Size = new Size(79, 25);
            label31.TabIndex = 28;
            label31.Text = "Center X";
            // 
            // textTextCY
            // 
            textTextCY.Location = new Point(851, 161);
            textTextCY.Name = "textTextCY";
            textTextCY.Size = new Size(58, 31);
            textTextCY.TabIndex = 46;
            textTextCY.Text = "30";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(767, 164);
            label32.Name = "label32";
            label32.Size = new Size(78, 25);
            label32.TabIndex = 26;
            label32.Text = "Center Y";
            // 
            // textTextStrings
            // 
            textTextStrings.Location = new Point(96, 111);
            textTextStrings.Name = "textTextStrings";
            textTextStrings.Size = new Size(626, 31);
            textTextStrings.TabIndex = 42;
            textTextStrings.Text = "0,1,2,3,4,5,6,7,8,9,10,11";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(24, 114);
            label19.Name = "label19";
            label19.Size = new Size(66, 25);
            label19.TabIndex = 24;
            label19.Text = "Strings";
            // 
            // textTextFontName
            // 
            textTextFontName.Location = new Point(322, 161);
            textTextFontName.Name = "textTextFontName";
            textTextFontName.Size = new Size(219, 31);
            textTextFontName.TabIndex = 44;
            textTextFontName.Text = "Arial";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(219, 164);
            label16.Name = "label16";
            label16.Size = new Size(97, 25);
            label16.TabIndex = 22;
            label16.Text = "Font name";
            // 
            // checkTextActive
            // 
            checkTextActive.AutoSize = true;
            checkTextActive.Checked = true;
            checkTextActive.CheckState = CheckState.Checked;
            checkTextActive.Location = new Point(458, 49);
            checkTextActive.Name = "checkTextActive";
            checkTextActive.Size = new Size(86, 29);
            checkTextActive.TabIndex = 41;
            checkTextActive.Text = "Active";
            checkTextActive.UseVisualStyleBackColor = true;
            // 
            // textTextName
            // 
            textTextName.Location = new Point(104, 50);
            textTextName.Name = "textTextName";
            textTextName.Size = new Size(320, 31);
            textTextName.TabIndex = 40;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(39, 53);
            label11.Name = "label11";
            label11.Size = new Size(59, 25);
            label11.TabIndex = 19;
            label11.Text = "Name";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(43, 164);
            label12.Name = "label12";
            label12.Size = new Size(55, 25);
            label12.TabIndex = 17;
            label12.Text = "Color";
            // 
            // buttonTextColor
            // 
            buttonTextColor.BackColor = Color.White;
            buttonTextColor.Location = new Point(104, 159);
            buttonTextColor.Name = "buttonTextColor";
            buttonTextColor.Size = new Size(97, 34);
            buttonTextColor.TabIndex = 43;
            buttonTextColor.UseVisualStyleBackColor = false;
            buttonTextColor.Click += button7_Click;
            // 
            // textTextNumTicks
            // 
            textTextNumTicks.Location = new Point(625, 215);
            textTextNumTicks.Name = "textTextNumTicks";
            textTextNumTicks.Size = new Size(97, 31);
            textTextNumTicks.TabIndex = 49;
            textTextNumTicks.Text = "12";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(529, 218);
            label13.Name = "label13";
            label13.Size = new Size(94, 25);
            label13.TabIndex = 15;
            label13.Text = "Num Ticks";
            // 
            // textTextStartAngle
            // 
            textTextStartAngle.Location = new Point(127, 215);
            textTextStartAngle.Name = "textTextStartAngle";
            textTextStartAngle.Size = new Size(97, 31);
            textTextStartAngle.TabIndex = 47;
            textTextStartAngle.Text = "0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(19, 218);
            label14.Name = "label14";
            label14.Size = new Size(99, 25);
            label14.TabIndex = 13;
            label14.Text = "Start Angle";
            // 
            // textTextDegsPerTick
            // 
            textTextDegsPerTick.Location = new Point(376, 215);
            textTextDegsPerTick.Name = "textTextDegsPerTick";
            textTextDegsPerTick.Size = new Size(97, 31);
            textTextDegsPerTick.TabIndex = 48;
            textTextDegsPerTick.Text = "30";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(280, 218);
            label15.Name = "label15";
            label15.Size = new Size(90, 25);
            label15.TabIndex = 11;
            label15.Text = "Degs/Tick";
            // 
            // button8
            // 
            button8.Location = new Point(761, 271);
            button8.Name = "button8";
            button8.Size = new Size(163, 34);
            button8.TabIndex = 52;
            button8.Text = "Add";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // textTextSize
            // 
            textTextSize.Location = new Point(332, 268);
            textTextSize.Name = "textTextSize";
            textTextSize.Size = new Size(75, 31);
            textTextSize.TabIndex = 51;
            textTextSize.Text = "10";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(244, 271);
            label17.Name = "label17";
            label17.Size = new Size(82, 25);
            label17.TabIndex = 6;
            label17.Text = "Font size";
            // 
            // textTextRadius
            // 
            textTextRadius.Location = new Point(136, 268);
            textTextRadius.Name = "textTextRadius";
            textTextRadius.Size = new Size(91, 31);
            textTextRadius.TabIndex = 50;
            textTextRadius.Text = "58";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(65, 271);
            label18.Name = "label18";
            label18.Size = new Size(65, 25);
            label18.TabIndex = 4;
            label18.Text = "Radius";
            // 
            // colorText
            // 
            colorText.AnyColor = true;
            colorText.FullOpen = true;
            // 
            // groupArcs
            // 
            groupArcs.Controls.Add(button7);
            groupArcs.Controls.Add(checkSolid);
            groupArcs.Controls.Add(listArcLayers);
            groupArcs.Controls.Add(textArcCX);
            groupArcs.Controls.Add(label29);
            groupArcs.Controls.Add(textArcSweepAngle);
            groupArcs.Controls.Add(textArcCY);
            groupArcs.Controls.Add(label22);
            groupArcs.Controls.Add(label30);
            groupArcs.Controls.Add(checkArcActive);
            groupArcs.Controls.Add(textArcName);
            groupArcs.Controls.Add(label20);
            groupArcs.Controls.Add(label21);
            groupArcs.Controls.Add(buttonArcColor);
            groupArcs.Controls.Add(textArcStartAngle);
            groupArcs.Controls.Add(label23);
            groupArcs.Controls.Add(textArcWidth);
            groupArcs.Controls.Add(label25);
            groupArcs.Controls.Add(button9);
            groupArcs.Controls.Add(textArcRadius);
            groupArcs.Controls.Add(label27);
            groupArcs.Location = new Point(38, 776);
            groupArcs.Name = "groupArcs";
            groupArcs.Size = new Size(1320, 310);
            groupArcs.TabIndex = 21;
            groupArcs.TabStop = false;
            groupArcs.Text = "Arcs";
            // 
            // button7
            // 
            button7.Location = new Point(1192, 265);
            button7.Name = "button7";
            button7.Size = new Size(108, 34);
            button7.TabIndex = 10;
            button7.Text = "Delete";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // checkSolid
            // 
            checkSolid.AutoSize = true;
            checkSolid.Checked = true;
            checkSolid.CheckState = CheckState.Checked;
            checkSolid.Location = new Point(500, 163);
            checkSolid.Name = "checkSolid";
            checkSolid.Size = new Size(78, 29);
            checkSolid.TabIndex = 69;
            checkSolid.Text = "Solid";
            checkSolid.UseVisualStyleBackColor = true;
            // 
            // listArcLayers
            // 
            listArcLayers.FormattingEnabled = true;
            listArcLayers.ItemHeight = 25;
            listArcLayers.Location = new Point(993, 30);
            listArcLayers.Name = "listArcLayers";
            listArcLayers.Size = new Size(307, 229);
            listArcLayers.TabIndex = 9;
            listArcLayers.SelectedIndexChanged += listArcLayers_SelectedIndexChanged;
            // 
            // textArcCX
            // 
            textArcCX.Location = new Point(713, 109);
            textArcCX.Name = "textArcCX";
            textArcCX.Size = new Size(55, 31);
            textArcCX.TabIndex = 65;
            textArcCX.Text = "30";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(628, 112);
            label29.Name = "label29";
            label29.Size = new Size(79, 25);
            label29.TabIndex = 28;
            label29.Text = "Center X";
            // 
            // textArcSweepAngle
            // 
            textArcSweepAngle.Location = new Point(371, 161);
            textArcSweepAngle.Name = "textArcSweepAngle";
            textArcSweepAngle.Size = new Size(97, 31);
            textArcSweepAngle.TabIndex = 68;
            textArcSweepAngle.Text = "360";
            // 
            // textArcCY
            // 
            textArcCY.Location = new Point(874, 109);
            textArcCY.Name = "textArcCY";
            textArcCY.Size = new Size(56, 31);
            textArcCY.TabIndex = 66;
            textArcCY.Text = "30";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(250, 164);
            label22.Name = "label22";
            label22.Size = new Size(115, 25);
            label22.TabIndex = 22;
            label22.Text = "Sweep Angle";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(790, 112);
            label30.Name = "label30";
            label30.Size = new Size(78, 25);
            label30.TabIndex = 26;
            label30.Text = "Center Y";
            // 
            // checkArcActive
            // 
            checkArcActive.AutoSize = true;
            checkArcActive.Checked = true;
            checkArcActive.CheckState = CheckState.Checked;
            checkArcActive.Location = new Point(458, 49);
            checkArcActive.Name = "checkArcActive";
            checkArcActive.Size = new Size(86, 29);
            checkArcActive.TabIndex = 61;
            checkArcActive.Text = "Active";
            checkArcActive.UseVisualStyleBackColor = true;
            // 
            // textArcName
            // 
            textArcName.Location = new Point(104, 50);
            textArcName.Name = "textArcName";
            textArcName.Size = new Size(320, 31);
            textArcName.TabIndex = 60;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(39, 53);
            label20.Name = "label20";
            label20.Size = new Size(59, 25);
            label20.TabIndex = 19;
            label20.Text = "Name";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(280, 112);
            label21.Name = "label21";
            label21.Size = new Size(55, 25);
            label21.TabIndex = 17;
            label21.Text = "Color";
            // 
            // buttonArcColor
            // 
            buttonArcColor.BackColor = Color.White;
            buttonArcColor.Location = new Point(341, 107);
            buttonArcColor.Name = "buttonArcColor";
            buttonArcColor.Size = new Size(97, 34);
            buttonArcColor.TabIndex = 63;
            buttonArcColor.UseVisualStyleBackColor = false;
            buttonArcColor.Click += buttonArcColor_Click;
            // 
            // textArcStartAngle
            // 
            textArcStartAngle.Location = new Point(129, 161);
            textArcStartAngle.Name = "textArcStartAngle";
            textArcStartAngle.Size = new Size(97, 31);
            textArcStartAngle.TabIndex = 67;
            textArcStartAngle.Text = "0";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(21, 164);
            label23.Name = "label23";
            label23.Size = new Size(99, 25);
            label23.TabIndex = 13;
            label23.Text = "Start Angle";
            // 
            // textArcWidth
            // 
            textArcWidth.Location = new Point(536, 109);
            textArcWidth.Name = "textArcWidth";
            textArcWidth.Size = new Size(68, 31);
            textArcWidth.TabIndex = 64;
            textArcWidth.Text = "1";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(467, 112);
            label25.Name = "label25";
            label25.Size = new Size(60, 25);
            label25.TabIndex = 9;
            label25.Text = "Width";
            // 
            // button9
            // 
            button9.Location = new Point(761, 164);
            button9.Name = "button9";
            button9.Size = new Size(163, 34);
            button9.TabIndex = 70;
            button9.Text = "Add";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // textArcRadius
            // 
            textArcRadius.Location = new Point(110, 109);
            textArcRadius.Name = "textArcRadius";
            textArcRadius.Size = new Size(150, 31);
            textArcRadius.TabIndex = 62;
            textArcRadius.Text = "58";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(39, 112);
            label27.Name = "label27";
            label27.Size = new Size(65, 25);
            label27.TabIndex = 4;
            label27.Text = "Radius";
            // 
            // colorArcs
            // 
            colorArcs.AnyColor = true;
            colorArcs.FullOpen = true;
            // 
            // button10
            // 
            button10.Location = new Point(484, 68);
            button10.Name = "button10";
            button10.Size = new Size(121, 34);
            button10.TabIndex = 4;
            button10.Text = "Load...";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // openBackdrop
            // 
            openBackdrop.DefaultExt = "*.png";
            openBackdrop.FileName = "openBackdrop";
            openBackdrop.Filter = "Bmp file|*.bmp|PNG files|*.png|All files|*.*";
            // 
            // labelCenter
            // 
            labelCenter.AutoSize = true;
            labelCenter.Location = new Point(628, 68);
            labelCenter.Name = "labelCenter";
            labelCenter.Size = new Size(0, 25);
            labelCenter.TabIndex = 25;
            // 
            // checkShowCenter
            // 
            checkShowCenter.AutoSize = true;
            checkShowCenter.Location = new Point(1571, 1101);
            checkShowCenter.Name = "checkShowCenter";
            checkShowCenter.Size = new Size(138, 29);
            checkShowCenter.TabIndex = 101;
            checkShowCenter.Text = "Show Center";
            checkShowCenter.UseVisualStyleBackColor = true;
            checkShowCenter.CheckedChanged += checkShowCenter_CheckedChanged;
            // 
            // groupLabels
            // 
            groupLabels.Controls.Add(button11);
            groupLabels.Controls.Add(textLabelX);
            groupLabels.Controls.Add(listLabelLayers);
            groupLabels.Controls.Add(label28);
            groupLabels.Controls.Add(textLabelText);
            groupLabels.Controls.Add(textLabelY);
            groupLabels.Controls.Add(label33);
            groupLabels.Controls.Add(label34);
            groupLabels.Controls.Add(checkLabelActive);
            groupLabels.Controls.Add(textLabelName);
            groupLabels.Controls.Add(label35);
            groupLabels.Controls.Add(label36);
            groupLabels.Controls.Add(buttonLabelColor);
            groupLabels.Controls.Add(textLabelSize);
            groupLabels.Controls.Add(label38);
            groupLabels.Controls.Add(button12);
            groupLabels.Controls.Add(textLabelFont);
            groupLabels.Controls.Add(label39);
            groupLabels.Location = new Point(38, 1092);
            groupLabels.Name = "groupLabels";
            groupLabels.Size = new Size(1320, 309);
            groupLabels.TabIndex = 29;
            groupLabels.TabStop = false;
            groupLabels.Text = "Labels";
            // 
            // button11
            // 
            button11.Location = new Point(1192, 265);
            button11.Name = "button11";
            button11.Size = new Size(108, 34);
            button11.TabIndex = 12;
            button11.Text = "Delete";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click_1;
            // 
            // textLabelX
            // 
            textLabelX.Location = new Point(703, 106);
            textLabelX.Name = "textLabelX";
            textLabelX.Size = new Size(56, 31);
            textLabelX.TabIndex = 85;
            textLabelX.Text = "30";
            // 
            // listLabelLayers
            // 
            listLabelLayers.FormattingEnabled = true;
            listLabelLayers.ItemHeight = 25;
            listLabelLayers.Location = new Point(993, 30);
            listLabelLayers.Name = "listLabelLayers";
            listLabelLayers.Size = new Size(307, 229);
            listLabelLayers.TabIndex = 11;
            listLabelLayers.SelectedIndexChanged += listLabelLayers_SelectedIndexChanged;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(674, 109);
            label28.Name = "label28";
            label28.Size = new Size(23, 25);
            label28.TabIndex = 28;
            label28.Text = "X";
            // 
            // textLabelText
            // 
            textLabelText.Location = new Point(93, 161);
            textLabelText.Name = "textLabelText";
            textLabelText.Size = new Size(375, 31);
            textLabelText.TabIndex = 87;
            textLabelText.Text = "ALT";
            // 
            // textLabelY
            // 
            textLabelY.Location = new Point(815, 103);
            textLabelY.Name = "textLabelY";
            textLabelY.Size = new Size(55, 31);
            textLabelY.TabIndex = 86;
            textLabelY.Text = "30";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(39, 164);
            label33.Name = "label33";
            label33.Size = new Size(42, 25);
            label33.TabIndex = 22;
            label33.Text = "Text";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(787, 106);
            label34.Name = "label34";
            label34.Size = new Size(22, 25);
            label34.TabIndex = 26;
            label34.Text = "Y";
            // 
            // checkLabelActive
            // 
            checkLabelActive.AutoSize = true;
            checkLabelActive.Checked = true;
            checkLabelActive.CheckState = CheckState.Checked;
            checkLabelActive.Location = new Point(458, 49);
            checkLabelActive.Name = "checkLabelActive";
            checkLabelActive.Size = new Size(86, 29);
            checkLabelActive.TabIndex = 81;
            checkLabelActive.Text = "Active";
            checkLabelActive.UseVisualStyleBackColor = true;
            // 
            // textLabelName
            // 
            textLabelName.Location = new Point(104, 50);
            textLabelName.Name = "textLabelName";
            textLabelName.Size = new Size(320, 31);
            textLabelName.TabIndex = 80;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(39, 53);
            label35.Name = "label35";
            label35.Size = new Size(59, 25);
            label35.TabIndex = 19;
            label35.Text = "Name";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(280, 112);
            label36.Name = "label36";
            label36.Size = new Size(55, 25);
            label36.TabIndex = 17;
            label36.Text = "Color";
            // 
            // buttonLabelColor
            // 
            buttonLabelColor.BackColor = Color.White;
            buttonLabelColor.Location = new Point(341, 107);
            buttonLabelColor.Name = "buttonLabelColor";
            buttonLabelColor.Size = new Size(97, 34);
            buttonLabelColor.TabIndex = 83;
            buttonLabelColor.UseVisualStyleBackColor = false;
            buttonLabelColor.Click += buttonLabelColor_Click;
            // 
            // textLabelSize
            // 
            textLabelSize.Location = new Point(557, 109);
            textLabelSize.Name = "textLabelSize";
            textLabelSize.Size = new Size(68, 31);
            textLabelSize.TabIndex = 84;
            textLabelSize.Text = "8";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(467, 112);
            label38.Name = "label38";
            label38.Size = new Size(84, 25);
            label38.TabIndex = 9;
            label38.Text = "Font Size";
            // 
            // button12
            // 
            button12.Location = new Point(761, 155);
            button12.Name = "button12";
            button12.Size = new Size(163, 34);
            button12.TabIndex = 99;
            button12.Text = "Add";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // textLabelFont
            // 
            textLabelFont.Location = new Point(93, 109);
            textLabelFont.Name = "textLabelFont";
            textLabelFont.Size = new Size(167, 31);
            textLabelFont.TabIndex = 82;
            textLabelFont.Text = "Arial";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(39, 112);
            label39.Name = "label39";
            label39.Size = new Size(48, 25);
            label39.TabIndex = 4;
            label39.Text = "Font";
            // 
            // colorLabels
            // 
            colorLabels.AnyColor = true;
            colorLabels.FullOpen = true;
            // 
            // textScaleFactor
            // 
            textScaleFactor.Location = new Point(2246, 1099);
            textScaleFactor.Name = "textScaleFactor";
            textScaleFactor.Size = new Size(150, 31);
            textScaleFactor.TabIndex = 32;
            textScaleFactor.Text = "1";
            // 
            // button13
            // 
            button13.Location = new Point(2099, 1097);
            button13.Name = "button13";
            button13.Size = new Size(141, 34);
            button13.TabIndex = 13;
            button13.Text = "Resize all";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2437, 1421);
            Controls.Add(button13);
            Controls.Add(textScaleFactor);
            Controls.Add(groupLabels);
            Controls.Add(checkShowCenter);
            Controls.Add(labelCenter);
            Controls.Add(button10);
            Controls.Add(groupArcs);
            Controls.Add(groupTexts);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(textImageH);
            Controls.Add(label3);
            Controls.Add(textImageW);
            Controls.Add(label2);
            Controls.Add(groupTicks);
            Controls.Add(button2);
            Controls.Add(picturePreview);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picturePreview).EndInit();
            groupTicks.ResumeLayout(false);
            groupTicks.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupTexts.ResumeLayout(false);
            groupTexts.PerformLayout();
            groupArcs.ResumeLayout(false);
            groupArcs.PerformLayout();
            groupLabels.ResumeLayout(false);
            groupLabels.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox picturePreview;
        private SaveFileDialog saveExportPng;
        private Button button2;
        private TextBox textInnerRadius;
        private Label label1;
        private GroupBox groupTicks;
        private TextBox textImageW;
        private Label label2;
        private TextBox textImageH;
        private Label label3;
        private Button button3;
        private TextBox textOuterRadius;
        private Label label4;
        private Button button4;
        private TextBox textTickWidth;
        private Label label5;
        private TextBox textDegsPerTick;
        private Label label6;
        private TextBox textNumTicks;
        private Label label8;
        private TextBox textStartAngle;
        private Label label7;
        private Label label9;
        private Button buttonTickColor;
        private ColorDialog colorTicks;
        private Button button5;
        private TextBox textTickName;
        private Label label10;
        private ListBox listTextLayers;
        private CheckBox checkTickActive;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private SaveFileDialog saveScaleDialog;
        private OpenFileDialog openScaleDialog;
        private GroupBox groupTexts;
        private CheckBox checkTextActive;
        private TextBox textTextName;
        private Label label11;
        private Label label12;
        private Button buttonTextColor;
        private TextBox textTextNumTicks;
        private Label label13;
        private TextBox textTextStartAngle;
        private Label label14;
        private TextBox textTextDegsPerTick;
        private Label label15;
        private Button button8;
        private TextBox textTextSize;
        private Label label17;
        private TextBox textTextRadius;
        private Label label18;
        private FontDialog fontDialog;
        private TextBox textTextFontName;
        private Label label16;
        private ColorDialog colorText;
        private TextBox textTextStrings;
        private Label label19;
        private GroupBox groupArcs;
        private CheckBox checkArcActive;
        private TextBox textArcName;
        private Label label20;
        private Label label21;
        private Button buttonArcColor;
        private TextBox textArcStartAngle;
        private Label label23;
        private TextBox textArcWidth;
        private Label label25;
        private Button button9;
        private TextBox textArcRadius;
        private Label label27;
        private TextBox textArcSweepAngle;
        private Label label22;
        private Button button7;
        private ListBox listArcLayers;
        private ColorDialog colorArcs;
        private ToolStripMenuItem newToolStripMenuItem;
        private Button button10;
        private OpenFileDialog openBackdrop;
        private TextBox textTickCX;
        private Label label26;
        private TextBox textTickCY;
        private Label label24;
        private Label labelCenter;
        private TextBox textArcCX;
        private Label label29;
        private TextBox textArcCY;
        private Label label30;
        private TextBox textTextCX;
        private Label label31;
        private TextBox textTextCY;
        private Label label32;
        private CheckBox checkShowCenter;
        private GroupBox groupLabels;
        private TextBox textLabelX;
        private Label label28;
        private TextBox textLabelText;
        private TextBox textLabelY;
        private Label label33;
        private Label label34;
        private CheckBox checkLabelActive;
        private TextBox textLabelName;
        private Label label35;
        private Label label36;
        private Button buttonLabelColor;
        private TextBox textLabelSize;
        private Label label38;
        private Button button12;
        private TextBox textLabelFont;
        private Label label39;
        private Button button11;
        private ListBox listLabelLayers;
        private ToolStripMenuItem saveasToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ColorDialog colorLabels;
        private CheckBox checkSolid;
        private TextBox textScaleFactor;
        private Button button13;
        private Button button6;
        private ListBox listTickLayers;
    }
}