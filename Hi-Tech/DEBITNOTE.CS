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
using Microsoft.VisualBasic;

namespace Hi_Tech
{
    public partial class DEBITNOTE : Form
    {
        public DEBITNOTE()
        {
            InitializeComponent();
        }
        bool tem = false;
        string g, rr;
        decimal f;
        string gg;
        decimal oramt, dedamt, k;
        decimal op, mp, tp;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter the Voucher number"); ;
            }
            else
            {
                panel1.Visible = true ;      
                label9.Text = label5.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Please Enter the Credit Note Reference Number");
            }
            else
            {
                if (textBox4.Text != "")
                {
                    inputbox();
                    genc();
                    label9.Text = k.ToString();
                    final();
                    label5.Text = op.ToString();
                    gen();
                    Save();
                    MessageBox.Show("Dear User the Amount to be Paid to '" + g + "' is Rupees '" + f + "' Since you have generated the Debit Note Towards the Item '" + gg + "'\n The Reson for Generation of Debit Note is : " + rr + "");
                    button2.Enabled = false;                   
                    button3.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Enter the Amount to be Deducted");
                }
            }
        }
        //Transfering Values 
        public void gen()
        {
            g = Convert.ToString(textBox2.Text);
            gg = Convert.ToString(label8.Text);
            f = Convert.ToDecimal(label5.Text);
        }

        //Generating Credit Note
        public void genc()
        {
            oramt = Convert.ToDecimal(label9.Text);
            dedamt = Convert.ToDecimal(textBox4.Text);
            k = oramt - dedamt;
        }

        //If Multiple Rows Present the choose item
        public void search1()
        {
            bool temp = false;
            if(con.State!=ConnectionState.Closed )
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmds = new SqlCommand("select Item_Name,Amount from Purchase where Item_Name='" + textBox5.Text + "'", con);
            SqlDataReader drz = cmds.ExecuteReader();
            while (drz.Read())
            {
                decimal l;
                label14.Text = drz.GetString(0);
                l = decimal.Parse(drz.GetDecimal(1).ToString());
                label9.Text = Convert.ToString(l);
                label7.Visible = true;
                textBox4.Visible = true;
                button2.Visible = true;
                temp = true;
            }
            if (temp == false)
            {
                MessageBox.Show("The Item Hasent been Purchase");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                label11.Text = label5.Text;
                label8.Text = Convert.ToString(textBox5.Text);
                search1();
                button5.Visible = true;
                //search4();
                label9.Visible = true;
                label18.Visible = true;
            }
            else
            {
                MessageBox.Show("Please enter the Item Name");
            }
        }

        public void search4()
        {
            if(con.State !=ConnectionState.Closed )
            {
                con.Close();
            }
            else
            {
                SqlCommand cmdsearch = new SqlCommand("select Amount from Purchase where Item_Name='" + textBox5.Text + "'", con);
                con.Open();
                SqlDataReader drsearch = cmdsearch.ExecuteReader();
                while (drsearch .Read ())
                {
                    decimal wwq;
                    wwq=decimal .Parse( drsearch.GetDecimal(0).ToString());
                    label8.Text = Convert.ToString(wwq);
                }
            }
            con.Close();
        }

        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

        private void textBox1_Leave(object sender, EventArgs e)
        {
            search();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Supplier_Name,Billed_Date,GT from Purchase_Main where Vch_No='" + textBox1.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr.GetString(0);
                    DateTime o;
                    o = DateTime.Parse(dr.GetDateTime(1).ToString());
                    textBox3.Text = Convert.ToString(o);
                    decimal gt;
                    gt = decimal.Parse(dr.GetDecimal(2).ToString());
                    label5.Text = Convert.ToString(gt);
                    tem = true;
                }
                if (tem == false)
                    MessageBox.Show("Bill Not Found Please check it");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            search3();
        }

        public void search3()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Discount from Purchase where Vch_No='" + textBox1.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    decimal oo = decimal.Parse(dr.GetDecimal(0).ToString());
                    label17.Text = Convert.ToString(oo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Inserting into datagrid
        public void search()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmde = new SqlCommand("SELECT Sl_No,Item_Name,Manufacturer,Model_No,HSN_Code,Qty,Price,SGST,CGST,Amount from Purchase where Vch_No='" + textBox1.Text + "'", con);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmde))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            con.Close();
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            DateTime gg, hh;
            gg = Convert.ToDateTime(dateTimePicker1.Text);
            hh = Convert.ToDateTime(DateTime.Now.Date);
            if (gg > hh)
            {
                MessageBox.Show("The Billed Date cannot be grater than today's date");
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.cancel_button;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.error;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //claculating final amt
        public void final()
        {
            mp = Convert.ToDecimal(label11.Text);
            tp = Convert.ToDecimal(textBox4.Text);
            op = mp - tp;
        }

        //Saving in Db
        public void Save()
        {
            con.Open();
            SqlCommand cmdsa = new SqlCommand("Insert into Debit_Note (Party_Name,Amt_Ded,Reason,Vch_No,Item_Name,Item_Amt,Amtto_Pay,Dated)values('" + this.textBox2.Text + "','" + this.textBox4.Text + "','" + rr + "','" + this.textBox1.Text + "','" + this.label8.Text + "','" + this.label9.Text + "','" + this.label5.Text + "','" + Convert.ToDateTime(this.dateTimePicker1.Text) + "')", con);
            cmdsa.ExecuteNonQuery();
            MessageBox.Show("Debit Note Generation Successfull");
            con.Close();
        }
        //Using Input Box to give the reason
        public void inputbox()
        {
            string message, title, defaultValue;
            // Set prompt. 
            message = "Enter the Reason for the generation of Debit Note";
            // Set title. 
            title = "Reason for Debit Note";
            // Set default value. 
            defaultValue = "";//Display message, title, and default value. 
            rr = Interaction.InputBox(message, title, defaultValue, 100, 100);// If user has clicked Cancel, set myValue to defaultValue 
        }
        private void DEBITNOTE_Load(object sender, EventArgs e)
        {

        }
    }
}
