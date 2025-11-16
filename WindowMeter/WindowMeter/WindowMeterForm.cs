using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace WindowMeter
{
    public partial class WindowMeterForm : Form
    {
        FormSetSize formSetSize = new FormSetSize();

        public WindowMeterForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\WindowMeter";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = folderPath + "\\settings.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    List<string> lines = new List<string>();

	                using (StreamReader r = new StreamReader(filePath))
	                {

	                    string line;
	                    while ((line = r.ReadLine()) != null)
	                    {
		                    lines.Add(line);
	                    }
	                }

                    var p = lines[0].Split(new char[] { ',', ']' });

                    int A = Convert.ToInt32(p[0].Substring(p[0].IndexOf('=') + 1));
                    int R = Convert.ToInt32(p[1].Substring(p[1].IndexOf('=') + 1));
                    int G = Convert.ToInt32(p[2].Substring(p[2].IndexOf('=') + 1));
                    int B = Convert.ToInt32(p[3].Substring(p[3].IndexOf('=') + 1));
                    this.BackColor = Color.FromArgb(255, R, G, B);
                }
                catch (Exception ex)
                {
                }
            }

            MyCallback callbackMethod = new MyCallback(PrintMessage);

            Hook.Register(callbackMethod);
        }

        public void PrintMessage(string message)
        {
            this.makeAreaScreensot = true;
        }

        Point dragOffset;
        private List<string> lastfile = new List<string>();

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 25;   // Caption bar height;
        private string sizeLabel;

        public void clearOldFiles() {
            foreach (string file in lastfile)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

            lastfile.Clear();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                dragOffset = this.PointToScreen(e.Location);
                var formLocation = FindForm().Location;
                dragOffset.X -= formLocation.X;
                dragOffset.Y -= formLocation.Y;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Opacity = 0.4;
                Point newLocation = this.PointToScreen(e.Location);

                newLocation.X -= dragOffset.X;
                newLocation.Y -= dragOffset.Y;

                FindForm().Location = newLocation;

            }
        }

        private void WindowMeterForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Width < e.X && this.Height < e.Y)
                {
                    this.Size = new Size(e.X, e.Y);
                }
            }

        }

        private void WindowMeterForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Opacity = 0.8;
            }

            if (e.Button == MouseButtons.Right)
            {
                Point pt = this.PointToScreen(e.Location);
                contextMenuStrip1.Show(pt);
            }
        }

        private void WindowMeterForm_Load(object sender, EventArgs e)
        {
            this.Left = Properties.Settings.Default.PosLeft;
            this.Top = Properties.Settings.Default.PosTop;

            if (!this.IsOnScreen(this))
            {
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void WindowMeterForm_Resize(object sender, EventArgs e)
        {

            this.sizeLabel = this.Width.ToString() + 'x' + this.Height.ToString();    
        }

        private void WindowMeterForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WindowMeterForm_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Width.ToString() + 'x' + this.Height.ToString());
        }

        private void WindowMeterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            if (e.KeyCode == Keys.F2)
            {
                this.CaptureAreaToFile();
            }

            if (e.KeyCode == Keys.F3)
            {
                Screen screen = Screen.FromControl(this);
                this.CaptureScreenToFile(screen);
            }

            if (e.KeyCode == Keys.F4)
            {
                Clipboard.SetText(this.Width.ToString() + 'x' + this.Height.ToString());
            }

            if (e.KeyCode == Keys.F5)
            {
                this.Height = 200;
                this.Width = 200;
                this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
                sizeLabel = this.Width.ToString() + 'x' + this.Height.ToString();  

            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }

            if (e.KeyCode == Keys.F10)
            {
                this.Close();
            }


            int add = 1;
            if (e.Alt)
                add = 20;

            if (e.Control || (e.Control && e.Alt))
            {
                if (e.KeyCode == Keys.Left)
                {
                    this.Width = this.Width - add;
                }
                if (e.KeyCode == Keys.Right)
                {
                    this.Width = this.Width + add;
                }
                if (e.KeyCode == Keys.Up)
                {
                    this.Height = this.Height - add;
                }
                if (e.KeyCode == Keys.Down)
                {
                    this.Height = this.Height + add;
                }
            }
            else {
                if (e.KeyCode == Keys.Left)
                {
                    this.Left = this.Left - add;
                }
                if (e.KeyCode == Keys.Right)
                {
                    this.Left = this.Left + add;
                }
                if (e.KeyCode == Keys.Up)
                {
                    this.Top = this.Top - add;
                }
                if (e.KeyCode == Keys.Down)
                {
                    this.Top = this.Top + add;
                }
            }
        }

        private void WindowMeterForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Height = 200;
            this.Width = 200;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            sizeLabel = this.Width.ToString() + 'x' + this.Height.ToString();
        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void WindowMeterForm_DoubleClick(object sender, EventArgs e)
        {
            this.CaptureAreaToFile();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.copyToolStripMenuItem.Text = "Copy " + sizeLabel;

            oCRRecognizeToolStripMenuItem.Visible = OCR.IsOCRAvailable();
        }

        private Bitmap CaptureScreen(Screen screen)
        {
            
            Rectangle bounds = screen.Bounds;
            Bitmap bmp = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            return bmp;
        }

        private void CaptureScreenToFile(Screen screen)
        {
            this.clearOldFiles();

            string lastfile = GetTempFile();
            this.lastfile.Add(lastfile);

            this.Hide();
            Rectangle r = this.RectangleToScreen(ClientRectangle);
            Bitmap b = this.CaptureScreen(screen);
            b.Save(lastfile, System.Drawing.Imaging.ImageFormat.Png);
            StringCollection paths = new StringCollection();
            paths.Add(lastfile);
            Clipboard.SetFileDropList(paths);
            //Clipboard.SetImage(b); //vlozit ako obrazok do schranky nie ako subor
            this.Show();
        }

        

        private void CaptureAreaToFile()
        {
            this.clearOldFiles();

            this.Hide();
            Rectangle r = this.RectangleToScreen(ClientRectangle);
            Bitmap b = GetDesktopImage(r);

            if (this.catchAsIcon512x512)
            {
                
                if (b.Width < b.Height) {
                    b = BitmapOperations.CropToCenter(b, b.Width, b.Width);
                }

                if (b.Width > b.Height)
                {
                    b = BitmapOperations.CropToCenter(b, b.Height, b.Height);
                }

                b = BitmapOperations.ResizeImage(b, 512, 512);
                
                string lastfile = GetTempFile(".ico");
                BitmapOperations.ConvertToIco(b, lastfile, 512);
                this.FileToClipboard(lastfile);
            }
            else
            {                
                string lastfile = GetTempFile(".png");                
                b.Save(lastfile, System.Drawing.Imaging.ImageFormat.Png);
                this.FileToClipboard(lastfile);
            }

            
            //Clipboard.SetImage(b);
            this.Show();
        }

        private Bitmap CaptureAreaToBitmap()
        {
            

            this.Hide();
            Rectangle r = this.RectangleToScreen(ClientRectangle);
            Bitmap b = GetDesktopImage(r);
            this.Show();
            return b;
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private void FileToClipboard(string path)
        {
            this.clearOldFiles();            
            this.lastfile.Add(path);

            StringCollection paths = new StringCollection();
            paths.Add(path);
            Clipboard.SetFileDropList(paths);
        }

        public Bitmap GetDesktopImage(Rectangle rect)
        {
            Graphics graphics;
            Bitmap bitmap;

            bitmap = new Bitmap(rect.Width, rect.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, new Size(rect.Width, rect.Height));
            return bitmap;
        }

        public string GetTempFile(string extension = ".png", int number = 0)
        {
            DateTime dt = DateTime.Now;
            String DocName = String.Format("{0:yyyy-M-d-HH-mm-ss}", dt) +( number > 0 ? "."+number.ToString()+"." : "") + extension;

            string path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DocName);
            return path;

        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CaptureAreaToFile();
        }

        private void captureWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void WindowMeterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PosLeft = this.Left;
            Properties.Settings.Default.PosTop = this.Top;
            Properties.Settings.Default.Save();

            this.clearOldFiles();

            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WindowMeter";
                string filePath = folderPath + "\\settings.txt";
                using (StreamWriter outfile = new StreamWriter(filePath))
                {
                    outfile.Write(this.BackColor.ToString());
                }
            }
            catch (Exception ex)
            {
            }

            Hook.UnRegister();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK )
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, 32);

            Graphics g = e.Graphics;

            int fontSize = 16;
            int textPos = 10;
            if (this.Height<50 || this.Width < 80) {
                fontSize = 8;
                textPos = 3;
            }
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", fontSize);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            g.DrawString(sizeLabel, drawFont, drawBrush, textPos, textPos, drawFormat);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            if (m.Msg == 0xa4)
            {  // Trap WM_NCRBUTTONDOWN
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                contextMenuStrip1.Show(pos);
                return;
            }

            base.WndProc(ref m);
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void centerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.centerToolStripMenuItem_Click(sender,e);
        }

        private void setSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void WindowMeterForm_Paint(object sender, PaintEventArgs e)
        {
            
        }

        // check if form is on screen
        public bool IsOnScreen(Form form)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                Point formTopLeft = new Point(form.Left, form.Top);

                if (screen.WorkingArea.Contains(formTopLeft))
                {
                    return true;
                }
            }

            return false;
        }

        public void SetSize(int width = 0, int height = 0)
        {
            this.Width = width;
            this.Height = height;
        }

        private void setSizeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            formSetSize.windowMeterForm = this;
            formSetSize.SetSize(this.Width, this.Height);
            formSetSize.ShowDialog();
        }


        private bool makeAreaScreensot = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (makeAreaScreensot) {
                this.CaptureAreaToFile();
                makeAreaScreensot = false;
            }
        }
        
        public bool catchAsIcon512x512 = false;

        private void catchAsIcon512x512ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.catchAsIcon512x512 = !this.catchAsIcon512x512;
            catchAsIcon512x512ToolStripMenuItem.Checked = this.catchAsIcon512x512;
        }

        private void screen1ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (Screen.AllScreens.Length<1)
            {                
                return;
            }

            Screen screen = Screen.AllScreens[0];

            this.CaptureScreenToFile(screen);

        }

        private void screen2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length < 2)
            {
                return;
            }

            Screen screen = Screen.AllScreens[1];

            this.CaptureScreenToFile(screen);
        }

        private void screen3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length < 3)
            {
                return;
            }

            Screen screen = Screen.AllScreens[2];

            this.CaptureScreenToFile(screen);
        }

        private void screen4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length < 4)
            {
                return;
            }

            Screen screen = Screen.AllScreens[3];

            this.CaptureScreenToFile(screen);
        }

        private void CaptureAlllScreenToFile()
        {
            if (Screen.AllScreens.Length <= 0)
            {
                return;
            }

            this.clearOldFiles();

            this.Hide();

            StringCollection paths = new StringCollection();

            int num = 0;

            foreach (Screen screen in Screen.AllScreens)
            {
                Rectangle r = this.RectangleToScreen(ClientRectangle);
                Bitmap b = this.CaptureScreen(screen);

                string lastfile = GetTempFile(".png", ++num);
                b.Save(lastfile, System.Drawing.Imaging.ImageFormat.Png);

                paths.Add(lastfile);
                
            }
            Clipboard.SetFileDropList(paths);

            
            
            this.Show();
        }

        private void allScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CaptureAlllScreenToFile();
        }

        private void currentScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.FromControl(this);
            this.CaptureScreenToFile(screen);
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.TopMost = !this.TopMost;
            topMostToolStripMenuItem.Checked = this.TopMost;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void optionsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            topMostToolStripMenuItem.Checked = this.TopMost;
        }

        private void oCRRecognizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = OCR.ImageToText(this.CaptureAreaToBitmap());
            
            if (text == null || text.Trim()=="") {
                text = "?";
            }

            Clipboard.SetText(text);
        }
    }
}
