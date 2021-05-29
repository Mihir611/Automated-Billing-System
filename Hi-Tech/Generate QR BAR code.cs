using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class Generate_QR_BAR_code : UserControl
    {
        public Generate_QR_BAR_code()
        {
            InitializeComponent();
        }

      

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
            label3.Text = "Enter the Text to Generate the Qr Code";
            textBox2.Visible = true;
            button1.Visible = true;
            panel4.Visible = false;
            pictureBox2.Image = null;
            textBox2.Text = "";
            button2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Visible = true;
            label3.Text = "Enter the Text to Generate the BAR Code";
            textBox2.Visible = true;
            button2.Visible = true;
            panel3.Visible = false;
            pictureBox1.Image = null;
            textBox2.Text = "";
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw qr = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = qr.Draw(textBox2.Text, 200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw bar = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox2.Image = bar.Draw(textBox2.Text, 175);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Generate Either QR Code or BarCode");
            }
            else
            {
                SaveFileDialog sf1 = new SaveFileDialog();
                sf1.InitialDirectory = @"D:\Images Of QR and BAR Codes\";
                sf1.Title = "Save Qr/BAR Code Images";
                sf1.DefaultExt = "jpg";
                sf1.Filter = "Images files (*.jpg)|*.jpg";
                sf1.FilterIndex = 2;
                sf1.RestoreDirectory = true;
                sf1.FileName = textBox3.Text;
                if (sf1.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(sf1.FileName);
                    }
                    else
                    {
                        pictureBox2.Image.Save(sf1.FileName);
                    }
                }
            }
        }

        private void Form43_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
    }

