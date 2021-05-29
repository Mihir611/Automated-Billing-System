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
    public partial class rest : Form
    {
        public rest()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rest_Load(object sender, EventArgs e)
        {
            serverName(".");
        }

        public void serverName(string str)
        {
            con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[2]);
            }
            dr.Close();
        }

        public void Createconnection()
        {
            con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            comboBox2.Items.Clear();
            cmd = new SqlCommand("select * from sysdatabases", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();
        }

        public void query(string que)
        {
            // ERROR: Not supported in C#: OnErrorStatement
            cmd = new SqlCommand(que, con);
            cmd.ExecuteNonQuery();
        }



        public void blank(string str)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) | string.IsNullOrEmpty(comboBox2.Text))
            {
                // label3.Visible = true;
                MessageBox.Show("Server Name & Database can not be Blank");
                return;
            }
            else
            {
                if (str == "restore")
                {
                    openFileDialog1.ShowDialog();
                    query("IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + comboBox2.Text + "') DROP DATABASE " + comboBox2.Text + " RESTORE DATABASE " + comboBox2.Text + " FROM DISK = '" + openFileDialog1.FileName + "'");
                    label3.Visible = true;
                    MessageBox .Show ("Database Backup file has been restore successfully");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Createconnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you really want to restore the database????");
            blank("restore");
        }
    }

}
