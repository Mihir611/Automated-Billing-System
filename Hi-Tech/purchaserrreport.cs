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
    public partial class purchaserrreport : UserControl
    {
        public purchaserrreport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PURCHASEDAILYREPORT ER = new PURCHASEDAILYREPORT();
            ER.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PURCHASEMONTHLYREPORT FRT =new PURCHASEMONTHLYREPORT();
            FRT.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PURCHASEYEARLYREPORT YTU = new PURCHASEYEARLYREPORT();
            YTU.Show();
        }
    }
}
