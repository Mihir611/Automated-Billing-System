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
    public partial class salesrep : UserControl
    {
        public salesrep()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SALEDAILYREP dr = new SALEDAILYREP();
            dr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SALEMONTHREPORT uoo = new SALEMONTHREPORT();
            uoo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SALEYEARLYREPORT ido = new SALEYEARLYREPORT();
            ido.Show();
        }
    }
}
