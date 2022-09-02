using System.Drawing;
using static System.Windows.Forms.DataFormats;
using System.IO;
using System.Drawing.Drawing2D;
using Microsoft.Win32;
using System.Runtime.CompilerServices;

namespace ScaleMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int W;
        private int H;
        private int CX;
        private int CY;
        private Graphics g;
        private Bitmap bmp;        
        private string regPath = "software\\Rabbit Engineering\\ScaleMaker";
        private string appTitle = "ScaleMaker build 9/1/2022";
        List<tick_layer> tick_layers;
        List<text_layer> text_layers;
        List<arc_layer> arc_layers;

        private void DrawLine(Color col, int linew, double angle, float radius_outer, float radius_inner)
        {
            using (Pen p = new Pen(col, linew))
            {
                double rads = (double)(angle) * 0.01745329;
                Point inner = new Point((int)(radius_inner * Math.Sin(rads)) + CX, -(int)(radius_inner * Math.Cos(rads)) + CY);
                Point outer = new Point((int)(radius_outer * Math.Sin(rads)) + CX, -(int)(radius_outer * Math.Cos(rads)) + CY);
                g.DrawLine(p, inner, outer);
            }
        }

        private void DrawNumber(Color col, double angle, float radius, string fontname, int fontsize, string num)
        {
            double rads = (double)(angle) * 0.01745329;
            Point pf = new Point((int)(radius * Math.Sin(rads)) + CX, -(int)(radius * Math.Cos(rads)) + CY);

            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                using (FontFamily ff = new FontFamily(fontname))
                {
                    using (SolidBrush br = new SolidBrush(col))
                    {
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            path.AddString(num, ff, 0, fontsize, pf, sf);
                            g.FillPath(br, path);
                        }
                    }
                }
            }
        }

        private void DrawArc(Color col, int width, float _radius, double _start_angle, double _sweep_angle)
        {
            int radius = (int)_radius;
            float start_angle = (float)_start_angle - 90;
            float sweep_angle = (float)_sweep_angle;

            using (Pen p = new Pen(col, width))
            {
                Point c = new Point(CX-radius, CY-radius);
                Size s = new Size(radius * 2, radius * 2);
                Rectangle r = new Rectangle(c, s);
                g.DrawArc(p, r, start_angle, sweep_angle);
            }
        }

        private string ReadRegKey(string prop)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(regPath))
            {
                if (key == null) return null;

                return (string)key.GetValue(prop);
            }
        }
        private void WriteRegKey(string prop, string value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(regPath))
            {
                key.SetValue(prop, value);                
            }
        }

        private void PrepScale(int _w, int _h)
        {
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();

            groupTicks.Enabled = true;
            groupArcs.Enabled = true;
            groupTexts.Enabled = true;

            W = _w; 
            H = _h;
            CX = W / 2;
            CY = H / 2;
            bmp = new Bitmap(W, H);
            g = Graphics.FromImage(bmp);            
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (SolidBrush b = new SolidBrush(Color.Red))
            {
                Rectangle r = new Rectangle(CX, CY, 1, 1);
                g.FillRectangle(b, r);
            }
            picturePreview.Image = bmp;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConfirmExit())
            {
                if (g != null) g.Dispose();
                if (bmp != null) bmp.Dispose();
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bmp == null) return;

            if (this.saveExportPng.ShowDialog() != DialogResult.OK) return;

            bmp.Save(this.saveExportPng.FileName);
            WriteRegKey("pngpath", this.saveExportPng.FileName);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picturePreview.Image = System.Drawing.SystemIcons.Question.ToBitmap();
            this.Text = appTitle;
            string s = ReadRegKey("pngpath");
            if (!string.IsNullOrEmpty(s)) this.saveExportPng.FileName = s;
            s = ReadRegKey("sclpath");
            if (!string.IsNullOrEmpty(s))
            {
                this.saveScaleDialog.FileName = s;
                this.openScaleDialog.FileName = s;
            }
            
            tick_layers = new List<tick_layer>();
            text_layers = new List<text_layer>();
            arc_layers = new List<arc_layer>();
            groupTicks.Enabled = false;
            groupTexts.Enabled = false;
            groupArcs.Enabled = false;
        }

        private void RenderArcLayers()
        {
            foreach (arc_layer tl in arc_layers)
            {
                if (!tl.active) continue;

                DrawArc(tl.col, tl.width, tl.radius, tl.startangle, tl.sweepangle);                
            }
        }

        private void RenderTickLayers()
        {
            foreach (tick_layer tl in tick_layers)
            {
                if (!tl.active) continue;

                for (int t = 0; t < tl.numticks; t++)
                {
                    DrawLine(tl.col, tl.width, tl.startangle + (double)t * tl.degspertick, tl.outer_radius, tl.inner_radius);
                }
            }
        }
        private void RenderTextLayers()
        {

            foreach (text_layer tl in text_layers)
            {
                if (!tl.active) continue;

                for (int t = 0; t < tl.numticks; t++)
                {
                    //DrawLine(tl.col, tl.width, tl.startangle + (double)t * tl.degspertick, tl.outer_radius, tl.inner_radius);
                    DrawNumber(tl.col, tl.startangle + (double)t * tl.degspertick, tl.radius, tl.fontname, tl.size, tl.strings[t]);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textImageW.Text)) return;
            if (string.IsNullOrEmpty(textImageH.Text)) return;
            
            PrepScale(Convert.ToInt32(textImageW.Text), Convert.ToInt32(textImageH.Text));
        }

        private bool ConfirmExit()
        {
            if (MessageBox.Show("Unsaved data will be lost", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) 
                return false;

            return true;
        }

        private bool CheckTickMarkData()
        {
            if (bmp == null) return false;
            if (g == null) return false;
            if (string.IsNullOrEmpty(textInnerRadius.Text)) return false;
            if (string.IsNullOrEmpty(textOuterRadius.Text)) return false;
            if (string.IsNullOrEmpty(textTickWidth.Text)) return false;
            if (string.IsNullOrEmpty(textStartAngle.Text)) return false;
            if (string.IsNullOrEmpty(textDegsPerTick.Text)) return false;
            if (string.IsNullOrEmpty(textNumTicks.Text)) return false;

            return true;
        }

        private bool CheckArcData()
        {
            if (bmp == null) return false;
            if (g == null) return false;
            if (string.IsNullOrEmpty(textArcRadius.Text)) return false;
            if (string.IsNullOrEmpty(textArcWidth.Text)) return false;
            if (string.IsNullOrEmpty(textArcStartAngle.Text)) return false;
            if (string.IsNullOrEmpty(textArcSweepAngle.Text)) return false;            

            return true;
        }

        private bool CheckTextData()
        {
            if (bmp == null) return false;
            if (g == null) return false;
            if (string.IsNullOrEmpty(textTextRadius.Text)) return false;            
            if (string.IsNullOrEmpty(textTextDegsPerTick.Text)) return false;
            if (string.IsNullOrEmpty(textTextStartAngle.Text)) return false;            
            if (string.IsNullOrEmpty(textTextNumTicks.Text)) return false;
            if (string.IsNullOrEmpty(textTextFontName.Text)) return false;            
            if (string.IsNullOrEmpty(textTextSize.Text)) return false;
            if (string.IsNullOrEmpty(textTextStrings.Text)) return false;                        

            return true;
        }

        void RefreshListboxes()
        {
            listTickLayers.Items.Clear();
            foreach(tick_layer tl in tick_layers)
            {
                listTickLayers.Items.Add(tl.name);
            }
            listTickLayers.Invalidate();

            listTextLayers.Items.Clear();
            foreach (text_layer tl in text_layers)
            {
              listTextLayers.Items.Add(tl.name);
            }
            listTextLayers.Invalidate();

            listArcLayers.Items.Clear();
            foreach (arc_layer tl in arc_layers)
            {
                listArcLayers.Items.Add(tl.name);
            }
            listArcLayers.Invalidate();
        }
        private void SetTickLayer(tick_layer tl)
        {
            textTickName.Text = tl.name;
            if (tl.active)
            {
                checkTickActive.Checked = true;
            }
            else
            {
                checkTickActive.Checked = false;
            }
            textInnerRadius.Text = Convert.ToString(tl.inner_radius);
            textOuterRadius.Text = Convert.ToString(tl.outer_radius);
            textStartAngle.Text = Convert.ToString(tl.startangle);
            buttonTickColor.BackColor = tl.col;
            textNumTicks.Text = Convert.ToString(tl.numticks);
            textDegsPerTick.Text = Convert.ToString(tl.degspertick);
            textTickWidth.Text = Convert.ToString(tl.width);            
        }

        private void SetArcLayer(arc_layer tl)
        {
            textArcName.Text = tl.name;
            if (tl.active)
            {
                checkArcActive.Checked = true;
            }
            else
            {
                checkArcActive.Checked = false;
            }
            textArcRadius.Text = Convert.ToString(tl.radius);
            textArcStartAngle.Text = Convert.ToString(tl.startangle);
            textArcWidth.Text = Convert.ToString(tl.width);
            textArcSweepAngle.Text = Convert.ToString(tl.sweepangle);
            buttonArcColor.BackColor = tl.col;
        }

        private void SetTextLayer(text_layer tl)
        {
            textTextName.Text = tl.name;
            if (tl.active)
            {
                checkTextActive.Checked = true;
            }
            else
            {
                checkTextActive.Checked = false;
            }
            textTextRadius.Text = Convert.ToString(tl.radius);            
            textTextStartAngle.Text = Convert.ToString(tl.startangle);
            buttonTextColor.BackColor = tl.col;
            textTextNumTicks.Text = Convert.ToString(tl.numticks);
            textTextDegsPerTick.Text = Convert.ToString(tl.degspertick);
            textTextSize.Text = Convert.ToString(tl.size);
            textTextStrings.Text = tl.raw_strings;
            textTextFontName.Text = tl.fontname;
        }

        private void SaveScale()
        {
            if (g == null) return;
            if (bmp == null) return;
            if (saveScaleDialog.ShowDialog() == DialogResult.Cancel) return;
            WriteRegKey("sclpath", this.saveScaleDialog.FileName);
            openScaleDialog.FileName = saveScaleDialog.FileName;

            using(TextWriter write = new StreamWriter(saveScaleDialog.FileName))
            {
                write.WriteLine("v1");
                write.WriteLine("{0},{1}", W, H);
                write.WriteLine("{0}", tick_layers.Count);
                foreach (tick_layer tl in tick_layers)
                {
                    tl.write(write);
                }                
                write.WriteLine("{0}", text_layers.Count);
                foreach (text_layer nl in text_layers)
                {
                    nl.write(write);
                }
                write.WriteLine("{0}", arc_layers.Count);
                foreach (arc_layer nl in arc_layers)
                {
                    nl.write(write);
                }
            }
        }

        private void OpenScale()
        {
            if (openScaleDialog.ShowDialog() == DialogResult.Cancel) return;            
            saveScaleDialog.FileName = openScaleDialog.FileName;

            char[] comma = { ',' };

            using (TextReader read = new StreamReader(openScaleDialog.FileName))
            {
                string magic = read.ReadLine(); // "v1");
                if (magic != "v1")
                {
                    MessageBox.Show(String.Format("{0} is not a valid SCL file.", openScaleDialog.FileName), "Invalid file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string s = read.ReadLine();//write.WriteLine("{0},{1}", W, H);
                string[] parts = s.Split(comma);
                PrepScale(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
                int num_ticks = Convert.ToInt32(read.ReadLine());//write.WriteLine("{0}", tick_layers.Count);
                tick_layers = new List<tick_layer>();
                for (int t = 0; t < num_ticks; t++)
                {
                    tick_layer tl = new tick_layer();
                    tl.read(read);
                    tick_layers.Add(tl);
                }
                int num_texts = Convert.ToInt32(read.ReadLine());//write.WriteLine("{0}", tick_layers.Count);
                text_layers = new List<text_layer>();
                for (int t = 0; t < num_texts; t++)
                {
                    text_layer tl = new text_layer();
                    tl.read(read);
                    text_layers.Add(tl);
                }
                int num_arc = Convert.ToInt32(read.ReadLine());//write.WriteLine("{0}", tick_layers.Count);
                arc_layers = new List<arc_layer>();
                for (int t = 0; t < num_arc; t++)
                {
                    arc_layer tl = new arc_layer();
                    tl.read(read);
                    arc_layers.Add(tl);
                }
            }
        }

        private void RefreshAndRender()
        {
            g.Clear(Color.Transparent);
            RenderArcLayers();
            RenderTextLayers();
            RenderTickLayers();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!CheckTickMarkData()) return;

            //PrepUndo();

            int inrad = Convert.ToInt32(textInnerRadius.Text);
            int outrad = Convert.ToInt32(textOuterRadius.Text);
            int lw = Convert.ToInt32(textTickWidth.Text);
            int numticks = Convert.ToInt32(textNumTicks.Text);
            double degspertick = Convert.ToDouble(textDegsPerTick.Text);
            double startangle = Convert.ToDouble(textStartAngle.Text);

            tick_layer t = new tick_layer();
            if (string.IsNullOrEmpty(textTickName.Text))
            {
                t.name = string.Format("Tick Layer {0}", tick_layers.Count);
            }
            else
            {
                t.name = textTickName.Text;
            }
            t.inner_radius = inrad;
            t.outer_radius = outrad;
            t.width = lw;
            t.numticks = numticks;
            t.degspertick = degspertick;
            t.startangle = startangle;
            t.active = checkTickActive.Checked;
            t.col = buttonTickColor.BackColor;
            tick_layers.Add(t);
            RefreshListboxes();

            //g.Clear(Color.Transparent);
            RefreshAndRender();
            //RenderTickLayers();

            picturePreview.Image = bmp;
            picturePreview.Invalidate();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorTicks.ShowDialog() == DialogResult.Cancel) return;
            buttonTickColor.BackColor = colorTicks.Color;

        }

        private void PreviewRedraw()
        {
            g.Clear(Color.Transparent);
            RenderTickLayers();
            RenderTextLayers();
            RenderArcLayers();
            picturePreview.Image = bmp;
            picturePreview.Invalidate();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //Undo();
            PreviewRedraw();            
        }

        private void listTickLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTickLayers.SelectedIndex < 0) return;
            tick_layer tl = tick_layers[listTickLayers.SelectedIndex];
            SetTickLayer(tl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listTickLayers.SelectedIndex < 0) return;
            tick_layer tl = tick_layers[listTickLayers.SelectedIndex];
            tick_layers.Remove(tl);
            RefreshListboxes();
            PreviewRedraw();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveScale();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenScale();
            RefreshListboxes();
            PreviewRedraw();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (colorText.ShowDialog() == DialogResult.Cancel) return;
            buttonTextColor.BackColor = colorText.Color;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!CheckTextData()) return;

            //PrepUndo();
            char[] comma = { ',' };
            int rad = Convert.ToInt32(textTextRadius.Text);            
            int s = Convert.ToInt32(textTextSize.Text);
            int numticks = Convert.ToInt32(textTextNumTicks.Text);
            double degspertick = Convert.ToDouble(textTextDegsPerTick.Text);
            double startangle = Convert.ToDouble(textTextStartAngle.Text);

            text_layer t = new text_layer();
            if (string.IsNullOrEmpty(textTextName.Text))
            {
                t.name = string.Format("Text Layer {0}", text_layers.Count);
            }
            else
            {
                t.name = textTextName.Text;
            }
            t.radius = rad;            
            t.size = s;
            t.numticks = numticks;
            t.degspertick = degspertick;
            t.startangle = startangle;
            t.active = checkTickActive.Checked;
            t.col = buttonTextColor.BackColor;
            t.fontname = textTextFontName.Text;
            t.strings = textTextStrings.Text.Split(comma);
            t.raw_strings = textTextStrings.Text;
            text_layers.Add(t);
            
            RefreshListboxes();

            //g.Clear(Color.Transparent);
            RefreshAndRender();
            //RenderTextLayers();

            picturePreview.Image = bmp;
            picturePreview.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listTextLayers.SelectedIndex < 0) return;
            text_layer tl = text_layers[listTextLayers.SelectedIndex];
            text_layers.Remove(tl);
            RefreshListboxes();
            PreviewRedraw();
        }

        private void listTextLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTextLayers.SelectedIndex < 0) return;
            text_layer tl = text_layers[listTextLayers.SelectedIndex];
            SetTextLayer(tl);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!CheckArcData()) return;

            //PrepUndo();

            int rad = Convert.ToInt32(textArcRadius.Text);            
            int lw = Convert.ToInt32(textArcWidth.Text);                        
            double startangle = Convert.ToDouble(textArcStartAngle.Text);
            double sweepangle = Convert.ToDouble(textArcSweepAngle.Text);

            arc_layer t = new arc_layer();
            if (string.IsNullOrEmpty(textArcName.Text))
            {
                t.name = string.Format("Arc Layer {0}", arc_layers.Count);
            }
            else
            {
                t.name = textArcName.Text;
            }
            t.radius = rad;            
            t.width = lw;            
            t.startangle = startangle;
            t.sweepangle = sweepangle;
            t.active = checkArcActive.Checked;
            t.col = buttonArcColor.BackColor;
            arc_layers.Add(t);
                        
            RefreshListboxes();

            //g.Clear(Color.Transparent);
            RefreshAndRender();
            //RenderArcLayers();

            picturePreview.Image = bmp;
            picturePreview.Invalidate();            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (listArcLayers.SelectedIndex < 0) return;
            arc_layer tl = arc_layers[listArcLayers.SelectedIndex];
            arc_layers.Remove(tl);
            RefreshListboxes();
            PreviewRedraw();
        }

        private void listArcLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listArcLayers.SelectedIndex < 0) return;
            arc_layer tl = arc_layers[listArcLayers.SelectedIndex];
            SetArcLayer(tl);
        }

        private void buttonArcColor_Click(object sender, EventArgs e)
        {
            if (colorArcs.ShowDialog() == DialogResult.Cancel) return;
            buttonArcColor.BackColor = colorArcs.Color;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arc_layers = new List<arc_layer>();
            text_layers = new List<text_layer>();
            tick_layers = new List<tick_layer>();
            RefreshListboxes();
            RefreshAndRender();
            if (bmp != null) bmp.Dispose();
            if (g != null) g.Dispose();
            groupArcs.Enabled = false;
            groupTexts.Enabled = false;
            groupTicks.Enabled = false;
            picturePreview.Image = System.Drawing.SystemIcons.Question.ToBitmap();
            picturePreview.Invalidate();
        }
    }

    public class tick_layer
    {
        public string name;     
        public bool active;
        public int inner_radius;
        public int outer_radius;
        public int width;
        public Color col;
        public double startangle;
        public double degspertick;
        public int numticks;

        public void read(TextReader read)
        {
            char[] comma = { ',' };
            
            name = read.ReadLine(); // WriteLine("{0}", this.name);
            active = Convert.ToBoolean(read.ReadLine()); //write.WriteLine("{0}", this.active);
            inner_radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);
            outer_radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.outer_radius);
            degspertick = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.degspertick);
            startangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);
            numticks = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.numticks);
            width = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.width);
            string s = read.ReadLine(); //write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);
            string[] parts = s.Split(comma);
            col = Color.FromArgb(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));              
        }
        public void write(TextWriter write)
        {
            write.WriteLine("{0}", this.name);
            write.WriteLine("{0}", this.active);
            write.WriteLine("{0}", this.inner_radius);
            write.WriteLine("{0}", this.outer_radius);
            write.WriteLine("{0}", this.degspertick);
            write.WriteLine("{0}", this.startangle);
            write.WriteLine("{0}", this.numticks);
            write.WriteLine("{0}", this.width);
            write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);            
        }
    }
}

