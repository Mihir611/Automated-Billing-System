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
    public partial class purchasebill : UserControl
    {
        public purchasebill()
        {
            InitializeComponent();
        }
        string thsmonth, thsdate, thsyear;
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            bool tem = false;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Enter the Purchase Order Number");
            }
            else
            {
                if(con.State !=ConnectionState.Closed )
                {
                    con.Close();
                }
                //checking for record exist
                SqlCommand command = new SqlCommand("select Order_ID from Purchase_Main where Order_ID='" + comboBox1.Text + "'", con);
                con.Open();
                SqlDataReader drcheck = command.ExecuteReader();
                if (drcheck.HasRows)
                {
                    MessageBox.Show("You have Already generated the Purchase bill for " + comboBox1.Text + " this Order Number");
                    con.Close();
                }
                else
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                    //selecting records from place_order_main
                    con.Open();
                    SqlCommand cmde = new SqlCommand("select Supplier_Name,Total from Place_Order_Main where Order_ID='" + comboBox1.Text + "'", con);
                    SqlDataReader dr = cmde.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox3.Text = dr.GetString(0);
                        label9.Text = comboBox1.Text;
                        decimal tot;
                        tot = decimal.Parse(dr.GetDecimal(1).ToString());
                        label16.Text = Convert.ToString(tot);
                        //comboBox1.Visible = false;
                        //label1.Visible = false;
                        //button1.Enabled = false;
                        panel1.Visible = true;
                        tem = true;
                    }
                    if (tem == false)
                    {
                        MessageBox.Show("Record not found");
                    }
                    else
                    {
                        //select records form place_order (item_Name etc ...)
                        if (con.State != ConnectionState.Closed)
                        {
                            con.Close();
                            con.Open();
                            SqlCommand cmd = new SqlCommand("select Sl_No,Item,Model_No,Manufacturer,HSN_Code,Qty,Price,Amount from Place_Order where Order_ID='" + comboBox1.Text + "'", con);
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    dataGridView1.DataSource = dt;
                                }
                            }
                        }
                    }
                    con.Close();
                    gst();
                    textBox3.Enabled = false;
                    totqty();
                    trns();
                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            disc();
        }
        //Calculating total Qty
        public void totqty()
        {
            decimal sum1 = 0;
            int z1 = 0;
            for (z1 = 0; z1 < dataGridView1.Rows.Count - 1; z1++)
            {
                sum1 += Convert.ToDecimal(dataGridView1.Rows[z1].Cells[5].Value);
            }
            label15.Text = sum1.ToString("#,0.00");
        }
        //to calculate total transaction done till date
        public void trns()
        {
            SqlCommand cmdt = new SqlCommand("Select Amount,Qty from Sup_det where Name='" + textBox3.Text + "'", con);
            con.Open();
            SqlDataReader drcheck = cmdt.ExecuteReader();
            while (drcheck.Read())
            {
                decimal lli, llo;
                lli = decimal.Parse(drcheck.GetDecimal(0).ToString());
                label19.Text = Convert.ToString(lli);
                llo = decimal.Parse(drcheck.GetDecimal(1).ToString());
                label27.Text = Convert.ToString(llo);
            }
            con.Close();
        }
        //code to update stock
        public void ups()
        {
            con.Open();
            for (int sto = 0; sto < dataGridView1.Rows.Count - 1; sto++)
            {
                SqlCommand sqlcommand = new SqlCommand("Update Stock set Qty=Qty+@quanty where HSN_Code=@num", con);
                sqlcommand.Parameters.AddWithValue("@quanty", SqlDbType.Decimal).Value = dataGridView1.Rows[sto].Cells[5].Value;
                sqlcommand.Parameters.AddWithValue("@num", SqlDbType.Int).Value = dataGridView1.Rows[sto].Cells[4].Value;
                sqlcommand.ExecuteNonQuery();
            }
            con.Close();
        }

        //Inserting into trable
        public void Insert23()
        {
            SqlCommand cmdins23 = new SqlCommand(@"Insert into Purchase_Main (Vch_No,Supplier_Name,Billed_Date,Order_ID,Gt)VALUES('" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "','" + this.label9.Text + "','" + this.label29.Text + "')", con);
            con.Open();
            cmdins23.ExecuteNonQuery();
            con.Close();
            datee();
        }

        //Updating Amount
        public void Insert24()
        {
            if(con.State!=ConnectionState.Closed )
            {
                con.Close();
            }
            SqlCommand cmdup = new SqlCommand("Update Sup_det set Amount=Amount+@amt where Name='" + textBox3.Text + "'", con);
            con.Open();
            cmdup.Parameters.AddWithValue("@amt", SqlDbType.Decimal).Value = Convert.ToDecimal(label16.Text);
            cmdup.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = textBox3.Text;
            cmdup.ExecuteNonQuery();
            con.Close();
        }

        //Udating Qty Bought
        public void Insert245()
        {
            SqlCommand cmdup245 = new SqlCommand("Update Sup_det set Qty=Qty+@qty where Name=@name", con);
            con.Open();
            cmdup245.Parameters.AddWithValue("@qty", SqlDbType.Decimal).Value = label15.Text;
            cmdup245.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = textBox3.Text;
            cmdup245.ExecuteNonQuery();
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            else
            {
                con.Open();
                for (int er = 0; er < dataGridView1.Rows.Count - 1; er++)
                {
                    SqlCommand cmdsav = new SqlCommand(@"Insert into Purchase (Vch_No,Narration,Sl_No,Item_Name,Manufacturer,Model_No,HSN_Code,Qty,Price,SGST,CGST,Amount,Discount,Round_Pl,Round_Mi)values('" + this.textBox2.Text + "','" + this.textBox7.Text + "','" + dataGridView1.Rows[er].Cells[0].Value + "','" + dataGridView1.Rows[er].Cells[1].Value + "','" + dataGridView1.Rows[er].Cells[3].Value + "','" + dataGridView1.Rows[er].Cells[2].Value + "','" + dataGridView1.Rows[er].Cells[4].Value + "','" + dataGridView1.Rows[er].Cells[5].Value + "','" + dataGridView1.Rows[er].Cells[6].Value + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + dataGridView1.Rows[er].Cells[7].Value + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "')", con);
                    cmdsav.ExecuteNonQuery();
                    MessageBox.Show("Records Inserted");
                }
                con.Close();
                ups();
                Insert23();
                formclr();
                Insert24();
                Insert245();
            }
        
    }
        //clearing all
        public void formclr()
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "";
            textBox8.Text = "0";
            textBox9.Text = "0";
            label7.Text = "0";
            label9.Text = "0";
            label34.Text = "0";
            label29.Text = "0";
            label32.Text = "0";
            label19.Text = "0";
            label27.Text = "0";
            label15.Text = "0";
            label16.Text = "0";
            label10.Text = "0";
            label11.Text = "0";
            label12.Text = "0";
            label13.Text = "0";
        }


        private void textBox2_Leave(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select Vch_No from Purchase_Main where Vch_No='" + this.textBox2.Text + "'", con);
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            else
            {
                con.Open();
                SqlDataReader drcheck1 = command.ExecuteReader();
                while (drcheck1.Read())
                {
                    Int16 Vch;
                    Vch = Int16.Parse(drcheck1.GetInt16(0).ToString());
                    label34.Text = Convert.ToString(Vch);
                    if (label34.Text == textBox2.Text)
                    {
                        MessageBox.Show("This Voucher Number already exists please insert the Voucher Number Properly");
                        formclr();
                    }
                }
            }
        }

        private void purchasebill_Load(object sender, EventArgs e)
        {
            formclr();
            string Sql = "select Order_ID from  Place_Order_Main";
            SqlConnection cont = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            cont.Open();
            SqlCommand cmd = new SqlCommand(Sql, cont);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);
            }
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            DateTime gg, hh;
            gg = Convert.ToDateTime(dateTimePicker2.Text);
            hh = Convert.ToDateTime(DateTime.Now.Date);
            if (gg > hh)
            {
                MessageBox.Show("The Billed Date cannot be grater than today's date");
                button2.Enabled = false;
            }
            else if (gg < hh)
            {
                MessageBox.Show("The Billed Date cannot be grater than today's date");
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        //getting GSTin
        public void gst()
        {
            bool temp = false;
            con.Open();
            SqlCommand cmdg = new SqlCommand("select Gstin from Sup_det where Name='" + textBox3.Text + "'", con);
            SqlDataReader dz = cmdg.ExecuteReader();
            while (dz.Read())
            {
                label7.Text = dz.GetString(0);
                temp = true;
            }
            if (temp == false)
            {
                MessageBox.Show("Record not Exist");
            }
            con.Close();
        }

        //calculating Discount
        public void disc()
        {
            decimal d, f, s;
            d = Convert.ToDecimal(textBox4.Text);
            f = Convert.ToDecimal(label16.Text);
            s = f - d;
            label10.Text = Convert.ToString(s);
            label29.Text = label10.Text;
        }
        public void datee()
        {
            DateTime dt = DateTime.Now;
            thsmonth = dt.ToString("MMMM");
            thsdate = dt.ToString("dd");
            thsyear = dt.ToString("yyyy");
            textBox10.Text = thsdate;
            textBox11.Text = thsmonth;
            textBox12.Text = thsyear;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand cmddt = new SqlCommand(@"Insert into Purchase_Main (Month,Dt1,Year) values ('" + this.textBox11.Text + "','" + this.textBox10.Text + "','" + this.textBox12.Text + "')", con);
                cmddt.ExecuteNonQuery();
                MessageBox.Show("Records Inserted");
            }
        }

    }
}
