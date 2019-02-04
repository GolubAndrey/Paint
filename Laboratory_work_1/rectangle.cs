using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Laboratory_work_1
{
    [Serializable]
    
    public class Rectangle : Line
    {
        public int width;
        public int height;
        
        public Rectangle(Point point_1, Point point_2, Color color, float pen_width) : base(point_1, point_2, color, pen_width)
        {
            //xyi = new Pen(color, pen_width);
            this.color = color;
            this.penWidth = pen_width;
            Set_coordinates(point_1, point_2);
        }

        public Rectangle(Color color, float pen_width) : base(color, pen_width)
        {

        }

        public Rectangle():base()
        {
        }

        public override void Set_coordinates(Point first_point, Point second_point)
        {
            width = second_point.X - first_point.X;
            height = second_point.Y - first_point.Y;
            if (width > 0)
            {
                if (height > 0)
                {
                    point_1 = first_point;
                }
                else
                {
                    height *= -1;
                    first_point.Y -= height;
                    point_1 = first_point;
                }
            }
            else
            {
                if (height > 0)
                {
                    width *= -1;
                    first_point.X -= width;
                    point_1 = first_point;
                }
                else
                {
                    width *= -1;
                    height *= -1;
                    first_point.X -= width;
                    first_point.Y -= height;
                    point_1 = first_point;
                }
            }
            point_2.X = point_1.X + width;
            point_2.Y = point_1.Y + height;
        }


        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(color,penWidth), point_1.X,point_1.Y, width, height);
        }
    }
}
