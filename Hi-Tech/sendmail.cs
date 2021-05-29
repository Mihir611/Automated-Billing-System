using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Hi_Tech
{
    public partial class sendmail : UserControl
    {
      
        OpenFileDialog h;
        String fileName = "";
        public sendmail()
        {
          
            InitializeComponent();
        }
        public void CLEAR()
        {
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool con = NetworkInterface.GetIsNetworkAvailable();
            if (con == true)
            {
                panel1.Enabled = true;
            }
            else
            {
                MessageBox.Show("PLEASE CONNECT TO THE INTERNET");
                panel1.Visible = false;
            }

            string d = Convert.ToString(listBox1.SelectedItem);
            if (textBox1.Text == "" || textBox2.Text == "" || d == "" || textBox6.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Please Fill In All Fields");
            }
            else if (checkBox1.Checked == false)
            {
                MessageBox.Show("The checkbox is unchecked please check it!!!");
            }
            else
            {
                try
                {
                    //SMTPCLIENT DETAILS
                    SmtpClient client = new SmtpClient();
                    client.Port = Convert.ToInt32(label5.Text);
                    client.Host = d;
                    client.EnableSsl = checkBox1.Checked;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);
                    //MESSAGE DETAILS
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(textBox1.Text);
                    mail.To.Add(textBox5.Text);
                    mail.Subject = textBox6.Text;
                    mail.IsBodyHtml = checkBox2.Checked;
                    mail.Body = richTextBox1.Text;
                    //FOR FILE ATTACHMENT
                    if (fileName.Length > 0)
                    {
                        Attachment a = new Attachment(fileName);
                        mail.Attachments.Add(a);
                    }
                    client.Send(mail);
                    MessageBox.Show("Mail Sent");
                    fileName = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                label9.Text = "File attached" + fileName;
            }
            else
            {
                label9.Text = "* No file has been Attached....";
                try
                {
                    h = new OpenFileDialog();
                    h.Filter = "Images(.jpg,.png)|*.png;*.jpg;|Pdf Files|*.pdf";
                    if (h.ShowDialog() == DialogResult.OK)
                    {
                        fileName = h.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (textBox1.Text != "")
            {
                if (Regex.IsMatch(textBox1.Text, pattern))
                {

                }
                else
                {
                    MessageBox.Show("PLEASE ENTER THE VALID EMAIL ADDRESS");
                    textBox1.Text = "";
                    return;
                }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            String pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (textBox5.Text != "")
            {
                if (Regex.IsMatch(textBox5.Text, pattern))
                {

                }
                else
                {
                    MessageBox.Show("PLEASE ENTER THE VALID EMAIL ADDRESS");
                    textBox5.Text = "";
                    return;
                }
            }
        }
    }
}
