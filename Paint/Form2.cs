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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            axShockwaveFlash1.Movie = Application.StartupPath + @"\test.swf";
        }

        private void axShockwaveFlash1_Enter(object sender, EventArgs e)
        {

        }
    }
}
