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
    public partial class itemmasterdel : UserControl
    {
        SqlDataAdapter adp = new SqlDataAdapter();
        public itemmasterdel()
        {
            InitializeComponent();
        }
        public void delcleaner()
        {
            
            label6.Text = "";
            label8.Text = "";
            label4.Text = "";
            label6.Visible = false;
            label8.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label3.Visible = false;
            button2.Visible = false;
            label2.Visible = false;
           comboBox1.Visible = true;
            label1.Visible = true;

        }
        private void itemmasterdel_Load(object sender, EventArgs e)
        {
            string Sql = "select  Item_name from Item";
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool temc = false;
            SqlConnection conc = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conc.Open();
            SqlCommand cmdc = new SqlCommand("SELECT Item_name,Vendor_name FROM Item WHERE Item_name='" +comboBox1.Text + "'", conc);
            SqlDataReader drzc = cmdc.ExecuteReader();
            while (drzc.Read())
            {
                label1.Visible = false;
                comboBox1.Visible = false;
                label2.Visible = true;
                label2.Text = "Item Found";
                label5.Visible = true;
                label6.Visible = true;
                label6.Text = drzc.GetString(0);
                label7.Visible = true;
                label8.Visible = true;
              
                label8.Text = drzc.GetString(1);
                button2.Visible = true;
                temc = true;
            }
            if (temc == false)
            {
                label2.Visible = true;
                label2.Text = "Item Not Found";
            }
            conc.Close();
            rev();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult M = MessageBox.Show("ARE U SURE U WANT TO DELETE THE ITEM?", "DELETE ITEM", MessageBoxButtons.OKCancel);
            if (M == DialogResult.OK)
            {
                SqlConnection cong = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                cong.Open();
                SqlCommand cmdg = new SqlCommand("DELETE FROM Item WHERE Item_Name='" + comboBox1.Text + "'", cong);
                MessageBox.Show("Item will be deleted form stock also..");
                MessageBox.Show("Item deleted successfully");
                cmdg.ExecuteNonQuery();
                cong.Close();
                delst();
            }
            if (M == DialogResult.Cancel)
            {
                MessageBox.Show("Item not deleted because user clicked cancel");
            }
        }
        //delete from stock
        public void delst()
        {
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmde = new SqlCommand("delete  from Stock where Item_Name='" + comboBox1.Text + "'", con);
            cmde.ExecuteNonQuery();
            con.Close();
        }

        //retriving from stock
        public void rev()
        {
            bool tem = false;
            SqlConnection conw = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("SELECT Qty FROM Stock WHERE Item_name='" + comboBox1.Text + "'", conw);
            SqlDataReader drze = cmdw.ExecuteReader();
            while (drze.Read())
            {
                label3.Visible = true;
                label4.Visible = true;
                decimal i;
                i = decimal.Parse(drze.GetDecimal(0).ToString());
                label4.Text = Convert.ToString(i);
                tem = true;
            }
            if (tem == false)
            {
                label2.Visible = true;
                label2.Text = "Item Not Found in Stock";
                button2.Visible = false;
            }
            conw.Close();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
          
            
        }
    }
}
