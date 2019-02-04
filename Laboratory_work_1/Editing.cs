using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratory_work_1
{
    public class Editing
    {
        public bool isChange;
        public Figure currentFigure;
        public int isChangeFigure;
        public int canChange;

        public Rectangle circuit;
        public Editing()
        {
        }

        public int CheckingClick(int x,int y,List list)
        {
            int temp;
            if ((temp = list.TakeNeededElement(x, y)) == -1)
            {
                this.isChange = false;
                return 0;
            }
            else
            {
                isChangeFigure = temp;
                currentFigure = list.TakeFigure(temp);
                isChange = true;
                circuit = new Rectangle(new Point(currentFigure.point_1.X - 5, currentFigure.point_1.Y - 5), new Point(currentFigure.point_2.X + 5, currentFigure.point_2.Y + 5), Color.Aqua, 5);
            }
            return 1;
        }

        public void EditClick(int x,int y)
        {
            if (isChange)
            {
                canChange = 0;
                if ((x > circuit.point_1.X - 5 && x < circuit.point_1.X + 5) && (y > circuit.point_1.Y-5 && y < circuit.point_1.Y + 5))
                    canChange = 7;
                if ((x > circuit.point_2.X - 5 && x < circuit.point_2.X + 5) && (y > circuit.point_1.Y -5 && y < circuit.point_1.Y + 5))
                    canChange = 9;
                if ((x > circuit.point_1.X - 5 && x < circuit.point_1.X + 5) && (y > circuit.point_2.Y - 5 && y < circuit.point_2.Y + 5))
                    canChange = 1;
                if ((x > circuit.point_2.X - 5 && x < circuit.point_2.X + 5) && (y > circuit.point_2.Y - 5 && y < circuit.point_2.Y +5))
                    canChange = 3;
            }
        }

        public Figure EditingInMove(int x,int y,List<Figure> list)
        {
            switch (canChange)
            {
                case 7:
                    {
                        if (y > list[isChangeFigure].point_2.Y - 10 && x > list[isChangeFigure].point_2.X - 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_2.X - 10, list[isChangeFigure].point_2.Y - 10), list[isChangeFigure].point_2);
                            break;
                        }
                        if (x > list[isChangeFigure].point_2.X - 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_2.X - 10, y), list[isChangeFigure].point_2);
                            break;
                        }
                        if (y > list[isChangeFigure].point_2.Y - 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(x, list[isChangeFigure].point_2.Y - 10), list[isChangeFigure].point_2);
                            break;
                        }
                        list[isChangeFigure].Set_coordinates(new Point(x, y), list[isChangeFigure].point_2);
                        break;
                    }
                case 1:
                    {
                        if (y < list[isChangeFigure].point_1.Y + 10 && x > list[isChangeFigure].point_2.X - 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_2.X-10, list[isChangeFigure].point_1.Y ), new Point(list[isChangeFigure].point_2.X, list[isChangeFigure].point_1.Y+10));
                            break;
                        }
                        if (x > list[isChangeFigure].point_2.X - 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_2.X-10, list[isChangeFigure].point_1.Y), new Point(list[isChangeFigure].point_2.X, y));
                            break;
                        }
                        if (y < list[isChangeFigure].point_1.Y + 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(x, list[isChangeFigure].point_1.Y), new Point(list[isChangeFigure].point_2.X,list[isChangeFigure].point_1.Y+10));
                            break;
                        }
                        list[isChangeFigure].Set_coordinates(new Point(x, list[isChangeFigure].point_1.Y), new Point(list[isChangeFigure].point_2.X, y));
                        break;
                    }
                case 3:
                    {
                        if (y < list[isChangeFigure].point_1.Y + 10 && x < list[isChangeFigure].point_1.X + 10)
                        {
                            list[isChangeFigure].Set_coordinates(list[isChangeFigure].point_1, new Point(list[isChangeFigure].point_1.X + 10, list[isChangeFigure].point_1.Y+10));
                            break;
                        }
                        if (x < list[isChangeFigure].point_1.X + 10)
                        {
                            list[isChangeFigure].Set_coordinates(list[isChangeFigure].point_1, new Point(list[isChangeFigure].point_1.X + 10, y));
                            break;
                        }
                        if (y < list[isChangeFigure].point_1.Y + 10)
                        {
                            list[isChangeFigure].Set_coordinates(list[isChangeFigure].point_1,new Point(x, list[isChangeFigure].point_1.Y+10));
                            break;
                        }
                        list[isChangeFigure].Set_coordinates(list[isChangeFigure].point_1, new Point(x, y));
                        break;
                    }
                case 9:
                    {
                        if (y > list[isChangeFigure].point_2.Y - 10 && x < list[isChangeFigure].point_1.X + 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_1.X, list[isChangeFigure].point_2.Y-10), new Point(list[isChangeFigure].point_1.X+10, list[isChangeFigure].point_2.Y));
                            break;
                        }
                        if (x < list[isChangeFigure].point_1.X - 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_1.X,y), new Point(list[isChangeFigure].point_1.X+10, list[isChangeFigure].point_2.Y));
                            break;
                        }
                        if (y > list[isChangeFigure].point_2.Y - 10)
                        {
                            list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_1.X, list[isChangeFigure].point_2.Y-10), new Point(x, list[isChangeFigure].point_2.Y));
                            break;
                        }
                        list[isChangeFigure].Set_coordinates(new Point(list[isChangeFigure].point_1.X, y), new Point(x, list[isChangeFigure].point_2.Y));
                        break;
                    }
            }
            circuit = new Rectangle(new Point(list[isChangeFigure].point_1.X - 5, list[isChangeFigure].point_1.Y - 5), new Point(list[isChangeFigure].point_2.X + 5, list[isChangeFigure].point_2.Y + 5), Color.Aqua, 5);
            return list[isChangeFigure];
        }
    }
}
