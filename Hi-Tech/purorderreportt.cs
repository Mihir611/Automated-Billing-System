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
    public partial class purorderreportt : Form
    {
        public purorderreportt()
        {
            InitializeComponent();
        }
        connect c = new connect();
        SqlCommand cmd = new SqlCommand();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.cmd.CommandText = "select * from Place_Order_Main where Month='" + comboBox1.Text + "'";
            crystalReportViewer1.SelectionFormula = "{Place_Order_Main.Month}='" + comboBox1.Text + "'";
            crystalReportViewer1.RefreshReport();
        }
    }
}
