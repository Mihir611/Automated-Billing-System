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
    public partial class Itemmasteradd : UserControl
    {
        SqlCommand cmd;
        SqlConnection cnn;
        public Itemmasteradd()
        {
            InitializeComponent();
        }
        public void clearsec()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox10.Text = "";
            textBox4.Text = "";
            textBox11.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton2.Checked = false;
           radioButton4.Checked = false;
        }
        public void cleer()
        {
            textBox1.Text = "";
            textBox10.Text = "";
            textBox4.Text = "";
            textBox11.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label6.Text = "0";
            label5.Text = "0";

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter the Name of the Item");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Enter the Model Number");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter the Name of the Default Vendor");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("Enter the Name of the Manufacturer");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter the Unit");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter the Correct Tax Catogory");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Enter the HSN Code");
            }
             else
            {
                cnn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
               
                SqlCommand command = new SqlCommand("select Item_Name from Item where Item_Name='" + textBox1.Text + "'", cnn);
                cnn.Open();
                SqlDataReader drcheck = command.ExecuteReader();
                if (drcheck.HasRows)
                {
                    MessageBox.Show("The Name already exists ..");
                    clearsec();
                    cnn.Close();
                }
                else
                {
                    cnn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                    cnn.Open();
                    cmd = new SqlCommand("INSERT INTO Item(Item_name,Vendor_name,Manufacturer,Model_no,Item_group,Tax_cat,Hsn_code,Unit,Stock,SalPricInc_Tax)VALUES(@Item_name,@Vendor_name,@Manufacturer,@Model_no,@Item_group,@Tax_cat,@Hsn_code,@Unit,@Stock,@SalPricInc_Tax)", cnn);
                    cmd.Parameters.AddWithValue("@Item_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Vendor_name", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Manufacturer", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Model_no", textBox10.Text);
                    if (radioButton1.Checked == true)
                        cmd.Parameters.AddWithValue("@Item_group", radioButton1.Text);
                    else if (radioButton2.Checked == true)
                        cmd.Parameters.AddWithValue("@Item_group", radioButton2.Text);
                    cmd.Parameters.AddWithValue("@Tax_cat", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Hsn_code", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Unit", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Stock", label6.Text);
                    if (radioButton3.Checked == true)
                        cmd.Parameters.AddWithValue("@SalPricInc_Tax", radioButton3.Text);
                    else if (radioButton4.Checked == true)
                        cmd.Parameters.AddWithValue("@SalPricInc_Tax", radioButton4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Records Inserted Successfully");
                    cnn.Close();
                    insstock();
                }
            }
        }
        public void insstock()
        {
            SqlConnection con987 = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con987.Open();
            SqlCommand cmd987 = new SqlCommand("Insert into Stock (Item_Name,HSN_Code,Qty,Re_Order,Company_Name)values('" + this.textBox1.Text + "','" + this.textBox6.Text + "','" + label6.Text + "','" + textBox7.Text + "','" + textBox4.Text + "')", con987);
            cmd987.ExecuteNonQuery();
            MessageBox.Show("Records Inserted..");
            con987.Close();
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter the Name of the Default Vendor");
            }
            else
            {
                bool temp = false;
                SqlConnection cone = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                cone.Open();
                SqlCommand command = new SqlCommand("select Name from Sup_det where Name='" + textBox4.Text + "'", cone);
                SqlDataReader drn = command.ExecuteReader();
                while (drn.Read())
                {
                    label5.Text = drn.GetString(0);
                    temp = true;
                    button1.Enabled = true;
                }
                if (temp == false)
                {
                    MessageBox.Show("Vendor not found please Insert this Account info to the Account Master");
                    DialogResult j = MessageBox.Show("Do you want to add this Vendor to the list??", "Add to List", MessageBoxButtons.YesNo);
                    if (j == DialogResult.Yes)
                    {
                       acmodifyy ad = new acmodifyy();
                        ad.Show();
                    }
                    if (j == DialogResult.No)
                    {
                        MessageBox.Show("you are not allowed to insert this record");
                        //button1.Enabled = false;
                        //MessageBox.Show("Exiting workspace");
                       // Close();
                    }
                }
                cone.Close();
            }
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void textBox5_Leave_1(object sender, EventArgs e)
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

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "Nos")
            {
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please enter correct unit i.e., Nos in the box");
                button1.Enabled = false;
            }
        }

        private void Itemmasteradd_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            clearsec();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }
    }
}
