using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hi_Tech
{
    public partial class purchase_return : UserControl
    {
        public purchase_return()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool poooennn = false;
            foreach (Form o in Application.OpenForms)
            {
                if (o.Text =="DEBITNOTE")
                {
                    poooennn = true;
                    o.BringToFront();
                    break;
                }
            }

            if (poooennn == false)
            {
                DEBITNOTE ad = new DEBITNOTE();
                ad.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool poooennn = false;
            foreach (Form o in Application.OpenForms)
            {
                if (o.Text == "PURCHASERETURN")
                {
                    poooennn = true;
                    o.BringToFront();
                    break;
                }
            }

            if (poooennn == false)
            {
               PURCHASERETURN ad = new PURCHASERETURN();
                ad.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool poooennn = false;
            foreach (Form o in Application.OpenForms)
            {
                if (o.Text == "LISTRETURNITEM")
                {
                    poooennn = true;
                    o.BringToFront();
                    break;
                }
            }

            if (poooennn == false)
            {
                LISTRETURNITEM ad = new LISTRETURNITEM();
                ad.Show();
            }
        

    }

        private void button4_Click(object sender, EventArgs e)
        {
            bool poooennn = false;
            foreach (Form o in Application.OpenForms)
            {
                if (o.Text == "LISTNOTEGENERATED")
                {
                    poooennn = true;
                    o.BringToFront();
                    break;
                }
            }

            if (poooennn == false)
            {
               LISTNOTEGENERATED ad = new LISTNOTEGENERATED();
                ad.Show();
            }

        }
    }
}
