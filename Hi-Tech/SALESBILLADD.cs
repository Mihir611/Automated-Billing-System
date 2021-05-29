using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Hi_Tech
{
    public partial class SALESBILLADD : Form
    {
        public SALESBILLADD()
        {
            InitializeComponent();
        }
        string thsmonth, thsdate, thsyear;
        string g;
        decimal x, y, cw, bb, aa, dd, ww, mm, qq, xx, ff, cc;
         int i;
        int cnt;
        string h;
        OpenFileDialog o;
        String fileName = "";
        SqlConnection con = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
        private void DataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            calculate();
            calctotal();
            totqty();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            split();
            button2.Enabled = true;
            label26.Text = label13.Text;
            panel5.Visible = true;
        }

        private void DataGridView1_Leave(object sender, EventArgs e)
        {
            cals();
            calctotal1();
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            disccal();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            roff();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            rof();
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {
            gt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter The Party Name");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter The Address");
            }
            if(radioButton1 .Checked ==true )
            {
                g = radioButton1.Text;
            }
            else if(radioButton2 .Checked ==true )
            {
                g = radioButton2.Text;
            }
            else if(radioButton3 .Checked ==true )
            {
                g = radioButton3.Text;
            }
            else if(radioButton4 .Checked ==true )
            {
                g = radioButton4.Text;
            }
            else
            {
                con.Open();
                try
                {
                    for (int i = 0; i < DataGridView1.Rows.Count - 1; i++)
                    {
                        SqlCommand cmdt = new SqlCommand(@"insert into SalesTest (Sl_No,Item_Name,Manufacturer,Model_No,HSN_Code,Qty,Price,SGST,CGST,Amount,subtotal,Vch_No,Round_pl,Round_mi,Discount,Total_Tax,DT1,Month,Year,Narration,Payment_Typ)VALUES('" + DataGridView1.Rows[i].Cells[0].Value + "','" + DataGridView1.Rows[i].Cells[1].Value + "','" + DataGridView1.Rows[i].Cells[2].Value + "','" + DataGridView1.Rows[i].Cells[3].Value + "','" + DataGridView1.Rows[i].Cells[4].Value + "','" + DataGridView1.Rows[i].Cells[5].Value + "','" + DataGridView1.Rows[i].Cells[6].Value + "','" + DataGridView1.Rows[i].Cells[7].Value + "','" + DataGridView1.Rows[i].Cells[8].Value + "','" + DataGridView1.Rows[i].Cells[9].Value + "','" + DataGridView1.Rows[i].Cells[10].Value + "','" + maskedTextBox1.Text + "','"+this.textBox2 .Text + "','" + this.textBox3.Text + "','" + this.TextBox1.Text + "','" + Convert.ToDecimal ( this.label26 .Text )+ "','" + this.textBox10.Text + "','" + this.textBox8.Text + "','" + this.textBox11.Text + "','" + this.textBox4.Text + "','"+g+"')", con);
                        cmdt.ExecuteNonQuery();
                        MessageBox.Show("Record Inserted");
                        genp();
                        MessageBox.Show("PDF Created Successfully");
                        con.Close();
                    }
                    insert2();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ups();
                if (fileName == "")
                {
                    DialogResult emi = MessageBox.Show("Do u want to send the E-Mail to " + textBox6.Text + "Click (Yes) to send the E-Mail or Click (No) if you donot want to send the  E-Mail", "Send Mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (emi == DialogResult.OK)
                    {
                        MessageBox.Show("Please select the file named bill number" + maskedTextBox1.Text + "to send the mail");
                        button4.Visible = true;
                    }
                    if (emi == DialogResult.No)
                    {
                        clrfn();
                    }
                }
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox9.Text, pattern))
            {
               
            }
            else
            {
               MessageBox.Show("Please Enter valid Email Address");
                return;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            String pattern = "^[a-zA-Z]+$";
            if (Regex.IsMatch(textBox6.Text, pattern))
            {
              
            }
            else
            {
                MessageBox.Show("Please Enter Valid Name");
                return;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label20.Visible = true;
            textBox4.Visible = true;
        }
        //updatimg discount
        public void ups()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            for (int sto = 0; sto < DataGridView1.Rows.Count - 1; sto++)
            {
                SqlCommand sqlcommand = new SqlCommand("Update Stock set Qty=Qty-@quanty where HSN_Code=@num", con);
                sqlcommand.Parameters.AddWithValue("@quanty", SqlDbType.Decimal).Value = DataGridView1.Rows[sto].Cells[5].Value;
                sqlcommand.Parameters.AddWithValue("@num", SqlDbType.Int).Value = DataGridView1.Rows[sto].Cells[4].Value;
                sqlcommand.ExecuteNonQuery();
            }
            con.Close();
        }

        //generating E-MAil
        public void em()
        {

            h = Convert.ToString(textBox9.Text);
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
                client.Credentials = new NetworkCredential(label31.Text.Trim(), textBox7.Text.Trim());
                //MAIL MESSAGE DETAILS
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(label31.Text.Trim());
                mail.To.Add(h);
                mail.Subject = "Material Purchase info";
                mail.Body = "Please open the below Attachment to view the order.";
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                label32.Text = "* No file has been Attached....";
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
            }
            else
            {
                label32.Text = "File attached" + fileName;
            }
        }

        //CLACULATION OF AMOUNT  I.E., PRICE*QTY
        public void calculate()
        {
            for (i = 0; i < DataGridView1.Rows.Count - 1; i++)
            {
                x = Convert.ToDecimal(DataGridView1.Rows[i].Cells[5].Value);
                y = Convert.ToDecimal(DataGridView1.Rows[i].Cells[6].Value);
                cw = x * y;
                DataGridView1.Rows[i].Cells[10].Value = Convert.ToDecimal(cw);
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            DateTime gg, hh;
            gg = Convert.ToDateTime(dateTimePicker1.Text);
            hh = Convert.ToDateTime(DateTime.Now.Date);
            if (gg > hh)
            {
                MessageBox.Show("The Billed Date cannot be grater than today's date");
                DataGridView1.Enabled = false;
            }
            else if (gg < hh)
            {
                MessageBox.Show("The Billed Date cannot be grater than today's date");
                DataGridView1.Enabled = false;
            }
            else
            {
                DataGridView1.Enabled = true;
            }
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Decimal)))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Decimal)))
            {
                e.Handled = true;
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (DataGridView1.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (DataGridView1.CurrentCell.ColumnIndex == 5) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(Column3_KeyPress);
            if (DataGridView1.CurrentCell.ColumnIndex == 6) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }

            if (DataGridView1.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (DataGridView1.CurrentCell.ColumnIndex == 7)//desired column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }

            if (DataGridView1.CurrentCell.ColumnIndex == 8)//desired column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }
        }
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

        private void label32_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button3.Visible = true;
            if (fileName == "")
            {
                MessageBox.Show("please attach the file named bill number " + maskedTextBox1.Text + "");
                button4.Enabled = true;
            }
            else
            { 
                button2.Enabled = false;
                button5.Enabled = false;
            }
        }

        //TAX VALUES FUNCTION
        //FUNCTION FOR CALCULATING TAX
        public void cals()
        {
            int j;
            for (j = 0; j < DataGridView1.Rows.Count - 1; j++)
            {
                bb = Convert.ToDecimal(DataGridView1.Rows[j].Cells[7].Value);
                aa = Convert.ToDecimal(DataGridView1.Rows[j].Cells[8].Value);
                ww = bb + aa;
                if (ww == 28)
                {
                    mm = 128;
                }
                else if (ww == 5)
                {
                    mm = 105;
                }
                else if (ww == 12)
                {
                    mm = 112;
                }
                else if (ww == 18)
                {
                    mm = 118;
                }
                else
                {
                    MessageBox.Show("Please Insert correct tax structure");
                }
                xx = Convert.ToDecimal(DataGridView1.Rows[j].Cells[10].Value);
                qq = (xx / mm) * 100;
                label30.Text = qq.ToString("#,0.00");
                DataGridView1.Rows[j].Cells[9].Value = Convert.ToDecimal(label30.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            em();
            clrfn();
        }

        //Calculating the Final CGST and SGST
        public void split()
        {
            dd = Convert.ToDecimal(Label7.Text);
            cc = Convert.ToDecimal(label10.Text);
            ff = (cc - dd) / 2;
            Label8.Text = ff.ToString("#,0.00");
            Label9.Text = ff.ToString("#,0.00");
        }

        //CLACULATING SUM
        public void calctotal()
        {
            decimal sum = 0;
            int z = 0;
            for (z = 0; z < DataGridView1.Rows.Count - 1; z++)
            {
                sum += Convert.ToDecimal(DataGridView1.Rows[z].Cells[10].Value);
            }
            label10.Text = sum.ToString("#,0.00");
            label15.Text = label10.Text;
        }
        //CALCULATING TOTALSUM OF GST
        public void calctotal1()
        {
            decimal sum1 = 0;
            int z1 = 0;
            for (z1 = 0; z1 < DataGridView1.Rows.Count - 1; z1++)
            {
                sum1 += Convert.ToDecimal(DataGridView1.Rows[z1].Cells[9].Value);
            }
            Label7.Text = sum1.ToString("#,0.00");
            label12.Text = sum1.ToString("#,0.00");
        }
        //DISCOUNT CALCULATION
        public void disccal()
        {
            decimal g, f, ans;
            g = Convert.ToDecimal(label10.Text);
            f = Convert.ToDecimal(TextBox1.Text);
            ans = g - f;
            label13.Text = ans.ToString("#,0.00");
            label15.Text = ans.ToString("#,0.00");
        }

        //ROUND OFF(+) CALLCULATION
        public void roff()
        {
            if (label13.Text == "0")
            {
                decimal m, n, an;
                m = Convert.ToDecimal(label10.Text);
                n = Convert.ToDecimal(textBox2.Text);
                an = m + n;
                label13.Text = an.ToString();
            }
            else
            {
                decimal m, n, an;
                m = Convert.ToDecimal(label10.Text);
                n = Convert.ToDecimal(textBox2.Text);
                an = m + n;
                label13.Text = an.ToString();
            }
        }

        //Calculating Round Off(-)
        public void rof()
        {
            if (label13.Text == "0")
            {
                decimal m1, n1, an1;
                m1 = Convert.ToDecimal(label10.Text);
                n1 = Convert.ToDecimal(textBox3.Text);
                an1 = m1 - n1;
                label13.Text = an1.ToString();
            }
            else
            {
                decimal m1, n1, an1;
                m1 = Convert.ToDecimal(label10.Text);
                n1 = Convert.ToDecimal(textBox3.Text);
                an1 = m1 - n1;
                label13.Text = an1.ToString();
            }
        }

        //Calculating GrandTotal
        public void gt()
        {
            label15.Text = label13.Text.ToString();
        }

        //Calculating Total Quantity
        public void totqty()
        {
            decimal sum11 = 0;
            int z11 = 0;
            for (z11 = 0; z11 < DataGridView1.Rows.Count - 1; z11++)
            {
                sum11 += Convert.ToDecimal(DataGridView1.Rows[z11].Cells[5].Value);
            }
            Label6.Text = sum11.ToString();
        }

        //Generating PDF
        public void genp()
        {
            int j, k, u;
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Bill Number .pdf", FileMode.Create));
            doc.Open();
            doc.AddAuthor("Mihir");
            doc.AddCreator("Mihir");
            Paragraph op = new Paragraph("Address");
            doc.Add(op);
            Paragraph paragraph = new Paragraph("Invoice Number: " + maskedTextBox1.Text + "                               Dated  " + dateTimePicker1.Text + "\nParty Name  " + textBox6.Text + "\nParty Address  " + textBox5.Text + "\nItems Bought\n\n");
            doc.Add(paragraph);
            //Inserting table
            PdfPTable table = new PdfPTable(DataGridView1.Columns.Count);
            //Adding header
            for (u = 0; u < DataGridView1.Columns.Count; u++)
            {
                table.AddCell(new Phrase(DataGridView1.Columns[u].HeaderText));
            }
            //Adding Rows
            for (j = 0; j < DataGridView1.Rows.Count; j++)
            {
                for (k = 0; k < DataGridView1.Columns.Count; k++)
                {
                    if (DataGridView1[k, j].Value != null)
                    {
                        table.AddCell(new Phrase(DataGridView1[k, j].Value.ToString()));
                    }
                }
            }
            doc.Add(table);//adding table
            Paragraph p = new Paragraph("\n Total Qty Purchased :" + Label6.Text + "\n SubTotal :" + label12.Text + " \n Discount : " + TextBox1.Text + " \n Round Off(+) :" + textBox2.Text + "\n Round Off(-) :" + textBox3.Text + "\n Grand Total :" + label15.Text + "");
            doc.Add(p);
            doc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SALESBILLADD_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            thsmonth = dt.ToString("MMMM");
            thsdate = dt.ToString("dd");
            thsyear = dt.ToString("yyyy");
            textBox8.Text = Convert.ToString(thsmonth);
            textBox10.Text = Convert.ToString(thsdate);
            textBox11.Text = Convert.ToString(thsyear);
            SqlConnection cona = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            cona.Open();
            SqlCommand cmda = new SqlCommand("Select count (*)  from  SalesTest1", cona);
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
        }
        //inserting into db
        public void insert2()
        {
            SqlConnection conins = new SqlConnection(@"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True");
            conins.Open();
            SqlCommand cmdins = new SqlCommand(@"insert into SalesTest1 (Cust_Name,E_Mail,Grand_Total,Cust_Address)VALUES('" + this.textBox6.Text.Trim() + "','" + this.textBox9.Text.Trim() + "','" + Convert.ToDecimal(label15.Text) + "','" + this.textBox5.Text.Trim() + "')", conins);
            cmdins.ExecuteNonQuery();
            MessageBox.Show("Record Inserted");
            conins.Close();
        }

        //clear function 
        public void clrfn()
        {
            TextBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            label26.Text = "0";
            Label9.Text = "0";
            Label8.Text = "0";
            label15.Text = "0";
            Label7.Text = "0";
            label10.Text = "0";
            Label6.Text = "0";
            label12.Text = "0";
            label13.Text = "0";
            label18.Text = "0";
            label19.Text = "0";
            label32.Text = "0";
            DataGridView1.Rows.Clear();
            cnt += 1;
        }
    }
}