public class text_layer
{
    public string name;
    public bool active;
    public int radius;
    public int size;
    public Color col;
    public double startangle;
    public double degspertick;
    public int numticks;
    public string[] strings;
    public string raw_strings;
    public string fontname;

    public void read(TextReader read)
    {
        char[] comma = { ',' };

        name = read.ReadLine(); // WriteLine("{0}", this.name);
        active = Convert.ToBoolean(read.ReadLine()); //write.WriteLine("{0}", this.active);
        radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);
        degspertick = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.degspertick);
        startangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);
        numticks = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.numticks);
        size = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.width);
        raw_strings = read.ReadLine(); //write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);        
        strings = raw_strings.Split(comma);
        fontname = read.ReadLine();
        string s = read.ReadLine();
        string[] parts = s.Split(comma);
        col = Color.FromArgb(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
    }
    public void write(TextWriter write)
    {
        write.WriteLine("{0}", this.name);
        write.WriteLine("{0}", this.active);
        write.WriteLine("{0}", this.radius);        
        write.WriteLine("{0}", this.degspertick);
        write.WriteLine("{0}", this.startangle);
        write.WriteLine("{0}", this.numticks);
        write.WriteLine("{0}", this.size);
        write.WriteLine("{0}", this.raw_strings);
        write.WriteLine("{0}", this.fontname);
        write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);
    }
}

public class arc_layer
{
    public string name;
    public bool active;
    public int radius;
    public int width;
    public Color col;
    public double startangle;
    public double sweepangle;
    
    public void read(TextReader read)
    {
        char[] comma = { ',' };
        name = read.ReadLine(); // WriteLine("{0}", this.name);
        active = Convert.ToBoolean(read.ReadLine()); //write.WriteLine("{0}", this.active);
        radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);
        width = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);        
        startangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);
        sweepangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);        
        string s = read.ReadLine();
        string[] parts = s.Split(comma);
        col = Color.FromArgb(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
    }
    public void write(TextWriter write)
    {
        write.WriteLine("{0}", this.name);
        write.WriteLine("{0}", this.active);
        write.WriteLine("{0}", this.radius);
        write.WriteLine("{0}", this.width);
        write.WriteLine("{0}", this.startangle);
        write.WriteLine("{0}", this.sweepangle);        
        write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);
    }
}
