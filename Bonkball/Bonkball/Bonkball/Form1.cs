using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        Okrugao Protagonist;
        Okrugao NPC;
        List<Okrugao> L;
        private void Form1_Load(object sender, EventArgs e)
        {
            //G = pictureBox1.CreateGraphics();
            p = new Pen(Color.Red);
            b = new SolidBrush(Color.Red);
            Protagonist = new Okrugao(10, 10);
            Protagonist.vx = 2; Protagonist.vy = 0;
            NPC = new Okrugao(100, 100);
            L = new List<Okrugao>();
            L.Add(Protagonist);
            L.Add(NPC);
        }
        int i = 1;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'A')
            {
                Protagonist.vx = -speed;
            }
            if (e.KeyValue == 'D')
            {
                Protagonist.vx = speed;
            }
            if (e.KeyValue == 'W')
            {
                Protagonist.vy = -speed;
            }
            if (e.KeyValue == 'S')
            {
                Protagonist.vy = speed;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'A')
            {
                Protagonist.vx = 0;
            }
            if (e.KeyValue == 'D')
            {
                Protagonist.vx = 0;
            }
            if (e.KeyValue == 'W')
            {
                Protagonist.vy = 0;
            }
            if (e.KeyValue == 'S')
            {
                Protagonist.vy = 0;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Okrugao lik in L)
            {

                e.Graphics.FillEllipse(b, lik.x, lik.y, 20, 20);

            }
            label1.Text = i.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            fajl();
            foreach (Okrugao lik in L){
                lik.tick();
            }
            //Protagonist.tick();
            i++;
            //x += vx;
            //y += vy;
        }
        private void fajl()
        {
            StreamReader sr = new StreamReader("instructions.txt");
            NPC.vx = float.Parse(sr.ReadLine());
            NPC.vy = float.Parse(sr.ReadLine());
            return;
        }
    }
}
