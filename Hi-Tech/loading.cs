using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class loading : Form
    {
        Timer timer1 = new Timer();
       // Timer timer2 = new Timer();
         public loading()
        {
            InitializeComponent();
        }
        void defaul(){
            
            this.progressbar1.Value = 0;
            this.label1.Left = 0;
        }
        int plus = 1;
        int lblplus = 3;
        void move(object sender, EventArgs e) {
            if (label1.Left<400||  progressbar1.Value<100) {
                progressbar1.Value += plus;
                label1.Left += lblplus;
                label1.Text = progressbar1.Value.ToString() + "%";

            }
            if (label1.Text == "100%")
            {
                timer1.Stop();
              EmployeeFORM s = new EmployeeFORM();
                s.Show();
                this.Close();
                }
            if (label1.Text == "20%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Blue");
            }
          else  if (label1.Text == "50%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Purple");
            }
            else if (label1.Text == "80%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Pink");
            }
            else if (label1.Text == "90%")
            {
                this.progressbar1.ProgressColor = ColorTranslator.FromHtml("Lime");
            }
        }
        private void loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Tick += new EventHandler(move);
            timer1.Interval = 50;
             }

    }
}
