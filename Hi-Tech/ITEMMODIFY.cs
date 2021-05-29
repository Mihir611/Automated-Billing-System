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
    public partial class ITEMMODIFY : UserControl
    {
        public ITEMMODIFY()
        {
            InitializeComponent();
        }
        public void cleane()
        {
            groupBox1.Visible = false;
            button4.Visible = false;
           comboBox1.Visible = true;
          
            label7.Visible = true;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void ITEMMODIFY_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            button4.Visible = false;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            bool tem = false;
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Item_Name,Vendor_Name,Model_no,Tax_cat,Hsn_code,Unit from Item where Item_name='" + comboBox1.Text.Trim() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            Int32 g;
            decimal t, h, i, j;

            while (dr.Read())
            {
                maskedTextBox1.Text = dr.GetString(0);
                textBox4.Text = dr.GetString(1);
                textBox10.Text = dr.GetString(2);
                t = decimal.Parse(dr.GetDecimal(3).ToString());
                textBox5.Text = Convert.ToString(t);
                g = Int32.Parse(dr.GetInt32(4).ToString());
                textBox6.Text = Convert.ToString(g);
                textBox3.Text = dr.GetString(5);
                tem = true;
                button4.Visible = true;
                //  MessageBox.Show("Records found");
            }
            if (tem == false)
                MessageBox.Show("Record not found");
            con.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            label7.Visible = false;
            comboBox1.Visible = false;
            button3.Visible = false;
            textBox2.Text = maskedTextBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Item set Vendor_Name='" + this.textBox4.Text + "',Model_no='" + this.textBox10.Text.Trim() + "',Tax_cat='" + this.textBox5.Text + "',Hsn_code='" + this.textBox6.Text + "',Unit='" + this.textBox3.Text + "'where Item_Name='" + comboBox1.Text.Trim() + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            con.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
           
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "5" || textBox5.Text == "12" || textBox5.Text == "18" || textBox5.Text == "28")
            {
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please enter the correct tax catagory \n The accepted Tax Catagories are 5%\n12%\n18%\n28%");
                button1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
