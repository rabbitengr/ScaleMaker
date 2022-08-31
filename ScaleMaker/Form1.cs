using System.Drawing;
using static System.Windows.Forms.DataFormats;
using System.IO;
using System.Drawing.Drawing2D;

namespace ScaleMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void DrawLine(Graphics g, Pen pen, int cx, int cy, float angle, float radius_outer, float radius_inner)
        {                        
            double rads = (double)(angle) * 0.01745329;
            Point inner = new Point((int)(radius_inner * Math.Sin(rads)) + cx, -(int)(radius_inner * Math.Cos(rads))+ cy);
            Point outer = new Point((int)(radius_outer * Math.Sin(rads)) + cx, -(int)(radius_outer * Math.Cos(rads))+ cy);            
            g.DrawLine(pen, inner, outer);            
        }

        private void DrawNumber(Graphics g, Color col, int cx, int cy, float angle, float radius, string fontname, int fontsize, string num)
        {
            double rads = (double)(angle) * 0.01745329;
            Point pf = new Point((int)(radius * Math.Sin(rads)) + cx, -(int)(radius * Math.Cos(rads)) + cy);

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

        private void button1_Click(object sender, EventArgs e)
        {
            int w = 122;
            int h = 122;
            Bitmap bmp = new Bitmap(w, h);            
            int pw = 1;
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            using (Pen p = new Pen(Color.Red, pw))
            {
                for (int i = 0; i < 12; i++)
                {
                    DrawLine(g, p, w / 2, h / 2, i*30, 58, 52); 
                }
                for (int i = 0; i < 12; i++)
                {
                    DrawLine(g, p, w / 2, h / 2, i*30+15, 58, 56);
                }
                for (int i = 0; i < 12; i++)
                {
                    DrawNumber(g, Color.Blue, w / 2, h / 2, i * 30, 43, "Arial", 10, String.Format("{0}", i * 3));
                }
            }

            bmp.Save("g:/temp/out.png");
            
            picturePreview.Image = bmp;
            picturePreview.Invalidate();

        }
    }
}