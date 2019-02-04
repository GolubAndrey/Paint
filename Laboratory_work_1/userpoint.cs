using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory_work_1
{
    class Userpoint:Figure
    {
        SolidBrush brush;
        public Pen pen;
        public Userpoint(Point point_1, Color color,float pen_width)
        {
            pen = new Pen(color, pen_width);
            brush = new SolidBrush(color);
            Set_coordinates(point_1,point_2);
        }

        public Userpoint(Color color, float pen_width)
        {
            pen = new Pen(color, pen_width);
            brush = new SolidBrush(color);
        }

        public override void Set_coordinates(Point first_point,Point second_point)
        {
            point_1 = first_point;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(brush, point_1.X,point_1.Y, 5, 5);
        }
    }
}
