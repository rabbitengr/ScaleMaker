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
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.textInnerRadius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonTickColor = new System.Windows.Forms.Button();
            this.textNumTicks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textStartAngle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textDegsPerTick = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textTickWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textOuterRadius = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textImageW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textImageH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.colorTicks = new System.Windows.Forms.ColorDialog();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picturePreview
            // 
            this.picturePreview.BackColor = System.Drawing.Color.Black;
            this.picturePreview.Location = new System.Drawing.Point(810, 12);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(512, 512);
            this.picturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePreview.TabIndex = 1;
            this.picturePreview.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "PNG files|*.png|All files|*.*";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1159, 530);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 34);
            this.button2.TabIndex = 31;
            this.button2.Text = "save as PNG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textInnerRadius
            // 
            this.textInnerRadius.Location = new System.Drawing.Point(166, 52);
            this.textInnerRadius.Name = "textInnerRadius";
            this.textInnerRadius.Size = new System.Drawing.Size(150, 31);
            this.textInnerRadius.TabIndex = 3;
            this.textInnerRadius.Text = "58";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inner Radius";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.buttonTickColor);
            this.groupBox1.Controls.Add(this.textNumTicks);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textStartAngle);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textDegsPerTick);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textTickWidth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.textOuterRadius);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textInnerRadius);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 294);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tickmarks";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tick Color";
            // 
            // buttonTickColor
            // 
            this.buttonTickColor.BackColor = System.Drawing.Color.White;
            this.buttonTickColor.Location = new System.Drawing.Point(376, 107);
            this.buttonTickColor.Name = "buttonTickColor";
            this.buttonTickColor.Size = new System.Drawing.Size(97, 34);
            this.buttonTickColor.TabIndex = 6;
            this.buttonTickColor.UseVisualStyleBackColor = false;
            this.buttonTickColor.Click += new System.EventHandler(this.button5_Click);
            // 
            // textNumTicks
            // 
            this.textNumTicks.Location = new System.Drawing.Point(625, 158);
            this.textNumTicks.Name = "textNumTicks";
            this.textNumTicks.Size = new System.Drawing.Size(97, 31);
            this.textNumTicks.TabIndex = 9;
            this.textNumTicks.Text = "12";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(529, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Num Ticks";
            // 
            // textStartAngle
            // 
            this.textStartAngle.Location = new System.Drawing.Point(127, 158);
            this.textStartAngle.Name = "textStartAngle";
            this.textStartAngle.Size = new System.Drawing.Size(97, 31);
            this.textStartAngle.TabIndex = 7;
            this.textStartAngle.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Start Angle";
            // 
            // textDegsPerTick
            // 
            this.textDegsPerTick.Location = new System.Drawing.Point(376, 158);
            this.textDegsPerTick.Name = "textDegsPerTick";
            this.textDegsPerTick.Size = new System.Drawing.Size(97, 31);
            this.textDegsPerTick.TabIndex = 8;
            this.textDegsPerTick.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Degs/Tick";
            // 
            // textTickWidth
            // 
            this.textTickWidth.Location = new System.Drawing.Point(127, 109);
            this.textTickWidth.Name = "textTickWidth";
            this.textTickWidth.Size = new System.Drawing.Size(97, 31);
            this.textTickWidth.TabIndex = 5;
            this.textTickWidth.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tick width";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(559, 228);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 34);
            this.button4.TabIndex = 10;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textOuterRadius
            // 
            this.textOuterRadius.Location = new System.Drawing.Point(480, 52);
            this.textOuterRadius.Name = "textOuterRadius";
            this.textOuterRadius.Size = new System.Drawing.Size(150, 31);
            this.textOuterRadius.TabIndex = 4;
            this.textOuterRadius.Text = "63";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Outer Radius";
            // 
            // textImageW
            // 
            this.textImageW.Location = new System.Drawing.Point(104, 41);
            this.textImageW.Name = "textImageW";
            this.textImageW.Size = new System.Drawing.Size(150, 31);
            this.textImageW.TabIndex = 1;
            this.textImageW.Text = "128";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Width";
            // 
            // textImageH
            // 
            this.textImageH.Location = new System.Drawing.Point(385, 41);
            this.textImageH.Name = "textImageH";
            this.textImageH.Size = new System.Drawing.Size(150, 31);
            this.textImageH.TabIndex = 2;
            this.textImageH.Text = "128";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Height";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(588, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 34);
            this.button3.TabIndex = 10;
            this.button3.Text = "New!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // colorTicks
            // 
            this.colorTicks.AnyColor = true;
            this.colorTicks.FullOpen = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(810, 530);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(163, 34);
            this.button5.TabIndex = 30;
            this.button5.Text = "Undo!";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 583);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textImageH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textImageW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.picturePreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox picturePreview;
        private SaveFileDialog saveFileDialog1;
        private Button button2;
        private TextBox textInnerRadius;
        private Label label1;
        private GroupBox groupBox1;
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
    }
}