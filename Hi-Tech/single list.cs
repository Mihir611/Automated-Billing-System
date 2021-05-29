using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hi_Tech
{
    public partial class single_list : UserControl
    {
        public single_list()
        {
            InitializeComponent();
        }
        public void CLEANV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
          
            textBox2.Text = "";
            label5.Text = "0";
            textBox3.Text = "";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label7.Text = "0";
        }
     
        private void button1_Click_1(object sender, EventArgs e)
        {
            search();
            search1();
            SqlDataAdapter adp = new SqlDataAdapter();
            connect c = new connect();
            DataSet ds = new DataSet();
            c.cmd.CommandText = "SELECT Item_Name,Model_No,Qty,Price,Amount FROM SalesTest WHERE Vch_No='" + comboBox1.Text + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "item");
            if (ds.Tables["item"].Rows.Count > 0)
            {
                label5.Text= comboBox1.Text;
                dataGridView1.DataSource = ds.Tables["item"];
                dataGridView1.Visible = true;
            }
            else
            {
                MessageBox.Show("No Record/Item Found Please Retype the Name Properly");
            }
        }
        public void search()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmde = new SqlCommand("select Payment_Typ,Discount,SGST,CGST FROM SalesTest WHERE Vch_No='" + comboBox1.Text + "'", con);
            SqlDataReader dre = cmde.ExecuteReader();
            while (dre.Read())
            {
                textBox2.Text = dre.GetString(0);
                decimal iiiu,LOL,WOL;
                iiiu = decimal.Parse(dre.GetDecimal(1).ToString());
                label2.Text = Convert.ToString(iiiu);
                LOL = decimal.Parse(dre.GetDecimal(2).ToString());
                label3.Text = Convert.ToString(LOL);
                WOL = decimal.Parse(dre.GetDecimal(3).ToString());
                label4.Text = Convert.ToString(WOL);

            }
            con.Close();
        }
        public void search1()
        {
            SqlConnection con11 = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con11.Open();
            SqlCommand cmde11 = new SqlCommand("select Cust_Name,Grand_Total FROM SalesTest1 WHERE Vch_No='" + comboBox1.Text + "'", con11);
            SqlDataReader dre11 = cmde11.ExecuteReader();
            while (dre11.Read())
            {
                textBox3.Text = dre11.GetString(0);
                decimal iiiuu;
                iiiuu = decimal.Parse(dre11.GetDecimal(1).ToString());
                label7.Text = Convert.ToString(iiiuu);
               }
            con11.Close();
        }

        private void single_list_Load(object sender, EventArgs e)
        {
            string Sql = "select Vch_No from SalesTest1";
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
        }
    }
}

