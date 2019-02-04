using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace Laboratory_work_1
{
    [Serializable]
    public class Circle : Square
    {
        public Circle(Point point_1, Point point_2, Color color, float pen_width) : base(point_1, point_2, color, pen_width)
        {
        }
        
        public Circle(Color color, float pen_width):base(color,pen_width)
        {

        }

        public Circle()
        {
        }


        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(color,penWidth), point_1.X,point_1.Y,width,width);
        }
    }
}
