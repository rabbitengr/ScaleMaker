using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using Microsoft.Win32;
using System.Configuration;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace ScaleMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string filename;

        private int W;
        private int H;
        private Graphics g;
        private Bitmap bmp;
        private Image backdrop;
        private string backdrop_name;
        private string backup_path;
        private string regPath = "software\\Rabbit Engineering\\ScaleMaker";
        private string appTitle = "ScaleMaker build 12/19/2024";
        List<tick_layer> tick_layers;
        List<text_layer> text_layers;
        List<arc_layer> arc_layers;
        List<label_layer> label_layers;

        private void Backup_Resources()
        {
            string resource_path = Path.GetDirectoryName(filename);
            string ts;
            int k = -1;
            do
            {
                k++;
                backup_path = Path.Combine(resource_path, string.Format("backup_{0}", k));
            } while (Directory.Exists(backup_path));
            Directory.CreateDirectory(backup_path);
            string[] files = Directory.GetFiles(resource_path);
            foreach (string f in files)
            {
                File.Copy(f, Path.Combine(backup_path, Path.GetFileName(f)));
            }

        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void Resize_Resources(double sf)
        {
            //YOU MUST BACKUP RESROUCE BEFORE DOING THIS!
            string resource_path = Path.GetDirectoryName(filename);
            string[] bmp = Directory.GetFiles(resource_path, "*.bmp");
            string[] png = Directory.GetFiles(resource_path, "*.png");
            string[] files = bmp.Concat(png).ToArray();
            foreach (string f in files)
            {
                string s = Path.Combine(backup_path, Path.GetFileName(f));
                Image img = Image.FromFile(s);
                int w = (int)((double)img.Width * sf);
                int h = (int)((double)img.Height * sf);
                Bitmap b = ResizeImage(img, w, h);
                b.Save(f);
                b.Dispose();
                img.Dispose();
            }
        }

        private void DrawLine(Color col, int linew, double angle, float radius_outer, float radius_inner, int CX, int CY)
        {
            using (Pen p = new Pen(col, linew))
            {
                double rads = (double)(angle) * 0.01745329;
                Point inner = new Point((int)(radius_inner * Math.Sin(rads)) + CX, -(int)(radius_inner * Math.Cos(rads)) + CY);
                Point outer = new Point((int)(radius_outer * Math.Sin(rads)) + CX, -(int)(radius_outer * Math.Cos(rads)) + CY);
                g.DrawLine(p, inner, outer);
            }
        }

        private void DrawLabel(Color col, string fontname, int fontsize, string text, int X, int Y)
        {

            Point pf = new Point(X, Y);

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
                            path.AddString(text, ff, 0, fontsize, pf, sf);
                            g.FillPath(br, path);
                        }
                    }
                }
            }
        }

        private void DrawNumber(Color col, double angle, float radius, string fontname, int fontsize, string num, int CX, int CY)
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

        private void DrawArc(Color col, int width, float _radius, double _start_angle, double _sweep_angle, int CX, int CY, int solid)
        {
            int radius = (int)_radius;
            float start_angle = (float)_start_angle - 90;
            float sweep_angle = (float)_sweep_angle;

            using (Pen p = new Pen(col, width))
            {
                using (SolidBrush b = new SolidBrush(col))
                {
                    Point c = new Point(CX - radius, CY - radius);
                    Size s = new Size(radius * 2, radius * 2);
                    Rectangle r = new Rectangle(c, s);
                    if (solid > 0)
                    {
                        g.FillPie(b, r, start_angle, sweep_angle);
                    }
                    else
                    {
                        g.DrawArc(p, r, start_angle, sweep_angle);
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

        private void PrepScale_KeepBackdrop(int _w, int _h)
        {
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();
            //if (backdrop != null) backdrop.Dispose();

            groupTicks.Enabled = true;
            groupArcs.Enabled = true;
            groupTexts.Enabled = true;
            groupLabels.Enabled = true;

            W = _w;
            H = _h;
            textImageW.Text = W.ToString();
            textImageH.Text = H.ToString();

            bmp = new Bitmap(W, H);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (SolidBrush b = new SolidBrush(Color.Red))
            {
                Rectangle r = new Rectangle(W / 2, H / 2, 1, 1);
                g.FillRectangle(b, r);
            }
            picturePreview.Image = bmp;

            string cx = (W / 2).ToString();
            string cy = (H / 2).ToString();
            textTextCX.Text = cx;
            textTextCY.Text = cy;
            textArcCX.Text = cx;
            textArcCY.Text = cy;
            textTickCY.Text = cx;
            textTickCX.Text = cy;
            textLabelX.Text = cx;
            textLabelY.Text = cy;
            labelCenter.Text = String.Format("Center is ({0},{1})", cx, cy);
        }

        private void PrepScale(int _w, int _h)
        {
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();
            if (backdrop != null) backdrop.Dispose();
            bmp = null;
            g = null;
            backdrop = null;

            groupTicks.Enabled = true;
            groupArcs.Enabled = true;
            groupTexts.Enabled = true;
            groupLabels.Enabled = true;

            W = _w;
            H = _h;
            textImageW.Text = W.ToString();
            textImageH.Text = H.ToString();

            bmp = new Bitmap(W, H);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (SolidBrush b = new SolidBrush(Color.Red))
            {
                Rectangle r = new Rectangle(W / 2, H / 2, 1, 1);
                g.FillRectangle(b, r);
            }
            picturePreview.Image = bmp;

            string cx = (W / 2).ToString();
            string cy = (H / 2).ToString();
            textTextCX.Text = cx;
            textTextCY.Text = cy;
            textArcCX.Text = cx;
            textArcCY.Text = cy;
            textTickCY.Text = cx;
            textTickCX.Text = cy;
            textLabelX.Text = cx;
            textLabelY.Text = cy;
            labelCenter.Text = String.Format("Center is ({0},{1})", cx, cy);
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
            s = ReadRegKey("backdrop");
            if (!string.IsNullOrEmpty(s))
            {
                this.openBackdrop.FileName = s;
            }

            tick_layers = new List<tick_layer>();
            text_layers = new List<text_layer>();
            arc_layers = new List<arc_layer>();
            label_layers = new List<label_layer>();
            groupTicks.Enabled = false;
            groupTexts.Enabled = false;
            groupArcs.Enabled = false;
            groupLabels.Enabled = false;
        }

        private void RenderArcLayers()
        {
            foreach (arc_layer tl in arc_layers)
            {
                if (!tl.active) continue;

                DrawArc(tl.col, tl.width, tl.radius, tl.startangle, tl.sweepangle, tl.cx, tl.cy, tl.solid);
            }
        }

        private void ScaleArcLayers(double f)
        {
            for (int i = 0; i < arc_layers.Count; i++)
            {
                //scale here
                arc_layers[i].radius = (int)((double)arc_layers[i].radius * f);
                arc_layers[i].width = (int)((double)arc_layers[i].width * f);
                arc_layers[i].cx = (int)((double)arc_layers[i].cx * f);
                arc_layers[i].cy = (int)((double)arc_layers[i].cy * f);
            }
        }

        private void RenderLabelLayers()
        {
            foreach (label_layer tl in label_layers)
            {
                if (!tl.active) continue;

                DrawLabel(tl.col, tl.fontname, tl.fontsize, tl.text, tl.x, tl.y);
                //DrawArc(tl.col, tl.width, tl.radius, tl.startangle, tl.sweepangle, tl.cx, tl.cy);
            }
        }
        private void ScaleLabelLayers(double f)
        {
            for (int i = 0; i < label_layers.Count; i++)
            {
                //scale here
                label_layers[i].fontsize = (int)((double)label_layers[i].fontsize * f);
                label_layers[i].x = (int)((double)label_layers[i].x * f);
                label_layers[i].y = (int)((double)label_layers[i].y * f);
            }
        }

        private void RenderTickLayers()
        {
            foreach (tick_layer tl in tick_layers)
            {
                if (!tl.active) continue;

                for (int t = 0; t < tl.numticks; t++)
                {
                    DrawLine(tl.col, tl.width, tl.startangle + (double)t * tl.degspertick, tl.outer_radius, tl.inner_radius, tl.cx, tl.cy);
                }
            }
        }

        private void ScaleTickLayers(double f)
        {
            for (int i = 0; i < tick_layers.Count; i++)
            {
                //scale here
                tick_layers[i].inner_radius = (int)((double)tick_layers[i].inner_radius * f);
                tick_layers[i].outer_radius = (int)((double)tick_layers[i].outer_radius * f);
                tick_layers[i].width = (int)((double)tick_layers[i].width * f);
                tick_layers[i].cx = (int)((double)tick_layers[i].cx * f);
                tick_layers[i].cy = (int)((double)tick_layers[i].cy * f);
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
                    DrawNumber(tl.col, tl.startangle + (double)t * tl.degspertick, tl.radius, tl.fontname, tl.size, tl.strings[t], tl.cx, tl.cy);
                }
            }
        }
        private void ScaleTextLayers(double f)
        {
            for (int i = 0; i < text_layers.Count; i++)
            {
                //scale here
                text_layers[i].radius = (int)((double)text_layers[i].radius * f);
                text_layers[i].size = (int)((double)text_layers[i].size * f);
                text_layers[i].cx = (int)((double)text_layers[i].cx * f);
                text_layers[i].cy = (int)((double)text_layers[i].cy * f);
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

        private bool CheckLabelData()
        {
            if (bmp == null) return false;
            if (g == null) return false;
            if (string.IsNullOrEmpty(textLabelFont.Text)) return false;
            if (string.IsNullOrEmpty(textLabelSize.Text)) return false;
            if (string.IsNullOrEmpty(textLabelText.Text)) return false;
            if (string.IsNullOrEmpty(textLabelX.Text)) return false;
            if (string.IsNullOrEmpty(textLabelY.Text)) return false;

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
            if (string.IsNullOrEmpty(textTickCY.Text)) return false;
            if (string.IsNullOrEmpty(textTickCX.Text)) return false;

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
            if (string.IsNullOrEmpty(textArcCX.Text)) return false;
            if (string.IsNullOrEmpty(textArcCY.Text)) return false;

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
            if (string.IsNullOrEmpty(textTextCX.Text)) return false;
            if (string.IsNullOrEmpty(textTextCY.Text)) return false;

            return true;
        }

        void RefreshListboxes()
        {
            listTickLayers.Items.Clear();
            foreach (tick_layer tl in tick_layers)
            {
                if (listTickLayers.Items.Contains(tl.name))
                {
                    string nn;
                    do
                    {
                        nn = string.Format("{0}.1", tl.name);
                    } while (listTickLayers.Items.Contains(nn));
                    tl.name = nn;
                }
                listTickLayers.Items.Add(tl.name);
            }
            listTickLayers.Invalidate();

            listTextLayers.Items.Clear();
            foreach (text_layer tl in text_layers)
            {
                if (listTextLayers.Items.Contains(tl.name))
                {
                    string nn;
                    do
                    {
                        nn = string.Format("{0}.1", tl.name);
                    } while (listTextLayers.Items.Contains(nn));
                    tl.name = nn;
                }
                listTextLayers.Items.Add(tl.name);
            }
            listTextLayers.Invalidate();

            listArcLayers.Items.Clear();
            foreach (arc_layer tl in arc_layers)
            {
                if (listArcLayers.Items.Contains(tl.name))
                {
                    string nn;
                    do
                    {
                        nn = string.Format("{0}.1", tl.name);
                    } while (listArcLayers.Items.Contains(nn));
                    tl.name = nn;
                }
                listArcLayers.Items.Add(tl.name);
            }
            listArcLayers.Invalidate();

            listLabelLayers.Items.Clear();
            foreach (label_layer tl in label_layers)
            {
                if (listLabelLayers.Items.Contains(tl.name))
                {
                    string nn;
                    do
                    {
                        nn = string.Format("{0}.1", tl.name);
                    } while (listLabelLayers.Items.Contains(nn));
                    tl.name = nn;
                }
                listLabelLayers.Items.Add(tl.name);
            }
            listLabelLayers.Invalidate();
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
            textTickCX.Text = Convert.ToString(tl.cx);
            textTickCY.Text = Convert.ToString(tl.cy);
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
            textArcCX.Text = Convert.ToString(tl.cx);
            textArcCY.Text = Convert.ToString(tl.cy);
            textArcRadius.Text = Convert.ToString(tl.radius);
            textArcStartAngle.Text = Convert.ToString(tl.startangle);
            textArcWidth.Text = Convert.ToString(tl.width);
            textArcSweepAngle.Text = Convert.ToString(tl.sweepangle);
            buttonArcColor.BackColor = tl.col;
            if (tl.solid > 0)
                checkSolid.Checked = true;
            else
                checkSolid.Checked = false;
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

            textTextCX.Text = Convert.ToString(tl.cx);
            textTextCY.Text = Convert.ToString(tl.cy);
            textTextRadius.Text = Convert.ToString(tl.radius);
            textTextStartAngle.Text = Convert.ToString(tl.startangle);
            buttonTextColor.BackColor = tl.col;
            textTextNumTicks.Text = Convert.ToString(tl.numticks);
            textTextDegsPerTick.Text = Convert.ToString(tl.degspertick);
            textTextSize.Text = Convert.ToString(tl.size);
            textTextStrings.Text = tl.raw_strings;
            textTextFontName.Text = tl.fontname;
        }

        private void SetLabelLayer(label_layer tl)
        {
            textLabelName.Text = tl.name;
            if (tl.active)
            {
                checkLabelActive.Checked = true;
            }
            else
            {
                checkLabelActive.Checked = false;
            }
            textLabelX.Text = Convert.ToString(tl.x);
            textLabelY.Text = Convert.ToString(tl.y);
            textLabelSize.Text = Convert.ToString(tl.fontsize);
            textLabelFont.Text = tl.fontname;
            textLabelText.Text = tl.text;
            buttonLabelColor.BackColor = tl.col;
        }

        private void SaveAsScale()
        {
            if (g == null) return;
            if (bmp == null) return;
            if (saveScaleDialog.ShowDialog() == DialogResult.Cancel) return;
            WriteRegKey("sclpath", this.saveScaleDialog.FileName);
            filename = this.saveScaleDialog.FileName;
            openScaleDialog.FileName = saveScaleDialog.FileName;
            DoSave();
        }

        private void DoSave()
        {
            using (TextWriter write = new StreamWriter(filename))
            {
                write.WriteLine("v1");
                if (string.IsNullOrEmpty(backdrop_name))
                {
                    write.WriteLine("null");
                }
                else
                {
                    write.WriteLine("{0}", backdrop_name);
                }
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
                write.WriteLine("{0}", label_layers.Count);
                foreach (label_layer nl in label_layers)
                {
                    nl.write(write);
                }
            }
        }

        private void OpenScale()
        {
            if (openScaleDialog.ShowDialog() == DialogResult.Cancel) return;
            saveScaleDialog.FileName = openScaleDialog.FileName;
            filename = openScaleDialog.FileName;
            char[] comma = { ',' };

            using (TextReader read = new StreamReader(openScaleDialog.FileName))
            {
                string magic = read.ReadLine(); // "v1");
                if (magic != "v1")
                {
                    MessageBox.Show(String.Format("{0} is not a valid SCL file.", openScaleDialog.FileName), "Invalid file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string bd = read.ReadLine();
                if (bd != "null")
                {
                    backdrop_name = bd;
                    if (!File.Exists(backdrop_name))
                    {
                        MessageBox.Show(String.Format("{0} cannot be read.", backdrop_name), "Cannot load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    backdrop = Image.FromFile(backdrop_name);
                }
                string s = read.ReadLine();//write.WriteLine("{0},{1}", W, H);
                string[] parts = s.Split(comma);
                PrepScale_KeepBackdrop(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
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
                int num_label = Convert.ToInt32(read.ReadLine());//write.WriteLine("{0}", tick_layers.Count);
                label_layers = new List<label_layer>();
                for (int t = 0; t < num_label; t++)
                {
                    label_layer tl = new label_layer();
                    tl.read(read);
                    label_layers.Add(tl);
                }
            }
        }

        private void RefreshAndRender()
        {
            if (g != null) g.Clear(Color.Transparent);

            if (backdrop != null)
            {
                Rectangle r = new Rectangle(0, 0, backdrop.Width, backdrop.Height);
                g.DrawImage(backdrop, r);
            }
            RenderTickLayers();
            RenderArcLayers();
            RenderTextLayers();
            RenderLabelLayers();

            if (checkShowCenter.Checked)
            {
                Pen p = new Pen(Color.Red);
                g.DrawLine(p, 0, H / 2, W, H / 2);
                g.DrawLine(p, W / 2, 0, W / 2, H);
            }

            picturePreview.Image = bmp;
            picturePreview.Invalidate();
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
            int _cx = Convert.ToInt32(textTickCX.Text);
            int _cy = Convert.ToInt32(textTickCY.Text);

            tick_layer t = new tick_layer();
            if (string.IsNullOrEmpty(textTickName.Text))
            {
                t.name = string.Format("Tick Layer {0}", tick_layers.Count);
            }
            else
            {
                t.name = textTickName.Text;
            }
            t.cx = _cx;
            t.cy = _cy;
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

            listTickLayers.SelectedIndex = listTickLayers.Items.Count - 1;

            //g.Clear(Color.Transparent);
            RefreshAndRender();
            //RenderTickLayers();            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            colorTicks.Color = buttonTickColor.BackColor;
            if (colorTicks.ShowDialog() == DialogResult.Cancel) return;
            buttonTickColor.BackColor = colorTicks.Color;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //Undo();
            RefreshAndRender();
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
            listTickLayers.SelectedIndex = listTickLayers.Items.Count - 1;
            RefreshAndRender();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename)) return;
            DoSave();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenScale();
            RefreshListboxes();
            RefreshAndRender();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            colorText.Color = buttonTextColor.BackColor;
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
            int _cx = Convert.ToInt32(textTextCX.Text);
            int _cy = Convert.ToInt32(textTextCY.Text);
            text_layer t = new text_layer();
            if (string.IsNullOrEmpty(textTextName.Text))
            {
                t.name = string.Format("Text Layer {0}", text_layers.Count);
            }
            else
            {
                t.name = textTextName.Text;
            }
            t.cx = _cx;
            t.cy = _cy;
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

            listTextLayers.SelectedIndex = listTextLayers.Items.Count - 1;

            //g.Clear(Color.Transparent);
            RefreshAndRender();
            //RenderTextLayers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listTextLayers.SelectedIndex < 0) return;
            text_layer tl = text_layers[listTextLayers.SelectedIndex];
            text_layers.Remove(tl);
            RefreshListboxes();
            listTextLayers.SelectedIndex = listTextLayers.Items.Count - 1;
            RefreshAndRender();
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
            int _cx = Convert.ToInt32(textArcCX.Text);
            int _cy = Convert.ToInt32(textArcCY.Text);

            arc_layer t = new arc_layer();
            if (string.IsNullOrEmpty(textArcName.Text))
            {
                t.name = string.Format("Arc Layer {0}", arc_layers.Count);
            }
            else
            {
                t.name = textArcName.Text;
            }
            t.cx = _cx;
            t.cy = _cy;
            t.radius = rad;
            t.width = lw;
            t.startangle = startangle;
            t.sweepangle = sweepangle;
            t.active = checkArcActive.Checked;
            t.col = buttonArcColor.BackColor;
            arc_layers.Add(t);
            if (checkSolid.Checked)
                t.solid = 1;
            else
                t.solid = 0;

            RefreshListboxes();

            listArcLayers.SelectedIndex = listArcLayers.Items.Count - 1;

            //g.Clear(Color.Transparent);
            RefreshAndRender();
            //RenderArcLayers();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (listArcLayers.SelectedIndex < 0) return;
            arc_layer tl = arc_layers[listArcLayers.SelectedIndex];
            arc_layers.Remove(tl);
            RefreshListboxes();
            listArcLayers.SelectedIndex = listArcLayers.Items.Count - 1;
            RefreshAndRender();
        }

        private void listArcLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listArcLayers.SelectedIndex < 0) return;
            arc_layer tl = arc_layers[listArcLayers.SelectedIndex];
            SetArcLayer(tl);
        }

        private void buttonArcColor_Click(object sender, EventArgs e)
        {
            colorArcs.Color = buttonArcColor.BackColor;
            if (colorArcs.ShowDialog() == DialogResult.Cancel) return;
            buttonArcColor.BackColor = colorArcs.Color;
        }

        private void NewScale()
        {
            arc_layers = new List<arc_layer>();
            text_layers = new List<text_layer>();
            tick_layers = new List<tick_layer>();
            label_layers = new List<label_layer>();
            RefreshListboxes();
            RefreshAndRender();
            backdrop_name = string.Empty;
            if (backdrop != null) { backdrop.Dispose(); backdrop = null; }
            if (bmp != null) bmp.Dispose();
            if (g != null) g.Dispose();
            groupArcs.Enabled = false;
            groupTexts.Enabled = false;
            groupTicks.Enabled = false;
            groupLabels.Enabled = false;
            picturePreview.Image = System.Drawing.SystemIcons.Question.ToBitmap();
            picturePreview.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewScale();
        }

        private void textCenterX_TextChanged(object sender, EventArgs e)
        {
        }

        private void textCenterY_TextChanged(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (openBackdrop.ShowDialog() == DialogResult.Cancel) return;
            backdrop_name = openBackdrop.FileName;
            WriteRegKey("backdrop", openBackdrop.FileName);
            if (backdrop != null) backdrop.Dispose();
            backdrop = Image.FromFile(openBackdrop.FileName);

            SetBackground();
        }

        void SetBackground()
        {
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();

            textImageW.Text = backdrop.Width.ToString();
            textImageH.Text = backdrop.Height.ToString();
            W = backdrop.Width;
            H = backdrop.Height;
            textImageW.Text = W.ToString();
            textImageH.Text = H.ToString();
            groupTicks.Enabled = true;
            groupArcs.Enabled = true;
            groupTexts.Enabled = true;
            groupLabels.Enabled = true;

            bmp = new Bitmap(W, H);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (SolidBrush b = new SolidBrush(Color.Red))
            {
                Rectangle r = new Rectangle(W / 2, H / 2, 1, 1);
                g.FillRectangle(b, r);
            }
            picturePreview.Image = bmp;

            string cx = (W / 2).ToString();
            string cy = (H / 2).ToString();
            textTextCX.Text = cx;
            textTextCY.Text = cy;
            textArcCX.Text = cx;
            textArcCY.Text = cy;
            textTickCX.Text = cx;
            textTickCY.Text = cy;
            textLabelX.Text = cx;
            textLabelY.Text = cy;
            labelCenter.Text = String.Format("Center is ({0},{1})", cx, cy);

            RefreshAndRender();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            arc_layers = new List<arc_layer>();
            text_layers = new List<text_layer>();
            tick_layers = new List<tick_layer>();
            label_layers = new List<label_layer>();
            RefreshListboxes();
            RefreshAndRender();
        }

        private void textImageW_TextChanged(object sender, EventArgs e)
        {
        }

        private void textImageH_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkShowCenter_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAndRender();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!CheckLabelData()) return;

            int _x = Convert.ToInt32(textLabelX.Text);
            int _y = Convert.ToInt32(textLabelY.Text);

            label_layer t = new label_layer();
            if (string.IsNullOrEmpty(textLabelName.Text))
            {
                t.name = string.Format("Label Layer {0}", label_layers.Count);
            }
            else
            {
                t.name = textLabelName.Text;
            }
            t.x = _x;
            t.y = _y;
            t.text = textLabelText.Text;
            t.fontname = textLabelFont.Text;
            t.fontsize = Convert.ToInt32(textLabelSize.Text);

            t.active = checkArcActive.Checked;
            t.col = buttonLabelColor.BackColor;
            label_layers.Add(t);

            RefreshListboxes();
            listLabelLayers.SelectedIndex = listLabelLayers.Items.Count - 1;

            //g.Clear(Color.Transparent);
            RefreshAndRender();
            //RenderArcLayers();
        }

        private void listLabelLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listLabelLayers.SelectedIndex < 0) return;
            label_layer tl = label_layers[listLabelLayers.SelectedIndex];
            SetLabelLayer(tl);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (listLabelLayers.SelectedIndex < 0) return;
            label_layer tl = label_layers[listLabelLayers.SelectedIndex];
            label_layers.Remove(tl);
            RefreshListboxes();
            listLabelLayers.SelectedIndex = listLabelLayers.Items.Count - 1;
            RefreshAndRender();
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsScale();
        }

        private void buttonLabelColor_Click(object sender, EventArgs e)
        {
            colorLabels.Color = buttonLabelColor.BackColor;
            if (colorLabels.ShowDialog() == DialogResult.Cancel) return;
            buttonLabelColor.BackColor = colorLabels.Color;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Resize all?", "Confirm resize", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            if (string.IsNullOrEmpty(textScaleFactor.Text)) return;
            if (textScaleFactor.Text == "1") return;

            if (backdrop != null) backdrop.Dispose();
            double sf = Convert.ToDouble(textScaleFactor.Text);
            Backup_Resources();
            Resize_Resources(sf);
            if (!string.IsNullOrEmpty(backdrop_name))
            {
                backdrop = Image.FromFile(backdrop_name);
            }
            PrepScale_KeepBackdrop((int)(W * sf), (int)(H * sf));
            ScaleArcLayers(sf);
            ScaleTextLayers(sf);
            ScaleTickLayers(sf);
            ScaleLabelLayers(sf);

            RefreshAndRender();
        }

        private void gotToGitRepoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "https://github.com/rabbitengr/ScaleMaker"
            };
            Process.Start(processStartInfo);
        }

        private void readDocsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "scalemaker.pdf"
            };
            Process.Start(processStartInfo);
        }
    }

    public class tick_layer
    {
        public string name;
        public bool active;
        public int inner_radius;
        public int outer_radius;
        public int width;
        public int cx;
        public int cy;
        public Color col;
        public double startangle;
        public double degspertick;
        public int numticks;

        public void read(TextReader read)
        {
            char[] comma = { ',' };

            name = read.ReadLine(); // WriteLine("{0}", this.name);
            active = Convert.ToBoolean(read.ReadLine()); //write.WriteLine("{0}", this.active);
            string s = read.ReadLine();
            string[] parts = s.Split(comma);
            cx = Convert.ToInt32(parts[0]);
            cy = Convert.ToInt32(parts[1]);
            inner_radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);
            outer_radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.outer_radius);
            degspertick = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.degspertick);
            startangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);
            numticks = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.numticks);
            width = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.width);
            s = read.ReadLine(); //write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);
            parts = s.Split(comma);
            col = Color.FromArgb(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
        }
        public void write(TextWriter write)
        {
            write.WriteLine("{0}", this.name);
            write.WriteLine("{0}", this.active);
            write.WriteLine("{0},{1}", this.cx, this.cy);
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
    public int cx;
    public int cy;
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
        string s = read.ReadLine();
        string[] parts = s.Split(comma);
        cx = Convert.ToInt32(parts[0]);
        cy = Convert.ToInt32(parts[1]);
        radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);
        degspertick = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.degspertick);
        startangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);
        numticks = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.numticks);
        size = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.width);
        raw_strings = read.ReadLine(); //write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);        
        strings = raw_strings.Split(comma);
        fontname = read.ReadLine();
        s = read.ReadLine();
        parts = s.Split(comma);
        col = Color.FromArgb(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
    }
    public void write(TextWriter write)
    {
        write.WriteLine("{0}", this.name);
        write.WriteLine("{0}", this.active);
        write.WriteLine("{0},{1}", this.cx, this.cy);
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

public class label_layer
{
    public string name;
    public bool active;
    public string fontname;
    public int fontsize;
    public string text;
    public int x;
    public int y;
    public Color col;

    public void read(TextReader read)
    {
        char[] comma = { ',' };
        name = read.ReadLine(); // WriteLine("{0}", this.name);
        active = Convert.ToBoolean(read.ReadLine()); //write.WriteLine("{0}", this.active);
        string s = read.ReadLine();
        string[] parts = s.Split(comma);
        x = Convert.ToInt32(parts[0]);
        y = Convert.ToInt32(parts[1]);
        fontname = read.ReadLine(); // WriteLine("{0}", this.name);
        fontsize = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);
        text = read.ReadLine(); // WriteLine("{0}", this.name);
        s = read.ReadLine();
        parts = s.Split(comma);
        col = Color.FromArgb(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
    }
    public void write(TextWriter write)
    {
        write.WriteLine("{0}", this.name);
        write.WriteLine("{0}", this.active);
        write.WriteLine("{0},{1}", this.x, this.y);
        write.WriteLine("{0}", this.fontname);
        write.WriteLine("{0}", this.fontsize);
        write.WriteLine("{0}", this.text);
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
    public int cx;
    public int cy;
    public double startangle;
    public double sweepangle;
    public int solid;

    public void read(TextReader read)
    {
        char[] comma = { ',' };
        name = read.ReadLine(); // WriteLine("{0}", this.name);
        active = Convert.ToBoolean(read.ReadLine()); //write.WriteLine("{0}", this.active);
        string s = read.ReadLine();
        string[] parts = s.Split(comma);
        cx = Convert.ToInt32(parts[0]);
        cy = Convert.ToInt32(parts[1]);
        radius = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);
        width = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.inner_radius);        
        startangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);
        sweepangle = Convert.ToDouble(read.ReadLine()); //write.WriteLine("{0}", this.startangle);        
        s = read.ReadLine();
        parts = s.Split(comma);
        col = Color.FromArgb(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]));
        solid = Convert.ToInt32(read.ReadLine()); //write.WriteLine("{0}", this.startangle);        
    }
    public void write(TextWriter write)
    {
        write.WriteLine("{0}", this.name);
        write.WriteLine("{0}", this.active);
        write.WriteLine("{0},{1}", this.cx, this.cy);
        write.WriteLine("{0}", this.radius);
        write.WriteLine("{0}", this.width);
        write.WriteLine("{0}", this.startangle);
        write.WriteLine("{0}", this.sweepangle);
        write.WriteLine("{0},{1},{2},{3}", this.col.A, this.col.R, this.col.G, this.col.B);
        write.WriteLine("{0}", this.solid);
    }
}
