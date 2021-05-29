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
    public partial class acmasterlist : UserControl
    {
        public acmasterlist()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("ENTER THE VENDOR NAME");
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                connect c = new connect();
                DataSet ds = new DataSet();
                c.cmd.CommandText = "SELECT * FROM Sup_det WHERE Name='" + comboBox1.Text + "'";
                adp.SelectCommand = c.cmd;
                adp.Fill(ds, "item");
                if (ds.Tables["item"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["item"];
                    dataGridView1.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Record/Item Found Please Retype the Name Properly");
                    dataGridView1.Visible = false;
                }
            }
        }

        private void acmasterlist_Load(object sender, EventArgs e)
        {
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
