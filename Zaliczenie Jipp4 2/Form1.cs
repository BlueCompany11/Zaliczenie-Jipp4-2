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

        }

        private void groupBoxOkrag_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxProstokat_Paint(object sender, PaintEventArgs e)
        {
            int centerX = (groupBoxProstokat.Left + groupBoxProstokat.Right) / 2;
            int centerY = (groupBoxProstokat.Top + groupBoxProstokat.Height) / 2;
            int radius = groupBoxProstokat.Width / 2;

            e.Graphics.DrawEllipse(Pens.Red, centerX - radius, centerY - radius,
                      radius + radius, radius + radius);
        }

        private void buttonOkrag_Click(object sender, EventArgs e)
        {
            Graphics g = groupBoxOkrag.CreateGraphics();
            int centerX = 40; //(groupBoxProstokat.Left + groupBoxProstokat.Right) / 2;
            int centerY = 40; //(groupBoxProstokat.Top + groupBoxProstokat.Height) / 2;
            int radius = groupBoxOkrag.Width / 32;
            g.DrawEllipse(Pens.Red, centerX - radius, centerY - radius,
                      radius + radius, radius + radius);

        }

        private void buttonProstokat_Click(object sender, EventArgs e)
        {
            Graphics g = groupBoxProstokat.CreateGraphics();
            g.DrawRectangle(Pens.SeaGreen, 10, 10, 50, 50);
        }

        private void buttonProsta_Click(object sender, EventArgs e)
        {
            Graphics g = groupBoxProsta.CreateGraphics();
            g.DrawLines(Pens.SeaGreen, new Point[] { new Point(10, 10), new Point(20, 20) });
        }
    }
}
