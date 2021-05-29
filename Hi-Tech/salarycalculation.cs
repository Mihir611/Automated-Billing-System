using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Hi_Tech
{
    public partial class salarycalculation : UserControl
    {
        public salarycalculation()
        {
            InitializeComponent();
        }
        double salary=0, cut=0, subcut=0, totalsalary=0,salary1=0;

        private void button1_Click(object sender, EventArgs e)
        {
            //checking for record exist 
            if(con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Salary WHERE ([emp_id] = @id)", con);
            check_User_Name.Parameters.AddWithValue("@id",textBox8.Text);
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
                label16.Text = "Dear Admin you have given the salary to this employee";
                button2.Visible = false;
            }
            else
            {
                if (textBox6.Text != "0")
                {
                    cut = (Convert.ToInt16(maskedTextBox1.Text) * 0.50) / 100;
                    subcut = cut * Convert.ToInt16(textBox6.Text);
                    salary = Convert.ToInt16(maskedTextBox1.Text) - subcut;
                }
                int clg = Convert.ToInt16(label21.Text);
                int clt = Convert.ToInt16(textBox7.Text);
                if (clt > clg)
                {
                    totalsalary = salary - 250;
                }
                else
                {
                    totalsalary = salary;
                }
                con.Close();
            }
            salary11();
            button2.Enabled = true; 
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label21 .Text == "0")
            {
                MessageBox.Show("This Employee Cant take anymore CL");
            }
            else
            {
                if(con.State !=ConnectionState.Closed)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Salary(salary,emp_id,Month,Reason,Advance_Taken)VALUES('" + this.label13.Text + "','" + this.textBox8.Text + "','" + this.textBox5.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted Successfully");
                con.Close();
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand sqlcommand = new SqlCommand("Update emp_det set CL=CL-@cl where emp_id=@id", con);
                sqlcommand.Parameters.AddWithValue("@cl", SqlDbType.NVarChar).Value = textBox7.Text;
                sqlcommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = textBox8.Text;
                sqlcommand.ExecuteNonQuery();
                con.Close();
            }
        }

        string thsmonth;
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

        private void salarycalculation_Load(object sender, EventArgs e)
        {
            calmon();
            textBox5.Text = thsmonth;
            string Sql = "select emp_name from emp_det";
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);
            }
        }
        //calculating Days
        public void das()
        {
            bool tema = false;
            con.Open();
            SqlCommand cmda = new SqlCommand("SELECT Days_Present,Days_Absent FROM Attendance WHERE emp_id='" + textBox8.Text.Trim() + "'", con);
            SqlDataReader dra = cmda.ExecuteReader();
            while (dra.Read())
            {
                textBox4.Text = dra.GetString(0);
                textBox6.Text = dra.GetString(1);
                tema = true;
            }
            if(tema ==false )
            {
                MessageBox.Show("Dear user the employee has joined the company this month please let him work for a month and then u can give him the salary..");
            }
            con.Close();
        }

        //calculating salsry
        public void salary11()
        {
                string g;
                double adv = Convert.ToDouble(textBox3.Text);
                double tot = totalsalary + adv;
                label13.Text = tot.ToString();
                g = tot.ToString();
                label14.Text = "Dear Admin U have given " + g + "Rs as the salary for this Employee";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Salary WHERE ([emp_id] = @id)", con);
            check_User_Name.Parameters.AddWithValue("@id", textBox8.Text);
            SqlDataReader reader = check_User_Name.ExecuteReader();
            if (reader.HasRows)
            {
                label16.Text = "Dear Admin you have given the salary to this employee";
                button2.Visible = false;
            }
            else
            {
                if (textBox7.Text == "0")
                {
                    if (textBox6.Text == "0")
                    {
                        if (textBox3.Text == "0")
                        {
                            string gh;
                            label13.Text = maskedTextBox1.Text;
                            gh = label13.Text;
                            label14.Text = "Dear Admin U have given " + gh + "Rs as the salary for this Employee";
                            button2.Enabled = true;
                        }
                    }
                }
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            bool tem = false;
            decimal t, t1;
            Int32 h;
            if(con.State !=ConnectionState.Closed )
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT emp_id,Designation,sal,CL FROM emp_det WHERE emp_name='" + comboBox1.Text.Trim() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                h = Int32.Parse(dr.GetInt32(0).ToString());
                textBox8.Text = Convert.ToString(h);
                t = decimal.Parse(dr.GetDecimal(2).ToString());
                maskedTextBox1.Text = Convert.ToString(t);
                maskedTextBox3.Text = dr.GetString(1);
                t1 = decimal.Parse(dr.GetDecimal(3).ToString());
                label21.Text = Convert.ToString(t1);
                tem = true;
                MessageBox.Show("Records found");
            }
            if (tem == false)
                MessageBox.Show("Record not found");
            con.Close();
            das();
            chec();
            imgret();
            checkadv();
        }

        //checking for 0
        public void chec()
        {
            if(textBox6 .Text =="0")
            {
                button3.Visible = true;
                button1.Visible = false;
            }
            else
            {
                button3.Visible = false;
                button1.Visible = true;
            }
        }

        //calculate Month
        public void calmon()
        {
            DateTime dt = DateTime.Today;
            thsmonth = dt.ToString("MMMM");
        }

        //retriving images
        public void imgret()
        {
            try
            {
                SqlCommand cmdf = new SqlCommand("select data from emp_det where emp_id='" + textBox8.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmdf);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["data"]);
                    pictureBox1.Image = new Bitmap(ms);
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        //checking for advance
        public void checkadv()
        {
            con.Open();
            bool temp = true;
            SqlCommand cmdz = new SqlCommand("SELECT Advance_Taken FROM Salary WHERE emp_id='" + textBox8.Text + "'", con);
            SqlDataReader drz = cmdz.ExecuteReader();
            while (drz.Read())
            {
                label24.Text = drz.GetString(0);
                temp = true;
            }
            if (temp == false)
                MessageBox.Show("Record not found");
            con.Close();
        }
    }
}
