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
    public partial class supoutlistalllitem : UserControl
    {
        public supoutlistalllitem()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");

        private void supoutlistalllitem_Load(object sender, EventArgs e)
        {
            search1();
          
        }
          
        //selecting from SalesTest table
        public void search1()
        {
            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataSet ds1 = new DataSet();
            SqlCommand cmd2 = new SqlCommand("select Vch_No,Item_Name,Model_No,HSN_Code,Qty,Price,SGST,CGST,subtotal from SalesTest", con);
            adp1.SelectCommand = cmd2;
            adp1.Fill(ds1, "item1");
            if (ds1.Tables["item1"].Rows.Count > 0)
            {
                dataGridView2.DataSource = ds1.Tables["item1"];
                dataGridView2.Visible = true;
            }
        }


       
       
    }
}
