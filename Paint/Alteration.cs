using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Alteration_form : Form
    {
        ColorDialog c = new ColorDialog();
        SolidBrush b = new SolidBrush(Color.Black);
        Pen p = new Pen(Color.Black, 5);
        Pen p2 = new Pen(Color.Orchid, 3);
        public Alteration_form()
        {
            InitializeComponent();
            comboBox3.SelectedIndex = 0;
        }






        private void button5_Click(object sender, EventArgs e)
        {
            c.ShowDialog();
            b.Color = c.Color;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (comboBox3.Text == "تجانس")
            {
                g.Clear(pictureBox1.BackColor);
                int t1 = int.Parse(textBox1.Text);
                int t2 = int.Parse(textBox2.Text);
                int t3 = int.Parse(textBox3.Text);
                int t4 = int.Parse(textBox4.Text);
                g.FillRectangle(b, t1, t2, t3, t4);
                Matrix m = new Matrix();
                int x = int.Parse(textBox5.Text);
                int y = int.Parse(textBox6.Text);
                m.Scale(x, y);
                g.Transform = m;
                g.FillRectangle(b, t1, t2, t3, t4);

            }
            else if (comboBox3.Text == "دوران")
            {

                g.Clear(pictureBox1.BackColor);
                int t1 = int.Parse(textBox1.Text);
                int t2 = int.Parse(textBox2.Text);
                int t3 = int.Parse(textBox3.Text);
                int t4 = int.Parse(textBox4.Text);
                g.FillRectangle(b, t1, t2, t3, t4);
                Matrix m = new Matrix();
                int d = int.Parse(textBox5.Text);
                m.Rotate(d);
                g.Transform = m;
                g.FillRectangle(b, t1, t2, t3, t4);

            }
            else if (comboBox3.Text == "کشش")
            {
                g.Clear(pictureBox1.BackColor);
                int t1 = int.Parse(textBox1.Text);
                int t2 = int.Parse(textBox2.Text);
                int t3 = int.Parse(textBox3.Text);
                int t4 = int.Parse(textBox4.Text);
                int d = int.Parse(textBox5.Text);
                g.DrawRectangle(p, t1, t2, t3, t4);
                g.DrawRectangle(p2, t1 - d, t2 - d, t3 + d, t4 + d);
                Matrix m = new Matrix();

            }
            else if (comboBox3.Text == "فاصله")
            {
                g.Clear(pictureBox1.BackColor);
                int t1 = int.Parse(textBox1.Text);
                int t2 = int.Parse(textBox2.Text);
                int t3 = int.Parse(textBox3.Text);
                int t4 = int.Parse(textBox4.Text);
                int d = int.Parse(textBox5.Text);
                g.DrawRectangle(p, t1, t2, t3, t4);
                g.DrawRectangle(p2, t1 + d + 100, t2 + d + 100, t3, t4);
                Matrix m = new Matrix();

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "تجانس")
            {
                label5.Text = "پارامتر اول";
                label6.Text = "پارامتر دوم";
                label6.Visible = true;
                textBox6.Visible = true;
            }
            else if (comboBox3.Text == "دوران")
            {
                label5.Text = "درجه دوران";
                label6.Visible = false;
                textBox6.Visible = false;
            }
            else if (comboBox3.Text == "کشش")
            {
                label5.Text = "ورودی";
                label6.Visible = false;
                textBox6.Visible = false;
            }
            else if (comboBox3.Text == "انتقال")
            {
                label5.Text = "فاصله";
                label6.Visible = false;
                textBox6.Visible = false;
            }



        }




    }
}
