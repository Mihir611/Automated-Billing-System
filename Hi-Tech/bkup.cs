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
    public partial class bkup : Form
    {
        public bkup()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            blank("backup");
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
                if (str == "backup")
                {
                    saveFileDialog1.FileName = comboBox2.Text;
                    saveFileDialog1.ShowDialog();
                    string s = null;
                    s = saveFileDialog1.FileName;
                    query("Backup database " + comboBox2.Text + " to disk='" + s + "'");
                    MessageBox .Show ( "Database BackUp has been created successful");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Createconnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bkup_Load(object sender, EventArgs e)
        {
            serverName(".");
        }
    }
}
