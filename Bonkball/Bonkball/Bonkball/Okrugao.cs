using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonkball
{
    public class Pokretljiv
    {
        public float ax;
        public float ay;
        public float vx;
        public float vy;
        public float x;
        public float y;
        public Pokretljiv(float xx = 0, float yy = 0)
        {
            ax = 0;
            ay = 0;
            vx = 0;
            vy = 0;
            x = xx;
            y = yy;
        }
        public void tick()
        {
            x += vx;
            y += vy;
            vx += ax;
            vy += ay;
        }
    }
}
