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
    public partial class stock : UserControl
    {
        public stock()
        {
            InitializeComponent();
          
        }
        public  void restartt()
        {
            button1.Visible = true;
            pictureBox1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            
           
            itemlabl.Text = "0";
            label5.Text = "0";
            label10.Text = "0";
           

        }
        private void search2button_Click(object sender, EventArgs e)
        {
          
            if( comboBox1.Text=="")
            {
                MessageBox.Show("Please SELECT THE Company Name");
            }
          else   if (comboBox1.Text != "")
            {
                search();
            }

        }
        public void search()
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            connect c = new connect();
            DataSet ds = new DataSet();
           
            c.cmd.CommandText = "select Item_Name,Qty from stock where Company_Name='" + comboBox1.Text + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "item");
            if (ds.Tables["item"].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables["item"];
                dataGridView1.Visible = true;
            }
            else
            {
                MessageBox.Show("No Record/Item Found Please Retype the Name Properly");
            }
        }
        //searching#1
        public void search1()
        {
            bool tem = false;
            SqlConnection con= new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
         
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Item_Name,Qty,Company_Name from Stock where Item_Name='" + comboBox2.Text + "'", con);
            SqlDataReader drz = cmd.ExecuteReader();
            while (drz.Read())
            {
                itemlabl.Text = drz.GetString(0);
                decimal i;
                i = decimal.Parse(drz.GetDecimal(1).ToString());
                label10.Text = Convert.ToString(i);
                groupBox1.Visible = true;
                label5.Text = drz.GetString(2);
                tem = true;
            }
            if (tem == false)
            {
                MessageBox.Show("Record DOESNT Exist in the Stock");
            }
            con.Close();
        }
         private void search1button_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please ENTER THE ITEM");
            }
            else if(comboBox3.Text=="")
            {
                MessageBox.Show("Please ENTER THE COMPANY");
            }
            else
            {
                search1();
            }
        }

        private void stock_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            string Sql = "select Company_Name from stock";
            SqlConnection conf = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conf.Open();
            SqlCommand cmd = new SqlCommand(Sql, conf);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }

            string Sqlr = "select Company_Name from stock";
            SqlConnection conff = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conff.Open();
            SqlCommand cmdt = new SqlCommand(Sqlr, conff);
            SqlDataReader DR1 = cmdt.ExecuteReader();
            while (DR1.Read())
            {
                comboBox3.Items.Add(DR1[0]);

            }
            string Sqlrr = "select Item_Name from stock";
            SqlConnection confff = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            confff.Open();
            SqlCommand cmdtt = new SqlCommand(Sqlrr, confff);
            SqlDataReader DR11 = cmdtt.ExecuteReader();
            while (DR11.Read())
            {
                comboBox2.Items.Add(DR11[0]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.stockTableAdapter.Fill(this._HI_TECHDataSet2.Stock);
            DialogResult n = MessageBox.Show("Do you want to check the stock by (NO)companyname or by the name of the (YES)item", "Hi-Tech", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (n == DialogResult.Yes)
            {
                panel1.Visible = true;
                button1.Visible = false;
                pictureBox1.Visible = false;
            }
            if (n == DialogResult.No)
            {
                button1.Visible = false;
                panel2.Visible = true;
                pictureBox1.Visible = false;
            }
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.stockTableAdapter.Fill(this._HI_TECHDataSet2.Stock);
            DialogResult n = MessageBox.Show("Do you want to check the stock by (NO)companyname or by the name of the (YES)item", "Hi-Tech", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (n == DialogResult.Yes)
            {
               panel1.Visible = true;
                 button1.Visible = false;
                pictureBox1.Visible = false;
                panel1.Visible = false;

            }
            if (n == DialogResult.No)
            {
                button1.Visible = false;
                pictureBox1.Visible = false;
                panel2.Visible = true;
                panel1.Visible = false;
            }

        }

    
    }
}
