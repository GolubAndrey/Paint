using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace Laboratory_work_1
{
    public class List
    {
        public List<Figure> figure_list;

        public List()
        {
            figure_list = new List<Figure>();
        }

        public void Add(Figure fig)
        {
            figure_list.Add(fig);
        }

        public void Draw(Graphics g)
        {
            foreach(Figure fig in this.figure_list)
            {
                fig.Draw(g);
            }
        }

        public int Length()
        {
            return figure_list.Count;
        }

        public void Delete(int index)
        {
            figure_list.RemoveAt(index);
        }



        public void Clear()
        {
            figure_list.Clear();
        }

        public int TakeNeededElement(int x,int y)
        {
            int count = 0;
            int ourFigure=0;
            for (int i = 0; i < figure_list.Count; i++)
            {
                if ((x < figure_list[i].point_2.X && x > figure_list[i].point_1.X) && (y < figure_list[i].point_2.Y && y > figure_list[i].point_1.Y))
                    ourFigure = i;
                else
                    count++;
            }
            if (count == figure_list.Count)
                return -1;
            else
                return ourFigure;
        }

        public void SwapElements(int index,Figure element)
        {
            figure_list[index] = element;
        }

        public void Save(string fileName)
        {
            foreach (Figure element in figure_list)
                element.colorInt = element.color.ToArgb();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, figure_list);
            }
        }

        public void Read(Stream tempStream)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
            using (tempStream)
            {
                List tempList = new List();
                tempList.figure_list = (List<Figure>)formatter.Deserialize(tempStream);

                figure_list.Clear();
                foreach (Figure element in tempList.figure_list)
                    figure_list.Add(element);
            }
            foreach (Figure element in figure_list)
                element.color = Color.FromArgb(element.colorInt);
        }

        public Figure TakeFigure(int index)
        {
            return figure_list[index];
        }
    }
}
