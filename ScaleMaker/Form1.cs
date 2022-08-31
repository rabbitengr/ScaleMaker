using System.Drawing;
using static System.Windows.Forms.DataFormats;
using System.IO;
using System.Drawing.Drawing2D;
using Microsoft.Win32;

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


        private void DrawLine(Color col, int linew, float angle, float radius_outer, float radius_inner)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int w = 122;
            int h = 122;
            PrepScale(w, h);
            for (int i = 0; i < 12; i++)
            {
                DrawLine(Color.Red, 2, i * 30, 58, 52);
            }
            for (int i = 0; i < 12; i++)
            {
                DrawLine(Color.Red, 2, i * 30 + 15, 58, 56);
            }
            for (int i = 0; i < 12; i++)
            {
                DrawNumber(Color.Blue, i * 30, 43, "Arial", 10, String.Format("{0}", i * 3));
            }
           
            picturePreview.Image = bmp;
            picturePreview.Invalidate();
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
            string s = ReadRegKey("pngpath");
            if (!string.IsNullOrEmpty(s)) this.saveFileDialog1.FileName = s;
        }
    }
}