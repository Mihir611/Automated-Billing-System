using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Hi_Tech
{
    public partial class CHOOSE : Form
    {
        int pw;
        bool hided;
        public CHOOSE()
        {
           InitializeComponent();
            pw = panel1.Height;
            
        }
            private void timer1_Tick(object sender, EventArgs e)
        {
            if (hided == true)
            {
                button2.Text = "^";
                panel1.Height = panel1.Height + 10;

                if (panel1.Height >= pw)
                {
                    timer1.Stop();
                    hided = false;
                    this.Refresh();
                }
            }
            else if (hided == false)
            {
                button2.Text = "-";
                panel1.Height = panel1.Height - 10;
                if (panel1.Height <= 0)
                {
                    timer1.Stop();
                    hided = true;
                    this.Refresh();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
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
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }
        private void CHOOSE_Load(object sender, EventArgs e)
        {
            CHOOSE c = new CHOOSE();
            bunifuCircleProgressbar1.animated = true;
            if ( DateTime.Now.Hour <= 12)
            {
                label5.Text = "GOOD MORNING";
                pictureBox1.BackgroundImage = Properties.Resources.iconfinder_sun_367527;
            }
            else if ( DateTime.Now.Hour <= 17)
            {
                label5.Text = "Good AFTERNOON";
              pictureBox1.BackgroundImage = Properties.Resources.iconfinder_sun_367527;
            }
            else if (DateTime.Now.Hour <= 21)
            {
                label5.Text = "Good EVENING";
                pictureBox1.BackgroundImage=Properties.Resources.iconfinder_Weather_Weather_Forecast_Sunrise_Sunset_Sun_3859148 ;
            }
            else if ( DateTime.Now.Hour <= 24)
            {
                label5.Text = "GOOD NIGHT";
                pictureBox1.BackgroundImage = Properties.Resources.iconfinder_full_moon_345357;
            }
            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongTimeString();
            timer3.Start();
            }
         private void timer3_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }
        private void buttonellipse1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
         private void buttonellipse2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void buttonellipse1_MouseEnter(object sender, EventArgs e)
        {
            this.buttonellipse1.BackColor = ColorTranslator.FromHtml("RED");
        }
        private void buttonellipse1_MouseLeave(object sender, EventArgs e)
        {
            this.buttonellipse1.BackColor = ColorTranslator.FromHtml("Transparent");
        }
        //ADMINISTRATOR BUTTON
        private void ADMINISTRATOR_Click(object sender, EventArgs e)
        {
            this.panel3.BackColor = ColorTranslator.FromHtml("lime");
            this.panel4.BackColor = ColorTranslator.FromHtml("DimGray");
            adminlogin adminfor = new adminlogin();
            adminfor.Show();
        }
        //EMPLOYEE BUTTON
        private void EMPLOYEE_Click(object sender, EventArgs e)
        {
            this.panel4.BackColor = ColorTranslator.FromHtml("lime");
            this.panel3.BackColor = ColorTranslator.FromHtml("DimGray");
           loading empform = new loading();
            empform.Show();
        }
        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }
        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }
        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }
        private void ADMINISTRATOR_MouseEnter(object sender, EventArgs e)
        {
            this.ADMINISTRATOR.BackColor = ColorTranslator.FromHtml("#4CAF50");
        }
        private void ADMINISTRATOR_MouseLeave(object sender, EventArgs e)
        {
            this.ADMINISTRATOR.BackColor = ColorTranslator.FromHtml("Gray");
        }
        private void EMPLOYEE_MouseEnter(object sender, EventArgs e)
        {
            this.EMPLOYEE.BackColor = ColorTranslator.FromHtml("#4CAF50");
        }
        private void EMPLOYEE_MouseLeave(object sender, EventArgs e)
        {
            this.EMPLOYEE.BackColor = ColorTranslator.FromHtml("Gray");
        }

        private void buttonellipse3_Click(object sender, EventArgs e)
        {
            conrest d = new conrest();
            d.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}