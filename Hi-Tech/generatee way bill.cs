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
    public partial class generatee_way_bill : Form
    {
        public generatee_way_bill()
        {
            InitializeComponent();
        }

        private void generatee_way_bill_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(label1.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
