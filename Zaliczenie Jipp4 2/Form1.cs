using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaliczenie_Jipp4_2
{
    public partial class Form1 : Form
    {
        public Form1() //aplikacja SDI single document interface - wyklad 4
        {
            InitializeComponent();
            SetTimer();
        }
        int x = 2;
        private void buttonOkrag_Click(object sender, EventArgs e)
        {
            Graphics g = groupBoxOkrag.CreateGraphics();
            int centerX =  groupBoxOkrag.Width / x;
            int centerY = groupBoxOkrag.Height / x;
            int radius = groupBoxOkrag.Width / x;
            x++; //dodac to do timera
            g.DrawEllipse(Pens.Red, centerX - radius, centerY - radius,
                      radius + radius, radius + radius);
        }
        int doprostokata = 10;
        private void buttonProstokat_Click(object sender, EventArgs e)
        {
            Graphics g = groupBoxProstokat.CreateGraphics();
            int topLeftX = groupBoxProstokat.Width / 20;
            int topLeftY = groupBoxProstokat.Height / 20;
            int height = (int)(groupBoxProstokat.Height * (0.9));
            int width = (int)(groupBoxProstokat.Width* (0.9));
            g.TranslateTransform(groupBoxProsta.Width / 2, groupBoxProsta.Height / 2);
            g.RotateTransform(doprostokata);
            doprostokata += 20;
            //g.RotateTransform(100);
            g.DrawRectangle(Pens.SeaGreen, topLeftX, topLeftY, width,height );
        }
        int doprostej = 10;
        private void buttonProsta_Click(object sender, EventArgs e)
        {
            Graphics g = groupBoxProsta.CreateGraphics();
            Point firstPoint = new Point(groupBoxProsta.Width / 20, groupBoxProsta.Height / 20);
            Point secondPoint = new Point(groupBoxProsta.Width, groupBoxProsta.Height);
            g.TranslateTransform(groupBoxProsta.Width / 2, groupBoxProsta.Height / 2);
            g.RotateTransform(doprostej);
            doprostej += 20;
            //g.RotateTransform(100);
            g.DrawLines(Pens.SeaGreen, new Point[] { firstPoint, secondPoint });
            
        }
        private static System.Timers.Timer aTimer;
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += buttonOkrag_Click;
            aTimer.Elapsed += buttonProstokat_Click;
            aTimer.Elapsed += buttonProsta_Click;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

    }
}
