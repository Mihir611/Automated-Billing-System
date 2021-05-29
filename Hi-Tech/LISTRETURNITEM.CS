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
    public partial class LISTRETURNITEM : Form
    {
        public LISTRETURNITEM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Enter the Supplier Name");
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                connect c = new connect();
                DataSet ds = new DataSet();
                c.cmd.CommandText = " select Item_Name,Qty_Returned,Amount,Reason,Date from Pur_Ret where Supplier_Name='" + comboBox1.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "item");
                if (ds.Tables["item"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["item"];
                    dataGridView1.Visible = true;
                    panel1.Visible = true;
                    label8.Text = comboBox1.Text;
                   comboBox1.Visible = false;
                    label1.Visible = false;
                    label7.Visible = true;
                    label8.Visible = true;
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

        private void LISTRETURNITEM_Load(object sender, EventArgs e)
        {
            string Sql = "select  Supplier_Name from Pur_Ret";//Pur_Ret where Supplier_Name
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
        }
    }
}
