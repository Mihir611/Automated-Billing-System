using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Hi_Tech
{
    public partial class place_order : UserControl
    {
        public place_order()
        {
            InitializeComponent();
        }
        string g, h;
        string thsmonth, thsdate, thsyear;
        OpenFileDialog o;
        String fileName = "";
        int u, j, k;

        private void button3_Click(object sender, EventArgs e)
        {
           h = Convert.ToString(textBox2.Text);
                int r;
                r = Convert.ToUInt16("587");
                try
                {
                    //SMTP DETAILS
                    SmtpClient client = new SmtpClient();
                    client.Port = r;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(label2.Text.Trim(), textBox6.Text .Trim());
                    //MAIL MESSAGE DETAILS
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(label2.Text.Trim());
                    mail.To.Add(h);
                    mail.Subject = "Order For Material";
                    mail.Body = "Please open the below PDF to view the order.";
                    //For File Attachment
                     if (fileName.Length > 0)
                        {
                            Attachment a = new Attachment(fileName);
                            mail.Attachments.Add(a);
                        }
                    client.Send(mail);
                    MessageBox.Show("Mail Sent!!!");
                    fileName = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            savingdb();
        }
        public void savingdb()
        {
            SqlConnection con234 = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con234.Open();
            //Convert to bin formate
            for (int y = 0; y < dataGridView1.Rows.Count - 1; y++)
            {
                SqlCommand cmd234 = new SqlCommand(@"Insert into Place_Order (Order_ID,Sl_No,Item,Model_No,Manufacturer,HSN_Code,Qty,Price,Amount)Values('" + this.maskedTextBox1.Text.Trim() + "','" + dataGridView1.Rows[y].Cells[0].Value + "','" + dataGridView1.Rows[y].Cells[1].Value + "','" + dataGridView1.Rows[y].Cells[2].Value + "','" + dataGridView1.Rows[y].Cells[3].Value + "','" + dataGridView1.Rows[y].Cells[4].Value + "','" + dataGridView1.Rows[y].Cells[5].Value + "','" + dataGridView1.Rows[y].Cells[6].Value + "','" + dataGridView1.Rows[y].Cells[7].Value + "')", con234);
                cmd234.ExecuteNonQuery();
            }
            MessageBox.Show("Records Saved");
            con234.Close();
            SqlConnection con2345 = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con2345.Open();
            SqlCommand cmd2345 = new SqlCommand(@"Insert into Place_Order_Main (Supplier_Name,Email,Total,Date,Month,Year)VALUES ('" + this.textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + Convert.ToDecimal(this.label15.Text.Trim()) + "','"+Convert.ToDecimal  ( this.label17 .Text )+"','"+this.label14 .Text +"','"+this.label20 .Text +"')", con2345);
            cmd2345.ExecuteNonQuery();
            con2345.Close();
        }

        private void place_order_Load(object sender, EventArgs e)
        {
            int cnt;
            SqlConnection cona = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            cona.Open();
            SqlCommand cmda = new SqlCommand("Select count (*)  from  Place_Order_Main", cona);
            cnt = Convert.ToInt16(cmda.ExecuteScalar());
            if (cnt > 0)
            {
                cnt += 1;
            }
            else
            {
                cnt = 1;
            }
            maskedTextBox1.Text = cnt.ToString();
            stockcheck();
            cbload();
            DateTime dt = DateTime.Now;
            thsmonth = dt.ToString("MMMM");
            thsdate = dt.ToString("dd");
            thsyear = dt.ToString("yyyy");
            label14.Text = Convert.ToString(thsmonth);
            label17.Text = Convert.ToString(thsdate);
            label20.Text = Convert.ToString(thsyear);

        }

        private void button4_Click(object sender, EventArgs e)
        {
             genp();
            button1.Visible = true;
        }

      
        //calculating total

        public void calctotal()
        {
            decimal sum = 0;
            int z = 0;
            for (z = 0; z < dataGridView1.Rows.Count - 1; z++)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[z].Cells[7].Value);
            }
            label15.Text = sum.ToString("#,0.00");
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool tem = false;
            SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Email,Mobile_No,Contact_per,Address FROM Sup_det where Name='" + textBox1.Text.Trim() + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            decimal i;
            while (dr.Read())
            {
                textBox2.Text = dr.GetString(0);
                i = decimal.Parse(dr.GetDecimal(1).ToString());
                textBox4.Text = Convert.ToString(i);
                textBox5.Text = dr.GetString(2);
                textBox3.Text = dr.GetString(3);
                tem = true;
            }
            if (tem == false)
                MessageBox.Show("Record not found");
            con.Close();
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                decimal x, y, c;
                x = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                y = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                c = x * y;
                dataGridView1.Rows[i].Cells[7].Value = Convert.ToDecimal(c);
            }
            calctotal();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 5) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(Column3_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 6) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        //handelling
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allowed only numeric value  ex.10
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //handelling
        private void Column3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection comins = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            comins.Open();
            SqlCommand cmdins = new SqlCommand("select Name from Sup_det where Name='"+comboBox1 .Text +"'", comins);
            SqlDataReader drins = cmdins.ExecuteReader();
            while(drins .Read ())
            {
                textBox1.Text = drins.GetString(0);
            }
            textBox1.Text = comboBox1.Text;
            panel1.Visible = true;
            dataGridView1.Visible = true;
           // label3.Visible = false;
           // comboBox1.Visible = false;
           // button5.Visible = false;
            button4.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                o = new OpenFileDialog();
                o.Filter = "Pdf Files|*.pdf";
                if (o.ShowDialog() == DialogResult.OK)
                {
                    fileName = o.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (fileName != "")
            {
                label12.Text = "File attached" + fileName;
                button3.Visible = true;
            }
            else
            {
                label12.Text = "* No file has been Attached....";
                MessageBox.Show("Please attach the file");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void genp()
        {
            g = Convert.ToString(maskedTextBox1.Text);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Order.pdf", FileMode.Create));
            doc.Open();
            doc.AddAuthor("Mihir");
            doc.AddCreator("Mihir");
            //Adding Paragraph
            Paragraph paragraph = new Paragraph("Order Number :" + g + "\nDear Sir/Madam \n\n We would like to order the following items. \n We need those items urgently \n The Items Required are as follows\n\n\n");
            doc.Add(paragraph);
            //Inserting table
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
            //Adding header
            for (u = 0; u < dataGridView1.Columns.Count; u++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[u].HeaderText));
            }
            //Adding Rows
            for (j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    if (dataGridView1[k, j].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1[k, j].Value.ToString()));
                    }
                }
            }
            doc.Add(table);//adding table
            //Adding footer i.e., Thankyou .........
            Paragraph pr = new Paragraph("\nThanking You,\nYour's Sincerly\n\n(mIHIR)");
            doc.Add(pr);
            doc.Close();
            MessageBox.Show("Creation Done");
        }
        //checking Stocks..
        public void stockcheck()
        {
            SqlConnection conv = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conv.Open();
            SqlCommand cmdv = new SqlCommand("select Item_Name,Company_Name,Qty,Re_Order from Stock where Qty<=Re_Order", conv);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmdv))
            {
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;
                    dataGridView2.Visible = true;
                }
            }

        }

        public void cbload()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            string Sql = "select Name from Sup_det";
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                comboBox1 .Items.Add(DR[0]);
            }
        }
    }
}
