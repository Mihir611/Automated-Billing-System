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
    public partial class acmasterdel : UserControl
    {
        public acmasterdel()
        {
            InitializeComponent();
        }

        connect c = new connect();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                label2.Visible = true;
                label2.Text = "Please enter the name of the item ";
            }
            bool tem = false;
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Sup_det WHERE Name='" + comboBox1.Text + "'", con);
            SqlDataReader drz = cmd.ExecuteReader();
            while (drz.Read())
            {
                label2.Visible = true;
                label2.Text = "Account Found";
                button2.Visible = true;
                dataGridView1.Visible = true;
                ins();
                tem = true;
            }
            if (tem == false)
            {
                label2.Visible = true;
                label2.Text = "Account Not Found";
                button2.Visible = false;
                dataGridView1.Visible = false;
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("PLEASE ENTER VENDOR");
            }
            else
            {
                DialogResult M = MessageBox.Show("ARE U SURE U WANT TO DELETE THE ITEM?", "DELETE ITEM", MessageBoxButtons.OKCancel);
                if (M == DialogResult.OK)
                {
                    c.cmd.CommandText = "DELETE FROM Sup_det WHERE Name='" + comboBox1.Text + "'";
                    MessageBox.Show("Item deleted successfully");
                    c.cmd.ExecuteNonQuery();
                }
                if (M == DialogResult.Cancel)
                {
                    MessageBox.Show("Item not deleted because user clicked cancel");
                }
            }
        }
        //inserting in db
        public void ins()
        {
            SqlConnection conw = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conw.Open();
            SqlCommand cmdw = new SqlCommand("SELECT * FROM Sup_det WHERE Name='" + comboBox1.Text + "'", conw);
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

        private void acmasterdel_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            dataGridView1.Visible = false;
            string Sql = "select Name from Sup_det";
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
