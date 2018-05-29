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
            TimerZmienilStatus += ((stan) => 
            {
                if (stan == true)
                {
                    BackColor = Color.Red;
                }
                else
                {
                    BackColor = Color.Aqua;
                }
            });

            
        }
        bool SprawdzCzyTimerDziala()
        {
            return aTimer.Enabled;
        }

        private static System.Timers.Timer aTimer;

        private delegate void TypReakcjiNaZmianeStatusuTimera(bool value);
        private event TypReakcjiNaZmianeStatusuTimera TimerZmienilStatus;

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += buttonOkrag_Click;
            aTimer.Elapsed += buttonProstokat_Click;
            aTimer.Elapsed += buttonProsta_Click;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Task.Run(async () =>
            {
                while (true)
                {
                    bool ostatniStatusTimera = aTimer.Enabled;
                    await Task.Delay(TimeSpan.FromSeconds(0.5));
                    if (TimerZmienilStatus != null)
                    {
                        //TimerZmienilStatus(ostatniStatusTimera);
                        if (ostatniStatusTimera != aTimer.Enabled)
                        {
                            TimerZmienilStatus(ostatniStatusTimera);
                        }
                    }

                }
            }
    );
        }

        private async Task StopTimer()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            aTimer.Stop();
        }

        private async void buttonUruchomAnimacje_Click(object sender, EventArgs e)
        {
            Form1 noweOkno = new Form1();
            noweOkno.Show();
            noweOkno.SetTimer();
            await StopTimer();
            MessageBox.Show("Animacja zakonczona");
        }

        private void buttonAnimacjaCalyCzas_Click(object sender, EventArgs e)
        {
            Form1 noweOkno = new Form1();
            noweOkno.Show();
            noweOkno.SetTimer();
            //tutaj timer nigdy sie nie zatrzymuje
        }

        int x = 2;
        private void buttonOkrag_Click(object sender, EventArgs e)
        {
            Graphics g = groupBoxOkrag.CreateGraphics();
            int centerX =  groupBoxOkrag.Width / x;
            int centerY = groupBoxOkrag.Height / x;
            int radius = groupBoxOkrag.Width / x;
            x++;
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
            g.DrawLines(Pens.SeaGreen, new Point[] { firstPoint, secondPoint });
            
        }
        
    }
}
