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
    public partial class first : Form
    {
        public first()
        {
            InitializeComponent();


        }














        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            Form ff = new Line_form();
            ff.Show();
        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {
            Form ff = new Alteration_form();
            ff.Show();
        }

        private void toolStripLabel3_Click_1(object sender, EventArgs e)
        {
            Form ff = new Form1();
            ff.Show();
        }

        private void toolStripLabel4_Click_1(object sender, EventArgs e)
        {
            Form ff = new Form2();
            ff.Show();
        }





    }
}
