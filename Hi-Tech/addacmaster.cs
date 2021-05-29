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
    public partial class addacmaster : UserControl
    {
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
        public addacmaster()
        {
            InitializeComponent();
        }
        public void ADCLEAR()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "0";
            textBox14.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            SqlCommand command = new SqlCommand("select Email from Sup_det where Email='" + textBox7.Text + "'", con);
            con.Open();
            SqlDataReader drcheck = command.ExecuteReader();
            if (drcheck.HasRows)
            {
                MessageBox.Show("The Email already exists ..");
                // clearsec();
                con.Close();
            }
            SqlCommand commande = new SqlCommand("select Mobile_No from Sup_det where Email='" + textBox10.Text + "'", con);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlDataReader drchecke = commande.ExecuteReader();
            if (drchecke.HasRows)
            {
                MessageBox.Show("The Mobile Number already exists ..");
                // clearsec();
                con.Close();
            }
            SqlCommand commandee = new SqlCommand("select Tel_No from Sup_det where Email='" + textBox7.Text + "'", con);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlDataReader drcheckee = commandee.ExecuteReader();
            if (drcheckee.HasRows)
            {
                MessageBox.Show("The Telphone Number already exists ..");
                // clearsec();
                con.Close();
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please insert the Name of the vendor");
                }
                else if (textBox14.Text == "")
                {
                    MessageBox.Show("Please enter the Station name");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Please Enter the GSTin of the Vendor");
                }

                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Please enter the Vendor's Address");
                }

                else if (comboBox2.Text  == "")
                {
                    MessageBox.Show("Please select the State/Pos of the Vendor");
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Please enter the Email-ID");
                }
                else if (textBox10.Text == "")
                {
                    MessageBox.Show("Please Enter the Mobile number");
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("Please enter the Mobile Number");
                }
                else if (textBox12.Text == "")
                {
                    MessageBox.Show("Please enter the Contact Persons Name");
                }
                else if (textBox15.Text == "")
                {
                    MessageBox.Show("Please enter the Pin code");
                }
                else if (textBox16.Text == "")
                {
                    MessageBox.Show("Please enter the Fax Number");
                }
                else
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Sup_det(Name,Address,Country,State,Email,Mobile_no,Tel_no,Contact_Per,Pin_code,Fax,Acgroup,OpBal,Bal,Station,Gstin,Amount,Qty)VALUES(@Name,@Address,@Country,@State,@Email,@Mobile_no,@Tel_no,@Contact_Per,@Pin_code,@Fax,@Acgroup,@OpBal,@Bal,@Station,@Gstin,@Amount,@Qty)", con);
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Country", textBox3.Text);
                    cmd.Parameters.AddWithValue("@State", comboBox2.Text .ToString());
                    cmd.Parameters.AddWithValue("@Email", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Mobile_no", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Tel_no", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Contact_Per", textBox12.Text);
                    cmd.Parameters.AddWithValue("@Pin_code", textBox15.Text);
                    cmd.Parameters.AddWithValue("@Fax", textBox16.Text);
                    if (radioButton1.Checked == true)
                        cmd.Parameters.AddWithValue("@Acgroup", radioButton1.Text);
                    else if (radioButton2.Checked == true)
                        cmd.Parameters.AddWithValue("@Acgroup", radioButton2.Text);
                    cmd.Parameters.AddWithValue("@OpBal", label4.Text);
                    cmd.Parameters.AddWithValue("@Bal", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Station", textBox14.Text);
                    cmd.Parameters.AddWithValue("@Gstin", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Amount", label14.Text);
                    cmd.Parameters.AddWithValue("@Qty", label19.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "0";
                    textBox14.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";
                }
              
            
                button1.Enabled = true;
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
                button1.Enabled = true;
                MessageBox.Show( "PLEASE ENTER THE VALID EMAIL");
                return;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            String pattern = "^((\\+91-?)|0)?[0-9]{10}$";
            if (textBox10.Text != "")
            {
                if (textBox10.Text.Length != 10)
                {
                    MessageBox.Show("ENTER 10 NUMBERS");
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            String pattern = "^((\\+91-?)|0)?[0-9]{10}$";
            if (textBox11.Text != "")
            {
                if (textBox11.Text.Length != 10)
                {
                    MessageBox.Show("ENTER 10 NUMBERS");
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit (e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
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

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void addacmaster_Load(object sender, EventArgs e)
        {

        }
    }
}

