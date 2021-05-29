using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class adminmain : UserControl
    {
        public adminmain()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            generatee_way_bill DE = new generatee_way_bill();
            DE.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoTur v = new VideoTur();
            v.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            help1 h = new help1();
            h.Show();
        }
    }
}
