using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace Hi_Tech
{
    public partial class empdetailadd : UserControl
    {
        public empdetailadd()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlConnection cnned;
        SqlConnection cnnede;
        SqlConnection cnnedee;
        SqlConnection cnnedeet;
        public void EMPADDCLEAN()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            textBox8.Text = "";
            label12.Text = "0";
            textBox5.Text = "";
            textBox4.Text = "";

        }
        SqlConnection con;
        
        string ImgLoc = "";
        private void empdetailadd_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            cnned = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            SqlCommand command = new SqlCommand("select phone from  emp_det where phone='" + textBox1.Text + "'", cnned);
            cnned.Open();
            SqlDataReader drcheck = command.ExecuteReader();

            cnnede = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
             SqlCommand commande = new SqlCommand("select alternate_phone from  emp_det where alternate_phone='" + textBox8.Text + "'", cnnede);
            cnnede.Open();
            SqlDataReader drchecke = commande.ExecuteReader();
            cnnedee = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            SqlCommand commandee = new SqlCommand("select empmail from  emp_det where empmail='" + textBox7.Text + "'", cnnedee);
            cnnedee.Open();
            SqlDataReader drcheckee = commandee.ExecuteReader();
            cnnedeet = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            SqlCommand commandeet = new SqlCommand("select emp_name from  emp_det where emp_name='" + textBox2.Text + "'", cnnedeet);
            cnnedeet.Open();
            SqlDataReader drcheckeet = commandeet.ExecuteReader();
            if (textBox2.Text == "")
            {
                MessageBox.Show("PLEASE ENTER THE NAME");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("PLEASE ENTER THE ADDRESS ");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("PLEASE ENTER THE PHONE NUMBER ");

            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("PLEASE ENTER THE ALTERNATIVE PHONE NUMBER ");

            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("PLEASE ENTER THE BASIC SALARY");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("PLEASE ENTER THE EMAIL ADDRESS");
            }
            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("PLEASE insert THE image");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter the Maximum number of CL's Awarded to this employee");
            }

           
          else  if (drcheck.HasRows)
            {
                MessageBox.Show("The phone number already exists ..");
              
                cnned.Close();
            }
            else if (drchecke.HasRows)
            {
                MessageBox.Show("The ALternate phone number already exists ..");

                cnnede.Close();
            }
            else if (drcheckee.HasRows)
            {
                MessageBox.Show("Theemail number already exists ..");

                cnnedee.Close();
            }
            else if (drcheckeet.HasRows)
            {
                MessageBox.Show("The name  already exists ..");

                cnnedeet.Close();
            }

            else
            {
                int a = Convert.ToInt16(label12.Text);
                int b = 18;
                if (a <= b)
                {
                    MessageBox.Show("As the Employee's age is less than 18 u cant insert the details", "Cant insert employee details");
                }
                else
                {
                    //mgm-server           //bgroup3
                    byte[] img = null;
                    FileStream fs = new FileStream(ImgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader cr = new BinaryReader(fs);
                    img = cr.ReadBytes((int)fs.Length);
                    con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO emp_det(emp_name,emp_add,empmail,phone,alternate_phone,dob,doj,gender,age,sal,Designation,Status,data,CL)VALUES(@emp_name,@emp_add,@empmail,@phone,@alternate_phone,@dob,@doj,@gender,@age,@sal,@Designation,@Status,@img,@cl)", con);
                    cmd.Parameters.AddWithValue("@emp_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@emp_add", textBox3.Text);
                    cmd.Parameters.AddWithValue("@empmail", textBox7.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox1.Text);
                    cmd.Parameters.AddWithValue("@alternate_phone", textBox8.Text);
                    cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = Convert.ToDateTime(dateTimePicker1.Text);
                    cmd.Parameters.Add("@doj", SqlDbType.DateTime).Value = Convert.ToDateTime(dateTimePicker2.Text);
                    if (radioButton6.Checked == true)
                        cmd.Parameters.AddWithValue("@gender", radioButton6.Text);
                    else if (radioButton7.Checked == true)
                        cmd.Parameters.AddWithValue("@gender", radioButton7.Text);
                    cmd.Parameters.AddWithValue("@age", label12.Text);
                    cmd.Parameters.AddWithValue("@sal", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Designation", listBox1.SelectedItem);
                    if (radioButton1.Checked == true)
                        cmd.Parameters.AddWithValue("@Status", radioButton1.Text);
                    if (radioButton2.Checked == true)
                        cmd.Parameters.AddWithValue("@Status", radioButton2.Text);
                    cmd.Parameters.AddWithValue("@img", img);
                    check();
                    cmd.Parameters.AddWithValue("@cl", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record(s) inserted successfully.", "Done");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox7.Text = "";
                    textBox1.Text = "";
                    textBox8.Text = "";
                    label12.Text = "0";
                    textBox5.Text = "";
                    textBox4.Text = "";
                    con.Close();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog m = new OpenFileDialog();
                m.Filter = "JPG Files(*.jpg)|*.jpg";
                m.Title = "Select Picture";
                if (m.ShowDialog() == DialogResult.OK)
                {
                    ImgLoc = m.FileName.ToString();
                    pictureBox1.ImageLocation = ImgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            dg();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            String pattern = "^((\\+91-?)|0)?[0-9]{10}$";
            if (Regex.IsMatch(textBox1.Text, pattern))
            {
             
            }
            else
            {
          MessageBox.Show  ( "phone no");
                return;
            }
            label14.Text = textBox1.Text;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox7.Text, pattern))
            {

            }
            else
            {
                MessageBox.Show("please enter valid email address");
                return;
            }
            label13.Text = textBox7.Text;
        }
        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            int age = DateTime.Today.Year - dateTimePicker1.Value.Year;
            label12.Text = age.ToString();
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            String pattern = "^((\\+91-?)|0)?[0-9]{10}$";
            if (Regex.IsMatch(textBox8.Text, pattern))
            {
                
            }
            else
            {
                MessageBox.Show( "phone no");
                return;
            }
            if (textBox8.Text == textBox1.Text)
            {
                MessageBox.Show("Phone number and Alternate Phone number Shouldn't be same ", "Shouldn't be Same");
            }
            label15.Text = textBox8.Text;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("SELECT DESIGNATION");
             
                textBox5.Enabled = false;
            }
            else if (listBox1.SelectedItem != null)
            {

                textBox5.Enabled = true;
            }
        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
              
                textBox5.Enabled = true;
            }
        }
        public void dg()
        {
            SqlConnection conw = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("SELECT empmail,phone,alternate_phone FROM emp_det where emp_name='" + textBox2.Text.Trim() + "'", conw);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmdw))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            conw.Close();
        }
        public void check()
        {
            for (int k = 0; k < dataGridView1.Rows.Count - 1; k++)
            {
                if (label13.Text == dataGridView1.Rows[k].Cells[0].Value)
                {
                    MessageBox.Show("email already exist");
                }
                else if (label14.Text == dataGridView1.Rows[k].Cells[1].Value)
                {
                    MessageBox.Show("Phone No already exist");
                }
                else if (label15.Text == dataGridView1.Rows[k].Cells[2].Value)
                {
                    MessageBox.Show("Alternative Phone No already exist");
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {

                e.Handled = true;
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
