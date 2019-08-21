using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeScreenshotOfWindow
{
    public partial class Form1 : Form
    {

        int x, y, w, h;
        string loc;

        public Bitmap Screenshot()
        {
            UpdateFormLocation();
            
            //Take Screenshot
            Bitmap bmpScreenshot = new Bitmap(w-14, h-37);

            Graphics g = Graphics.FromImage(bmpScreenshot);
            
            string FileLocation = "X:/Programmieren/Daten/EggIncBotScreenshots/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

            g.CopyFromScreen(y+7,x+30,0,0, new Size(w-14, h-37));
            bmpScreenshot.Save(FileLocation, ImageFormat.Png);
            return bmpScreenshot;
        }

        public string getLocationofWindow()
        {
            int windowHeight = this.Height;
            int windowWidth = this.Width;

            int windowTop = this.Top;
            int windowLeft = this.Left;

            string result =  windowTop.ToString() +","+ windowLeft.ToString() + ","+ windowHeight + "," + windowWidth;

            return result;
        }
        
        //converts location string to single intgers x y width and height
        public int StringToIntLocationX()
        {
            string LocationOfWindow = getLocationofWindow();
            string stringx;

            string[] tmp = LocationOfWindow.Split(',');
            stringx = tmp[0];

            x = Convert.ToInt32(stringx);

            return x;
        }
        public int StringToIntLocationY()
        {
            string LocationOfWindow = getLocationofWindow();
            string stringy;

            string[] tmp = LocationOfWindow.Split(',');
            stringy = tmp[1];

            y = Convert.ToInt32(stringy);

            return y;
        }
        public int StringToIntLocationW()
        {
            string LocationOfWindow = getLocationofWindow();
            string stringw;

            string[] tmp = LocationOfWindow.Split(',');
            stringw = tmp[3];

            w = Convert.ToInt32(stringw);

            return w;
        }
        public int StringToIntLocationH()
        {
            string LocationOfWindow = getLocationofWindow();
            string stringh;

            string[] tmp = LocationOfWindow.Split(',');
            stringh = tmp[2];

            h = Convert.ToInt32(stringh);

            return h;
        }

        private void UpdateLabels()
        {
            loc = getLocationofWindow();

            y = StringToIntLocationY();
            x = StringToIntLocationX();
            h = StringToIntLocationH();
            w = StringToIntLocationW();

            label1.Text = x.ToString();
            label2.Text = y.ToString();
            label3.Text = w.ToString();
            label4.Text = h.ToString();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Screenshot();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Screenshot();
        }
        
        public void UpdateFormLocation()
        {
            loc = getLocationofWindow();

            y = StringToIntLocationY();
            x = StringToIntLocationX();
            h = StringToIntLocationH();
            w = StringToIntLocationW();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }
        
    }
}
