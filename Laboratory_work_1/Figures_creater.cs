using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratory_work_1
{
    class Figures_creater
    {
        public Figure Create_object(string name,Color c,float pen_width)
        {
            string full_name = string.Format("{0}.{1}",GetType().Namespace,name);
            Figure obj = (Figure)Activator.CreateInstance(Type.GetType(full_name), c,pen_width);
            return obj;
        }
    }
}
