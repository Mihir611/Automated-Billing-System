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
    public partial class SALESBILLOPENER : UserControl
    {
        public SALESBILLOPENER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ispoeen = false;
            foreach (Form b in Application.OpenForms)
            {
                if (b.Text == "SALESBILLADD")
                {
                    ispoeen = true;
                    b.BringToFront();
                    break;
                }
            }
            if (ispoeen == false)
            {
                SALESBILLADD SS = new SALESBILLADD();
                SS.Show();
            }
        }
    }
}
