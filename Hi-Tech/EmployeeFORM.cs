using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class EmployeeFORM : Form
    {
        bool hided1 = true;
        bool hided2 = true;
        bool hided3 = true;
        public EmployeeFORM()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hided1 == true)
            {

                panel3.Height = panel3.Height + 20;
                panel6.Visible = false;
                panel9.Visible = false;
                panel19.Visible = false;
                pictureBox3.Visible = false;
                panel20.Visible = false;
                pictureBox4.Visible = false;
                if (panel3.Height >= 200)
                {
                    timer1.Stop();
                    hided1 = false;
                    this.Refresh();
                }
            }
            else if (hided1 == false)
            {
                panel3.Height = panel3.Height - 20;
                panel6.Visible = true;
                panel9.Visible = true;
                panel19.Visible = true;
                pictureBox3.Visible = true;
                panel20.Visible = true;
                pictureBox4.Visible = true;
                if (panel3.Height <= 55)
                {
                    timer1.Stop();
                    hided1 = true;
                    this.Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel12.Visible = false;
            panel15.Visible = false;
            this.panel18.BackColor = ColorTranslator.FromHtml("lime");
            this.panel19.BackColor = ColorTranslator.FromHtml("Black");
            this.panel20.BackColor = ColorTranslator.FromHtml("Black");

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer3.Start();
            this.panel19.BackColor = ColorTranslator.FromHtml("lime");
            this.panel18.BackColor = ColorTranslator.FromHtml("Black");
            this.panel20.BackColor = ColorTranslator.FromHtml("Black");

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (hided2 == true)
            {

                panel6.Height = panel6.Height + 20;
                panel9.Visible = false;
                panel20.Visible = false;
                pictureBox4.Visible = false;
                if (panel6.Height >= 200)
                {
                    timer3.Stop();
                    hided2 = false;
                    this.Refresh();
                }
            }
            else if (hided2 == false)
            {
                panel6.Height = panel6.Height - 20;
                panel9.Visible = true;
                panel20.Visible = true;
                pictureBox4.Visible =true;
                if (panel6.Height <= 55)
                {
                    timer3.Stop();
                    hided2 = true;
                    this.Refresh();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timer4.Start();
            panel12.Visible = false;
            this.panel19.BackColor = ColorTranslator.FromHtml("Black");
            this.panel18.BackColor = ColorTranslator.FromHtml("Black");
            this.panel20.BackColor = ColorTranslator.FromHtml("lime");
            panel15.Visible = false;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (hided3 == true)
            {

                panel9.Height = panel9.Height + 20;

                if (panel9.Height >= 100)
                {
                    timer4.Stop();
                    hided3 = false;
                    this.Refresh();
                }
            }
            else if (hided3 == false)
            {
                panel9.Height = panel9.Height - 20;

                if (panel9.Height <= 55)
                {
                    timer4.Stop();
                    hided3 = true;
                    this.Refresh();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sendmail1.BringToFront();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            purchasebill1.BringToFront();
         
            panel12.Visible = false;
            panel15.Visible = false;
          }

        private void button3_Click(object sender, EventArgs e)
        {
            salesbillopener1.BringToFront();
           panel12.Visible = false;
            panel15.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            place_order1.BringToFront();
            panel12.Visible = false;
            panel15.Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
            panel15.Visible = false;
            itemmasteradd1.BringToFront();
            this.panel13.BackColor = ColorTranslator.FromHtml("lime");
            this.panel14.BackColor = ColorTranslator.FromHtml("DimGray");
        }
         private void EmployeeFORM_Load(object sender, EventArgs e)
        {
            employeemain1.BringToFront();
            panel12.Visible = false;
            panel15.Visible = false;
           

        }
        private void button10_Click(object sender, EventArgs e)
        {
            itemmasteradd1.BringToFront();
            this.panel13.BackColor = ColorTranslator.FromHtml("lime");
            this.panel14.BackColor = ColorTranslator.FromHtml("DimGray");


        }
        //list
        private void button11_Click(object sender, EventArgs e)
        {
            itemmasterlist1.BringToFront();
            this.panel14.BackColor = ColorTranslator.FromHtml("lime");
            this.panel13.BackColor = ColorTranslator.FromHtml("DimGray");

        }
        //ACCOUNT MASTER
        private void button7_Click(object sender, EventArgs e)
        {
            panel15.Visible = true;
            panel12.Visible = false;
            addacmaster1.BringToFront();
            this.panel17.BackColor = ColorTranslator.FromHtml("lime");
            this.panel16.BackColor = ColorTranslator.FromHtml("DimGray");
        }
         private void button15_Click(object sender, EventArgs e)
        {
            addacmaster1.BringToFront();
            this.panel17.BackColor = ColorTranslator.FromHtml("lime");
            this.panel16.BackColor = ColorTranslator.FromHtml("DimGray");
         }
        //ACLIST
        private void button14_Click(object sender, EventArgs e)
        {
            acmasterlist1.BringToFront();
            this.panel16.BackColor = ColorTranslator.FromHtml("lime");
            this.panel17.BackColor = ColorTranslator.FromHtml("DimGray");
        }

        private void buttonellipse1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void buttonellipse1_MouseEnter(object sender, EventArgs e)
        {
            buttonellipse1.BackgroundImage = Properties.Resources.error;
        }

        private void buttonellipse1_MouseLeave(object sender, EventArgs e)
        {
            buttonellipse1.BackgroundImage = Properties.Resources.cancel_button;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            bkup h = new bkup();
            h.Show();
        }
    }
}