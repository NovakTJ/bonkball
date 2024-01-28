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
using System.Globalization;

namespace Bonkball
{
    public partial class Form1 : Form
    {
        NumberFormatInfo nbf;
        public Form1()
        {
            InitializeComponent();
        }
        float speed=3;
        Ball ball;
        Brush red;
        Brush blue;
        Pokretljiv Protagonist;
        List<Pokretljiv> L;
        List<Crtez> Plavi;
        List<Crtez> Crveni;
        bool PlaviImajuLoptu;
        StreamReader sr;
        int numberOfPlayers = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            nbf = System.Globalization.NumberFormatInfo.InvariantInfo;
            //G = pictureBox1.CreateGraphics();
            sr = new StreamReader("instructions.txt");
            ball = new Ball();
            PlaviImajuLoptu = true;
            red = new SolidBrush(Color.Red);
            blue = new SolidBrush(Color.Blue);
            Protagonist = new Pokretljiv(49.5f, 88);
            Protagonist.vx = 0; Protagonist.vy = 0;
            L = new List<Pokretljiv>();
            L.Add(Protagonist);
            Plavi = new List<Crtez>();
            Crveni = new List<Crtez>();
            L.Add(Protagonist);
            initial_instructions();
        }
        int i = 1;

        private void initial_instructions()
        {
            numberOfPlayers = int.Parse(sr.ReadLine());
            for (int i = 0; i < numberOfPlayers / 2; i++)
            {
                Plavi.Add(new Crtez());
            }
            for (int i = 0; i < numberOfPlayers / 2; i++)
            {
                Crveni.Add(new Crtez());
            }
        }

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

            if (PlaviImajuLoptu)
            {
                foreach (Crtez lik in Plavi)
                {
                    lik.draw(e.Graphics, blue);

                }
                foreach (Crtez lik in Crveni)
                {
                    lik.draw(e.Graphics, red);
                }
            }
            else
            {
                foreach (Crtez lik in Crveni)
                {
                    lik.draw(e.Graphics, red);
                }
                foreach (Crtez lik in Plavi)
                {
                    lik.draw(e.Graphics, blue);
                }
            }
            foreach(Pokretljiv lik in L)
            {
                e.Graphics.FillEllipse(red, lik.x-10, lik.y-10, 20, 20);
            }
            ball.draw(e.Graphics);
            label1.Text = i.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            pictureBox1.Refresh();
            fajl();
            
        }
        private void fajl()
        {
            string potez;
            string tim_sa_loptom;
            //StreamReader sr = new StreamReader("instructions.txt");
            if (sr.EndOfStream)
            {
                return;
            }
            potez=sr.ReadLine(); //"potez"
            if (potez != "potez")
            {
                throw new Exception("ne poklapa se citanje");
            }
            sr.ReadLine(); //#potez
            ball.update(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()));
            tim_sa_loptom = sr.ReadLine();
            PlaviImajuLoptu = (tim_sa_loptom == "1");

            foreach (Crtez igrac in Plavi)
            {
                float xx;
                float yy;
                sr.ReadLine(); //id
                sr.ReadLine(); //1 (plavi) ili -1 (crveni)
                xx = float.Parse(sr.ReadLine(),nbf);
                yy= float.Parse(sr.ReadLine(),nbf);
                igrac.update(xx, yy);
                label2.Text = xx.ToString() + " " + yy.ToString();
                sr.ReadLine(); //message
                sr.ReadLine(); //ima loptu (1)
                sr.ReadLine(); // \n
            }

            foreach (Crtez igrac in Crveni)
            {
                sr.ReadLine(); //id
                sr.ReadLine(); //1 (plavi) ili -1 (crveni)
                igrac.update(float.Parse(sr.ReadLine(),nbf), float.Parse(sr.ReadLine(),nbf));
                sr.ReadLine(); //message
                sr.ReadLine(); //ima loptu (1)
                sr.ReadLine(); // \n
            }

            return;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
