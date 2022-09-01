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
        private Bitmap undoBmp;
        private string regPath = "software\\Rabbit Engineering\\ScaleMaker";
        private string appTitle = "ScaleMaker build 8/31/2022";
        List<tick_layer> tick_layers;

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

        private void DrawNumber(Color col, float angle, float radius, string fontname, int fontsize, string num)
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
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bmp == null) return;

            if (this.saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            bmp.Save(this.saveFileDialog1.FileName);
            WriteRegKey("pngpath", this.saveFileDialog1.FileName);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picturePreview.Image = System.Drawing.SystemIcons.Question.ToBitmap();
            this.Text = appTitle;
            string s = ReadRegKey("pngpath");
            if (!string.IsNullOrEmpty(s)) this.saveFileDialog1.FileName = s;
            tick_layers = new List<tick_layer>();
        }

        private void RenderTickLayers()
        {

            foreach (tick_layer tl in tick_layers)
            {
                for (int t = 0; t < tl.numticks; t++)
                {
                    DrawLine(tl.col, tl.width, tl.startangle + (double)t * tl.degspertick, tl.outer_radius, tl.inner_radius);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textImageW.Text)) return;
            if (string.IsNullOrEmpty(textImageH.Text)) return;
            
            PrepScale(Convert.ToInt32(textImageW.Text), Convert.ToInt32(textImageH.Text));
        }

        private void PrepUndo()
        {
            if (bmp == null) return;
            undoBmp = (Bitmap)bmp.Clone();
        }
        private void Undo()
        {
            if (undoBmp == null) return;

            bmp = (Bitmap)undoBmp.Clone();
            g = Graphics.FromImage(bmp);
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
            t.active = true;
            t.col = buttonTickColor.BackColor;
            tick_layers.Add(t);

            RenderTickLayers();

            picturePreview.Image = bmp;
            picturePreview.Invalidate();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorTicks.ShowDialog() == DialogResult.Cancel) return;
            buttonTickColor.BackColor = colorTicks.Color;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //Undo();
            g.Clear(Color.Transparent);
            RenderTickLayers();
            picturePreview.Image = bmp;
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

        }
        public void write(TextWriter write)
        {

        }
    }
}
