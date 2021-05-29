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
    public partial class supinlist : UserControl
    {
        public supinlist()
        {
            InitializeComponent();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            search();
            search1();
            dataGridView1.Visible = true;
            SqlDataAdapter adp = new SqlDataAdapter();
            connect c = new connect();
            DataSet ds = new DataSet();
            c.cmd.CommandText = "SELECT Sl_No,ITem_Name,Manufacturer,Model_No,HSN_Code,Qty,Price,SGST,CGST,Amount FROM purchase WHERE Vch_No='" + comboBox1.Text + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "item");
            if (ds.Tables["item"].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables["item"];
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("No Record/Item Found Please Retype the Name Properly");
            }
            c.cnn.Close();
        }

        public void search()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmde = new SqlCommand("select Narration,Discount FROM Purchase WHERE Vch_No='" + comboBox1.Text + "'", con);
            SqlDataReader dre = cmde.ExecuteReader();
            while (dre.Read())
            {
                textBox4.Text = dre.GetString(0);
                textBox3.Text = comboBox1.Text;
                decimal iiiu;
                iiiu = decimal.Parse(dre.GetDecimal(1).ToString ());
                textBox6.Text = Convert.ToString(iiiu);
            }
            con.Close();
        }
        public void search1()
        {
            SqlConnection con1=new SqlConnection (@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select GT,Supplier_Name from Purchase_Main where Vch_No='" + comboBox1.Text + "'", con1);
            SqlDataReader drt = cmd1.ExecuteReader();
            while (drt.Read())
            {
                decimal iiiud;
                iiiud = decimal.Parse(drt.GetDecimal(0).ToString());
                label7.Text = Convert.ToString(iiiud);
                textBox5.Text = drt.GetString(1);
            }
            con1.Close();
        }

        private void supinlist_Load(object sender, EventArgs e)
        {
            string Sql = "select  Vch_No from purchase";
            SqlConnection con1 = new SqlConnection(@"Data Source = MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            con1.Open();
            SqlCommand cmd = new SqlCommand(Sql, con1);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
        }
    }
}

