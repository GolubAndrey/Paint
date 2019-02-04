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
    

    public class Line : Figure
    {
        //public Pen xyi;
        public Line(Point point_1,Point point_2,Color color,float pen_width)
        {
            this.color = color;
            this.penWidth = pen_width;
            Set_coordinates(point_1,point_2);

        }
        

        public Line()
        {
        }

        public Line(Color color,float pen_width)
        {
            this.color = color;
            this.penWidth = pen_width;
        }

        public override void Set_coordinates(Point first_point, Point second_point)
        {
            point_1 = first_point;
            point_2 = second_point;
        }
        

        public override void Draw(Graphics g)
        { 
            g.DrawLine(new Pen(color,penWidth), point_1,point_2);
        }
    }
}
