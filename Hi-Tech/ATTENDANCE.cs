using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class ATTENDANCE : Form
    {
        public ATTENDANCE()
        {
            InitializeComponent();
        }
        SqlDataAdapter adp = new SqlDataAdapter();
        connect c = new connect();
        string thsmonth, thsyear;
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now.AddMonths(-1);
            int y = Convert.ToInt16(dt.Year);
            int m = Convert.ToInt16(dt.Month);
            int totdays = Convert.ToInt16(DateTime.DaysInMonth(y, m));
            textBox4.Text = Convert.ToString(totdays);
            string g;
            try
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmdf = new SqlCommand("select emp_name,empmail,data from emp_det where emp_id='" + comboBox1.Text + "'", con);
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
            bool tem = false;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmde = new SqlCommand("select emp_name,empmail,Status,CL from emp_det where emp_id='" + comboBox1.Text + "'", con);
            SqlDataReader dr = cmde.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr.GetString(0);
                g = Convert.ToString(textBox1.Text);
                textBox2.Text = dr.GetString(1);
                label25.Text = dr.GetString(2);
                decimal  cl;
                cl = decimal.Parse(dr.GetDecimal (3).ToString());
                label18.Text = Convert.ToString(cl);
                panel1.Visible = true;
                label4.Text = g;
                tem = true;
            }
            if (tem == false)
            {
                MessageBox.Show("NoRecord(s) Found");
                con.Close();
            }
            else
            {
                panel1.Visible = false;
                DialogResult n = MessageBox.Show("All Credentials OK????", "Check", MessageBoxButtons.OKCancel);
                if (n == DialogResult.OK)
                {
                    panel1.Visible = true;
                    display();
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    comboBox1.Visible = false;
                    button3.Visible = false;
                    button1.Visible = true;
                    label5.Visible = false;
                    label2.Visible = false;
                    label1.Visible = false;
                    label13.Text = textBox2.Text;
                    label11.Text = comboBox1.Text;
                }
                if (n == DialogResult.Cancel)
                {
                    label7.Text = "Please Re-Enter the Correct Employee-ID";
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    comboBox1.Visible = true;
                    button3.Visible = true;
                    panel1.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            bool tem = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Month,Year from Attendance where emp_id='" + label11.Text + "'", con);
            SqlDataReader drz = cmd.ExecuteReader();
            while (drz.Read())
            {
                textBox9.Text = drz.GetString(0);
                textBox10.Text = drz.GetString(1);
                if (thsmonth == textBox9.Text)
                {
                    MessageBox.Show("Dear User you Have Already inserted the Attendance");
                }
                else if (thsyear == textBox10.Text)
                {
                    MessageBox.Show("Dear User you Have Already inserted the Attendance");
                }
                tem = true;
            }
            if (tem == false)
            {
                if (label25.Text == "In-Active")
                {
                    MessageBox.Show("you cannot give the attendance to this employee because he has already left the company");
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    comboBox1.Visible = true;
                    button3.Visible = true;
                    panel1.Visible = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                 
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("please enter the number of day's worked");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("please enteer the number of day's the employee is absent");
                }
                else
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmdc = new SqlCommand(@"Insert into Attendance (Month,Year,Days_Present,Days_Absent,emp_id,DOI)VALUES('" + this.textBox7.Text.Trim() + "','" + this.textBox8.Text.Trim() + "','" + this.textBox5.Text.Trim() + "','" + this.textBox6.Text.Trim() + "','" + this.label11.Text.Trim() + "','" + DateTime.Now.Month + "')", con);
                    cmdc.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Records Inserted");
                }
            }
            panel1.Visible = false;
            label1.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = "";
            label2.Visible = true;
            textBox2.Visible = true;
            textBox2.Text = "";
            label5.Visible = true;
            comboBox1.Visible = true;
            comboBox1.Text = "";
            button3.Visible = true;
        }

     
        private void textBox6_Leave(object sender, EventArgs e)
        {
            int day = Convert.ToInt16(textBox5.Text) - Convert.ToInt16(textBox6.Text);
            label22.Text = day.ToString();
        }

        private void ATTENDANCE_Load(object sender, EventArgs e)
        {
            calmon();
            textBox7.Text = thsmonth.ToString();
            calyear();
            textBox8.Text = thsyear.ToString();
            string Sql = "select emp_id from emp_det";// emp_det where emp_id
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
        }
        //Calculating Month
        public void calmon()
        {
            DateTime dt2 = DateTime.Now.AddMonths(-1);
            thsmonth = dt2.ToString("MMMM");
        }

        //Calculating Year
        public void calyear()
        {
            DateTime dt1 = DateTime.Today;
            thsyear = dt1.ToString("yyyy");
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.cancel_button;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.error;
        }

        public void display()
        {
            //displaying Attendance in datagrid
            SqlDataAdapter adp = new SqlDataAdapter();
            connect c = new connect();
            DataSet ds = new DataSet();
            c.cmd.CommandText = "SELECT Month,Days_Present,Days_Absent FROM Attendance WHERE emp_id='" + comboBox1.Text + "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "item");
            if (ds.Tables["item"].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables["item"];
                dataGridView1.Visible = true;
            }
        }
    }

}
