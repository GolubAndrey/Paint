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
    public class Square : Rectangle
    {
        public Square(Point point_1, Point point_2, Color color, float pen_width) : base(point_1, point_2, color, pen_width)
        {
        }

        public Square(Color color, float pen_width):base(color,pen_width)
        {

        }

        public Square()
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
                    first_point.Y -= width;
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
                    first_point.X -= width;
                    first_point.Y -= width;
                    point_1 = first_point;
                }
            }
            //width = height;
            point_2.X = point_1.X + width;
            point_2.Y = point_1.Y + width;
        }



        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(color,penWidth), point_1.X, point_1.Y, width, width);
        }
    }
}
