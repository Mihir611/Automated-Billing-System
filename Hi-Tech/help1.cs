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
    public partial class help1 : Form
    {
        public help1()
        {
            InitializeComponent();
        }

        private void help1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("F:/mihir/My Project Worh help Forms/Help.html");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
