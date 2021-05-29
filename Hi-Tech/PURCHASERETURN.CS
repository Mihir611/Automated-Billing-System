using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class PURCHASERETURN : Form
    {
        public PURCHASERETURN()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");


        private void PURCHASERETURN_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            bool tem = false;
            SqlCommand cmd = new SqlCommand("Select Supplier_Name,Billed_Date from Purchase_Main where Vch_No='" + textBox1.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox4.Text = dr.GetString(0);
                DateTime dt;
                dt = DateTime.Parse(dr.GetDateTime(1).ToString());
                textBox2.Text = Convert.ToString(dt);
                panel1.Visible = true;
                panel2.Visible = true;
                tem = true;
            }
            if (tem == false)
            {
                MessageBox.Show("Bill Entry Not Found Please Check it", "Check IT");
            }
            con.Close();
            dbins();
            gettin();
            GGT();
            qty1();
            getdis();
        }
        //Inserting into database
        public void dbins()
        {
            con.Open();
            SqlCommand cmdb = new SqlCommand("SELECT Item_Name,Manufacturer,Model_No,HSN_Code,Qty,Price,CGST,SGST,Amount from Purchase where Vch_No='" + textBox1.Text + "'", con);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmdb))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            con.Close();
        }
        //getting discount
        public void getdis()
        {
            if(con.State!=ConnectionState.Closed )
            {
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmdb1 = new SqlCommand("SELECT Discount from Purchase where Vch_No='" + textBox1.Text + "'", con);
                SqlDataReader dd1 = cmdb1.ExecuteReader();
                while (dd1 .Read ())
                {
                    decimal d1;
                    d1 = decimal.Parse(dd1.GetDecimal(0).ToString());
                    label21.Text = Convert.ToString(d1);
                }
                con.Close();
            }
        }

        //getting GSTin
        public void gettin()
        {
            SqlCommand cmdg = new SqlCommand("Select Gstin from Sup_det where Name='" + textBox4.Text + "'", con);
            con.Open();
            SqlDataReader dre = cmdg.ExecuteReader();
            while (dre.Read())
            {
                label8.Text = dre.GetString(0);
            }
            con.Close();
        }

        //getting GT
        public void GGT()
        {
            SqlCommand cmdgt = new SqlCommand("Select GT from Purchase_Main where Vch_No='" + textBox1.Text + "'", con);
            con.Open();
            SqlDataReader dgt = cmdgt.ExecuteReader();
            while (dgt.Read())
            {
                decimal gt;
                gt = decimal.Parse(dgt.GetDecimal(0).ToString());
                label4.Text = Convert.ToString(gt);
            }
            con.Close();
        }

        //getting Qty
        public void qty1()
        {
            SqlCommand conqty = new SqlCommand("Select qty from Purchase where Vch_No='" + textBox1.Text + "'", con);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            else
            {
                con.Open();
                SqlDataReader dgtt = conqty.ExecuteReader();
                while (dgtt.Read())
                {
                    decimal qty;
                    qty = decimal.Parse(dgtt.GetDecimal(0).ToString());
                    label10.Text = Convert.ToString(qty);
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool temp = false;
            decimal i;
            con.Open();
            SqlCommand cmdret = new SqlCommand("Select Item_Name from purchase where HSN_Code='" + textBox3.Text + "'", con);
            SqlDataReader dret = cmdret.ExecuteReader();
            while (dret.Read())
            {
                // i = decimal.Parse(dret.GetDecimal(0).ToString());
                label17.Text = dret.GetString(0);
                label12.Visible = true;
                label15.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                button2.Enabled = true;
                button1.Enabled = false;
                temp = true;
            }
            if (temp == false)
            {
                button2.Enabled = false;
                MessageBox.Show("You Havent Purchase this Item or Please enter the valied HSN Code", "Check IT");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Please Enter the Quantity to be Returned", "Check It");
            }
            else
            {
                Int16 qt, qtl;
                qt = Convert.ToInt16(label10.Text);
                qtl = Convert.ToInt16(textBox7.Text);
                if (qtl > qt)
                {
                    MessageBox.Show("You Cannot return this quantity of this product becuse it is grater than the Quantity Present in the Purchase bill ");
                }
                else
                {
                    DateTime gg, hh;
                    gg = Convert.ToDateTime(dateTimePicker1.Text);
                    hh = Convert.ToDateTime(DateTime.Now.Date);
                    if (gg > hh)
                    {
                        MessageBox.Show("The Billed Date cannot be grater than today's date");
                    }
                    else
                    {
                        button2.Enabled = true;
                        if (textBox6.Text != "")
                        {
                            if (textBox5.Text != "")
                            {
                                con.Open();
                                SqlCommand cmdins = new SqlCommand(@"Insert into Pur_Ret (Item_Name,Qty_Returned,Amount,Reason,Date,Supplier_Name)values('" + this.textBox3.Text + "','" + this.textBox7.Text + "','" + this.textBox6.Text + "','" + this.textBox5.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + this.textBox4.Text + "')", con);
                                cmdins.ExecuteNonQuery();
                                MessageBox.Show("Returnd Item(s) Details are stored successfully ");
                                decimal pay = Convert.ToDecimal(label4.Text) - Convert.ToDecimal(textBox6.Text);
                                string h;
                                h = textBox4.Text;
                                MessageBox .Show ("Dear Admin you have to pay Rs '"+pay+"'  to  '"+h+"'");
                                clrfn();
                            }
                            else
                            {
                                MessageBox.Show("Please Enter the Reason for Returning these Items", "Enter Reason");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter the Amount of the Items Being Returned", "Check IT");
                        }
                    }
                }
            }
            con.Close();
            ups();
        }
        //udating stock

        public void ups()
        {
            con.Open();
            SqlCommand sqlcommand = new SqlCommand("Update Stock set Qty=Qty-@quanty where HSN_Code=@num", con);
            sqlcommand.Parameters.AddWithValue("@quanty", SqlDbType.Decimal).Value = textBox7.Text;
            sqlcommand.Parameters.AddWithValue("@num", SqlDbType.Int).Value = textBox3.Text;
            sqlcommand.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.cancel_button;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Properties.Resources.error;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if(con.State !=ConnectionState.Closed )
            {
                con.Close();
            }
            else
            {
                SqlCommand cmdsql = new SqlCommand("select Price from Purchase where HSN_Code ='"+textBox3 .Text +"'",con);
                con.Open();
                SqlDataReader drsql = cmdsql.ExecuteReader();
                while (drsql .Read ())
                {
                    decimal amt;
                    amt = decimal.Parse(drsql.GetDecimal(0).ToString());
                    label18.Text = Convert.ToString(amt);
                }
            }
            con.Close();
            decimal ti,pi,ci;
            ci = Convert.ToDecimal(label18.Text);
            ti = Convert.ToDecimal(textBox7.Text);
            pi = ti * ci;
            textBox6.Text = Convert.ToString(pi);
        }
        //clear function
        public void clrfn()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            label8.Text = "0";
            label4.Text = "0";
            label10.Text = "0";
            label21.Text = "0";
            label17.Text = "0";
            label18.Text = "0";
            label14.Text = "0";
            label16.Text = "0";
            panel1.Visible = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
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
