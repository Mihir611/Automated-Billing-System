using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Hi_Tech
{
    public partial class ACMODIFY : UserControl
    {
        public ACMODIFY()
        {
            InitializeComponent();
        }
        public void clenn()
        {
            groupBox1.Visible = false;
            button4.Visible = false;
            label1.Visible = true;
            textBox1.Text = "";
            comboBox1.Visible = true;
            button3.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool tem = false;
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name,Address,Email,Mobile_no,Tel_no,Contact_per,Pin_code,Fax,Gstin from Sup_det where Name='" + comboBox1.Text.Trim() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            decimal g, h, i, j;
            while (dr.Read())
            {
                textBox1.Text = dr.GetString(0);
                textBox5.Text = dr.GetString(1);
                textBox7.Text = dr.GetString(2);
                g = decimal.Parse(dr.GetDecimal(3).ToString());
                textBox10.Text = Convert.ToString(g);
                h = decimal.Parse(dr.GetDecimal(4).ToString());
                textBox11.Text = Convert.ToString(h);
                textBox12.Text = dr.GetString(5);
                i = Int32.Parse(dr.GetInt32(6).ToString());
                textBox15.Text = Convert.ToString(i);
                j = decimal.Parse(dr.GetDecimal(7).ToString());
                textBox16.Text = Convert.ToString(j);
                textBox6.Text = dr.GetString(8);
                tem = true;
                button4.Visible = true;
                comboBox1.Text = "";
            }
            if (tem == false)
            {
                MessageBox.Show("Record not found");
                button4.Visible = false;
            }
            con.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            label1.Visible = false;
            comboBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox2.Text = textBox1.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sup_det set name='" + this.textBox1.Text.Trim() + "',Address='" + this.textBox5.Text + "',Email='" + this.textBox7.Text.Trim() + "',Mobile_no='" + this.textBox10.Text + "',Tel_no='" + this.textBox11.Text + "',Contact_per='" + this.textBox12.Text + "',Pin_code='" + this.textBox15.Text + "',Fax='" + this.textBox16.Text + "',Gstin='" + this.textBox6.Text + "'where Name='" + comboBox1.Text.Trim() + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            groupBox1.Visible = false;
            label1.Visible = true;
            button3.Visible = true;
            comboBox1.Visible = true;
            con.Close();
        }

        private void ACMODIFY_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            button4.Visible = false;
            string Sql = "select name from Sup_det";
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space))|| !(char.IsDigit(e.KeyChar)))
            {

                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                 e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                 e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox7.Text, pattern))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
               
                MessageBox.Show("PLEASE ENTER THE VALID EMAIL");
                return;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }
    }
}
