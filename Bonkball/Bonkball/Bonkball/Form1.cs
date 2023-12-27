using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonkball
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics G;
        Pen p;
        Brush b;
        float vx,x,y;
        float vy;
        float speed=3;
        private void Form1_Load(object sender, EventArgs e)
        {
            //G = pictureBox1.CreateGraphics();
            p = new Pen(Color.Red);
            b = new SolidBrush(Color.Red);
            vx =2; vy = 0;
            x = 10;
            y = 10;
        }
        int i = 1;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'A')
            {
                vx = -speed;
            }
            if (e.KeyValue == 'D')
            {
                vx = speed;
            }
            if (e.KeyValue == 'W')
            {
                vy = -speed;
            }
            if (e.KeyValue == 'S')
            {
                vy = speed;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'A')
            {
                vx = 0;
            }
            if (e.KeyValue == 'D')
            {
                vx = 0;
            }
            if (e.KeyValue == 'W')
            {
                vy = 0;
            }
            if (e.KeyValue == 'S')
            {
                vy = 0;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(b, x, y, 200, 200);
            label1.Text = i.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            i++;
            x += vx;
            y += vy;
        }
    }
}
