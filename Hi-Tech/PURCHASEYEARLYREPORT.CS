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
    public partial class PURCHASEYEARLYREPORT : Form
    {
        public PURCHASEYEARLYREPORT()
        {
            InitializeComponent();
        }
        connect c = new connect();
        SqlCommand cmd = new SqlCommand();

        private void PURCHASEYEARLYREPORT_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.cmd.CommandText = "select * from Purchase_Main where Year='" + comboBox1.Text + "'";
            crystalReportViewer1.SelectionFormula = "{Purchase_Main.Year}='" + comboBox1.Text + "'";
            crystalReportViewer1.RefreshReport();
        }
    }
}
