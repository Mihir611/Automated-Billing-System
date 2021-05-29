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
    public partial class editcompany : UserControl
    {
        public editcompany()
        {
            InitializeComponent();
        }
        OpenFileDialog h;
        String fileName = "";

        public void clear() {
            textBox1.Clear();
        }
        private void editcompany_Load(object sender, EventArgs e)
        {
           
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("ENTER THE NAME OF THE COMPANY");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("ENTER THE ADDRESS");
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("ENTER THE COUNTRY");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("ENTER THE STATE");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("ENTER THE USERNAME(ADMIN)");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("ENTER THE GSTIN");
            }
            else if (textBox12.Text == "")
            {
                MessageBox.Show("ENTER THE EMAIL-ID");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("ENTER THE TEL N0");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Company_det(Company_Name,Address,Country,State,User_Name,GSTin,FY_Begining_From,Books_Commencing_From,EMail,Tell_No)VALUES('" + this.textBox1.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + this.textBox10.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + Convert.ToDateTime(dateTimePicker2.Text) + "','" + this.textBox12.Text + "','" + this.textBox11.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            h = new OpenFileDialog();
            h.Filter = "Images(.jpg,.png)|*.jpg";
            if (h.ShowDialog() == DialogResult.OK)
            {
                fileName = h.FileName;
            }
            /* pictureBox1.Image = Image.FromFile(fileName);*/
            pictureBox1.BackgroundImage = Image.FromFile(fileName);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button3.Visible = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox7.Text = textBox1.Text;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (textBox12.Text!="")
            {
                if (Regex.IsMatch(textBox12.Text, pattern))
                {

                }
                else
                {

                    MessageBox.Show("PLEASE ENTER THE VALID EMAIL");
                    return;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
