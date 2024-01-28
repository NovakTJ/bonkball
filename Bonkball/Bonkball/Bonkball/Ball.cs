using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bonkball
{
    public class Ball
    {
        float x;
        float y;
        Brush white;
        public Ball(float xx=0,float yy=0)
        {
            white = new SolidBrush(Color.White);
            x = xx;
            y = yy;
        }
        public void draw(Graphics g)
        {
            g.FillEllipse(white, x-1.5f, y-1.5f, 3, 3);
            return;
        }
        public void update(float xx,float yy)
        {
            x = xx;
            y = yy;
        }
    }
}
