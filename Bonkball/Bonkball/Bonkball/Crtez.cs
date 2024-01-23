using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bonkball
{
    public class Crtez
    {
        float x;
        float y;
        string message;
        Brush black;
        public Crtez(float xx=0, float yy=0, string mmessage="")
        {
            x = xx;
            y = yy;
            message = mmessage;
        }
        public void draw(Graphics g, Brush b)
        {
            g.FillEllipse(b, x, y, 20, 20);
            return;
        }
        public void write_message()
        {
            return;
        }
        public void update(float xx, float yy, string mmessage="")
        {
            x = xx;
            y = yy;
            message = mmessage;
        }
    }
}
