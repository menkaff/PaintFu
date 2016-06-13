using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Line_form : Form
    {
        ColorDialog c;
        int topor = 0;

        Pen p = new Pen(Color.Black, 10);
        SolidBrush b = new SolidBrush(Color.Black);
        Font font = new Font("b zar", 22);
        Graphics gg;
        Bitmap bmp;
        int x1, y1, run = 0;
        int xpast = 0;
        int ypast = 0;

        public Line_form()
        {

            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            c = new ColorDialog();
            c.ShowDialog();
            p.Color = c.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c = new ColorDialog();
            c.ShowDialog();
            p.Color = c.Color;
        }







        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            c = new ColorDialog();
            c.ShowDialog();
            b.Color = c.Color;
            p.Color = c.Color;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            c = new ColorDialog();
            c.ShowDialog();
            p.Color = c.Color;
            b.Color = c.Color;
        }







        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Width = comboBox1.SelectedIndex + 3;


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = new Font("b zar", float.Parse(comboBox2.Text));
        }



        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {

            int p1, p2;

            if (run == 1)
            {


                gg = pictureBox3.CreateGraphics();
                if (e.X > xpast)
                    p1 = xpast;
                else
                    p1 = xpast + 10;
                if (e.Y > ypast)
                    p2 = ypast;
                else
                    p2 = ypast + 10;

                if (comboBox4.Text == "مستطیل")
                {
                   // gg.FillRectangle(white, x1 - 5, y1 - 5, p1, p2);
                    pictureBox3.Refresh();
                    if (checkBox1.Checked == true)
                    {
                        
                        gg.FillRectangle(b, x1, y1, e.X, e.Y);
                    }

                    else
                    {
                       
                        gg.DrawRectangle(p, x1, y1, e.X, e.Y);
                    }


                }
                else if (comboBox4.Text == "خط")
                {
                    
                    //gg.FillRectangle(white, x1 - 5, y1 - 5, p1, p2);
                    pictureBox3.Refresh();
                    gg.DrawLine(p, x1, y1, e.X, e.Y);
                }

                else if (comboBox4.Text == "دایره و بیضی")
                {
                    //gg.FillEllipse(white, x1 - 5, y1 - 5, p1, p2);
                    pictureBox3.Refresh();
                    if (checkBox1.Checked == true)
                        gg.FillEllipse(b, x1, y1, e.X, e.Y);
                    else
                        gg.DrawEllipse(p, x1, y1, e.X, e.Y);

                }

                else if (comboBox4.Text == "منحنی")
                {
                    Point PT1 = new Point(x1, y1);
                    Point PT2 = new Point(240, 150);
                    Point PT3 = new Point(122, 222);
                    Point PT4 = new Point(e.X, e.Y);
                    //gg.FillRectangle(white, x1 - 5, y1 - 5, p1, p2);
                    pictureBox3.Refresh();
                    gg.DrawBezier(p, PT1, PT2, PT3, PT4);
                }


                xpast = e.X;
                ypast = e.Y;

            }


        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (run == 1)
            {

                gg = pictureBox3.CreateGraphics();
                if (comboBox4.Text == "مستطیل")
                {



                    gg.DrawRectangle(p, x1, y1, e.X, e.Y);
                }
                else if (comboBox4.Text == "خط")
                {

                    gg.DrawLine(p, x1, y1, e.X, e.Y);
                }

                else if (comboBox4.Text == "دایره و بیضی")
                {

                    gg.DrawEllipse(p, x1, y1, e.X, e.Y);
                }


            }
            run = 0;
            xpast = 0;
            ypast = 0;
            x1 = 0;
            y1 = 0;





        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            run = 1;
                 if (comboBox4.Text == "نمایش متن")
                {
                    gg = pictureBox3.CreateGraphics();

                    string ss = Convert.ToString(textBox1.Text);
                    gg.DrawString(ss, font, b, new Rectangle(x1, y1, 200, 200));
                    gg.Dispose();

                }



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog sfdlg = new SaveFileDialog())
            {
                sfdlg.Title = "Save Dialog";
                sfdlg.Filter = "Bitmap Images (*.bmp)|*.bmp|All files(*.*)|*.*";
                if (sfdlg.ShowDialog(this) == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height))
                    {
                        pictureBox3.Invalidate();
                        pictureBox3.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        pictureBox3.Invalidate();
                        pictureBox3.Image = bmp;
                        pictureBox3.Image.Save("cc.Jpg");
                        bmp.Save(sfdlg.FileName);
                        MessageBox.Show("Saved Successfully.....");

                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            c = new ColorDialog();
            c.ShowDialog();

        }



        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox3.CreateGraphics();
            g.Clear(pictureBox3.BackColor);
            g.Dispose();
        }



        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (topor == 1)
            {
               // toolStripLabel1.BackgroundImage = Image.FromFile("C:/Users/Mehrdad/Downloads/rezvan.fahimi/ddd/Paint/Resources/rect.bmp");
                topor = 0;
                checkBox1.Checked = false;
            }
            else if (topor == 0)
            {
                //toolStripLabel1.BackgroundImage = Image.FromFile("C:/Users/Mehrdad/Downloads/rezvan.fahimi/ddd/Paint/Resources/rect2.bmp");
                topor = 1;
                checkBox1.Checked = true;
            }
        }



        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            c = new ColorDialog();
            c.ShowDialog();
            p.Color = c.Color;
            b.Color = c.Color;


        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            int size=(comboBox2.SelectedIndex*2)+8;
            font = new Font("b zar", size);
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            p.Width = comboBox1.SelectedIndex + 3;
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfdlg = new SaveFileDialog())
            {
                sfdlg.Title = "Save Dialog";
                sfdlg.Filter = "Bitmap Images (*.bmp)|*.bmp|All files(*.*)|*.*";
                if (sfdlg.ShowDialog(this) == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height))
                    {
                        pictureBox3.Invalidate();
                        pictureBox3.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        pictureBox3.Invalidate();
                        pictureBox3.Image = bmp;
                        pictureBox3.Image.Save("cc.Jpg");
                        bmp.Save(sfdlg.FileName);

                    }
                }
            }
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                Image img = Image.FromFile(dlg.FileName);
                pictureBox3.Image = img;
            }

            dlg.Dispose();
        }













    }
}