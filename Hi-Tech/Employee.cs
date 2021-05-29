using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class Employee : Form
    {
        connect cnn;
        public Employee()
        {
            InitializeComponent();
        }

        private void buttonellipse1_Click(object sender, EventArgs e)
        {
            Employee.ActiveForm.Close();
        }

        private void buttonellipse1_MouseEnter(object sender, EventArgs e)
        {
            this.buttonellipse1.BackColor = ColorTranslator.FromHtml("RED");
        }

        private void buttonellipse1_MouseLeave(object sender, EventArgs e)
        {
            this.buttonellipse1.BackColor = ColorTranslator.FromHtml("Transparent");
        }
         bool t = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Top++;
            if (label1.Top == 200)
            {
                label1.Top = 100;
            }
        }
         private void Employee_Load(object sender, EventArgs e)
        {


            timer1.Start();
            label1.Top = 100;

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            try {
                SqlConnection sqlcon=new SqlConnection(@"Data Source=MIHIR-PC; Initial Catalog=HI-TECH;Integrated Security = True");
                String quer = "select *  from emp_det where emp_name='" + usernametxt.Text.Trim() + "'and phone='" + passwordtxt.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(quer, sqlcon);
                DataTable dtb = new DataTable();
                sda.Fill(dtb);
                if (dtb.Rows.Count == 1)
                {
                   loading et = new loading();
                    et.Show();
                    timer2.Start();
                }
                else
                {
                    MessageBox.Show("INVALID USERNAME OR PASSWORD");
                }
            }
            catch
            {
                MessageBox.Show("INVALID USERNAME OR PASSWORD");

            }
            finally { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer2.Stop();
                this.Close();
            }
        }
       
    }
}
