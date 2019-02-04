using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory_work_1
{
    class Pentagon:Figure
    {
        public Pen pen;
        private Point point_1,point_2, point_3, point_4, point_5;
        public Point[] array;

        public Pentagon(Point[] array, Color color, float pen_width)
        {
            this.array = array;
            array= new Point[5] { point_1, point_2, point_3, point_4, point_5 };
            pen = new Pen(color, pen_width);
        }
        

        public override void Set_coordinates(Point first_point, Point second_point)
        {
            //
        }
        

        public override void Draw(Graphics g)
        {
            g.DrawPolygon(pen, array);
        }

    }
}
