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
    public partial class SALEMONTHREPORT : Form
    {
        public SALEMONTHREPORT()
        {
            InitializeComponent();
        }
        connect c = new connect();
        SqlCommand cmd = new SqlCommand();

        private void SALEMONTHREPORT_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.cmd.CommandText = "select * from SalesTest where Month='" + comboBox1.Text + "'";
            crystalReportViewer1.SelectionFormula = "{SalesTest.Month}='" + comboBox1.Text + "'";
            crystalReportViewer1.RefreshReport();
        }
    }
}
