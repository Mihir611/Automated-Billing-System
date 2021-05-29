using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class PURCHASEDAILYREPORT : Form
    {
        public PURCHASEDAILYREPORT()
        {
            InitializeComponent();
        }
        connect c = new connect();
        SqlCommand cmd = new SqlCommand();
        private void PURCHASEDAILYREPORT_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToString("dd");

            c.cmd.CommandText = "select * from Purchase_Main where Dt1=" + label1.Text;
            crystalReportViewer1.SelectionFormula = "{Purchase_Main.Dt1}=" + label1.Text;
            crystalReportViewer1.RefreshReport();
        }
    }
}
