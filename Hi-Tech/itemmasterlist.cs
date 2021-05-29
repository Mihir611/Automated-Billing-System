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
    public partial class itemmasterlist : UserControl
    {
        public itemmasterlist()
        {
            InitializeComponent();
        }
        public void moclean()
        {
           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            SqlDataAdapter adp = new SqlDataAdapter();
            connect c = new connect();
            DataSet ds = new DataSet();
            c.cmd.CommandText = "SELECT * FROM Item WHERE Item_Name='" + comboBox1.Text+ "'";
            adp.SelectCommand = c.cmd;
            adp.Fill(ds, "item");
            if (ds.Tables["item"].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables["item"];
            }
            else
            {
                MessageBox.Show("No Record/Item Found Please Retype the Name Properly");
            }
        }

        private void itemmasterlist_Load(object sender, EventArgs e)
        {
            string Sql = "select  Item_name from Item";
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1.Items.Add(DR[0]);

            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

