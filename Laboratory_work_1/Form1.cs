using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Laboratory_work_1
{
    public partial class Form1 : Form
    {
        private Color color=Color.Black;
        private float pen_width=5;
        Bitmap bmp,temp_bmp,allotingBmp;
        private Figures_creater new_factory = new Figures_creater();

        bool isDraw = false;
        //bool isChange = false;
        //int canChange = 0;
        //int isChangeFigure;
        private string view_figure="Line";
        private Figure currrent_figure;
        Editing edit;
        
        public List list;
        

        public Point fp;
        public Point sp;

        Rectangle rec;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            temp_bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            allotingBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            list = new List();
            edit = new Editing();
            KeyPreview = true;
        }

        private void Cleaning()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cleaning();
            list.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
                color = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view_figure = "Line";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view_figure = "Rectangle";
        }


        private void button5_Click(object sender, EventArgs e)
        {
            view_figure = "Square";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            view_figure = "Ellipse";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            view_figure = "Circle";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            view_figure = "Userpoint";
        }


        private void picturebox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (edit.canChange!=0)
            {
                list.SwapElements(edit.isChangeFigure,edit.EditingInMove(e.X, e.Y, list.figure_list));    
                bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
                list.Draw(Graphics.FromImage(bmp));
                allotingBmp = new Bitmap(bmp);
                edit.circuit.Draw(Graphics.FromImage(allotingBmp));
                pictureBox1.Image = allotingBmp;
            }
            else
                if (!edit.isChange)
                if (isDraw)
                {
                    sp.X = e.X;
                    sp.Y = e.Y;
                    bmp = new Bitmap(temp_bmp);
                    currrent_figure.Set_coordinates(fp, new Point(e.X, e.Y));
                    currrent_figure.Draw(Graphics.FromImage(bmp));
                    pictureBox1.Image = bmp;
                }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            edit.EditClick(e.X, e.Y);
                isDraw = true;
                fp = new Point(e.X, e.Y);
                sp = new Point(e.X, e.Y);
                temp_bmp = bmp;
                pictureBox1.Image = temp_bmp;
                currrent_figure = new_factory.Create_object(view_figure, color, pen_width);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && edit.isChange)
            {
                list.Delete(edit.isChangeFigure);
            }
            allotingBmp = bmp;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            list.Draw(Graphics.FromImage(bmp));
            pictureBox1.Image = bmp;
            //edit.isChange = false;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    list.Save(saveFileDialog1.FileName);
                }
            }
            catch(Exception ex)
            {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            list.Read(myStream);
                            Cleaning();
                            list.Draw(Graphics.FromImage(bmp));
                            pictureBox1.Image = bmp;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect file");
                }
                finally
                {
                    if (myStream != null)
                        myStream.Close();
                }
            }
        }

        private void picturebox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (edit.canChange == 0)
            {
                isDraw = false;
                if (fp != sp)
                {
                    temp_bmp = bmp;
                    pictureBox1.Image = temp_bmp;
                    list.Add(currrent_figure);
                }
                else
                {
                    if (edit.CheckingClick(e.X, e.Y, list) == 0)
                    {
                        pictureBox1.Image = bmp;
                    }
                    else
                    {
                        allotingBmp = bmp;
                        bmp = new Bitmap(allotingBmp);
                        edit.circuit.Draw(Graphics.FromImage(bmp));
                        pictureBox1.Image = bmp;
                        bmp = allotingBmp;
                    }
                }
            }
            else
            {
                edit.canChange = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
