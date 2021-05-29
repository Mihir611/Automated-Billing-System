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
    public partial class SALEDAILYREP : Form
    {
        public SALEDAILYREP()
        {
            InitializeComponent();
        }
        connect c = new connect();
        SqlCommand cmd = new SqlCommand();

        private void SALEDAILYREP_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToString("dd");

            c.cmd.CommandText = "select * from SalesTest where DT1=" + label1.Text;
            crystalReportViewer1.SelectionFormula = "{SalesTest.DT1}=" + label1.Text;
            crystalReportViewer1.RefreshReport();

        }
    }
}
