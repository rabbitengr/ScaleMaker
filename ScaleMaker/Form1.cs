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

        private void button1_Click(object sender, EventArgs e)
        {
            int w = 200;
            int h = 200;
            Bitmap bmp = new Bitmap(w, h);
            int pw = 1;
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Tan);
            Pen p = new Pen(Color.Red, pw);
            
            for (int i = 0; i < 12; i++)
            {
                DrawLine(g, p, w / 2, h / 2, i*30, 100, 80); 
            }
            for (int i = 0; i < 12; i++)
            {
                DrawLine(g, p, w / 2, h / 2, i*30+15, 100, 90);
            }

            //g.DrawLine(p, new Point(0, 0), new Point(w, h/3));
            picturePreview.Image = bmp;
            picturePreview.Refresh();

        }
    }
}