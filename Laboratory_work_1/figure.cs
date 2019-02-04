using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;

namespace Laboratory_work_1
{
    
    [Serializable]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Ellipse))]
    [XmlInclude(typeof(Square))]

    public abstract class Figure
    {
       // [XmlElement(ElementName ="color")]
        //[XmlElement]
        //[XmlAttribute]
        [XmlIgnore]
        public Color color;

        public int colorInt;
        public float penWidth;
        public Point point_2;
        public Point point_1;


        public abstract void Set_coordinates(Point first_point, Point second_point);
        
        

        public abstract void Draw(Graphics g);
        
        

        
    }
}
