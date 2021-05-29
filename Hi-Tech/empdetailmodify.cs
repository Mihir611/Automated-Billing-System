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
    public partial class empdetailmodify : UserControl
    {
        public empdetailmodify()
        {
            InitializeComponent();
        }
       
        String h;
        public void fr()
        {
            textBox3.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            textBox8.Text = "";
            groupBox4.Visible = false;
            button3.Visible = false;//modify
            pictureBox1.Visible = false;
            button4.Visible = true;//search
            comboBox1.Visible = true;
            label2.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bool tem = false;
            decimal t, h;
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select emp_name,emp_add,empmail,phone,alternate_phone from emp_det where emp_name='" + comboBox1.Text.Trim() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                maskedTextBox1.Text = dr.GetString(0);
                textBox3.Text = dr.GetString(1);
                textBox7.Text = dr.GetString(2);
                t = decimal.Parse(dr.GetDecimal(3).ToString());
                textBox1.Text = Convert.ToString(t);
                h = decimal.Parse(dr.GetDecimal(4).ToString());
                textBox8.Text = Convert.ToString(h);
                tem = true;
                MessageBox.Show("Records found");
                button3.Visible = true;
                pictureBox1.Visible = true;
                button4.Visible = false;
                comboBox1.Visible = false;
                label2.Visible = false;
            }
            if (tem == false)
            {
                MessageBox.Show("Record not found");
                con.Close();
                button3.Visible = false;
                pictureBox1.Visible = false;
                button4.Visible = true;
                comboBox1.Visible = true;
                label2.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            button3.Visible = false;
            pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("select status");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("PLEASE ENTER ADDRESS");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("PLEASE ENTER EMAIL");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("PLEASE ENTER PHONE");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("PLEASE ENTER ALTERNATE PHONE");
            }
         
            else
            {


                SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("update emp_det set emp_add='" + this.textBox3.Text + "',empmail='" + this.textBox7.Text.Trim() + "',phone='" + this.textBox1.Text + "',alternate_phone='" + this.textBox8.Text + "',Status='" + h + "'where emp_name='" + comboBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                MessageBox.Show("Record Updated");
                label2.Visible = true;
              
               comboBox1.Visible = true;
                button4.Visible = true;
                button3.Visible = false;
                groupBox4.Visible = false;
                con.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            h = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            h = radioButton2.Text;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (textBox7.Text != "")
            {
                if (Regex.IsMatch(textBox7.Text, pattern))
                {

                }
                else
                {
                    MessageBox.Show("PLEASE ENTER THE VALID EMAIL");
                    return;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            button3.Visible = false;
            pictureBox1.Visible = false;
        }

        private void empdetailmodify_Load(object sender, EventArgs e)
        {
            string Sql = "select emp_name from emp_det";//emp_det where emp_name
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
