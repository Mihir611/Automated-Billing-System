using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Hi_Tech
{
    public partial class adminlogin : Form
    {

        connect cnn;
        public adminlogin()
        {
            InitializeComponent();
            this.Size = new Size(380, 510);
        }
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
        private void adminlogin_Load(object sender, EventArgs e)
        {
            bunifuThinButton23.Visible = false;
            LOGIN2BTN.Visible = false;
            panel11.BackgroundImage = Properties.Resources.eyeclosed;
            label13.Text = "SHOW";
            panel10.BackgroundImage = Properties.Resources.eyeclosed;
            label12.Text = "SHOW";
            panel9.BackgroundImage = Properties.Resources.eyeclosed;
            label11.Text = "SHOW";
            this.panel1.BackColor = ColorTranslator.FromHtml("Lime");
            this.panel2.BackColor = ColorTranslator.FromHtml("Transparent");
            this.panel8.BackColor = ColorTranslator.FromHtml("White");
            PASSWORD2TXT.Visible = false;
            CONFIRMPASSWORD2TXT.Visible = false;
            UPDATEBTN.Visible = false ;
            LOGIN2BTN.Visible = false;
            label8.Visible = false;
            CONFIRMPASSWORDLBL.Visible = false;
            PASSWORD2LBL.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer4.Stop();
                this.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.Left -= 5;
            btnback.Left -= 5;
            if (panel3.Left == 0)
            {
                timer1.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            panel3.Left += 5;
            btnback.Left += 5;
            if (panel3.Left == 380)
            {
                timer2.Stop();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timer1.Start();
            this.panel2.BackColor = ColorTranslator.FromHtml("Lime");
            this.panel1.BackColor = ColorTranslator.FromHtml("Transparent");
            this.panel8.BackColor = ColorTranslator.FromHtml("White");
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            timer2.Start();
            PASSWORD2TXT.Text = "";
            CONFIRMPASSWORD2TXT.Text = "";
            CONFIRMPASSWORDLBL.Visible = false;
            PASSWORD2LBL.Visible = false;
            label8.Visible = false;
            VALIDCODETXT.Text = "";
            USERNAME2.Text = "";
            PASSWORD2TXT.Visible = false;
            CONFIRMPASSWORD2TXT.Visible = false;
            panel10.Visible = false;
            UPDATEBTN.Visible = false;
            LOGIN2BTN.Visible = false;
            this.panel1.BackColor = ColorTranslator.FromHtml("Transparent");
            this.panel2.BackColor = ColorTranslator.FromHtml("Lime");
            this.panel8.BackColor = ColorTranslator.FromHtml("White");
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
               

                    string p, pa, g, f;
                f = Convert.ToString(bunifuMaterialTextbox1.Text);
                 cnn = new connect();
                cnn.cmd.CommandText = "select Password from Table_1 where Username=@user";
                cnn.cmd.Parameters.Clear();
                cnn.cmd.Parameters.AddWithValue("@user", bunifuMaterialTextbox1.Text);
                p = Convert.ToString(cnn.cmd.ExecuteScalar());
                cnn.cmd.Parameters.AddWithValue("@pass", bunifuMaterialTextbox2.Text);
                pa = Convert.ToString(cnn.cmd.ExecuteScalar());

                if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox2.Text == "")
                {
                    MessageBox.Show("U left Either User Name or the Password Field Empty or u Didnt select Admin(Owner)/Employee Field Please Check it");
                    //secure Login
                }
                else if (bunifuMaterialTextbox2.Text != pa)
                {
                    MessageBox.Show("ENTER THE VALID USERNAME OR PASSWORD");
                }

                else if (bunifuMaterialTextbox2.Text == p && bunifuMaterialTextbox2.Text != "")
                {
                    if (bunifuMaterialTextbox1.Text != "HI")
                    {
                        MessageBox.Show("Dear user since u are the employee of the company So please select Employee form the list");
                    }
                    else
                    {
                      adloding v = new adloding();
                        v.Show();
                        this.Close();
                    }
                }
              
            }

            catch
            {
                throw;
            }
            finally
            {
            }
        }
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            String pattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$";
            if (Regex.IsMatch(PASSWORD2TXT.Text, pattern))
            {
               
                    label9.Visible = false;
                    if (PASSWORD2TXT.Text == "")
                    {
                        MessageBox.Show("ENTER THE PASSWORD");
                    }
                    else if (CONFIRMPASSWORD2TXT.Text == "")
                    {
                        MessageBox.Show("ENTER THE CONFIRM PASSWORD");
                    }
                    else if (PASSWORD2TXT.Text != "" && CONFIRMPASSWORD2TXT.Text != "")
                    {
                        string g, h;
                        g = PASSWORD2TXT.Text;
                        h = CONFIRMPASSWORD2TXT.Text;
                        if (g == h)
                        {
                            SqlCommand command = new SqlCommand("select Password from Table_1 where Password='" + PASSWORD2TXT.Text + "'", con);
                            con.Open();
                            SqlDataReader drcheck = command.ExecuteReader();
                            if (drcheck.HasRows)
                            {
                                MessageBox.Show("you have already given this Password Please change IT");
                                con.Close();
                            }
                            else
                            {
                                try
                                {
                                    cnn = new connect();
                                    cnn.cmd.CommandText = "Update Table_1 set Password=@pass where Username=@user";
                                    cnn.cmd.Parameters.Clear();
                                    cnn.cmd.Parameters.AddWithValue("@user", USERNAME2.Text);
                                    cnn.cmd.Parameters.AddWithValue("@pass", PASSWORD2TXT.Text);
                                    cnn.cmd.ExecuteNonQuery();
                                    MessageBox.Show("Password Updated Successfully");
                                    LOGIN2BTN.Visible = true;
                                    UPDATEBTN.Visible = false;
                                label8.Visible = false;
                                }
                                catch
                                {
                                    throw;
                                }
                                finally
                                {
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("The Comfirm Password and the New Password field should be the same");
                        }
                    }
                }
            
            else
            {
                label8.Visible = true;
            }
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            if (USERNAME2.Text != "HI")
            {
                MessageBox.Show("The User " + USERNAME2.Text + " is not allowed to change the password");
            }
            else
            {
              
                if (VALIDCODETXT.Text == "1024-2048-4096-8192")//1024-2048-4096-8192
                {
                    PASSWORD2TXT.Visible = true;
                    CONFIRMPASSWORD2TXT.Visible = true;
                    UPDATEBTN.Visible = true;
                 
                    CONFIRMPASSWORDLBL.Visible = true;
                    PASSWORD2LBL.Visible = true;
                    panel10.Visible = true;
                 }
                else
                {
                    MessageBox.Show("ENTER THE VALID CODE");
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            timer2.Start();
            CONFIRMPASSWORDLBL.Visible = false;
            label8.Visible = false;
            PASSWORD2LBL.Visible = false;
            PASSWORD2TXT.Text = "";
            CONFIRMPASSWORD2TXT.Text = "";
            VALIDCODETXT.Text = "";
            USERNAME2.Text = "";
            CONFIRMPASSWORD2TXT.Visible = false;
            PASSWORD2TXT.Visible = false;
            panel10.Visible = false;
            UPDATEBTN.Visible = false;
            LOGIN2BTN.Visible = false;
            CONFIRMPASSWORDLBL.Visible = false;
            PASSWORD2LBL.Visible = false;
            timer2.Start();
            this.panel2.BackColor = ColorTranslator.FromHtml("Transparent");
            this.panel1.BackColor = ColorTranslator.FromHtml("Lime");
            USERNAME2.Text = "";
            VALIDCODETXT.Text = "";
            CONFIRMPASSWORD2TXT.Text = "";
            PASSWORD2TXT.Text = "";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.error;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.cancel_button;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timer5.Start();
            this.panel8.BackColor = ColorTranslator.FromHtml("Lime");
            this.panel2.BackColor = ColorTranslator.FromHtml("Transparent");
            this.panel1.BackColor = ColorTranslator.FromHtml("Transparent");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            panel7.Left += 5;
            BTN2BACK.Left += 5;
            if (panel7.Left == 380)
            {
                timer3.Stop();
            }
        }

      

        private void timer5_Tick(object sender, EventArgs e)
        {
            panel7.Left -= 5;
            BTN2BACK.Left -= 5;
            if (panel7.Left == 0)
            {
                timer5.Stop();
            }
        }

        private void BTN2BACK_Click(object sender, EventArgs e)
        {
            timer3.Start();
            OLDPASSWORD.Text="";
            PASSWORD3.Text = "" ;
            CONFIRMPASSWORD3.Text = "";
           
            this.panel1.BackColor = ColorTranslator.FromHtml("Lime");
            this.panel2.BackColor = ColorTranslator.FromHtml("Transparent");
            this.panel8.BackColor = ColorTranslator.FromHtml("White");
        }

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
            OLDPASSWORD.Text = "";
            PASSWORD3.Text = "";
            CONFIRMPASSWORD3.Text = "";
            this.panel1.BackColor = ColorTranslator.FromHtml("Lime");
            this.panel2.BackColor = ColorTranslator.FromHtml("Transparent");
            this.panel8.BackColor = ColorTranslator.FromHtml("White");
        }

        private void update2_Click(object sender, EventArgs e)
        {
            string g, t;
            String pattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$";
            if (Regex.IsMatch(PASSWORD3.Text, pattern) && Regex.IsMatch(CONFIRMPASSWORD3.Text, pattern))
                
            {
                if (OLDPASSWORD.Text == "")
                {
                    MessageBox.Show("ENTER ALL FIELDS");
                }
                else if (PASSWORD3.Text == "")
                {
                    MessageBox.Show("ENTER ALL FIELDS");
                }
                else if (CONFIRMPASSWORD3.Text == "")
                {
                    MessageBox.Show("ENTER ALL FIELDS");
                }

                else if (OLDPASSWORD.Text != "" && PASSWORD3.Text != "" && CONFIRMPASSWORD3.Text != "")
                {
                    SqlConnection coon = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                    SqlCommand cdd = new SqlCommand("select Password from Table_1 where Password='" + OLDPASSWORD.Text + "'", coon);
                    coon.Open();
                    SqlDataReader drc = cdd.ExecuteReader();

                    if (drc.HasRows)
                    {
                        g = OLDPASSWORD.Text;
                        t = PASSWORD3.Text;
                        String y = CONFIRMPASSWORD3.Text;
                        if (g == t)
                        {
                            MessageBox.Show("new password cannot be old password");
                        }
                        else if (t != y)
                        {
                            MessageBox.Show("NEW PASSWORD SHOULD MATCH CONFIRM PASSWORD");
                        }
                        else if (t == y)
                        {
                            cnn = new connect();
                            cnn.cmd.CommandText = "Update Table_1 set Password=@pass where Password=@user";
                            cnn.cmd.Parameters.Clear();
                            cnn.cmd.Parameters.AddWithValue("@user", OLDPASSWORD.Text);
                            cnn.cmd.Parameters.AddWithValue("@pass", PASSWORD3.Text);
                            cnn.cmd.ExecuteNonQuery();
                            MessageBox.Show("Password Updated Successfully");
                            bunifuThinButton23.Visible = true;

                        }
                        coon.Close();
                    }


                    else
                    {
                        MessageBox.Show("CHECK ALL FIELDS");
                        coon.Close();
                    }
                }
                

            }
        }

      

        private void panel9_Click(object sender, EventArgs e)
        {
            if (label11.Text == "SHOW")
            {
                bunifuMaterialTextbox2.isPassword = false;
                panel9.BackgroundImage = Properties.Resources.eye;

                label11.Text = "HIDE";
            }
            else if (label11.Text == "HIDE")
            {
                bunifuMaterialTextbox2.isPassword = true;
                panel9.BackgroundImage = Properties.Resources.eyeclosed;

                label11.Text = "SHOW";
            }




        }

        private void panel10_Click(object sender, EventArgs e)
        {
            if (label12.Text == "SHOW")
            {
                PASSWORD2TXT.isPassword = false;
                CONFIRMPASSWORD2TXT.isPassword = false;
                panel10.BackgroundImage = Properties.Resources.eye;

                label12.Text = "HIDE";
            }
            else if (label12.Text == "HIDE")
            {
                PASSWORD2TXT.isPassword = true;
                CONFIRMPASSWORD2TXT.isPassword = true;
                panel10.BackgroundImage = Properties.Resources.eyeclosed;

                label12.Text = "SHOW";
            }
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            if (label13.Text == "SHOW")
            {
               OLDPASSWORD.isPassword = false;
                CONFIRMPASSWORD3.isPassword = false;
               PASSWORD3.isPassword = false;
                panel11.BackgroundImage = Properties.Resources.eye;
                label13.Text = "HIDE";
            }
            else if (label13.Text == "HIDE")
            {
                OLDPASSWORD.isPassword = true;
                CONFIRMPASSWORD3.isPassword = true;
                PASSWORD3.isPassword = true;
                panel11.BackgroundImage = Properties.Resources.eyeclosed;
                label13.Text = "SHOW";
            }
        }

        private void PASSWORD3_Enter(object sender, EventArgs e)
        {
            OLDPASSWORD.isPassword = true;
            PASSWORD3.isPassword = true;
            CONFIRMPASSWORD3.isPassword = true;
            panel11.BackgroundImage = Properties.Resources.eyeclosed;
            label13.Text = "SHOW";
        }

        private void OLDPASSWORD_Enter(object sender, EventArgs e)
        {
            OLDPASSWORD.isPassword = true;
            PASSWORD3.isPassword = true;
            CONFIRMPASSWORD3.isPassword = true;
            panel11.BackgroundImage = Properties.Resources.eyeclosed;
            label13.Text = "SHOW";
        }

        private void CONFIRMPASSWORD3_Enter(object sender, EventArgs e)
        {
            OLDPASSWORD.isPassword = true;
            PASSWORD3.isPassword = true;
            CONFIRMPASSWORD3.isPassword = true;
            panel11.BackgroundImage = Properties.Resources.eyeclosed;
            label13.Text = "SHOW";
        }

        private void PASSWORD2TXT_Enter(object sender, EventArgs e)
        {
          PASSWORD2TXT.isPassword = true;
            CONFIRMPASSWORD2TXT.isPassword = true;
            panel10.BackgroundImage = Properties.Resources.eyeclosed;
            label12.Text = "SHOW";

        }

        private void CONFIRMPASSWORD2TXT_Enter(object sender, EventArgs e)
        {
            PASSWORD2TXT.isPassword = true;
            CONFIRMPASSWORD2TXT.isPassword = true;
            panel10.BackgroundImage = Properties.Resources.eyeclosed;
            label12.Text = "SHOW";
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            panel9.BackgroundImage = Properties.Resources.eyeclosed;
            bunifuMaterialTextbox2.isPassword = true;
            label11.Text = "SHOW";
        }
    }
 }




