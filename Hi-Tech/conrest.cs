using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class conrest : Form
    {
        public conrest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1 .Text =="")
            {
                MessageBox.Show("Please enter the user name");
            }
            else if(textBox2 .Text =="")
            {
                MessageBox.Show("Please enter the Master password");
            }
            else if(textBox1 .Text =="AdminHI-Tech" && textBox2 .Text =="adminmihir")
            {
                DialogResult m = MessageBox.Show("Do you really want to restore the database??", "RESTORE DTABASE??", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.Yes)
                {
                    MessageBox.Show("Please look for the file named  HI_TECH");
                    Close();
                    rest d = new rest();
                    d.Show();
                }
                if(m==DialogResult.No )
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter the proper username and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            readme h = new readme();
            h.Show();
        }
    }
}
