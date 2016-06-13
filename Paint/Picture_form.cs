using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Picture_form : Form
    {


        public Picture_form()
        {
            InitializeComponent();
        }



        private void label11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                Image img = Image.FromFile(dlg.FileName);
                pictureBox1.Image = img;
            }

            dlg.Dispose();
        }
    }
}
