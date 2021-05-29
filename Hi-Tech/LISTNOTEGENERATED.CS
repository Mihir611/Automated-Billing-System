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
    public partial class LISTNOTEGENERATED : Form
    {
        public LISTNOTEGENERATED()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter the Supplier Name");
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                connect c = new connect();
                DataSet ds = new DataSet();
                c.cmd.CommandText = "Select Vch_No,Item_Name,Item_Amt,Amt_Ded,Amtto_Pay,Dated,Reason from Debit_Note where Party_Name='" + textBox1.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "item");
                if (ds.Tables["item"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["item"];
                    dataGridView1.Visible = true;
                    panel1.Visible = true;
                    label8.Text = textBox1.Text;
                    textBox1.Visible = false;
                    label1.Visible = false;
                }
                else
                {
                    MessageBox.Show("No Record/Item Found Please Retype the Name Properly");

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.cancel_button;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.error;
        }
    }
}
