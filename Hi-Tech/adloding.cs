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
    public partial class adloding : Form
    {
        Timer timer1 = new Timer();
        public adloding()
        {
            InitializeComponent();
        }
        void defaul()
        {

            this.progressbar1.Value = 0;
            this.label1.Left = 0;
        }
        int plus = 1;
        int lblplus = 3;
        void move(object sender, EventArgs e)
        {
            if (label1.Left < 400 || progressbar1.Value < 100)
            {
                progressbar1.Value += plus;
                label1.Left += lblplus;
                label2.Left += lblplus;
                label1.Text = progressbar1.Value.ToString() + "%";

            }
            if (label1.Text == "100%")
            {
                timer1.Stop();
               adminform s = new adminform();
                s.Show();
                this.Close();
            }
            if (label1.Text == "20%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Blue");
                label2.Text = "Checking";
            }
            else if (label1.Text == "50%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Purple");
                label2.Text = "Calculating Stock";
                SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Qty from Stock where QtY<=Re_Order",con );
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    label3.Visible = true;
                    label3 .Text ="There are few items which are going negative in Stock please re-order it to mintain the stock";
                }
                con.Close();
            }
            else if (label1.Text == "80%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Red");
                label2.Text = "Working";
            }
            else if (label1.Text == "90%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Lime");
                label2.Text = "Wait for some time";
            }
        }

        private void adloding_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Tick += new EventHandler(move);
            timer1.Interval = 50;
        }
    }
}
